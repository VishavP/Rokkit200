using Rokkit200.Models.DataModels;

namespace Rokkit200.Models.Models
{
    public class SystemDb
    {
        public List<Customer> customers { get; set; }
        private SystemDb()
        {
            customers = new List<Customer>();
            var accounts = new List<Account>();
            accounts.Add(new Account() { AccountId = 1, Balance = 2000 });
            accounts.Add(new Account() { AccountId = 2, Balance = 5000 });
            accounts.Add(new Account() { AccountId = 3, Balance = 1000, Overdraft = 10000 });
            accounts.Add(new Account() { AccountId = 4, Balance = -5000, Overdraft = 20000 });
        }
    }
}
