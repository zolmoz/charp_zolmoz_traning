﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager appmanager) : base(appmanager) { }

        public void AddAccount(AccountData account)
        {
            if (IsAccountExists(account))
            {
                return;
            }

            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            Console.Out.WriteLine(telnet.Read());
        }


        public void DeleteAccount(AccountData account)
        {
            if (!IsAccountExists(account))
            {
                return;
            }

            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);
            Console.Out.WriteLine(telnet.Read());
        }


        public bool IsAccountExists(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();

            telnet.WriteLine("verify " + account.Name);
            String output = telnet.Read();
            Console.Out.WriteLine(output);

            return !output.Contains("does not exist");
        }


        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            Console.Out.WriteLine(telnet.Read());

            return telnet;
        }
    }
}