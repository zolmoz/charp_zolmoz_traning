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
    public class NavigationHelper : HelperBase
    {
       
        private string baseURL;

        public NavigationHelper(ApplicationManager applicationManager, string baseURL) : base(applicationManager)
        {
           
            this.baseURL = baseURL;

        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL )
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomepage()
        {
            if (driver.Url == baseURL + "/edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
