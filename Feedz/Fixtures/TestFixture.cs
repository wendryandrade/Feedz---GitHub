using Feedz.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.Fixtures
{
    public class TestFixture //: IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //timeout implicito
        }

        //TearDown
        //public void Dispose()
        //{
        //    Driver.Quit();
        //}
    }
}
