using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInput
{
    public abstract class AbstractInputReader : MonoBehaviour
    {
        [Header("Configruation")]
        public bool hideMouse;

        [Header("Output Signal")]
        public Vector2 movement;
        public bool isSprinting;
        public bool isJumping;
        public bool isCurShowed;
        public bool isInteract;
        public bool isESC;
    }
}