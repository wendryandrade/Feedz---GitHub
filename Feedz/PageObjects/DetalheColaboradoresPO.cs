using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class DetalheColaboradoresPO
    {
        private IWebDriver driver;

        private By byPapeis;
        private By byBotaoFiltrarColaboradores;

        public DetalheColaboradoresPO(IWebDriver driver)
        {
            this.driver = driver;
            
            byPapeis = By.CssSelector("select#role");
            byBotaoFiltrarColaboradores = By.CssSelector("button.btn.btn-primary");
        }

        public DetalheColaboradoresPO SelecionarPapeis(string Papeis)
        {
            driver.FindElement(byPapeis).SendKeys(Papeis);
            return this;
        }

        public DetalheColaboradoresPO Filtrar()
        {
            driver.FindElement(byBotaoFiltrarColaboradores).Click();
            return this;
        }

        public void FiltrarPreenchido(string Papeis)
        {
            SelecionarPapeis(Papeis)
                .Filtrar();
        }
    }
}
