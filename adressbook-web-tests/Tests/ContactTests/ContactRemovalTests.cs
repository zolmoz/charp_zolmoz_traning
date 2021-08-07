using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Navigate.OpenHomePage();
            if (!applicationManager.Contact.IsContactExist())
            {
                applicationManager.Contact.Create(new ContactData("Julli", "Apple"));
            }

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Remove(0);
            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
