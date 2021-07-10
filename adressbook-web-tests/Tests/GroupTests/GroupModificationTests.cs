using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
                applicationManager.Groups.Modify(1, newData);
            
       
            

        }

    }
}
