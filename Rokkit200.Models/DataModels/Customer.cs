namespace Rokkit200.Models.DataModels
{
    public class Customer
    {
        public string customerNum { get; set; }
        public ulong balance { get; set; }
        public ulong overdraft { get; set; }    
    }

    public class SystemDb
    {

        public List<Customer> customers { get; set; }
        private SystemDb()
        {
            customers = new List<Customer>();
        }

        public void InitCustomers()
        {
            var rng = new Random();
            ulong randomNumber = NextULong(rng,1000000000000000,9999999999999999999);
            customers.Add(new Customer(){
                customerNum = Guid.NewGuid().ToString(), 
                balance= randomNumber, 
                overdraft=randomNumber});
        }

        public ulong NextULong(Random self, ulong min, ulong max)
        {
            var buf = new byte[sizeof(ulong)];
            self.NextBytes(buf);
            ulong n = BitConverter.ToUInt64(buf, 0);
            double normalised = n / (ulong.MaxValue + 1.0);
            double range = (double)max - min;
            return (ulong)(normalised * range) + min;
        }
    }
}
