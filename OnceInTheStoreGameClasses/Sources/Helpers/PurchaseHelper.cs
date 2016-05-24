// Aleksey 061WR Pustohaylov [stilluswr@gmail.com]
using OnceInTheStoreGameClasses.Classes;

namespace OnceInTheStoreGameClasses.Helpers
{
    public class PurchaseHelper
    {
        public PossibilityOfBuyingEnum MakePurchaseIfCanAndGetResult(
            Player player,
            Shopman shopman,
            Item item )
        {
            var itemPriceFromShopman = shopman.GetItemPrice(
                player.PlayerRaceName, player.Level, player.HasVipAccount, item );
            var canPlayerBuyItemResult = player.CanBuyItem( itemPriceFromShopman );
            if( canPlayerBuyItemResult == PossibilityOfBuyingEnum.Ok )
                player.BuyItem( item, itemPriceFromShopman );
            return canPlayerBuyItemResult;
            //Тут еще по идее надо добавить золото продавцу, но по заданию это не нужно
        }
    }
}