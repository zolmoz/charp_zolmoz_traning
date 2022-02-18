using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace adressbook_web_tests
{

    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            applicationManager.Contact.CreateContactIfNotExist();
            applicationManager.Groups.CreateGroupIfNotExist();

            GroupData group = GroupData.GetAllGroups()[0];

            List<ContactData> oldList = group.GetContacts();

            if (ContactData.GetAllContacts().Count - oldList.Count == 0)
            {
                ContactData newcontact = new ContactData("Ivi", "Poison");
                applicationManager.Contact.Create(newcontact);
            }

            ContactData contact = ContactData.GetAllContacts().Except(group.GetContacts()).First();

            applicationManager.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
