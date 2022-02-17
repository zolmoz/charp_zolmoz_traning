using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace adressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20)));
            }
            return contacts;
        }


        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                 File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value,
                    Company = range.Cells[i, 3].Value,
                    Address = range.Cells[i, 4].Value,
                    Middlename = range.Cells[i, 5].Value,
                    Nickname = range.Cells[i, 6].Value,
                    Title = range.Cells[i, 7].Value,
                    Fax = range.Cells[i, 8].Value,
                    Mobile = range.Cells[i, 9].Value,
                    Home = range.Cells[i, 10].Value,
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Middlename = parts[2],
                    Nickname = parts[3],
                    Title = parts[4],
                    Company = parts[5],
                    Address = parts[6],
                    Fax = parts[7],
                    Mobile = parts[8],
                    Home = parts[9]
                });
            }
            return contacts;
        }


        [Test,TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            

            List<ContactData> oldContact = applicationManager.Contact.GetContactList();
            applicationManager.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count + 1, applicationManager.Contact.GetContactCount());
            List<ContactData> newContact = applicationManager.Contact.GetContactList();

            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }

            


        [Test]
        public void EmptyContactCreationTest()
        {
                      
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
