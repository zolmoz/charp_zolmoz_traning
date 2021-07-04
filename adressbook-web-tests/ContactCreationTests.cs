﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       

        [Test]
        public void ContactCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitNewContactCreation();
            //Заполнение данных для создания контакта
            ContactData contact = new ContactData("Ivan");
            contact.Middlename = "Ivanovich";
            contact.Lastname = "Ivanov ";
            contact.Nickname = "Vanya ";
            contact.Title = " ";
            contact.Company = "OOO Ivan ";
            contact.Address = "123 Maple str ";
            contact.Home = "1234567";
            contact.Mobile = "987654";
            contact.Work = "3214589";
            contact.Fax = " 258963";
            contact.Email = "test@test.ru ";
            contact.Email2 = " ";
            contact.Email3 = " ";
            contact.Homepage = "home.com";
            contact.Bday = "10";
            contact.Bmonth = "May";
            contact.Byear = "1958";
            contact.Aday = "12";
            contact.Amonth = "May";
            contact.Ayear = "1258";
            contact.Address2 = " ";
            contact.Phone2 = " ";
            contact.Notes = "test";
            contactHelper.FullContactPage(contact);
            contactHelper.SubmitContactCreation();
            navigationHelper.ReturnToHomepage();
            loginHelper.Logout();

        }
  
    }
}
