// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""4af324d8-65c6-4e54-9f75-c8708a4d24b1"",
            ""actions"": [
                {
                    ""name"": ""ExitGame"",
                    ""type"": ""Button"",
                    ""id"": ""fbbd1619-2290-43ba-b761-494e20a0265c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""70cf6ed4-5335-474e-95cd-e94d8f3c9073"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""de6d666c-f624-4bab-9d79-5cba22ee2602"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LongJump"",
                    ""type"": ""Button"",
                    ""id"": ""12e96952-bccd-4805-b2cb-6710b36e9649"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63ea0d59-36e2-45bd-bff3-4784658b0d01"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""3461cd8c-b9fc-41d9-9f95-51e7ea922521"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""74085212-cc8d-4b90-bef5-21e7d3b86bc0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ca65c793-554a-4efa-ae6a-267f608d38ff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c1f257e8-db6d-4a8a-986b-a8dee2d814f2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02b0b815-886f-49fa-b96a-9144255bee66"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold(duration=0.35)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Play
        m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
        m_Play_ExitGame = m_Play.FindAction("ExitGame", throwIfNotFound: true);
        m_Play_Movement = m_Play.FindAction("Movement", throwIfNotFound: true);
        m_Play_Jump = m_Play.FindAction("Jump", throwIfNotFound: true);
        m_Play_LongJump = m_Play.FindAction("LongJump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Play
    private readonly InputActionMap m_Play;
    private IPlayActions m_PlayActionsCallbackInterface;
    private readonly InputAction m_Play_ExitGame;
    private readonly InputAction m_Play_Movement;
    private readonly InputAction m_Play_Jump;
    private readonly InputAction m_Play_LongJump;
    public struct PlayActions
    {
        private @InputMaster m_Wrapper;
        public PlayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitGame => m_Wrapper.m_Play_ExitGame;
        public InputAction @Movement => m_Wrapper.m_Play_Movement;
        public InputAction @Jump => m_Wrapper.m_Play_Jump;
        public InputAction @LongJump => m_Wrapper.m_Play_LongJump;
        public InputActionMap Get() { return m_Wrapper.m_Play; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
        public void SetCallbacks(IPlayActions instance)
        {
            if (m_Wrapper.m_PlayActionsCallbackInterface != null)
            {
                @ExitGame.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnExitGame;
                @ExitGame.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnExitGame;
                @ExitGame.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnExitGame;
                @Movement.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @LongJump.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnLongJump;
                @LongJump.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnLongJump;
                @LongJump.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnLongJump;
            }
            m_Wrapper.m_PlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ExitGame.started += instance.OnExitGame;
                @ExitGame.performed += instance.OnExitGame;
                @ExitGame.canceled += instance.OnExitGame;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LongJump.started += instance.OnLongJump;
                @LongJump.performed += instance.OnLongJump;
                @LongJump.canceled += instance.OnLongJump;
            }
        }
    }
    public PlayActions @Play => new PlayActions(this);
    public interface IPlayActions
    {
        void OnExitGame(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLongJump(InputAction.CallbackContext context);
    }
}
