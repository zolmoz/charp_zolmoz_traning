using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {

        private AccountData currAccount;
        public AccountData CurrAccount
        {
            get
            {
                return currAccount;
            }
        }

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
            currAccount = new AccountData();
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }

            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
           
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.Name("password")).Count() > 0);

            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            currAccount = account;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
                currAccount = new AccountData();
            }
        }
    }
}