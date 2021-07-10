using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]

        public void ContactModificationTest()
        {

            ContactData updatecontact = new ContactData("1");
            updatecontact.Middlename = "1";
            updatecontact.Lastname = " 1";
            updatecontact.Nickname = "1 ";
            updatecontact.Title = " ";
            updatecontact.Company = "1";
            updatecontact.Address = "1 ";
            updatecontact.Home = "1";
            updatecontact.Mobile = "1";
            updatecontact.Work = "1";
            updatecontact.Fax = "1 ";
            updatecontact.Email = " 1";
            updatecontact.Email2 = "1 ";
            updatecontact.Email3 = " 1";
            updatecontact.Homepage = "1";
            updatecontact.Bday = "1";
            updatecontact.Bmonth = "June";
            updatecontact.Byear = "1111";
            updatecontact.Aday = "2";
            updatecontact.Amonth = "June";
            updatecontact.Ayear = "1111";
            updatecontact.Address2 = "1 ";
            updatecontact.Phone2 = " 1";
            updatecontact.Notes = "1";

            applicationManager.Contact.Modify(updatecontact);
        }
    }
}
