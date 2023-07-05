using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Input
{
    public class PlatformerController : MonoBehaviour
    {
        //private Animator _animator;
        private InputReader _cs;
        private CharacterController _cc;
        private bool _grounded;
        private int _layerMask;
        private Collider2D c;

        public Vector2 _velo;
        [Header("Player Data")]
        public float speed = 5;
        public float jumpStartSpeed = 3;
        public float gravity = 1;
        public float maxFallSpeed = -10;
        public bool canVertical;

        private void Start()
        {
            _cs = GetComponent<InputReader>();
            //_animator = GetComponent<Animator>();
            _cc = GetComponent<CharacterController>();
            _layerMask = LayerMask.GetMask("Ground");
        }

        // Update is called once per frame
        void Update()
        {
            _grounded = false;
            Vector2 circlePosition = new Vector2(transform.position.x, transform.position.y-0.5f);
            c = Physics2D.OverlapCircle(circlePosition, 0.5f, _layerMask);
            if (c != null) _grounded = true;

            JumpAndGravity();
            Move();
            _cc.Move(_velo * Time.deltaTime);
        }
        private void JumpAndGravity()
        {
            if (canVertical) return;
            if (_grounded)
            {
                _velo.y = 0;
                if (_cs.isJumping) _velo.y = jumpStartSpeed;
            }
            else
            {
                _velo.y -= gravity * Time.deltaTime;
                if (_velo.y < maxFallSpeed) _velo.y = maxFallSpeed;
            }
        }
        private void Move()
        {
            _velo.x = _cs.movement.x * speed;
            if (canVertical) _velo.y = _cs.movement.y * speed;
        }
    }
}