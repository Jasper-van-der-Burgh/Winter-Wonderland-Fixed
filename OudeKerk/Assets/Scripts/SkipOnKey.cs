using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland {
    public class SkipOnKey : MonoBehaviour {
        [SerializeField]
        private KeyCode _key = KeyCode.Space;

        [SerializeField, Range( 0f, 15f )]
        private float _cooldown = 3f;


        private float _skipCooldown = 0;
        private bool _activated = false;
        private bool _enabled = true;



        public void SetCooldown() {
            _skipCooldown = _cooldown;
        }

        public void DisableCountdown() {
            _enabled = false;
        }

        public void EnableCountdown() {
            _enabled = true;
        }

        private void Update() {
            if ( _enabled ) {
                if ( _skipCooldown > 0 ) _skipCooldown = Mathf.Max( _skipCooldown - Time.deltaTime, 0 );
                if ( !_activated && _skipCooldown <= Mathf.Epsilon && Input.GetKeyDown( _key ) ) {
                    _activated = true;
                    SceneManagement.Next();
                }
            }
        }
    }
}