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
    public class Menu
    {
        //private readonly ICommon I;
        private readonly ScenarioContext _s;
        public Menu(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<ICommon>("Driver").Driver, this);
        }
        //public Menu(ICommon d)
        //{
        //    I= d;
        //    PageFactory.InitElements(d.Driver, this);
        //}

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        private IWebElement search { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='oxd-main-menu']/li/a")]
        private IList<IWebElement> items { get; set; }


        private By loc = By.XPath("//ul[@class='oxd-main-menu']/li/a");
        public void Search_Item(String item)
        {
            search.SendKeys(item);

        }

        public EmployeePage Select_Item()
        {
            _s.Get<ICommon>("Driver").WaitForElement(loc);
            foreach (IWebElement w in items)
            {
                if (w.Text == "PIM")
                {
                    w.Click();
                    break;
                }
            }

            return new EmployeePage(_s);

        }

    }
}
