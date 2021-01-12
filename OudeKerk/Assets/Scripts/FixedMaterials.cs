using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WinterWonderland {
    [RequireComponent( typeof( SegmentSetup ) )]
    public class FixedMaterials : MonoBehaviour {
        public Material[] Materials => _materials;


        public int Index {
            get { return _index; }
            set { _index = value; }
        }


        [SerializeField]
        private Material[] _materials = null;

        [SerializeField]
        private int _index = 0;

        [SerializeField, Range( 0.1f, 2f )]
        private float _scale = 0.5f;


        private SegmentSetup _segmentSetup = null;



        private void Start() {
            Debug.Assert( _materials.Length > 0, "No materials were added to the material looper." );
            _segmentSetup = GetComponent<SegmentSetup>();
            _segmentSetup.SetMaxSetup( _materials.Length );


            if ( null != _materials && _index < _materials.Length && null != _materials[ _index ] ) {
                _segmentSetup.Scale( _scale );
                _segmentSetup.SpawnSetup( _index );
                MeshRenderer renderer = GetComponent<MeshRenderer>();
                renderer.material = _materials[ _index++ ];
            }
        }
    }
}