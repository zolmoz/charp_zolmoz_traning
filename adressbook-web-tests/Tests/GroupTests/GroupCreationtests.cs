using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("name_1");
            group.Header = "test";
            group.Footer = "test";
            applicationManager.Groups.Create(group);
            

        }


        [Test]
        public void EmptyGroupCreationTest()
        {
 
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            applicationManager.Groups.Create(group);
           

        }

    }
}
