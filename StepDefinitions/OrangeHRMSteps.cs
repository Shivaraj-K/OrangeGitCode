using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM.Pages;
using OrangeHRM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.StepDefinitions
{
    [Binding]
    public class OrangeHRMSteps
    {
        private readonly ScenarioContext _s;
        Menu m;
        EmployeePage e;
        String msg;

        public OrangeHRMSteps(ScenarioContext s)
        {
            _s = s;
        }
        

        [Given(@"User on the OrangeHRM login page")]
        public void GivenUserOnTheOrangeHRMLoginPage()
        {
        
        }

        [When(@"User login with valid Credential")]
        public void WhenUserLoginWithValidCredential()
        {
          m=  _s.Get<ICommon>("Driver").Login.UserCredential("Admin", "admin123");
        }

        [When(@"User Select Item name as ""([^""]*)"" in main-menu")]
        public void WhenUserSelectItemNameAsInMain_Menu(string pIM)
        {
            m.Search_Item(pIM);
            e=m.Select_Item();
        }

        [When(@"Add the employee")]
        public void WhenAddTheEmployee()
        {
            msg= e.ValidateEmployee();
          
        }

        [Then(@"Verify Addeed employee present inthe Employee List")]
        public void ThenVerifyAddeedEmployeePresentIntheEmployeeList()
        {
            String msgs = e.Result();

            Assert.AreEqual(msg, msgs);

        }

    }
}
