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
                applicationManager.Contact.Create(new ContactData("Julli", "Apple", "owl str 258",
                "11111", "2222", "3333"));
            }

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

    }
}
