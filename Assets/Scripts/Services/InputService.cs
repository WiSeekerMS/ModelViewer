using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services
{
    public class InputService : IDisposable
    {
        private Controls _controls;
        
        public bool IsGrab => _controls != null && _controls.Main.Grab.IsPressed();
        public float XAxisDelta => _controls != null ? _controls.Main.AxisX.ReadValue<float>() : 0f;
        public float YAxisDelta => _controls != null ? _controls.Main.AxisY.ReadValue<float>() : 0f;
        public Vector2 MousePosition = Mouse.current.position.ReadValue();
        
        public InputService()
        {
            _controls = new Controls();
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Enable();
        }
    }
}