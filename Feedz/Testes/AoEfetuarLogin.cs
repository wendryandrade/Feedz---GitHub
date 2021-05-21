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
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveRealizarScript()
        {
            bool compara = true;
            bool compara2 = true;
            bool compara3 = true;
            bool compara4 = true;

            var menuPO = new MenuPO(driver);

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");

            while (compara == true)
            {
                if (driver.Url.Equals("https://app.feedz.com.br/inicio"))
                {
                    try
                    {
                        //Preencher Humor Diário
                        new HumorDiarioPO(driver)
                            .PreencherHumorDiario();

                        while (compara2 == true)
                        {
                            //Clicar Organograma
                            menuPO.ClicarOrganograma();

                            if (driver.Url.StartsWith("https://app.feedz.com.br/organograma"))
                            {
                                //Exportar Organograma
                                new DetalheOrganogramaPO(driver)
                                    .ExportarOrganograma();

                                Thread.Sleep(4000);

                                while (compara3 == true)
                                {
                                    //Visitar Objetivos
                                    var detalheObjetivoPO = new DetalheObjetivoPO(driver);
                                    detalheObjetivoPO.Visitar();

                                    if (driver.Url.Equals("https://app.feedz.com.br/okr"))
                                    {
                                        //Filtrar Objetivos
                                        detalheObjetivoPO.FiltrarPreenchido("01/06/2020", "31/06/2020");

                                        while (compara4 == true)
                                        {
                                            //Clicar Colaboradores
                                            menuPO.ClicarColaboradores();

                                            if (driver.Url.Equals("https://app.feedz.com.br/colaboradores"))
                                            {
                                                //Filtrar Colaboradores
                                                new DetalheColaboradoresPO(driver)
                                                    .FiltrarPreenchido("Gestor");

                                                //Logout
                                                menuPO.EfetuarLogout();

                                                compara4 = false;
                                            }
                                        }

                                        compara3 = false;
                                    }
                                }

                                compara2 = false;
                            }
                        }

                        throw new Exception();
                    }

                    catch (Exception)
                    {
                        while (compara2 == true)
                        {

                            //Clicar Organograma
                            menuPO.ClicarOrganograma();

                            if (driver.Url.StartsWith("https://app.feedz.com.br/organograma"))
                            {
                                //Exportar Organograma
                                new DetalheOrganogramaPO(driver)
                                    .ExportarOrganograma();

                                Thread.Sleep(4000);

                                while (compara3 == true)
                                {
                                    //Visitar Objetivos
                                    var detalheObjetivoPO = new DetalheObjetivoPO(driver);
                                    detalheObjetivoPO.Visitar();

                                    if (driver.Url.Equals("https://app.feedz.com.br/okr"))
                                    {
                                        //Filtrar Objetivos
                                        detalheObjetivoPO.FiltrarPreenchido("01/06/2020", "31/06/2020");

                                        while (compara4 == true)
                                        {
                                            //Clicar Colaboradores
                                            menuPO.ClicarColaboradores();

                                            if (driver.Url.Equals("https://app.feedz.com.br/colaboradores"))
                                            {
                                                //Filtrar Colaboradores
                                                new DetalheColaboradoresPO(driver)
                                                    .FiltrarPreenchido("Gestor");

                                                //Logout
                                                menuPO.EfetuarLogout();

                                                compara4 = false;
                                            }
                                        }

                                        compara3 = false;
                                    }
                                }

                                compara2 = false;
                            }
                        }
                    }

                    compara = false;
                }
            }
        }

        [Fact]
        public void DadoCredenciaisValidasDeveLogar()
        {
            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarPaginaLogin()
        {
            //Tentativa de Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "");
        }
    }
}