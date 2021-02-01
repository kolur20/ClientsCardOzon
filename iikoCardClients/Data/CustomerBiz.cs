namespace iikoCardClients.Data.Biz
{
    class Customer
    {

        public bool anonymized { get; set; }
        public object birthday { get; set; }
        public Card[] cards { get; set; }
        public Category[] categories { get; set; }
        public string comment { get; set; }
        public int consentStatus { get; set; }
        public string cultureName { get; set; }
        public object email { get; set; }
        public string id { get; set; }
        public int iikoCardOrdersSum { get; set; }
        public bool isBlocked { get; set; }
        public bool isDeleted { get; set; }
        public object middleName { get; set; }
        public string name { get; set; }
        public object personalDataConsentFrom { get; set; }
        public object personalDataConsentTo { get; set; }
        public object personalDataProcessingFrom { get; set; }
        public object personalDataProcessingTo { get; set; }
        public object phone { get; set; }
        public object rank { get; set; }
        public object referrerId { get; set; }
        public int sex { get; set; }
        public bool shouldReceiveLoyaltyInfo { get; set; }
        public bool shouldReceiveOrderStatusInfo { get; set; }
        public bool shouldReceivePromoActionsInfo { get; set; }
        public object surname { get; set; }
        public string userData { get; set; }
        public Walletbalance[] walletBalances { get; set; }
}

public class Card
{
    public string Id { get; set; }
    public bool IsActivated { get; set; }
    public object NetworkId { get; set; }
    public string Number { get; set; }
    public string OrganizationId { get; set; }
    public object OrganizationName { get; set; }
    public string Track { get; set; }
    public object ValidToDate { get; set; }
}

public class Category
{
    public string id { get; set; }
    public bool isActive { get; set; }
    public bool isDefaultForNewGuests { get; set; }
    public string name { get; set; }
}

public class Walletbalance
{
    public float balance { get; set; }
    public Wallet wallet { get; set; }
}

public class Wallet
{
    public string id { get; set; }
    public string name { get; set; }
    public string programType { get; set; }
    public string type { get; set; }
}

}
