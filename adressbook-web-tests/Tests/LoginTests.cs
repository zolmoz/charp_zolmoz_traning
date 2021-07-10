using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace adressbook_web_tests 
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredential()
        {
           
            //подготовка
            applicationManager.Auth.Logout();
            // действие
            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);
            // проверка
            Assert.IsTrue(applicationManager.Auth.IsLoggeInAccount(account));
        }

        [Test]
        public void LoginWithUnValidCredential()
        {

            //подготовка
            applicationManager.Auth.Logout();
            // действие
            AccountData account = new AccountData("admin", "12345");
            applicationManager.Auth.Login(account);
            // проверка
            Assert.IsFalse(applicationManager.Auth.IsLoggeInAccount(account));
        }

    }
}
