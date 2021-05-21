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
    public class AoPesquisarComunicados
    {
        private IWebDriver driver;

        public AoPesquisarComunicados(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoEPreenchimentoPesquisarComunicados()
        {
            bool compara = true;
            bool compara2 = true;

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");

            //Comunicados
            var menuPO = new MenuPO(driver);

            while (compara == true)
            {
                if (driver.Url.Equals("https://app.feedz.com.br/inicio"))
                {
                    //Clicar Comunicados
                    menuPO.ClicarComunicados();

                    Thread.Sleep(2000);

                    while (compara2 == true)
                    {
                        if (driver.Url.Equals("https://app.feedz.com.br/comunicados"))
                        {
                            //Pesquisar Comunicados
                            new DetalheComunicadosPO(driver)
                                .PesquisarDestaque("Gamificação");

                            //Logout
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
