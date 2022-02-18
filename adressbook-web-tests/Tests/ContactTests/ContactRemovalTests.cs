using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Navigate.OpenHomePage();

            applicationManager.Contact.CreateContactIfNotExist();

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            applicationManager.Contact.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contact.GetContactCount());
            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);       
            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ContactRemovalTestDB()
        {
            {
                applicationManager.Contact.CreateContactIfNotExist();

                List<ContactData> oldContacts = ContactData.GetAllContacts();
                System.Console.Out.Write("Before : " + oldContacts.Count);
                ContactData toBeRemoved = oldContacts[0];
                applicationManager.Contact.RemoveById(toBeRemoved.Id);
                Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contact.GetContactCount());
                oldContacts.RemoveAt(0);
                List<ContactData> newContacts = ContactData.GetAllContacts();
                System.Console.Out.Write("After Deletion: " + newContacts.Count);
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);
                foreach (ContactData contact in newContacts)
                {
                    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);

                }
            }
        }


    }
}
