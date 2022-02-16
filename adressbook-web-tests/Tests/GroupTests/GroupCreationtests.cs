using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;


namespace adressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        
        
        public static IEnumerable<GroupData> RandomGroupDataProvider()

        {

            List<GroupData> group = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                group.Add(new GroupData(GenerateRandomString(20))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return group;
        }

        
        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }


        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(group);
        }

        
        /*[Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }*/

    }
}
