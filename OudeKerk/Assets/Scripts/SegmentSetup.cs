using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WinterWonderland {
    public class SegmentSetup : MonoBehaviour {
        [SerializeField]
        private GameObject[] _prefabs = null;

        private GameObject[] _setup = null;
        private int _lastIndex = 0;
        private float _scale = 1f;



        public void SetMaxSetup( int amount ) {
            _setup = new GameObject[ amount ];
        }

        public void Scale( float scale ) {
            _scale = scale;
        }

        public void SpawnSetup( int index ) {
            if ( null != _prefabs && _prefabs.Length > index ) {
                if ( null != _setup[ _lastIndex ] ) {
                    _setup[ _lastIndex ].SetActive( false );
                }
                if ( null == _setup[ index ] ) {
                    _setup[ index ] = ( GameObject )GameObject.Instantiate( _prefabs[ index ], transform.position, Quaternion.identity );
                    _setup[ index ].transform.position -= new Vector3( 0, transform.localScale.z * 5f, 0 );
                    _setup[ index ].transform.localScale *= _scale;
                }
                else {
                    _setup[ index ].SetActive( true );
                }
                _lastIndex = index;
            }
        }
    }
  }