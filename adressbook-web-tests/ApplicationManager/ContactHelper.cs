﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;


namespace adressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
       

        public ContactHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        private List<ContactData> contactCache = null;


        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                applicationManager.Navigate.OpenHomePage();
                IList<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {

                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                        {
                        Id = element.FindElement(By.TagName("Input")).GetAttribute("id")
                            });
                }
            }
            return new List<ContactData>(contactCache);
        }


        internal ContactHelper Modify(int v, ContactData updatecontact)
        {
            SelectContact();
            InitContactModification();
            ShortContactPage(updatecontact);
            ApproveEditContact();
            applicationManager.Navigate.ReturnToHomepage();
            
            return this;
        }

        

        public ContactHelper Remove(int p)
        {
            
            SelectContact();
            RemoveContact();
            ApproveRemoveContact();
            applicationManager.Navigate.OpenHomePage();
            return this;
        }



        public ContactHelper Create(ContactData contact)
        {
            
            InitNewContactCreation();
            ShortContactPage(contact);
            SubmitContactCreation();
            applicationManager.Navigate.ReturnToHomepage();
            
            return this;
        }

        public ContactHelper InitContactModification()
        {
           
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper ApproveEditContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

        public ContactHelper ApproveRemoveContact()
        {
           
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
           
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper InitNewContactCreation()
        {
            //Init new contact
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            //submit creation contact
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
            return this;
        }


        public ContactHelper FullContactPage(ContactData contactData)
        {
            //full contact page
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("middlename"), contactData.Middlename);
            Type(By.Name("lastname"), contactData.Lastname);
            Type(By.Name("nickname"), contactData.Nickname);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("homepage"), contactData.Homepage);

            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactData.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactData.Bmonth);
            Type(By.Name("byear"), contactData.Byear);

            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactData.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactData.Amonth);
            Type(By.Name("ayear"), contactData.Ayear);

            Type(By.Name("address2"), contactData.Address2);
            Type(By.Name("phone2"), contactData.Phone2);
            Type(By.Name("notes"), contactData.Notes);

            return this;
        }


        public ContactHelper ShortContactPage(ContactData contactData)
        {
            //full contact page
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("lastname"), contactData.Lastname);
            return this;
        }

    }
}
