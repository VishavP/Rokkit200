using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokkit200.Models.DataModels
{
    public class Account
    {
        public string CustomerNum { get; set; }
        public long AccountId { get; set; }
        public long Balance { get; set; }
        public long Overdraft { get; set; }
        public AccountType AccountType { get; set; }

    }
}
