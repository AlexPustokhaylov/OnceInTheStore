// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using System.Collections.Generic;
using OnceInTheStoreGameClasses.Helpers;

namespace OnceInTheStoreGameClasses.Classes
{
    public class Player
    {
        #region Data
        //===============================================================================================[]
        private readonly RaceNameEnum _playerRaceName;
        private int _gold;
        private readonly int _level;
        private readonly bool _hasVipAccount;
        private readonly List<Item> _boughtItems = new List<Item>();
        //===============================================================================================[]
        #endregion




        #region Public data
        //===============================================================================================[]
        public RaceNameEnum PlayerRaceName { get { return _playerRaceName; } }
        public int Gold { get { return _gold; } }
        public int Level { get { return _level; } }
        public bool HasVipAccount { get { return _hasVipAccount; } }
        public List<Item> BoughtItems { get { return _boughtItems; } }
        //===============================================================================================[]
        #endregion




        #region Constructor
        //===============================================================================================[]
        public Player(
            RaceNameEnum raceName,
            int gold,
            int level,
            bool hasVipAccount )
        {
            _playerRaceName = raceName;
            _gold = gold;
            _level = level;
            _hasVipAccount = hasVipAccount;
        }

        //===============================================================================================[]
        #endregion




        #region Methods 
        //===============================================================================================[]
        public PossibilityOfBuyingEnum CanBuyItem( int goldPrice )
        {
            if( _playerRaceName == RaceNameEnum.Elf &&
                _boughtItems.Count >= 3 )
                return PossibilityOfBuyingEnum.NoFreeSlots;
            if( _gold < goldPrice )
                return PossibilityOfBuyingEnum.NoMoney;
            return PossibilityOfBuyingEnum.Ok;
        }

        //-------------------------------------------------------------------------------------[]
        public void BuyItem(
            Item item,
            int goldPrice )
        {
            if( CanBuyItem( goldPrice ) ==
                PossibilityOfBuyingEnum.Ok ) {
                _gold -= goldPrice;
                _boughtItems.Add( item );
            }
        }

        //===============================================================================================[]
        #endregion
    }
}