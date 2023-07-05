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
            if (Input.GetKey(KeyCode.W)) { _v.y += 1; }
            if (Input.GetKey(KeyCode.S)) { _v.y -= 1; }
            if (Input.GetKey(KeyCode.D)) { _v.x += 1; }
            if (Input.GetKey(KeyCode.A)) { _v.x -= 1; }
            movement = _v.normalized;
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }
    }
}