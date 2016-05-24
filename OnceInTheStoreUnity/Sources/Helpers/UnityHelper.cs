// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OnceInTheStoreGameClasses.Helpers
{
    public static class UnityHelper
    {
        #region Helpers
        //===============================================================================================[]
        public static TComponent FindComponent< TComponent >() where TComponent : MonoBehaviour
        {
            var type = typeof( TComponent );
            var component = ( TComponent ) Object.FindObjectOfType( type );
            AssertObjectIsNotNull( component, type );
            return component;
        }

        //-------------------------------------------------------------------------------------[]
        public static Rect GetRect(
            float x,
            float y,
            float width,
            float height )
        {
            return new Rect( x, y, width, height );
        }

        //===============================================================================================[]
        #endregion




        #region Verification
        //===============================================================================================[]
        private static void AssertObjectIsNotNull(
            Object obj,
            Type type )
        {
            if( obj == null )
                throw new Exception( string.Format( "Can't find component {0}", type ) );
        }

        //===============================================================================================[]
        #endregion
    }
}