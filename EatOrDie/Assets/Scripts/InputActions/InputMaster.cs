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
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""632f663d-7616-429e-b621-2adb9a279f66"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6cd658fe-84c8-4055-a441-4b6e67dceb61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""bc33c352-859a-48ea-93a2-cca51f56419d"",
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
                    ""name"": """",
                    ""id"": ""5989febf-9eba-4f3b-abbd-add166904bf6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c36a048b-516f-4ef7-9c61-79c54b2e2b06"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""f844eaee-5b40-40dd-874f-e9e2c7269514"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1e5065c0-9bda-4f76-8128-a52b5cb9b0e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1fc9bc81-31b1-4e39-8f92-94e870adf55b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""29cf521e-8873-48e8-acc4-1df5cc9a726f"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fe320294-a2a5-4f9b-a3fb-2114d48a7638"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""Button"",
                    ""id"": ""bbb9ff33-df38-4fd4-bc7c-48dcc6abfee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a1cd2c0-9a33-48d9-9523-be76012a03e7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""64288777-5d66-498b-a428-4d98926c3790"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ed4d460-5154-4004-94f8-0a8ce42cb444"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cec58594-5742-4eab-976f-7df005799ad7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02d30129-e469-4252-bb82-c005b95a6790"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f3ee6f-2365-4d8b-bc48-2543c84278d6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
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
        m_Play_Move = m_Play.FindAction("Move", throwIfNotFound: true);
        m_Play_Jump = m_Play.FindAction("Jump", throwIfNotFound: true);
        m_Play_Duck = m_Play.FindAction("Duck", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Primary = m_Touch.FindAction("Primary", throwIfNotFound: true);
        m_Touch_LeftMouse = m_Touch.FindAction("LeftMouse", throwIfNotFound: true);
        m_Touch_MousePosition = m_Touch.FindAction("MousePosition", throwIfNotFound: true);
        m_Touch_Target = m_Touch.FindAction("Target", throwIfNotFound: true);
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
    private readonly InputAction m_Play_Move;
    private readonly InputAction m_Play_Jump;
    private readonly InputAction m_Play_Duck;
    public struct PlayActions
    {
        private @InputMaster m_Wrapper;
        public PlayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitGame => m_Wrapper.m_Play_ExitGame;
        public InputAction @Move => m_Wrapper.m_Play_Move;
        public InputAction @Jump => m_Wrapper.m_Play_Jump;
        public InputAction @Duck => m_Wrapper.m_Play_Duck;
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
                @Move.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnJump;
                @Duck.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnDuck;
            }
            m_Wrapper.m_PlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ExitGame.started += instance.OnExitGame;
                @ExitGame.performed += instance.OnExitGame;
                @ExitGame.canceled += instance.OnExitGame;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
            }
        }
    }
    public PlayActions @Play => new PlayActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Primary;
    private readonly InputAction m_Touch_LeftMouse;
    private readonly InputAction m_Touch_MousePosition;
    private readonly InputAction m_Touch_Target;
    public struct TouchActions
    {
        private @InputMaster m_Wrapper;
        public TouchActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_Touch_Primary;
        public InputAction @LeftMouse => m_Wrapper.m_Touch_LeftMouse;
        public InputAction @MousePosition => m_Wrapper.m_Touch_MousePosition;
        public InputAction @Target => m_Wrapper.m_Touch_Target;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Primary.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimary;
                @LeftMouse.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftMouse;
                @MousePosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnMousePosition;
                @Target.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTarget;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @LeftMouse.started += instance.OnLeftMouse;
                @LeftMouse.performed += instance.OnLeftMouse;
                @LeftMouse.canceled += instance.OnLeftMouse;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface IPlayActions
    {
        void OnExitGame(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
    }
}
