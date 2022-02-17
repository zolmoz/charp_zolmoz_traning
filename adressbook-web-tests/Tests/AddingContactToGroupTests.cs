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
                GroupData group = GroupData.GetAllGroups()[0];
                List<ContactData> oldList = group.GetContacts();
                ContactData contact = ContactData.GetAllContacts().Except(oldList).First();

                applicationManager.Contact.AddContactToGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);
            }
        }
    }
