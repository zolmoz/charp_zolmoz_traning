﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace adressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
             

        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
              
        }


        public GroupHelper Create(GroupData group)
        {
            applicationManager.Navigate.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            applicationManager.Navigate.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
           
        }

        public GroupHelper Remove(int p)
        {
            applicationManager.Navigate.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//input[5]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
          
                driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
                return this;
            
           

            
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
          
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);

            return this;
        }

       
    }
}
