using Rokkit200.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Rokkit200.Services.CustomExceptions;
using Rokkit200.Models.DataModels;

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
                if(Syste)
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

            }
            catch (AccountNotFoundException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}