using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WinterWonderland {
    public class Shiner : MonoBehaviour {
        [SerializeField, Range( 0.04f, 0.4f )]
        private float _interval = 0.15f;


        private List<BlockLayer> _blockLayers = null;
        private float _counter = 0;
        private int _index = 0;
        private bool _activated = false;



        public void SummonParticles( List<BlockLayer> pBlockLayers ) {
            _blockLayers = pBlockLayers;
            _activated = true;
        }

        private void Update() {
            if ( _activated && null != _blockLayers && _blockLayers.Count > 0 && _index < _blockLayers.Count && null != _blockLayers[ _index ] ) {
                _counter += Time.deltaTime;
                if ( _counter >= _interval ) {
                    _counter %= _interval;
                    SineHover _sineHover = _blockLayers[ _index ].GetComponent<SineHover>();
                    SummonParticles[] particles = _blockLayers[ _index++ ].GetComponents<SummonParticles>();
                    if ( null != particles && null != _sineHover && particles.Length > 0 && particles[ 0 ] ) {
                        particles[ 0 ].Spawn( _sineHover.StartPosition );
                    }
                }
            }
        }
    }
}