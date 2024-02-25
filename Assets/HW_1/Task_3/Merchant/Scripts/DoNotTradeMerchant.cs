namespace HW_1.Task3
{
    public class DoNotTradeMerchant : Merchant
    {
        protected override void TradeWithPlayer(PlayerController player)
        {
            print("I won't trade with you!!");
        }
    }
}