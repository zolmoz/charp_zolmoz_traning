using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.Remove(1);
     
        }
 

    }
}
