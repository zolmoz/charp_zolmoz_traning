using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace adressbook_web_tests
{

    [TestFixture]
   
    public class ContactInformationTest : AuthTestBase
    {

        [Test]
        public void TestContactInformation()
        {
           ContactData formTable = applicationManager.Contact.GetContactInformationFromTable(0);
           ContactData formForm = applicationManager.Contact.GetContactInformationFromEditForm(0);

            //verification

            Assert.AreEqual(formTable, formForm);
            Assert.AreEqual(formTable.Address, formForm.Address);
            Assert.AreEqual(formTable.AllPhones, formForm.AllPhones);
            Assert.AreEqual(formTable.AllMails, formForm.AllMails);

        }


    }


}
