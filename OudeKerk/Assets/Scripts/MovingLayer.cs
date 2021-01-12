using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland
{
    public class MovingLayer : MonoBehaviour
    {
        public bool MovementEnabled => _movementOn;

        [SerializeField]
        protected Vector3 _direction = Vector3.zero;

        [SerializeField, Range( 0f, 10f )]
        protected float _speed = 1f;

        protected bool _movementOn = false;
        protected float _invert = 1f;



        public virtual void Move() {
            _movementOn = true;
        }

        public void StopMove() {
            _movementOn = false;
        }

        protected int RandomSign() {
            int sign = Random.Range( 0, 2 );
            return ( sign == 0 ) ? -1 : sign;
        }
    }
}