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
                    ""processors"": ""ScaleVector2(x=2500,y=2500),DeltaTime"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
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
    }
}
