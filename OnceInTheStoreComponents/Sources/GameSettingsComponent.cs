// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using UnityEngine;

namespace OnceInTheStoreComponents
{
    [ AddComponentMenu( "OnceInTheStore::Components/GameSettingsComponent" ) ]
    internal class GameSettingsComponent : MonoBehaviour
    {
        #region Public data
        //===============================================================================================[]
        public bool PlayerHasVipAccount = true;
        public int PlayerLevel = 2;
        public int PlayerGold = 10000;
        //-------------------------------------------------------------------------------------[]
        public int RedSwordLevel = 1;
        public int RedSwordPrice = 10;
        public int GreenSwordLevel = 2;
        public int GreenSwordPrice = 20;
        //-------------------------------------------------------------------------------------[]
        public int WhiteHelmetLevel = 3;
        public int WhiteHelmetPrice = 30;
        public int BlueHelmetLevel = 4;
        public int BlueHelmetPrice = 40;
        public int RedHelmetLevel = 5;
        public int RedHelmetPrice = 50;
        //===============================================================================================[]
        #endregion
    }
}