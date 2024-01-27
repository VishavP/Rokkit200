using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rokkit200.Services.Interfaces
{
    public interface IAccountService
    {
        public void openSavingsAccount(Int64 accountId, Int64 amountToDeposit);
        public void openCurrentAccount(Int64 accountId);
        public void withdraw(Int64 accountId, int amountToWithdraw);
        //throws AccountNotFoundException, WithdrawalAmountTooLargeException;
        public void deposit(Int64 accountId, int amountToDeposit);
        //throws AccountNotFoundException;
    }

}
