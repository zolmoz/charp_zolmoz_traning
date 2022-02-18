﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public LoginHelper Login { get; set; }
        public NavigationHelper Navigator { get; set; }
        public ProjectHelper Project { get; set; }
        public APIHelper API { get; set; }


        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Login = new LoginHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
            Project = new ProjectHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php/";
                app.Value = newInstance;
            }

            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get
            {
                return Login;
            }
        }
    }
}