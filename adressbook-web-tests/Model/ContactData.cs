using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace adressbook_web_tests
{

    [Table(Name = "addressbook")]



    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allMails;

        public bool Equals(ContactData other)
        {
            
        if (Object.ReferenceEquals(other, null))
        {
            return false;
        }
        if (Object.ReferenceEquals(Firstname, other.Firstname))
        {
            return true;
        }
        if (Object.ReferenceEquals(Lastname, other.Lastname))
        {
            return true;
        }
        return Firstname == other.Firstname && Lastname == other.Lastname;
            
        }

        public  int GetHashCode(string firstname, string lastname)
        {
            return GetHashCode(firstname, lastname);
        }

        public override string ToString()
        {
            return "full name=" + Firstname + Lastname; 
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) == 0)
                {
                 
                    return Firstname.CompareTo(other.Firstname);
                }
         
            return Lastname.CompareTo(other.Lastname);
        }

        public ContactData()
        {
        }
          public ContactData(string firstname)
         {
            Firstname = firstname;

         }
         public ContactData(string firstname, string lastname)
         {
             Firstname = firstname;
             Lastname = lastname;

         }
        
        public ContactData(string firstname, string lastname,string address, string home, string mobile, string work)
         {
             Firstname = firstname;
             Lastname = lastname;
             Address = address;
             Home = home;
             Mobile = mobile;
             Work = work;

         }


        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }
       
        [Column(Name = "title")]
        public string Title { get; set; }
        
        [Column(Name = "company")]
        public string Company { get; set; }
        
        [Column(Name = "address")]
        public string Address { get; set; }
        
        [Column(Name = "home")]
        public string Home { get; set; }
        
        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }
       
        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }
   
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUpPhones(Home) + CleanUpPhones(Mobile) + CleanUpPhones(Work).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()\r\n]", "");
        }

        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3).Trim();
                }
            }
            set
            {
                allMails = value;
            }
        }

        private string CleanUpEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ \r\n]", "");
        }

        public static List<ContactData> GetAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}