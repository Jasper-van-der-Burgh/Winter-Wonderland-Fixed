using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland {
    [RequireComponent( typeof( SegmentSetup ) )]
    public class LoopMaterials : MonoBehaviour {
        public Material[] Materials => _materials;
        public int Index => _index;
        public bool Fixed => _fixed;


        [SerializeField]
        private Material[] _materials = null;

        [SerializeField, Range( 0f, 1.2f )]
        private float _switchTime = 0.4f;

        [SerializeField]
        private int _index = 0;

        [SerializeField]
        private MovingLayer _movingLayer = null;


        private SegmentSetup _segmentSetup = null;
        private float _switchTimer = 0f;
        private bool _fixed = false;



        private void Start() {
            Debug.Assert( _materials.Length > 0, "No materials were added to the material looper." );
            _segmentSetup = GetComponent<SegmentSetup>();
            _segmentSetup.SetMaxSetup( _materials.Length );
            LoopThroughMaterials();
        }

        private void FixedUpdate() {
            _fixed = !_movingLayer.MovementEnabled;

            _switchTimer += Time.fixedDeltaTime;
            if ( !_fixed && _switchTimer > _switchTime ) {
                _switchTimer %= _switchTime;
                LoopThroughMaterials();
            }
        }
        
        private void LoopThroughMaterials() {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if ( renderer && null != _materials && _materials.Length > 0 ) {
                _index %= _materials.Length;
                if ( _materials[ _index ] ) {
                    _segmentSetup.SpawnSetup( _index );
                    renderer.material = _materials[ _index++ ];
                }
            }
        }
    }
}