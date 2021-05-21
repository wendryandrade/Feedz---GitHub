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
    public class AoExportarOrganograma
    {
        private IWebDriver driver;

        public AoExportarOrganograma(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoECliqueExportarOrganograma()
        {
            bool compara = true;
            bool compara2 = true;

            var menuPO = new MenuPO(driver);

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");

            while (compara == true)
            {
                if (driver.Url.Equals("https://app.feedz.com.br/inicio"))
                {
                    //Clicar Organograma
                    menuPO.ClicarOrganograma();

                    while (compara2 == true)
                    {
                        if (driver.Url.StartsWith("https://app.feedz.com.br/organograma"))
                        {
                            //Exportar Organograma
                            new DetalheOrganogramaPO(driver)
                                .ExportarOrganograma();

                            Thread.Sleep(4000);

                            menuPO.EfetuarLogout();

                            compara2 = false;
                        }
                    }

                    compara = false;
                }
            }
        }
    }
}
