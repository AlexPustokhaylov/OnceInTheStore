// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using OnceInTheStoreGameClasses.Helpers;
using UnityEngine;

// Resharper disable UnusedMember.Global

namespace OnceInTheStoreComponents
{
    [ AddComponentMenu( "OnceInTheStore::Components/ChooseRaceComponent" ) ]
    internal class ChooseRaceComponent : MonoBehaviour
    {
        #region Public data
        //===============================================================================================[]
        public event DefaultDelegateWithRaceName PlayerChooseRaceEvent;
        public GUISkin GuiSkin;
        //===============================================================================================[]
        #endregion




        #region Data
        //===============================================================================================[]
        private const int OrcButtonWidth = 150;
        private const int OrcButtonHeight = 50;
        private const int ElfButtonWidth = 150;
        private const int ElfButtonHeight = 50;
        //-------------------------------------------------------------------------------------[]
        private Rect _orcFaceRect;
        private Rect _elfFaceRect;
        //===============================================================================================[]
        #endregion




        #region MonoBehaviour
        //===============================================================================================[]
        public void Start()
        {
            _orcFaceRect = UnityHelper.GetRect(
                Screen.width/2f - 1.5f*OrcButtonWidth,
                Screen.height/2 - OrcButtonHeight,
                OrcButtonWidth,
                OrcButtonHeight );
            _elfFaceRect = UnityHelper.GetRect(
                Screen.width/2f + 0.5f*ElfButtonWidth,
                Screen.height/2 - ElfButtonHeight,
                ElfButtonWidth,
                ElfButtonHeight );
        }

        //-------------------------------------------------------------------------------------[]
        public void OnGUI()
        {
            if( GUI.Button( _orcFaceRect, RaceNameEnum.Orc.ToString(), GuiSkin.button ) )
                PlayerChooseRaceEvent( RaceNameEnum.Orc );
            if( GUI.Button( _elfFaceRect, RaceNameEnum.Elf.ToString(), GuiSkin.button ) )
                PlayerChooseRaceEvent( RaceNameEnum.Elf );
        }

        //===============================================================================================[]
        #endregion
    }
}