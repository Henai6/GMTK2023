using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInput
{
    public class NativeInputReader : AbstractInputReader
    {
        private void Awake()
        {
            movement = new Vector2();
        }
        private Vector2 _v = new Vector2();
        private void Update()
        {
            _v = Vector2.zero;
            _v.y += Input.GetAxisRaw("Vertical");
            _v.x += Input.GetAxisRaw("Horizontal");
            movement = _v.normalized;

            isJumping = Input.GetButtonDown("Jump");
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }
    }
}