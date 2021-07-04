using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace adressbook_web_tests
{

    [TestFixture]
    public class ContactRemovalTests :TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Contact.Remove();
        }

    }
}
