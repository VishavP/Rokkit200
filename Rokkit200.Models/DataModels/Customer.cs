namespace Rokkit200.Models.DataModels
{
    public class Customer
    {
        public string customerNum { get; set; }
        public long balance { get; set; }
        public long overdraft { get; set; }    
    }

    public class SystemDb
    {
        public List<Customer> customers { get; set; }
        private SystemDb()
        {
            customers = new List<Customer>();
            customers.Add(new Customer { customerNum = "1", balance = 2000 });
            customers.Add(new Customer { customerNum = "2", balance = 5000 });
            customers.Add(new Customer { customerNum = "3", balance = 1000, overdraft = 1000 });
            customers.Add(new Customer { customerNum = "4", balance = -5000, overdraft = 20000 });
        }
    }
}
