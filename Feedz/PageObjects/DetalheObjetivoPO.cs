using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class DetalheObjetivoPO
    {
        private IWebDriver driver;
        private By byInputDataInicial;
        private By byInputDataFinal;
        private By byBotaoFiltrar;

        public DetalheObjetivoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputDataInicial = By.Id("datepicker-filter-start");
            byInputDataFinal = By.Id("datepicker-filter-end");
            byBotaoFiltrar = By.CssSelector("a.btn.btn-primary.btn-filter");
        }

        public DetalheObjetivoPO Visitar()
        {
            driver.Navigate().GoToUrl("https://app.feedz.com.br/okr");
            return this;
        }


        public DetalheObjetivoPO SelecionarDatas(string DataInicial, string DataFinal)
        {
            driver.FindElement(byInputDataInicial).SendKeys(DataInicial);
            driver.FindElement(byInputDataFinal).SendKeys(DataFinal);
            return this;
        }

        public DetalheObjetivoPO Filtrar()
        {
            driver.FindElement(byBotaoFiltrar).Click();

            driver.Navigate().GoToUrl("https://app.feedz.com.br/okr/15093");
            return this;
        }

        public void FiltrarPreenchido(string DataInicial, string DataFinal)
        {
            SelecionarDatas(DataInicial, DataFinal)
                .Filtrar();
        }
    }
}
