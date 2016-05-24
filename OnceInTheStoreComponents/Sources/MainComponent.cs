// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using System.Collections.Generic;
using OnceInTheStoreGameClasses.Classes;
using OnceInTheStoreGameClasses.Helpers;
using UnityEngine;

// Resharper disable UnusedMember.Global

namespace OnceInTheStoreComponents
{
    [ AddComponentMenu( "OnceInTheStore::Components/MainComponent" ) ]
    internal class MainComponent : MonoBehaviour
    {
        #region Data
        //===============================================================================================[]
        private ChooseRaceComponent _chooseRaceComponent;
        private StoreComponent _storeComponent;
        private GameSettingsComponent _gameSettingsComponent;
        private Player _player;
        private Shopman _shopman;
        private PurchaseHelper _purchaseHelper;
        //===============================================================================================[]
        #endregion




        #region MonoBehaviour
        //===============================================================================================[]
        public void Awake()
        {
            FindComponents();
            DisableScreenComponents();
            StartGameAndOpenFirstScreen();
        }

        //===============================================================================================[]
        #endregion




        #region Routines
        //===============================================================================================[]
        private void FindComponents()
        {
            _chooseRaceComponent = UnityHelper.FindComponent<ChooseRaceComponent>();
            _chooseRaceComponent.PlayerChooseRaceEvent += CreatePlayerAndShopmanAndOpenSecondScreen;

            _storeComponent = UnityHelper.FindComponent<StoreComponent>();
            _storeComponent.GetCurrentPlayer = GetCurrentPlayer;
            _storeComponent.GetCurrentSwordsForSale = GetCurrentSwordsForSale;
            _storeComponent.GetCurrentHelmetsForSale = GetCurrentHelmetsForSale;
            _storeComponent.BuySelectedItemIfCanAndGetResult = BuySelectedItemIfCanAndGetResult;
            _storeComponent.GetCurrentPlayerBoughtItems = GetCurrentPlayerBoughtItems;

            _gameSettingsComponent = UnityHelper.FindComponent<GameSettingsComponent>();
        }

        //-------------------------------------------------------------------------------------[]
        private void DisableScreenComponents()
        {
            _chooseRaceComponent.enabled = false;
            _storeComponent.enabled = false;
        }

        //-------------------------------------------------------------------------------------[]
        private void StartGameAndOpenFirstScreen()
        {
            _chooseRaceComponent.enabled = true;
        }

        //-------------------------------------------------------------------------------------[]
        private void CreatePlayerAndShopmanAndOpenSecondScreen( RaceNameEnum raceName )
        {
            _chooseRaceComponent.enabled = false;

            _player = new Player(
                raceName,
                _gameSettingsComponent.PlayerGold,
                _gameSettingsComponent.PlayerLevel,
                _gameSettingsComponent.PlayerHasVipAccount );

            _shopman = new Shopman( GetCurrentItems() );

            _purchaseHelper = new PurchaseHelper();

            _storeComponent.enabled = true;
        }

        //-------------------------------------------------------------------------------------[]
        private Player GetCurrentPlayer()
        {
            return _player;
        }

        //-------------------------------------------------------------------------------------[]
        private IEnumerable<Item> GetCurrentItems()
        {
            var itemsList = new List<Item>();

            var redSword = new Item(
                ItemTypeEnum.Sword, _gameSettingsComponent.RedSwordLevel, _gameSettingsComponent.RedSwordPrice, "Red" );
            var greenSword = new Item(
                ItemTypeEnum.Sword,
                _gameSettingsComponent.GreenSwordLevel,
                _gameSettingsComponent.GreenSwordPrice,
                "Green" );

            itemsList.Add( redSword );
            itemsList.Add( greenSword );

            var whiteHelmet = new Item(
                ItemTypeEnum.Helmet,
                _gameSettingsComponent.WhiteHelmetLevel,
                _gameSettingsComponent.WhiteHelmetPrice,
                "White" );
            var blueHelmet = new Item(
                ItemTypeEnum.Helmet,
                _gameSettingsComponent.BlueHelmetLevel,
                _gameSettingsComponent.BlueHelmetPrice,
                "Blue" );
            var redHelmet = new Item(
                ItemTypeEnum.Helmet, _gameSettingsComponent.RedHelmetLevel, _gameSettingsComponent.RedHelmetPrice, "Red" );

            itemsList.Add( whiteHelmet );
            itemsList.Add( blueHelmet );
            itemsList.Add( redHelmet );

            return itemsList;
        }

        //-------------------------------------------------------------------------------------[]
        private IEnumerable<Item> GetCurrentSwordsForSale()
        {
            return _shopman.SwordsForSale;
        }

        //-------------------------------------------------------------------------------------[]
        private IEnumerable<Item> GetCurrentHelmetsForSale()
        {
            return _shopman.HelmetsForSale;
        }

        //-------------------------------------------------------------------------------------[]
        private PossibilityOfBuyingEnum BuySelectedItemIfCanAndGetResult( Item item )
        {
            return _purchaseHelper.MakePurchaseIfCanAndGetResult( _player, _shopman, item );
        }

        //-------------------------------------------------------------------------------------[]
        private IEnumerable<Item> GetCurrentPlayerBoughtItems()
        {
            return _player.BoughtItems;
        }

        //===============================================================================================[]
        #endregion
    }
}