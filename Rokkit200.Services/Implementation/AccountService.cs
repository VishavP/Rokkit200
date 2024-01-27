using Rokkit200.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Rokkit200.Services.CustomExceptions;
using Rokkit200.Models.DataModels;
using Rokkit200.Models.Models;

namespace Rokkit200.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> _logger;
        private static SystemDb systemDb;

        public AccountService(ILogger<AccountService> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void openCurrentAccount(long accountId)
        {
            throw new NotImplementedException();
        }

        public void openSavingsAccount(long accountId, long amountToDeposit)
        {
            throw new NotImplementedException();
        }

        public void deposit(long accountId, int amountToDeposit)
        {
            try
            {
                Customer? account = systemDb.customers.FirstOrDefault(x => x.Account.AccountId == accountId);
                if (account == null) throw new AccountNotFoundException();
                if (account.Account.AccountType == AccountType.SavingsAccount)
                {
                    if(amountToDeposit >= 1000)
                    {
                        account.Account.Balance += amountToDeposit;
                    }
                }
                else if (account.Account.AccountType == AccountType.CurrentAccount)
                {
                    account.Account.Balance += amountToDeposit;
                }
            }
            catch (AccountNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void withdraw(long accountId, int amountToWithdraw)
        {
            try
            {
                Customer? account = systemDb.customers.FirstOrDefault(x => x.Account.AccountId == accountId);
                if (account == null)
                {
                    throw new AccountNotFoundException() { Message = "Account Not Found." };
                }
                if(account.Account.AccountType == AccountType.SavingsAccount)
                {
                    if(account.Account.Balance - amountToWithdraw > 1000 )
                    {
                        account.Account.Balance -= amountToWithdraw;
                    }
                    else
                    {
                        throw new Exception("Insufficient funds. Account must have minimum of R1000.");
                    }
                }
                else if(account.Account.AccountType == AccountType.CurrentAccount)
                {
                    if(account.Account.Balance - account.Account.Overdraft - amountToWithdraw < 100000)
                    {
                        if(amountToWithdraw <= (account.Account.Balance + account.Account.Overdraft))
                        {
                            account.Account.Balance -= amountToWithdraw;
                        }
                        else 
                        {
                            throw new Exception("Insufficient funds.");
                        }
                    }
                }
            }
            catch (AccountNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}