using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Drivers
{
    public class DriverIn
    {
        IWebDriver d;
        String browser;
        private readonly ScenarioContext _s;
        public DriverIn(ScenarioContext s)
        {
            _s = s;
        }
        public IWebDriver DriverInIt()
        {

            browser = TestContext.Parameters["browser"];


            //string browserName = ScenarioContext.Current.ScenarioInfo.Arguments.FirstOrDefault(arg => arg.StartsWith("--browser="));
            if (browser == null)
            {
                browser = ConfigurationManager.AppSettings["browser"];
            }
            int Imp = Int32.Parse(ConfigurationManager.AppSettings["implicit"]);
            // String browser = ConfigurationManager.AppSettings["browser"];
            String url= ConfigurationManager.AppSettings["url"];
            //Console.WriteLine(browser);
            if (d == null)
            {
                if (browser.ToLower() == "chrome")
                {
                    d = new ChromeDriver();
                }
                else if (browser.ToLower() == "firefox")
                {
                    d = new FirefoxDriver();
                }
                else if (browser.ToLower() == "edge")
                {
                    d = new EdgeDriver();
                }
                d.Url = url;
                d.Manage().Window.Maximize();
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Imp);
                _s.Set(d, "webDriver");
            }
            return d;
        }
    }
}
