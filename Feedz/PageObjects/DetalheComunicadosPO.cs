using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class DetalheComunicadosPO
    {
        private IWebDriver driver;

        private By byPesquisarDestaque;
        private By byPesquisarOutros;

        public DetalheComunicadosPO(IWebDriver driver)
        {
            this.driver = driver;

            byPesquisarDestaque = By.CssSelector("input[aria-controls='DataTables_Table_0']");
            byPesquisarOutros = By.CssSelector("input[aria-controls='notice-table-filter']");
        }

        public DetalheComunicadosPO PesquisarDestaque(string Pesquisa)
        {
            driver.FindElement(byPesquisarDestaque).SendKeys(Pesquisa);
            return this;
        }

        public DetalheComunicadosPO PesquisarOutros(string Pesquisa)
        {
            driver.FindElement(byPesquisarOutros).SendKeys(Pesquisa);
            return this;
        }

        public void Pesquisar(string PesquisaDestaque, string PesquisaOutros)
        {
            PesquisarDestaque(PesquisaDestaque)
                .PesquisarOutros(PesquisaOutros);
        }
    }
}
