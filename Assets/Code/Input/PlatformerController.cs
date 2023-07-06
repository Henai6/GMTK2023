using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace CustomInput
{
    public class PlatformerController : MonoBehaviour
    {
        //private Animator _animator;
        private AbstractInputReader _cs;
        private Rigidbody2D _rb;
        private bool _grounded;
        private int _layerMask;
        private Collider2D c;

        public Vector2 _velo;
        [Header("Player Data")]
        public float speed = 5;
        public float jumpStartSpeed = 8;
        public float gravity = 10;
        public float maxFallSpeed = -20;
        public bool canVertical;

        private void Start()
        {
            _cs = GetComponent<AbstractInputReader>();
            //_animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _layerMask = LayerMask.GetMask("Ground") + LayerMask.GetMask("Default");
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
            _rb.velocity = _velo;
            if (_velo.x > 0.7) EventDispatcher.Instance.IndexedEvent(0);
        }
        private void JumpAndGravity()
        {
            
            if (canVertical) return;
            if (_grounded)
            {
                if (_velo.y < 0) _velo.y = 0;
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