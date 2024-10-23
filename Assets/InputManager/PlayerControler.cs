//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputManager/PlayerControler.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControler: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControler"",
    ""maps"": [
        {
            ""name"": ""PCInputmanager"",
            ""id"": ""c492b3b6-311c-49be-a05f-5cc460ab8e2e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""88889712-cd7d-49e3-b3a7-7a2d7241499d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""2ceefc81-dd86-4541-b3cc-3757db08dbd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveKeyboard"",
                    ""type"": ""Value"",
                    ""id"": ""26646222-6a47-4329-a8df-7c5849c285b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b04a93c0-79e1-4d86-82b3-34719034c75e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""9a24c128-b543-42b6-b2d0-4ddc3025ccb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""798f34ae-1342-46c4-9078-df70fd1fddf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2efd012-474c-4181-9c5a-c611622e5b89"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9f3a8a0-d465-4039-b0b1-052a81807267"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d23889c-37f3-4a92-bf49-82cb3f68e349"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83d5fd8c-73d3-4052-b69c-f4bbb51a3615"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""7a3e3acd-538c-4cbc-a028-246fe40e916c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""48f68af3-f2c9-4849-bf23-a4f6e1076117"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22c82fb0-139e-4fbd-887e-e3defd37cef7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""d3fc3ac2-757d-4959-a903-f9b09ba00adf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1b2115eb-4613-447b-95fa-510b08ded802"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""75828b97-6595-4e84-9276-43bc85ea3b80"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""83b86cfd-d9f3-4390-8d7d-9f4dc045df55"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3230112b-3fcd-4ac4-b5eb-f4a7ca8180b0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6f97ad-5fef-486e-949c-91665f13de5b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac4d56e7-74fb-4f5c-ad47-c80ea629a710"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PCInputmanager
        m_PCInputmanager = asset.FindActionMap("PCInputmanager", throwIfNotFound: true);
        m_PCInputmanager_Move = m_PCInputmanager.FindAction("Move", throwIfNotFound: true);
        m_PCInputmanager_Shooting = m_PCInputmanager.FindAction("Shooting", throwIfNotFound: true);
        m_PCInputmanager_MoveKeyboard = m_PCInputmanager.FindAction("MoveKeyboard", throwIfNotFound: true);
        m_PCInputmanager_Pause = m_PCInputmanager.FindAction("Pause", throwIfNotFound: true);
        m_PCInputmanager_Shield = m_PCInputmanager.FindAction("Shield", throwIfNotFound: true);
        m_PCInputmanager_Switch = m_PCInputmanager.FindAction("Switch", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PCInputmanager
    private readonly InputActionMap m_PCInputmanager;
    private List<IPCInputmanagerActions> m_PCInputmanagerActionsCallbackInterfaces = new List<IPCInputmanagerActions>();
    private readonly InputAction m_PCInputmanager_Move;
    private readonly InputAction m_PCInputmanager_Shooting;
    private readonly InputAction m_PCInputmanager_MoveKeyboard;
    private readonly InputAction m_PCInputmanager_Pause;
    private readonly InputAction m_PCInputmanager_Shield;
    private readonly InputAction m_PCInputmanager_Switch;
    public struct PCInputmanagerActions
    {
        private @PlayerControler m_Wrapper;
        public PCInputmanagerActions(@PlayerControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PCInputmanager_Move;
        public InputAction @Shooting => m_Wrapper.m_PCInputmanager_Shooting;
        public InputAction @MoveKeyboard => m_Wrapper.m_PCInputmanager_MoveKeyboard;
        public InputAction @Pause => m_Wrapper.m_PCInputmanager_Pause;
        public InputAction @Shield => m_Wrapper.m_PCInputmanager_Shield;
        public InputAction @Switch => m_Wrapper.m_PCInputmanager_Switch;
        public InputActionMap Get() { return m_Wrapper.m_PCInputmanager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PCInputmanagerActions set) { return set.Get(); }
        public void AddCallbacks(IPCInputmanagerActions instance)
        {
            if (instance == null || m_Wrapper.m_PCInputmanagerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PCInputmanagerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Shooting.started += instance.OnShooting;
            @Shooting.performed += instance.OnShooting;
            @Shooting.canceled += instance.OnShooting;
            @MoveKeyboard.started += instance.OnMoveKeyboard;
            @MoveKeyboard.performed += instance.OnMoveKeyboard;
            @MoveKeyboard.canceled += instance.OnMoveKeyboard;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Shield.started += instance.OnShield;
            @Shield.performed += instance.OnShield;
            @Shield.canceled += instance.OnShield;
            @Switch.started += instance.OnSwitch;
            @Switch.performed += instance.OnSwitch;
            @Switch.canceled += instance.OnSwitch;
        }

        private void UnregisterCallbacks(IPCInputmanagerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Shooting.started -= instance.OnShooting;
            @Shooting.performed -= instance.OnShooting;
            @Shooting.canceled -= instance.OnShooting;
            @MoveKeyboard.started -= instance.OnMoveKeyboard;
            @MoveKeyboard.performed -= instance.OnMoveKeyboard;
            @MoveKeyboard.canceled -= instance.OnMoveKeyboard;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Shield.started -= instance.OnShield;
            @Shield.performed -= instance.OnShield;
            @Shield.canceled -= instance.OnShield;
            @Switch.started -= instance.OnSwitch;
            @Switch.performed -= instance.OnSwitch;
            @Switch.canceled -= instance.OnSwitch;
        }

        public void RemoveCallbacks(IPCInputmanagerActions instance)
        {
            if (m_Wrapper.m_PCInputmanagerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPCInputmanagerActions instance)
        {
            foreach (var item in m_Wrapper.m_PCInputmanagerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PCInputmanagerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PCInputmanagerActions @PCInputmanager => new PCInputmanagerActions(this);
    public interface IPCInputmanagerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
        void OnMoveKeyboard(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
}
