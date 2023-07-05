using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputReader : MonoBehaviour
    {
        private GenernalInput inputs;
        [Header("Configruation")]
        public bool hideMouse;
        [Header("Output Signal")]
        public Vector2 movement;
        public bool isSprinting;
        public bool isJumping;
        public bool isCurShowed;
        public bool isESC;

        private void Awake()
        {
            inputs = new GenernalInput();
        }
        private void OnEnable()
        {
            inputs.Enable();
            inputs.Player.WSAD.performed += OnWSADPerformed;
            inputs.Player.WSAD.canceled += OnWSADCanceled;
            inputs.Player.Sprint.performed += OnSprintPerformed;
            inputs.Player.Jump.performed += OnJumpStarted;
            inputs.Player.Jump.canceled += OnJumpCanceled;
            inputs.Player.ShowCur.performed += OnShowCurPerformed;
        }
        private void OnDisable()
        {
            inputs.Disable();
            inputs.Player.WSAD.performed -= OnWSADPerformed;
            inputs.Player.WSAD.canceled -= OnWSADCanceled;
            inputs.Player.Sprint.performed -= OnSprintPerformed;
            inputs.Player.Jump.performed -= OnJumpStarted;
            inputs.Player.Jump.canceled -= OnJumpCanceled;
            inputs.Player.ShowCur.performed -= OnShowCurPerformed;
        }
        private void OnWSADPerformed(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }
        private void OnWSADCanceled(InputAction.CallbackContext context)
        {
            movement = Vector2.zero;
        }
        private void OnSprintPerformed(InputAction.CallbackContext context)
        {
            isSprinting = context.ReadValueAsButton();
        }
        private void OnJumpStarted(InputAction.CallbackContext context)
        {
            isJumping = true;
        }
        private void OnJumpCanceled(InputAction.CallbackContext context)
        {
            isJumping = false;
        }
        private void OnShowCurPerformed(InputAction.CallbackContext context)
        {
            isCurShowed = context.ReadValueAsButton();
        }
        public void Update()
        {
            if (inputs == null)
            {
                inputs = new GenernalInput();
                if (enabled) OnEnable();
            }
        }
    }
}