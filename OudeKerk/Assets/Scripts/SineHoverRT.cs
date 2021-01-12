using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace WinterWonderland
{
    public class SineHoverRT : MovingLayer
    {
        public Vector3 StartPosition => _startPosition;


        [SerializeField, Range( 0f, 100f )]
        private float _amount = 5f;

        private RectTransform _rectForm = null;
        private Vector3 _startPosition = Vector3.zero;
        private float _time = 0;



        private void Start() {
            _rectForm = GetComponent<RectTransform>();
            _startPosition = _rectForm.position;
            _rectForm.position = _startPosition + _direction.normalized * _amount * _invert;
        }

        private void Update() {
            if ( _direction.magnitude > Mathf.Epsilon ) {
                _time += Time.deltaTime * Mathf.PI * 2f;
                float sin = Mathf.Sin( _time * _speed );
                _rectForm.position = _startPosition + _direction.normalized * _amount * _invert * sin;
            }
        }
    }
}