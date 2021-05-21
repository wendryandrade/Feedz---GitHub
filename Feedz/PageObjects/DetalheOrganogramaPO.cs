using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class DetalheOrganogramaPO
    {
        private IWebDriver driver;

        private By byBotaoExportarOrganograma;

        public DetalheOrganogramaPO(IWebDriver driver)
        {
            this.driver = driver;

            byBotaoExportarOrganograma = By.CssSelector("button#export-org-chart");
        }

        public void ExportarOrganograma()
        {
            driver.FindElement(byBotaoExportarOrganograma).Click();
        }
    }
}
