// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using System;
using System.Collections.Generic;
using System.Linq;
using OnceInTheStoreGameClasses.Classes;
using OnceInTheStoreGameClasses.Helpers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OnceInTheStoreComponents
{
    [ AddComponentMenu( "OnceInTheStore::Components/StoreComponent" ) ]
    internal class StoreComponent : MonoBehaviour
    {
        #region Public data
        //===============================================================================================[]
        public Func<Player> GetCurrentPlayer { private get; set; }
        public Func<IEnumerable<Item>> GetCurrentSwordsForSale { private get; set; }
        public Func<IEnumerable<Item>> GetCurrentHelmetsForSale { private get; set; }
        public Func<Item, PossibilityOfBuyingEnum> BuySelectedItemIfCanAndGetResult { private get; set; }
        public Func<IEnumerable<Item>> GetCurrentPlayerBoughtItems { private get; set; }
        //-------------------------------------------------------------------------------------[]
        public GameObject Item3DBox;
        public GUISkin GuiSkin;
        //===============================================================================================[]
        #endregion




        #region Data
        //===============================================================================================[]
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 600;
        private const int ScreenBuyWidth = 500;
        private const int ScreenBuyHeight = 600;
        //-------------------------------------------------------------------------------------[]
        private const int PlayerGoldLabelWidth = 200;
        private const int PlayerGoldLabelHeight = 30;
        private const int ItemsTypeLabelWidth = 200;
        private const int ItemsTypeLabelHeight = 30;
        private const int SwordsGridWidth = 200;
        private const int SwordsGridHeight = 100;
        private const int HelmetsGridWidth = 300;
        private const int HelmetsGridHeight = 100;
        private const int BuyButtonWidth = 150;
        private const int BuyButtonHeight = 40;
        //-------------------------------------------------------------------------------------[]
        private const int PlayerItemsGridWidth = 250;
        private const int PlayerItemsGridHeight = 83;
        //-------------------------------------------------------------------------------------[]
        private Rect _screenRect;
        private Rect _screenBuyRect;
        private Rect _screenBuyPlayerGoldLabelRect;
        private Rect _screenBuySwordsLabelRect;
        private Rect _screenBuySwordsGridRect;
        private Rect _screenBuyHelmetLabelRect;
        private Rect _screenBuyHelmetGridRect;
        private Rect _screenBuyButtonRect;
        //-------------------------------------------------------------------------------------[]
        private int _swordSelectedIndex = -1;
        private int _helmetSelectedIndex = -1;
        private int _prevSwordSelectedIndex = -1;
        private int _prevHelmetSelectedIndex = -1;
        //-------------------------------------------------------------------------------------[]
        private Rect _screenViewRect;
        private Rect _screenViewObjectBoxRect;
        private Rect _screenViewInventoryBoxRect;
        private Rect _screenViewInventoryPlayerItemsRect;
        //-------------------------------------------------------------------------------------[]
        private Player CurrentPlayer { get { return GetCurrentPlayer(); } }
        private IEnumerable<Item> CurrentSwordsForSale { get { return GetCurrentSwordsForSale(); } }
        private IEnumerable<Item> CurrentHelmetsForSale { get { return GetCurrentHelmetsForSale(); } }
        private IEnumerable<Item> CurrentPlayerBoughtItems { get { return GetCurrentPlayerBoughtItems(); } }
        //-------------------------------------------------------------------------------------[]
        private Object _item3DBoxGameObject;
        //===============================================================================================[]
        #endregion




        #region MonoBehaviour
        //===============================================================================================[]
        public void Start()
        {
            DoStart();
        }

        //-------------------------------------------------------------------------------------[]
        public void OnGUI()
        {
            DoOnGui();
        }

        //===============================================================================================[]
        #endregion




        #region Routines
        //===============================================================================================[]
        private void DoStart()
        {
            CreateMainRect();
            CreateAllBuyRects();
            CreateAllViewRects();
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateMainRect()
        {
            _screenRect = UnityHelper.GetRect(
                ( Screen.width - ScreenWidth )/2f, ( Screen.height - ScreenHeight )/2f, ScreenWidth, ScreenHeight );
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateAllBuyRects()
        {
            CreateMainAndTopBuyRects();
            CreateBuySwordsRects();
            CreateBuyHelmetsRects();
            CreateBuyButtonRect();
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateMainAndTopBuyRects()
        {
            _screenBuyRect = UnityHelper.GetRect( _screenRect.x, _screenRect.y, ScreenBuyWidth, ScreenBuyHeight );

            _screenBuyPlayerGoldLabelRect =
                UnityHelper.GetRect(
                    _screenBuyRect.x + _screenBuyRect.width/2 - PlayerGoldLabelWidth/2,
                    _screenBuyRect.y,
                    PlayerGoldLabelWidth,
                    PlayerGoldLabelHeight );
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateBuySwordsRects()
        {
            _screenBuySwordsLabelRect = UnityHelper.GetRect(
                _screenBuyRect.x,
                _screenBuyPlayerGoldLabelRect.y + _screenBuyPlayerGoldLabelRect.height,
                ItemsTypeLabelWidth,
                ItemsTypeLabelHeight );

            _screenBuySwordsGridRect = UnityHelper.GetRect(
                _screenBuyRect.x,
                _screenBuySwordsLabelRect.y + _screenBuySwordsLabelRect.height,
                SwordsGridWidth,
                SwordsGridHeight );
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateBuyHelmetsRects()
        {
            _screenBuyHelmetLabelRect = UnityHelper.GetRect(
                _screenBuyRect.x,
                _screenBuySwordsGridRect.y + _screenBuySwordsGridRect.height + 10,
                ItemsTypeLabelWidth,
                ItemsTypeLabelHeight );

            _screenBuyHelmetGridRect = UnityHelper.GetRect(
                _screenBuyRect.x,
                _screenBuyHelmetLabelRect.y + _screenBuyHelmetLabelRect.height,
                HelmetsGridWidth,
                HelmetsGridHeight );
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateBuyButtonRect()
        {
            _screenBuyButtonRect = UnityHelper.GetRect(
                _screenBuyRect.x + _screenBuyRect.width - BuyButtonWidth,
                _screenBuyRect.y + _screenBuyRect.height - BuyButtonHeight,
                BuyButtonWidth,
                BuyButtonHeight );
        }

        //-------------------------------------------------------------------------------------[]
        private void CreateAllViewRects()
        {
            _screenViewRect = UnityHelper.GetRect(
                _screenBuyRect.x + _screenBuyRect.width,
                _screenRect.y,
                _screenRect.width - _screenBuyRect.width,
                _screenRect.height );

            _screenViewObjectBoxRect = UnityHelper.GetRect(
                _screenViewRect.x + 10,
                _screenViewRect.y + 10,
                _screenViewRect.width - 10*2,
                _screenViewRect.height/2 - _screenViewRect.height/100 );

            _screenViewInventoryBoxRect = UnityHelper.GetRect(
                _screenViewRect.x + 10,
                _screenViewObjectBoxRect.y + _screenViewObjectBoxRect.height + 10,
                _screenViewRect.width - 10*2,
                _screenViewRect.height/2 - 10 );
        }

        //-------------------------------------------------------------------------------------[]
        private void DoOnGui()
        {
            DrawAllBuyGuiItems();
            DrawAllViewGuiItems();
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawAllBuyGuiItems()
        {
            DrawPlayerGoldInfo();
            DrawSwordsInfo();
            DrawHelmetInfo();
            DrawBuyButton();
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawPlayerGoldInfo()
        {
            GUI.Label( _screenBuyPlayerGoldLabelRect, "GOLD: " + CurrentPlayer.Gold );
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawSwordsInfo()
        {
            GUI.Label( _screenBuySwordsLabelRect, "Swords" );
            _swordSelectedIndex = GUI.SelectionGrid(
                _screenBuySwordsGridRect,
                _swordSelectedIndex,
                CurrentSwordsForSale.Select( t => t.ItemName ).ToArray(),
                2,
                GuiSkin.button );
            if( _prevSwordSelectedIndex != _swordSelectedIndex ) {
                _helmetSelectedIndex = -1;
                _prevHelmetSelectedIndex = -1;
                DestroyOldAndCreateCreateSelectedItemGameObject();
            }
            _prevSwordSelectedIndex = _swordSelectedIndex;
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawHelmetInfo()
        {
            GUI.Label( _screenBuyHelmetLabelRect, "Helmets" );
            _helmetSelectedIndex = GUI.SelectionGrid(
                _screenBuyHelmetGridRect,
                _helmetSelectedIndex,
                CurrentHelmetsForSale.Select( t => t.ItemName ).ToArray(),
                3,
                GuiSkin.button );
            if( _prevHelmetSelectedIndex != _helmetSelectedIndex ) {
                _swordSelectedIndex = -1;
                _prevSwordSelectedIndex = -1;
                DestroyOldAndCreateCreateSelectedItemGameObject();
            }
            _prevHelmetSelectedIndex = _helmetSelectedIndex;
        }

        //-------------------------------------------------------------------------------------[]
        private void DestroyOldAndCreateCreateSelectedItemGameObject()
        {
            if( _item3DBoxGameObject != null )
                Destroy( _item3DBoxGameObject );
            var selectedItem = GetSelectedItem();
            if( selectedItem != null ) {
                _item3DBoxGameObject = Instantiate( Item3DBox );
                _item3DBoxGameObject.name = selectedItem.ItemName;
            }
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawBuyButton()
        {
            if( GUI.Button( _screenBuyButtonRect, "Buy", GuiSkin.button ) )
                BuyCurrentItem();
        }

        //-------------------------------------------------------------------------------------[]
        private void DrawAllViewGuiItems()
        {
            var playerItemsGridHeightcoef = CurrentPlayerBoughtItems.Count() < 4
                                                ? 1
                                                : CurrentPlayerBoughtItems.Count() > 3 &&
                                                  CurrentPlayerBoughtItems.Count() < 7
                                                      ? 2
                                                      : 3;
            _screenViewInventoryPlayerItemsRect =
                UnityHelper.GetRect(
                    _screenViewInventoryBoxRect.x + _screenViewInventoryBoxRect.width/2 - PlayerItemsGridWidth/2,
                    _screenViewInventoryBoxRect.y + 28,
                    PlayerItemsGridWidth,
                    PlayerItemsGridHeight*playerItemsGridHeightcoef );

            GUI.Box( _screenViewObjectBoxRect, "View object", GuiSkin.box );
            GUI.Box( _screenViewInventoryBoxRect, "View inventory", GuiSkin.box );
            GUI.SelectionGrid(
                _screenViewInventoryPlayerItemsRect,
                -1,
                CurrentPlayerBoughtItems.Select( t => t.ItemName ).ToArray(),
                3,
                GuiSkin.button );
        }

        //-------------------------------------------------------------------------------------[]
        private Item GetSelectedItem()
        {
            if( _swordSelectedIndex != -1 )
                return CurrentSwordsForSale.ElementAt( _swordSelectedIndex );
            if( _helmetSelectedIndex != -1 )
                return CurrentHelmetsForSale.ElementAt( _helmetSelectedIndex );
            return null;
        }

        //-------------------------------------------------------------------------------------[]
        private void BuyCurrentItem()
        {
            var buyingResult = PossibilityOfBuyingEnum.NoResult;
            var selectedItem = GetSelectedItem();
            if( selectedItem != null )
                buyingResult = BuySelectedItemIfCanAndGetResult( selectedItem );
            else
                Debug.Log( "No item is selected to buy" );
            if( buyingResult == PossibilityOfBuyingEnum.NoMoney )
                Debug.Log( "Player doesn't have money to buy selected item" );
            if( buyingResult == PossibilityOfBuyingEnum.NoFreeSlots )
                Debug.Log( "Player doesn't have free slot to buy selected item" );
        }

        //===============================================================================================[]
        #endregion
    }
}