using Feedz.Fixtures;
using Feedz.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Feedz.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarColaboradores
    {
        private IWebDriver driver;

        public AoFiltrarColaboradores(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoEPapeisFiltrarColaboradores()
        {
            bool compara = true;
            bool compara2 = true;

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");

            //Colaboradores
            var menuPO = new MenuPO(driver); 

            while (compara == true)
            {
                if (driver.Url.Equals("https://app.feedz.com.br/inicio"))
                {
                    //Clicar Colaboradores
                    menuPO.ClicarColaboradores();

                    while (compara2 == true)
                    {
                        if (driver.Url.Equals("https://app.feedz.com.br/colaboradores"))
                        {
                            //Filtrar Colaboradores
                            new DetalheColaboradoresPO(driver)
                                .FiltrarPreenchido("Gestor");

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
