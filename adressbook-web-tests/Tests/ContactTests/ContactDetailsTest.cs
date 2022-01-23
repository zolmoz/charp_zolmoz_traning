using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace adressbook_web_tests
{
    [TestFixture]
    public class ContactDetailsTest : AuthTestBase
    {
        [Test]

        public void TestContactDetails()
        {

            ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditForm(0);
            string contactFromForm = applicationManager.Contact.PersonViewForContact(fromForm);

            string contactDetails = applicationManager.Contact.GetContactInformationFromPersonView(0);
            Assert.AreEqual(contactFromForm, contactDetails);
        }
    }
}


