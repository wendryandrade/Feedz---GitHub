using Feedz.Fixtures;
using Feedz.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Feedz.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarObjetivos
    {
        private IWebDriver driver;

        public AoFiltrarObjetivos(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoEDatasFiltrarObjetivos()
        {
            bool compara = true;
            
            var detalheObjetivoPO = new DetalheObjetivoPO(driver);

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");
            
            while (compara == true)
            {
                driver.Navigate().GoToUrl("https://app.feedz.com.br/okr");

                if (driver.Url.StartsWith("https://app.feedz.com.br/okr"))
                {
                    //Filtrar Objetivos
                    detalheObjetivoPO.FiltrarPreenchido("01/06/2020", "31/06/2020");

                    //Logout
                    new MenuPO(driver)
                        .EfetuarLogout();

                    compara = false;
                }
            }
        }
    }
}
