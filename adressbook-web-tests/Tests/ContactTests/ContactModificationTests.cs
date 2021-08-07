﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {

            ContactData updatecontact = new ContactData("1","2");
           

            applicationManager.Navigate.OpenHomePage();
            if (!applicationManager.Contact.IsContactExist())
            {
                applicationManager.Contact.Create(new ContactData ("Julli",  "Apple"));
            }

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Modify(0,updatecontact);

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts[0].Firstname = updatecontact.Firstname;
            oldContacts[0].Lastname = updatecontact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}