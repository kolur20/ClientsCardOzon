using System.Collections.Generic;

namespace iikoCardClients.Data
{
    public class ShortCustomerInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Card { get; set; }
        public IEnumerable<string> Category { get; set; }
        public Wallet Wallet { get; set; }
    }
}