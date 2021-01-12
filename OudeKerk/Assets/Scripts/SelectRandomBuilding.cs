using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WinterWonderland {
    public class SelectRandomBuilding : MonoBehaviour {
        [SerializeField]
        private Transform _door = null;


        private int[] _randomNumber = null;



        private void Awake() {
            if ( _door ) {
                FixedMaterials[] fixedMaterials = _door.GetComponentsInChildren<FixedMaterials>().ToArray();
                if ( fixedMaterials.Length > 0 ) {
                    _randomNumber = new int[ fixedMaterials.Length ];

                    for ( int i = 0; i < fixedMaterials.Length; ++i ) {
                        _randomNumber[ i ] = Random.Range( 0, fixedMaterials[ i ].Materials.Length );
                        fixedMaterials[ i ].Index = _randomNumber[ i ];
                    }
                }
            }
        }
    }
}