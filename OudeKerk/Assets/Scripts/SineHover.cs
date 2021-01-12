using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland {
    public class SineHover : MovingLayer {
        public Vector3 StartPosition => _startPosition;


        [SerializeField, Range( 0f, 10f )]
        private float _amount = 5f;

        private Vector3 _startPosition;
        private float _time = 0;
        private float _offset = 0;



        public bool IsCenteredAround( float pLenience ) {
            return Vector3.Distance( transform.position, _startPosition ) < pLenience;
        }

        public override void Move() {
            base.Move();
            _startPosition = transform.position;
            transform.position = _startPosition + _direction.normalized * _amount * _invert;
        }

        private void Start() {
            _offset = RandomSign();
            if ( _offset == 1 ) {
                _invert = -1f;
            }
            _offset *= Mathf.PI * 0.5f * _invert;
        }

        private void Update() {
            if ( _movementOn && _direction.magnitude > Mathf.Epsilon ) {
                _time += Time.deltaTime * Mathf.PI * 2f;
                float sin = Mathf.Sin( _offset + _time * _speed );
                transform.position = _startPosition + _direction.normalized * _amount * _invert * sin;
            }
        }
    }
}