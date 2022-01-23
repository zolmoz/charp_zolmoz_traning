using System;
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



        public ContactHelper ViewContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
            return this;
        }

        public string GetContactInformationFromPersonView(int index)
        {
            applicationManager.Navigate.OpenHomePage();
            ViewContactDetails(index);
            string content = driver.FindElement(By.Id("content")).Text;
            return content;
        }

        public string PersonViewForContact(ContactData contact)
        {
            string contactDetaiedView = EmptyValueCheck(contact.Firstname).Replace("\r\n", "") + " " +
              EmptyValueCheck(contact.Lastname).Replace("\r\n", "") + "\r\n" +
              EmptyValueCheck(contact.Address) + "\r\n" +
              EmptyPhoneValueCheck("H", contact.Home) +
              EmptyPhoneValueCheck("M", contact.Mobile) +
              EmptyPhoneValueCheck("W", contact.Work) + "\r\n" +
              EmptyValueCheck(contact.Email) +
              EmptyValueCheck(contact.Email2) +
              EmptyValueCheck(contact.Email3);


            return contactDetaiedView.Trim();
        }

        private static string EmptyValueCheck(string value)
        {
            if (value == "" || value == null)
                return "";

            return value.Trim() + "\r\n";
        }

        private static string EmptyPhoneValueCheck(string prefix, string phone)
        {
            if (phone == "" || phone == null)
                return "";

            return prefix + ": " + phone.Trim() + "\r\n";
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            applicationManager.Navigate.OpenHomePage();
            
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allMails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = Regex.Replace(allPhones, "[ \r\n]", ""),
                AllMails = Regex.Replace(allMails, "[ \r\n]", "")
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            applicationManager.Navigate.OpenHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email1,
                Email2 = email2,
                Email3 = email3
            };

            
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
            InitContactModification(0);
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

        public void InitContactModification(int index)
        {

            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
           
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
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            return this;
        }

    }
}
