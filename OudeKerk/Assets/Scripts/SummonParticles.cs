using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland {
    public class SummonParticles : MonoBehaviour {
        [SerializeField]
        private GameObject _particleEffect = null;

        [SerializeField]
        private float _zLocation = 9.5f;



        public void Spawn( Vector3 pPosition ) {
            if ( null != _particleEffect ) {
                Vector3 placement = ( pPosition.magnitude > Mathf.Epsilon ) ? pPosition : transform.position;
                placement.z = _zLocation;
                GameObject spawnedEffect = Instantiate( _particleEffect, placement, Quaternion.Euler( new Vector3( 0, 180f, 0 ) ) );
                float expirationTime = 2f;
                float lifetime = 0.5f;
                ParticleSystem particleSystem = spawnedEffect.GetComponentInChildren<ParticleSystem>();
                if ( particleSystem ) {
                    expirationTime = particleSystem.main.duration;
                    lifetime = particleSystem.main.startLifetime.constantMax;
                }
                Destroy( spawnedEffect, expirationTime + lifetime );
            }
        }
    }
}