using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Drivers;
using OrangeHRM.Pages;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Utilities
{
    public interface ICommon
    {
        public IWebDriver Driver { get; set; }
        public LoginPage Login { get; set; }
        public void WaitForElement(By locator);
        public void InvisibleMethod(By locator);
    }
    public class CommonClass : ICommon
    {
        private readonly ScenarioContext _s;
        WebDriverWait wait;
        public CommonClass(ScenarioContext s)
        {
            _s = s;
             DriverIn d= new DriverIn(s);
            s.Set(d, "dd");
           Driver = s.Get<DriverIn>("dd").DriverInIt();
            // Driver = new DriverIn().DriverInIt();

            wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(100));
            //PageFactory.InitElements(Driver, this);
           
        }

        public IWebDriver Driver { get; set; }
        public LoginPage Login { get; set; }

        public void WaitForElement(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }


        public void InvisibleMethod(By locator)
        {
           // wait.Until(ExpectedConditions.ElementToBeSelected(locator));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }


        public void addEmployee()
        {

        }
    }
}
