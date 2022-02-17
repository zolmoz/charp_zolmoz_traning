using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace adressbook_web_tests
{
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

        public ContactData()
        {
        }
        /* public ContactData(string firstname, string middlename, string lastname, string nickname, string title, string company, string address, string home, string mobile,
                              string work, string fax, string  email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday,
                              string amonth, string ayear, string address2, string phone2, string notes )
          {
              Firstname = firstname;
              Middlename = middlename;
              Lastname = lastname;
              Nickname = nickname;
              Title = title;
              Company = company;
              Address = address;
              Home = home;
              Mobile = mobile;
              Work = work;
              Fax = fax;
              Email = email;
              Email2 = email2;
              Email3 = email3;
              Homepage = homepage;
              Bday = bday;
              Bmonth = bmonth;
              Byear = byear;
              Aday = aday;
              Amonth = amonth;
              Ayear = ayear;
              Address2 = address2;
              Phone2 = phone2;
              Notes = notes;

          }*/

        public string Firstname { get; set; }
      

        public string Middlename { get; set; }


        public string Lastname { get; set; }


        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }


        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }

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
    }
}