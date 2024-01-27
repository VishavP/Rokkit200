using Rokkit200.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokkit200.Services.Implementation
{
    public class AccountService : IAccountService
    {
        public void deposit(long accountId, int amountToDeposit)
        {
            throw new NotImplementedException();
        }

        public void openCurrentAccount(long accountId)
        {
            throw new NotImplementedException();
        }

        public void openSavingsAccount(long accountId, long amountToDeposit)
        {
            throw new NotImplementedException();
        }

        public void withdraw(long accountId, int amountToWithdraw)
        {
            throw new NotImplementedException();
        }
    }
}
