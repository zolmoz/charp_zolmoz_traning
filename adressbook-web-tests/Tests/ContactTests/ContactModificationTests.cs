using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {

        [Test]

        public void ContactModificationTest()
        {
            ContactData updatecontact = new ContactData("1", "2");
            applicationManager.Navigate.OpenHomePage();
            if (!applicationManager.Contact.IsContactExist())
            {
                applicationManager.Contact.Create(new ContactData("Julli", "Apple"));
            }
            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();
            ContactData oldData = oldContacts[0];
            applicationManager.Contact.Modify(0, updatecontact);
            Assert.AreEqual(oldContacts.Count, applicationManager.Contact.GetContactCount());
            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts[0].Firstname = updatecontact.Firstname;
            oldContacts[0].Lastname = updatecontact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(updatecontact.Firstname, contact.Firstname);
                    Assert.AreEqual(updatecontact.Lastname, contact.Lastname);
                }
            }
        }


        [Test]
        public void ContactModificationTestDB()
        {
            ContactData newContactData = new ContactData("Julli", "Orange");
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            newContactData.Id = oldContacts[0].Id;
            applicationManager.Contact.ModifyById(newContactData);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == newContactData.Id)
                {
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
        }

    }
}


    



