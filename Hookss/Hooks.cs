using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OrangeHRM.Drivers;
using OrangeHRM.Pages;
using OrangeHRM.Utilities;
using TechTalk.SpecFlow;

namespace OrangeHRM.Hookss
{
    [Binding]
    public sealed class Hooks : Extent
    {
        //private readonly IObjectContainer _container;
        // private ICommon _c;
        private readonly ScenarioContext _s;
        IWebDriver d;

        public Hooks(ScenarioContext s)
        {
            _s = s;
        }
        //public Hooks(IObjectContainer container)
        //{
        //    _container = container;
        //}

        [BeforeTestRun]
        public static void BeforeRun()
        {
            ExtentMethod();
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            TearDowmMethod();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext ff)
        {
           f= e.CreateTest<Feature>(ff.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void Setup(ScenarioContext ss)
        {

            ICommon c = new CommonClass(_s);
            _s.Set(c, "Driver");
           d= _s.Get<ICommon>("Driver").Driver;

            //_container.RegisterInstanceAs<IWebDriver>(d);
            //_container.RegisterInstanceAs<ICommon>(_c);
            _s.Get<ICommon>("Driver").Login = new LoginPage(_s);

            t=f.CreateNode<Scenario>(ss.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TearDownMethod()
        {
            //d=_container.Resolve<IWebDriver>();
            //if(d!=null)
            //{
            //    Thread.Sleep(8000);
            //    d.Quit();
            //}
        }

        [AfterStep]
        public void AfterStepss(ScenarioContext ss)
        {
            String type=ss.StepContext.StepInfo.StepDefinitionType.ToString();
            String name = ss.StepContext.StepInfo.Text;
           IWebDriver dr= _s.Get<ICommon>("Driver").Driver;

            if(ss.TestError==null)
            {
                if(type=="Given")
                {
                    t.CreateNode<Given>(name);
                }
                else if(type=="When")
                {
                    t.CreateNode<When>(name);
                }
                else if(type=="Then")
                {
                    t.CreateNode<Then>(name);
                }
            }


            else if(ss.TestError!=null)
            {
                if (type == "Given")
                {
                    t.CreateNode<Given>(name).Fail(ss.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenMethod(dr,ss)).Build());
                }
                else if (type == "When")
                {
                    t.CreateNode<When>(name).Fail(ss.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenMethod(dr, ss)).Build());
                }
                else if (type == "Then")
                {
                    t.CreateNode<Then>(name).Fail(ss.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenMethod(dr, ss)).Build());
                }
            }

        }
    }
}