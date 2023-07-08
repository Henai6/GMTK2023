using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInput
{
    public class TetrisController : MonoBehaviour
    {
        private AbstractInputReader _ir;
        public bool _isReseted;
        private void Start()
        {
            _ir = GetComponent<AbstractInputReader>();
        }

        private void Update()
        {
            if (_isReseted && _ir.movement.sqrMagnitude > 0.1f)
            {
                _isReseted = false;
                gameDirection? dir = null;
                if (_ir.movement.x < -0.8f) dir = gameDirection.Left;
                if (_ir.movement.y > 0.8f) dir = gameDirection.Up;
                if (_ir.movement.x > 0.8f) dir = gameDirection.Right;
                if (_ir.movement.y < -0.8f) dir = gameDirection.Down;
                switch (dir)
                {
                    case gameDirection.Left:
                        //Debug.Log("moving left");
                        break;
                    case gameDirection.Up:
                        //Debug.Log("moving up");
                        break;
                    case gameDirection.Right:
                        //Debug.Log("moving right");
                        break;
                    case gameDirection.Down:
                        //Debug.Log("moving down");
                        break;
                    default:
                        Debug.Log("error dir");
                        return;
                }
                EventDispatcher.Instance.MoveEvent((int)dir);
            }
            if (_ir.movement.sqrMagnitude < 0.1f) _isReseted = true;
            if (_ir.isJumping) Debug.Log("going to rotate!!!");
        }


    }
}