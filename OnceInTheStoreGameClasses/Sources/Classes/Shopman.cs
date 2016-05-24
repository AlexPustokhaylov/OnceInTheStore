// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using System;
using System.Collections.Generic;
using System.Linq;
using OnceInTheStoreGameClasses.Helpers;

namespace OnceInTheStoreGameClasses.Classes
{
    public class Shopman
    {
        #region Data
        //===============================================================================================[]
        private readonly List<Item> _itemsForSale = new List<Item>();
        //===============================================================================================[]
        #endregion




        #region Public data
        //===============================================================================================[]
        public List<Item> ItemsForSale { get { return _itemsForSale; } }
        public List<Item> SwordsForSale { get { return _itemsForSale.Where( t => t.ItemType == ItemTypeEnum.Sword ).ToList(); } }
        public List<Item> HelmetsForSale { get { return _itemsForSale.Where( t => t.ItemType == ItemTypeEnum.Helmet ).ToList(); } }
        //===============================================================================================[]
        #endregion




        #region Constructor
        //===============================================================================================[]
        public Shopman( IEnumerable<Item> itemsForSale )
        {
            foreach( var item in itemsForSale ) {
                _itemsForSale.Add( item );
            }
        }

        //===============================================================================================[]
        #endregion




        #region Methods
        //===============================================================================================[]
        public int GetItemPrice(
            RaceNameEnum playerRace,
            int playerLevel,
            bool playerHasVipAccount,
            Item item )
        {
            var priceCoef = 1.0;
            if( playerRace == RaceNameEnum.Orc &&
                item.ItemType == ItemTypeEnum.Sword )
                priceCoef += 0.15;
            if( item.ItemLevel > playerLevel )
                priceCoef += 0.05;
            if( playerHasVipAccount )
                priceCoef -= 0.1;
            return ( int ) Math.Round( item.ItemPrice*priceCoef );
        }

        //===============================================================================================[]
        #endregion
    }
}