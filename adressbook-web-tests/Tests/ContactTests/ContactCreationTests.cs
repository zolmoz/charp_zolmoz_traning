﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
       

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("Ivan", "Ivanov");
          
            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }


        [Test]
        public void EmptyContactCreationTest()
        {
                      
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
