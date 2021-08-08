using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace adressbook_web_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager applicationManager) : base(applicationManager)
        {


        }
        public void Login(AccountData account)
        {
            if (IsLoggeIn())
            {
                if (IsLoggeInAccount(account))
                {
                    return;
                }
                Logout();
            }
            applicationManager.Navigate.OpenHomePage();
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }




        public void Logout()
        {
            if (IsLoggeIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                applicationManager.Navigate.OpenHomePage();

            }

        }

        public bool IsLoggeIn()
        {
            return IsElementPresent(By.Name("logout"));

        }
        public bool IsLoggeInAccount(AccountData account)
        {
            return IsLoggeIn()
                && GetLogetUserName() == account.Username;

        }

        public string GetLogetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);

        }
    }
}
