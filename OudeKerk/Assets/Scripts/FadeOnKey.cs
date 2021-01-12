using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace WinterWonderland
{
    public class FadeOnKey : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _key = KeyCode.Space;

        [SerializeField, Range( 0.001f, 2f )]
        private float _duration = 1f;


        private MaskableGraphic _image = null;
        private bool _activated = false;
        private float _alphaStep = 0;



        private void Update() {
            if ( !_activated ) {
                if ( Input.GetKeyDown( _key ) ) {
                    _activated = true;
                    _image = GetComponent<MaskableGraphic>();
                    if ( _duration != 0 )
                        _alphaStep = _image.color.a / _duration;
                }
            }
            else if ( _image ) {
                _image.color -= new Color( 0, 0, 0, _alphaStep * Time.deltaTime );
            }
        }
    }
}