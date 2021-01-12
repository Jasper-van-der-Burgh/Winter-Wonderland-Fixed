using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WinterWonderland {
    public class VoidController : MonoBehaviour {
        [SerializeField]
        private Transform _void = null;

        [SerializeField]
        private SkipOnKey _skipObj = null;

        [SerializeField, Range( 0.1f, 1.7f )]
        private float _playCooldown = 0.8f;


        private List<BlockLayer> _blockLayers = null;
        private int _currentLayer = 0;
        private bool _gameStarted = false;
        private bool _playingEnabled = true;



        private void Awake() {
            if ( _skipObj ) {
                _skipObj.SetCooldown();
                _skipObj.DisableCountdown();
            }
            else {
                Debug.LogWarning( "No SkipOnKey object known to VoidController." );
            }
        }

        private void Start() {
            if ( _void ) {
                _blockLayers = _void.GetComponentsInChildren<BlockLayer>().ToList();
            }
        }

        private void Update() {
            if ( Input.GetKeyDown( KeyCode.Space ) ) {
                if ( !_gameStarted ) {
                    _gameStarted = true;
                }
                else if ( _playingEnabled && _playCooldown <= 0 && _blockLayers.Count > 0 ) {
                    _blockLayers[ _currentLayer ].TakeTurn();
                    SineHover movingLayer = _blockLayers[ _currentLayer ].GetComponent<SineHover>();
                    if ( null != movingLayer ) {
                        if ( movingLayer.IsCenteredAround( 0.6666667f ) ) {
                            SummonParticles[] particles = _blockLayers[ _currentLayer ].transform.GetComponents<SummonParticles>();
                            for ( int i = 0; i < particles.Length; ++i ) {
                                Vector3 pos = ( i == 0 ) ? movingLayer.StartPosition : Vector3.zero;
                                particles[ i ].Spawn( pos );
                            }
                        }
                    }
                    else {
                        Debug.LogWarning( $"{_blockLayers[ _currentLayer ].name} doesn't have a MovingLayer component!" );
                    }


                    if ( ++_currentLayer >= _blockLayers.Count ) {
                        _playingEnabled = false;
                        if ( GetComponent<Shiner>() ) {
                            GetComponent<Shiner>().SummonParticles( _blockLayers );
                        }
                        foreach ( BlockLayer layer in _blockLayers ) {
                            layer.GameOver();
                        }
                        EndGame();
                    }
                    else {
                        _blockLayers[ _currentLayer ].GiveTurn();
                    }
                }
            }
            else if ( _gameStarted && _playCooldown > 0 ) {
                _playCooldown = Mathf.Max( _playCooldown - Time.deltaTime );
                if ( _playCooldown <= 0 && _blockLayers.Count > 0 ) {
                    _blockLayers[ _currentLayer ].GiveTurn();
                }
            }
        }

        private void EndGame() {
            if ( _skipObj )
                _skipObj.EnableCountdown();
            else {
                Debug.LogWarning( "No SkipOnKey object known to VoidController. Skipping to next scene..." );
                SceneManagement.Next();
            }
        }
    }
}