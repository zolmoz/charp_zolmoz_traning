using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Remove(0);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);

        }
 

    }
}
