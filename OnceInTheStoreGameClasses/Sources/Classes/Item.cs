// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using OnceInTheStoreGameClasses.Helpers;

namespace OnceInTheStoreGameClasses.Classes
{
    public class Item
    {
        #region Data
        //===============================================================================================[]
        private readonly ItemTypeEnum _itemType;
        private readonly int _itemLevel;
        private readonly int _itemPrice;
        private readonly string _itemName;
        //===============================================================================================[]
        #endregion




        #region Data
        //===============================================================================================[]
        public ItemTypeEnum ItemType { get { return _itemType; } }
        public int ItemLevel { get { return _itemLevel; } }
        public int ItemPrice { get { return _itemPrice; } }
        public string ItemName { get { return _itemName; } }
        //===============================================================================================[]
        #endregion




        #region Constructor
        //===============================================================================================[]
        public Item(
            ItemTypeEnum itemType,
            int itemLevel,
            int itemPrice,
            string itemName )
        {
            _itemType = itemType;
            _itemLevel = itemLevel;
            _itemPrice = itemPrice;
            _itemName = itemName;
        }

        //===============================================================================================[]
        #endregion
    }
}