using System;
using System.Collections.Generic;
using System.Reflection;
using EatOrDie.InputActions;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.Utilities;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace EatOrDie
{
    [DefaultExecutionOrder(-100)]
    public class InputManager : MonoBehaviour
    {
        // Dead zone to help account for floating point errors when comparing to zero.
        private static readonly float Deadzone = 0.005f;
        
        // 2D Colliders used to detect touch actions by zone.
        [SerializeField] private PolygonCollider2D jump;
        [SerializeField] private PolygonCollider2D backward;
        [SerializeField] private PolygonCollider2D forward;
        [SerializeField] private PolygonCollider2D duck;
        [SerializeField] private CircleCollider2D deadZone;
        
        // Reference to the camera for the screenToWorldPoint matrix function.
        [SerializeField] private Camera cam;
        
        // The control system that processes all incoming input, from all sources.
        private InputMaster controls;
        
        #region Boiler Plate

        private void Start()
        {
        }

        /// <summary>
        /// Enable the control system, enable the action maps, and enable the Enhanced Touch System.
        /// </summary>
        private void OnEnable()
        {
            controls = new InputMaster();
            controls.Touch.Enable();
            controls.Play.Enable();
            EnhancedTouchSupport.Enable();
        }
        /// <summary>
        /// Disable the Enhanced Touch System, disable the Action Maps, and dispose of the control system.
        /// </summary>
        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
            controls.Play.Disable();
            controls.Touch.Disable();
            controls.Dispose();
        }

        #endregion

        #region Touch Processing

        // Avoid redundant declarations, cache values in these variables.
        private CustomTouchState tState, primaryTState, secondTState;
        private ReadOnlyArray<Finger> activeFingers;
        private Vector3 primaryPosition, secondaryPosition;
        private bool inDeadZone, isActiveTouchATap;
        /// <summary>
        /// Process touch input. Uses 2D colliders to define screen 'zones'.
        /// Clears state and recalculates with current primary and secondary touch input locations.
        /// Additional touches are ignored.
        /// </summary>
        private void ProcessTouch()
        {
            tState.Clear();
            primaryTState.Clear();
            secondTState.Clear();
            
            // Set default touch positions to be off screen and out of range of the colliders.
            primaryPosition = Vector2.one * 100;
            secondaryPosition = Vector2.one * 100;
            
            // Get all currently active fingers touching the screen.
            activeFingers = Touch.activeFingers;

            isActiveTouchATap = false;
            // Calculate primary fingers state
            if (activeFingers.Count >= 1 )
            {
                isActiveTouchATap = activeFingers[0].currentTouch.isTap;
                primaryTState.Tap = isActiveTouchATap;
                primaryTState.TapPosition = cam.ScreenToWorldPoint(activeFingers[0].currentTouch.screenPosition);
                
                var pressTime = activeFingers[0].currentTouch.time - activeFingers[0].currentTouch.startTime;
                if (pressTime > 0.05f)
                {
                    primaryPosition = cam.ScreenToWorldPoint(activeFingers[0].screenPosition);

                    inDeadZone = false;
                    inDeadZone = deadZone.OverlapPoint(primaryPosition);

                    primaryTState.Forwards = forward.OverlapPoint(primaryPosition) && !inDeadZone;
                    primaryTState.Backwards = backward.OverlapPoint(primaryPosition) && !inDeadZone;
                    primaryTState.Jump = jump.OverlapPoint(primaryPosition) && !inDeadZone;
                    primaryTState.Duck = duck.OverlapPoint(primaryPosition) && !inDeadZone;
                }
            }
            
            isActiveTouchATap = false;
            // Calculate secondary finger state
            if (activeFingers.Count >= 2)
            {
                isActiveTouchATap = activeFingers[1].currentTouch.isTap;
                secondTState.Tap = isActiveTouchATap;
                secondTState.TapPosition = cam.ScreenToWorldPoint(activeFingers[1].currentTouch.screenPosition);
                
                var pressTime = activeFingers[1].currentTouch.time - activeFingers[1].currentTouch.startTime;
                if (pressTime > 0.05f)
                {
                    secondaryPosition = cam.ScreenToWorldPoint(activeFingers[1].screenPosition);

                    inDeadZone = false;
                    inDeadZone = deadZone.OverlapPoint(secondaryPosition);

                    secondTState.Forwards = forward.OverlapPoint(secondaryPosition) && !inDeadZone;
                    secondTState.Backwards = backward.OverlapPoint(secondaryPosition) && !inDeadZone;
                    secondTState.Jump = jump.OverlapPoint(secondaryPosition) && !inDeadZone;
                    secondTState.Duck = duck.OverlapPoint(secondaryPosition) && !inDeadZone;
                }
            }
            
            // Combine the primary and secondary states, making sure the primary state supersedes
            // the secondary if both forwards/backwards are touched simultaneously.
            tState.Forwards = primaryTState.Forwards || (secondTState.Forwards && !primaryTState.Backwards);
            tState.Backwards = primaryTState.Backwards || (secondTState.Backwards && !primaryTState.Forwards);
            tState.Jump = primaryTState.Jump || secondTState.Jump;
            tState.Duck = primaryTState.Duck || secondTState.Duck;
            tState.Tap = primaryTState.Tap || secondTState.Tap;
            tState.TapPosition = !tState.Tap
                ? Vector2.one * -10000
                : primaryTState.Tap
                    ? primaryTState.TapPosition
                    : secondTState.TapPosition;
            Debug.Log(tState.ToString());
        }

        #endregion

        #region Mouse Processing
        
        private Vector2 mousePosition;
        private Vector2 mouseWorldPosition;
        private CustomInputState mState;
        /// <summary>
        /// Process Mouse input.
        /// </summary>
        private void ProcessMouse()
        {
            // Set default touch positions to be off screen and out of range of the colliders.
            mousePosition = Vector2.one * -10000;
            mouseWorldPosition = Vector2.one * -10000;

            if (controls.Touch.LeftMouse.ReadValue<float>() > 0)
                mousePosition = controls.Touch.MousePosition.ReadValue<Vector2>();

            mouseWorldPosition = cam.ScreenToWorldPoint(mousePosition);
                        
            inDeadZone = false;
            inDeadZone = deadZone.OverlapPoint(mouseWorldPosition);
            
            mState.Forward = forward.OverlapPoint(mouseWorldPosition) && !inDeadZone;
            mState.Backward = backward.OverlapPoint(mouseWorldPosition) && !inDeadZone;
            mState.Jump = jump.OverlapPoint(mouseWorldPosition) && !inDeadZone;
            mState.Duck = duck.OverlapPoint(mouseWorldPosition) && !inDeadZone;
        }
        
        #endregion

        #region Keyboard Processing
        
        // Avoid redundant declarations, cache values in these variables.
        private CustomKeyState kState;
        /// <summary>
        /// Process keyboard input. Clears current state and updates with current values.
        /// </summary>
        private void ProcessKeyboard()
        {
            kState.Clear();

            kState.Forwards = controls.Play.Move.ReadValue<float>() > Deadzone;
            kState.Backwards = controls.Play.Move.ReadValue<float>() < -Deadzone;
            kState.Duck = controls.Play.Duck.ReadValue<float>() > Deadzone;
            kState.Jump = !kState.Jump && controls.Play.Jump.triggered;
            kState.Escape = controls.Play.ExitGame.triggered;
        }

        #endregion
        
        #region Combine States
        
        // Avoid redundant declarations, cache values in these variables.
        private CustomInputState state;
        /// <summary>
        /// Combine the touch and keyboard states (Lets hope no one is trying to use both simultaneously.)
        /// </summary>
        private void CombineAllInput()
        {
            state.Clear();

            state.Forward = tState.Forwards || mState.Forward || kState.Forwards;
            state.Backward = tState.Backwards || mState.Backward || kState.Backwards;
            state.Jump = tState.Jump || mState.Jump || kState.Jump;
            state.Duck = tState.Duck || mState.Duck ||kState.Duck;
            state.Escape = kState.Escape;
            
            state.Tap = tState.Tap;
            state.TapPosition = tState.TapPosition;
        }
        
        #endregion
        
        
        private void Update()
        {
            ProcessTouch();
            ProcessKeyboard();
            //ProcessMouse();
            CombineAllInput();
             
            if (state.Forward) 
                MoveForward();
            if (state.Backward) 
                MoveBackward();
            if (state.Jump) 
                Jump();
            if (state.Duck) 
                Duck();
            
            if (state.Tap)
                Tap(state.TapPosition);
            
            if (state.Escape)
                Application.Quit();
        }

        public event EventHandler OnForward;
        protected virtual void MoveForward()
        {
            var handler = OnForward;
            handler?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler OnBackward;
        protected virtual void MoveBackward()
        {
            var handler = OnBackward;                  
            handler?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler OnJump;
        protected virtual void Jump()
        {
            var handler = OnJump;
            handler?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler OnDuck;
        protected virtual void Duck()
        {
            var handler = OnDuck;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<TapPositionEventArgs> OnTap;
        protected virtual void Tap(Vector2 tp)
        {
            var handler = OnTap;
            handler?.Invoke(this, new TapPositionEventArgs { TapPosition = tp});
            //Debug.Log($"Tapped: {tp}");
        }
    }

    public class TapPositionEventArgs : EventArgs
    {
        public Vector2 TapPosition;
    }
}