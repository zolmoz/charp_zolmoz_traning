using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace adressbook_web_tests
{
    public class RemovingContactFromGroupTest : AuthTestBase
    {
        [Test]

        public void TestRemovingContactToGroup()
        {
            GroupData group = GroupData.GetAllGroups()[0];

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            applicationManager.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}