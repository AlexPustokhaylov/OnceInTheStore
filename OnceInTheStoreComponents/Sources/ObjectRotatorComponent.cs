// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using UnityEngine;

namespace OnceInTheStoreComponents
{
    [ AddComponentMenu( "OnceInTheStore::Components/ObjectRotatorComponent" ) ]
    internal class ObjectRotatorComponent : MonoBehaviour
    {
        #region Data
        //===============================================================================================[]
        private bool _down;
        //===============================================================================================[]
        #endregion




        #region Public data
        //===============================================================================================[]
        public float SensitivityX = 10.0f;
        public float SensitivityY = 10.0f;
        //===============================================================================================[]
        #endregion




        #region MonoBehaviour
        //===============================================================================================[]
        public void Update()
        {
            if( Input.GetKey( KeyCode.LeftAlt ) ||
                Input.GetKey( KeyCode.RightAlt ) ) {
                if( Input.GetMouseButtonDown( 0 ) )
                    _down = true;
                else if( Input.GetMouseButtonUp( 0 ) )
                    _down = false;

                if( _down ) {
                    var rotationX = Input.GetAxis( "Mouse X" )*SensitivityX;
                    var rotationY = Input.GetAxis( "Mouse Y" )*SensitivityY;
                    transform.RotateAroundLocal( Camera.mainCamera.transform.up, -Mathf.Deg2Rad*rotationX );
                    transform.RotateAroundLocal( Camera.mainCamera.transform.right, Mathf.Deg2Rad*rotationY );
                }
            }
        }

        //===============================================================================================[]
        #endregion
    }
}