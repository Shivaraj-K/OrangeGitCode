using OpenQA.Selenium;
using OrangeHRM.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    public class LoginPage
    {
        // ICommon I;
        private ScenarioContext _s;
        public LoginPage(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<ICommon>("Driver").Driver, this);
        }
        //public LoginPage(ICommon d) 
        //{ 
        //    I = d;
        //    PageFactory.InitElements(d.Driver, this);
        //}

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement userName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".orangehrm-login-button")]
        private IWebElement login { get; set; }


        public Menu UserCredential(String  username, String password)
        {
            userName.SendKeys(username);
            Password.SendKeys(password);
            login.Click();
            return new Menu(_s);
        }
    }
}


