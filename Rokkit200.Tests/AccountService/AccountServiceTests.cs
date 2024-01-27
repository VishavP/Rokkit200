using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Rokkit200.Models.DataModels;
using Rokkit200.Models.Models;
using Rokkit200.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokkit200.Tests.AccountServiceTest
{
    [TestFixture]
    public class AccountServiceTests
    {
        private ILogger<AccountService> logger;
        private AccountService accountService;
        private SystemDb  systemDb;
        [SetUp]
        public void OnSetup()
        {
            accountService = new AccountService(logger);
            systemDb.customers.Add(new Customer({ CustomerNumber = "999", Account = new Account() { AccountType=AccountType.SavingsAccount, Balance=1000L, Overdraft=0, AccountId=1} 
            });
        }

        [Test]
        public void when_withdrawing_from_savingsAcc()
        {
            Customer? savingsAcc = systemDb.customers.First(x=>x.CustomerNumber=="999");
            accountService.withdraw(1,500);
            Assert.That(savingsAcc.Account.Balance == 500);

        }
    }
}
