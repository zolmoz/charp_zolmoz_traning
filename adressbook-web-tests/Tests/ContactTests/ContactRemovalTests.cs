using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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
                applicationManager.Contact.Create(new ContactData("Julli", " ", "Apple", "Lili", " ", "HP", "123 Main", " ", " ",
                            "123456", " ", "test@test.ru", " ", " ", " ", "12", "April", "1989", "24",
                            "May", "1999", "", "", "test"));
            }
            applicationManager.Contact.Remove();
        }

    }
}
