using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()

        { 
            applicationManager.Navigate.GoToGroupsPage();
            if (!applicationManager.Groups.IsGroupExist())
            {
                applicationManager.Groups.Create(new GroupData("names"));
            }
                applicationManager.Groups.Remove(1);

            }
 

    }
}
