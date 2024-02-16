//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/GameControlsAsset.inputactions
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

namespace Scripts.Player.Inputs
{
    public partial class @GameControlsAsset: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControlsAsset()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControlsAsset"",
    ""maps"": [
        {
            ""name"": ""CameraMap"",
            ""id"": ""a0dc03a0-e96a-41de-93d3-4207db7d052d"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b443bd63-5a87-42d1-b813-f17a1de255d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""876f804d-2c05-462f-ba0b-38355d8d547b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56f131a1-7276-4146-adec-7d507b2be6f5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""DeltaTime,ScaleVector2(x=2000,y=2000)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MovementMap"",
            ""id"": ""f2c0fd46-e128-4d29-b79e-86c742ffa048"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c863b89c-4546-4ddf-8983-4688f7b3afdd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c2852d39-11f0-4305-a322-e0372b48d2b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a11dcf64-03e8-4b27-83a2-a66c4c9d14f0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a9913ca6-10e7-45b6-a6dc-f268caedabb3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c7ab9f72-32ae-4efd-a430-e2fd405e9472"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c1d51807-92eb-4558-bb76-5962212550fb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a50fdc25-5807-4b05-9c41-5fa1cc62e6d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2d09c5e4-28d3-4fbc-b0e3-84960f11dbd1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47772146-8735-48c9-8d65-1f3b19fed4eb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7afad844-0a4f-4e05-9b26-3470065e655e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AbilitiesMap"",
            ""id"": ""f2611154-399e-4351-99d6-3feb379b9b12"",
            ""actions"": [
                {
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""95caf3e0-119d-4154-b9e9-1b3c78597406"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45bb819c-3830-46e3-b3fb-60c11ef6aa8c"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // CameraMap
            m_CameraMap = asset.FindActionMap("CameraMap", throwIfNotFound: true);
            m_CameraMap_Look = m_CameraMap.FindAction("Look", throwIfNotFound: true);
            // MovementMap
            m_MovementMap = asset.FindActionMap("MovementMap", throwIfNotFound: true);
            m_MovementMap_Move = m_MovementMap.FindAction("Move", throwIfNotFound: true);
            m_MovementMap_Jump = m_MovementMap.FindAction("Jump", throwIfNotFound: true);
            // AbilitiesMap
            m_AbilitiesMap = asset.FindActionMap("AbilitiesMap", throwIfNotFound: true);
            m_AbilitiesMap_Test = m_AbilitiesMap.FindAction("Test", throwIfNotFound: true);
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

        // CameraMap
        private readonly InputActionMap m_CameraMap;
        private List<ICameraMapActions> m_CameraMapActionsCallbackInterfaces = new List<ICameraMapActions>();
        private readonly InputAction m_CameraMap_Look;
        public struct CameraMapActions
        {
            private @GameControlsAsset m_Wrapper;
            public CameraMapActions(@GameControlsAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_CameraMap_Look;
            public InputActionMap Get() { return m_Wrapper.m_CameraMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraMapActions set) { return set.Get(); }
            public void AddCallbacks(ICameraMapActions instance)
            {
                if (instance == null || m_Wrapper.m_CameraMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CameraMapActionsCallbackInterfaces.Add(instance);
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }

            private void UnregisterCallbacks(ICameraMapActions instance)
            {
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
            }

            public void RemoveCallbacks(ICameraMapActions instance)
            {
                if (m_Wrapper.m_CameraMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICameraMapActions instance)
            {
                foreach (var item in m_Wrapper.m_CameraMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CameraMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CameraMapActions @CameraMap => new CameraMapActions(this);

        // MovementMap
        private readonly InputActionMap m_MovementMap;
        private List<IMovementMapActions> m_MovementMapActionsCallbackInterfaces = new List<IMovementMapActions>();
        private readonly InputAction m_MovementMap_Move;
        private readonly InputAction m_MovementMap_Jump;
        public struct MovementMapActions
        {
            private @GameControlsAsset m_Wrapper;
            public MovementMapActions(@GameControlsAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_MovementMap_Move;
            public InputAction @Jump => m_Wrapper.m_MovementMap_Jump;
            public InputActionMap Get() { return m_Wrapper.m_MovementMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementMapActions set) { return set.Get(); }
            public void AddCallbacks(IMovementMapActions instance)
            {
                if (instance == null || m_Wrapper.m_MovementMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MovementMapActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }

            private void UnregisterCallbacks(IMovementMapActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
            }

            public void RemoveCallbacks(IMovementMapActions instance)
            {
                if (m_Wrapper.m_MovementMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMovementMapActions instance)
            {
                foreach (var item in m_Wrapper.m_MovementMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MovementMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MovementMapActions @MovementMap => new MovementMapActions(this);

        // AbilitiesMap
        private readonly InputActionMap m_AbilitiesMap;
        private List<IAbilitiesMapActions> m_AbilitiesMapActionsCallbackInterfaces = new List<IAbilitiesMapActions>();
        private readonly InputAction m_AbilitiesMap_Test;
        public struct AbilitiesMapActions
        {
            private @GameControlsAsset m_Wrapper;
            public AbilitiesMapActions(@GameControlsAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @Test => m_Wrapper.m_AbilitiesMap_Test;
            public InputActionMap Get() { return m_Wrapper.m_AbilitiesMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AbilitiesMapActions set) { return set.Get(); }
            public void AddCallbacks(IAbilitiesMapActions instance)
            {
                if (instance == null || m_Wrapper.m_AbilitiesMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_AbilitiesMapActionsCallbackInterfaces.Add(instance);
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }

            private void UnregisterCallbacks(IAbilitiesMapActions instance)
            {
                @Test.started -= instance.OnTest;
                @Test.performed -= instance.OnTest;
                @Test.canceled -= instance.OnTest;
            }

            public void RemoveCallbacks(IAbilitiesMapActions instance)
            {
                if (m_Wrapper.m_AbilitiesMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IAbilitiesMapActions instance)
            {
                foreach (var item in m_Wrapper.m_AbilitiesMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_AbilitiesMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public AbilitiesMapActions @AbilitiesMap => new AbilitiesMapActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface ICameraMapActions
        {
            void OnLook(InputAction.CallbackContext context);
        }
        public interface IMovementMapActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IAbilitiesMapActions
        {
            void OnTest(InputAction.CallbackContext context);
        }
    }
}
