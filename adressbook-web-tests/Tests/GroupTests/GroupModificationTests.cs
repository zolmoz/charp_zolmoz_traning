using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace adressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {


        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("ttttt");
            newData.Header = null;
            newData.Footer = null;

            applicationManager.Navigate.GoToGroupsPage();
            if (!applicationManager.Groups.IsGroupExist())
            {
                applicationManager.Groups.Create(new GroupData("names"));
            }

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Modify(0, newData);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
