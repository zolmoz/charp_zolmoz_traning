using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace adressbook_web_tests
{
    public class TestBase
    {

         protected ApplicationManager applicationManager;


        [SetUp]
        protected void SetupTest()
        {
              
            applicationManager = new ApplicationManager();
            applicationManager.Navigate.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            applicationManager.Stop();
        }




        

        

    

       

        




    }
}
