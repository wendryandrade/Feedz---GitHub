using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class DetalheNotificaçõesPO
    {
        private IWebDriver driver;

        private By byMarcarComoLidas;

        public DetalheNotificaçõesPO(IWebDriver driver)
        {
            this.driver = driver;

            byMarcarComoLidas = By.CssSelector("span.mark-as-read");
        }

        public void MarcarComoLidas()
        {
            driver.FindElement(byMarcarComoLidas).Click();
        }
    }
}
