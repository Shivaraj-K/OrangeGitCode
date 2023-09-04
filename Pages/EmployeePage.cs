using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OrangeHRM.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    public class EmployeePage
    {
        //private readonly ICommon I;
        private readonly ScenarioContext _s;

        String id = JsonRead.ReaderJsonDataId();
        String msgs;

        public EmployeePage(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<ICommon>("Driver").Driver, this);
        }
        //public EmployeePage(ICommon d)
        //{
        //    I = d;
        //    PageFactory.InitElements(d.Driver, this);
        //}

        [FindsBy(How = How.XPath, Using = "//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']")]
        private IWebElement EmpId { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='oxd-form-actions']//button[@type='submit']")]
        private IWebElement search { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='oxd-toaster_1']/div[@aria-live='assertive']")]
        private IWebElement invisible { get; set; }

        private By invisibleLoc = By.XPath("//div[@id='oxd-toaster_1']/div[@aria-live='assertive']");

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Record Found')]")]
        private IWebElement Rec_F { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div/span)[2]")]
        private IWebElement Rec { get; set; }


        [FindsBy(How = How.LinkText, Using = "Add Employee")]
        private IWebElement AddEmp { get; set; }

        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "middleName")]
        private IWebElement MiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'oxd-grid-2')]//input")]
        private IWebElement EmpID { get; set; }
        ////div[contains(@class,'oxd-form-actions')]//button[@type='submit']

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'oxd-form-actions')]//button[@type='submit']")]
        private IWebElement save { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        private IWebElement EmplList { get; set; }

        private By loc_ID = By.XPath("//div[contains(@class,'oxd-grid-2')]//input");
        private By loc_Id = By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']");
        private By loc_Rec = By.XPath("(//div/span)[2]");
        private By loc_Save = By.XPath("//div[contains(@class,'oxd-form-actions')]//button[@type='submit']");
        private By loc_Search = By.XPath("//div[@class='oxd-form-actions']//button[@type='submit']");
        private By loc_EmpList = By.LinkText("Employee List");
        public String ValidateEmployee()
        {
            msgs = EmployeeList(id);

            
            if (msgs.Contains("Records"))
            {
                ExcelReader excelReader = new ExcelReader();
                IEnumerable<Dictionary<string, string>> data = excelReader.ReadData();
                
                foreach (var row in data)
                {
                    if(row!=null)
                    {
                        msgs = Employee_Add(row["FirstName"], row["MiddleName"], row["LastName"]);
                    }
                    
                   // msgs = Employee_Add(row["FirstName"], row["MiddleName"], row["LastName"]);
                }
            }
            Console.WriteLine(msgs);
            return msgs;

        }
        //Record Found  ////span[contains(.,'No Records Found')]
        public String EmployeeList(String _id)
        {
            //Thread.Sleep(3000);
            _s.Get<ICommon>("Driver").WaitForElement(loc_Id);
            EmpId.SendKeys(_id);
            search.Click();
            // Thread.Sleep(5000);
            _s.Get<ICommon>("Driver").WaitForElement(loc_Rec);
            String ss = Rec.Text;
            String s = ss.Split(" ")[1].Trim();
            return s;
        }


        public String Employee_Add(String FirstNames,String MiddleNames,String LastNames)
        {

            Actions a = new Actions(_s.Get<ICommon>("Driver").Driver);
            
            AddEmp.Click();

            //I.InvisibleMethod(By.XPath("//div[contains(@class,'oxd-grid-2')]//input"));
            Thread.Sleep(10000);
            a.MoveToElement(EmpID).Click().DoubleClick().KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
            //Thread.Sleep(5000);
            _s.Get<ICommon>("Driver").WaitForElement(By.Name("firstName"));
            Console.WriteLine(FirstNames + "  12121121212121212");
            Console.WriteLine(MiddleNames + "  12121121212121212");
            Console.WriteLine(LastNames + "  12121121212121212");
            FirstName.SendKeys(FirstNames);
            MiddleName.SendKeys(MiddleNames);
            LastName.SendKeys(LastNames);
            _s.Get<ICommon>("Driver").WaitForElement(loc_Save);
            // Thread.Sleep(3000);

            save.Click();
            //Thread.Sleep(10000);
            _s.Get<ICommon>("Driver").WaitForElement(loc_EmpList);
            EmplList.Click();
            _s.Get<ICommon>("Driver").WaitForElement(loc_Id);
            //Thread.Sleep(10000);
            a.MoveToElement(EmpId).Click().KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();
            _s.Get<ICommon>("Driver").WaitForElement(loc_Search);
            // Thread.Sleep(5000);
            search.Click();
            // Thread.Sleep(5000);
            _s.Get<ICommon>("Driver").WaitForElement(loc_Rec);
            String ss = Rec.Text;
            String s = ss.Split(" ")[1].Trim();
            //String ms= EmployeeList(S_id);

            //yield  return s;
        
        Console.WriteLine(s);
             return s;
        }

        public String Result()
        {
            String r = Rec.Text.Split(" ")[0];
            String num = r.Split("(")[1].Split(")")[0];
            int n = Int32.Parse(num);
            String mssg = "";
            if (n == 1)
            {
                mssg = "Record";
            }
            else if (n > 1)
            {
                mssg = "Records";
            }

            return mssg;
        }
    }
}
