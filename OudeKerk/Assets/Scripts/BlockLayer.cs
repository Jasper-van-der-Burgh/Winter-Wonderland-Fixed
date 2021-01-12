using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WinterWonderland {
    [RequireComponent( typeof( MovingLayer ) )]
    public class BlockLayer : MonoBehaviour {
        public GameObject[] Planes => _planes;


        [SerializeField]
        private GameObject[] _planes = null;

        [SerializeField]
        private Material _ice = null;

        private MovingLayer _movingLayer = null;



        public void GiveTurn() {
            if ( _movingLayer ) {
                _movingLayer.Move();
            }
            if ( null != _planes && _planes[ 1 ] ) {
                if ( _ice )
                    _planes[ 1 ].GetComponent<MeshRenderer>().material = _ice;
            }
        }

        public void TakeTurn() {
            if ( _movingLayer )
                _movingLayer.StopMove();
        }

        public void GameOver() {
            if ( null != _planes ) {
                foreach ( GameObject plane in _planes ) {
                    plane.SetActive( false );
                }
            }
        }

        private void Start() {
            Transform[] voidForms = GetComponentsInChildren<Transform>().Where( form => form != transform ).ToArray();
            _planes = new GameObject[ voidForms.Length ];
            for ( int i = 0; i < voidForms.Length; ++i ) {
                _planes[ i ] = voidForms[ i ].gameObject;
            }
            _movingLayer = GetComponent<MovingLayer>();
        }
    }
}