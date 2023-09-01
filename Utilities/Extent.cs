using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Utilities
{
    public class Extent
    {
        public static ExtentReports e;
        public static ExtentHtmlReporter HR;
        public static ExtentTest f;
        public static ExtentTest t;

        public static String dir=AppDomain.CurrentDomain.BaseDirectory;
        public static String path = dir.Replace("bin\\Debug\\net6.0\\", "TestResults\\");
        public static void ExtentMethod()
        {
            HR = new ExtentHtmlReporter(path);
            HR.Config.DocumentTitle = "Extent Reports";
            HR.Config.ReportName = "Ecom Report";

            e = new ExtentReports();
            e.AttachReporter(HR);
            e.AddSystemInfo("Tester", "Shivaraj");
            e.AddSystemInfo("Developer", "Shivu");

        }

        public static void TearDowmMethod()
        {
            e.Flush();
        }


        public String ScreenMethod(IWebDriver d,ScenarioContext sc)
        {
            ITakesScreenshot it = (ITakesScreenshot)d;
            Screenshot ss=it.GetScreenshot();

            String p=Path.Combine(path, sc.ScenarioInfo.Title + ".png");

            ss.SaveAsFile(p,ScreenshotImageFormat.Png);
            return p;
        }

    }
}
