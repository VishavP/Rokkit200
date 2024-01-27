using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Rokkit200.Models.DataModels;
using Rokkit200.Models.Models;
using Rokkit200.Services.Implementation;

namespace Rokkit200.Tests.AccountServiceTest
{
    [TestFixture]
    public class AccountServiceTests
    {
        private ILogger<AccountService> logger;
        private AccountService accountService;
        private SystemDb systemDb;
        
        [SetUp]
        public void OnSetup()
        {
            accountService = new AccountService(logger);
            systemDb.customers.Add(new Customer
            {
                CustomerNumber = "999",
                Account = new Account
                {
                    AccountType = AccountType.SavingsAccount,
                    Balance = 1000L,
                    Overdraft = 0,
                    AccountId = 1
                }
            });

            systemDb.customers.Add(new Customer
            {
                CustomerNumber = "777",
                Account = new Account
                {
                    AccountType = AccountType.CurrentAccount,
                    Balance = 1000L,
                    Overdraft = 0,
                    AccountId = 1
                }
            });
        }

        [Test]
        public void when_withdrawing_less_than_balance_from_savingsAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x=>x.CustomerNumber=="999");
            accountService.withdraw(1,500);
            Assert.That(savingsAcc.Account.Balance == 500L);
        }

        [Test]
        public void when_withdrawing_more_than_balance_from_savingsAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x => x.CustomerNumber == "999");
            accountService.withdraw(1, 2000);
            Assert.That(savingsAcc.Account.Balance == -1000L);
        }

        [Test]
        public void when_withdrawing_less_than_balance_from_currentAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x => x.CustomerNumber == "777");
            accountService.withdraw(1, 500);
            Assert.That(savingsAcc.Account.Balance == 500L);
        }

        [Test]
        public void when_withdrawing_more_than_balance_from_currentAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x => x.CustomerNumber == "777");
            accountService.withdraw(1, 2000);
            Assert.That(savingsAcc.Account.Balance == -1000L);
        }

        [Test]
        public void when_depositing_less_than_balance_from_currentAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x => x.CustomerNumber == "777");
            accountService.deposit(1, 500);
            Assert.That(savingsAcc.Account.Balance == 1500L);
        }

        [Test]
        public void when_depositing_more_than_balance_from_currentAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x => x.CustomerNumber == "777");
            accountService.deposit(1, 2000);
            Assert.That(savingsAcc.Account.Balance == 3000L);
        }
    }
}
