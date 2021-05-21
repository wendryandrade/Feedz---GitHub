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
    public class AoPreencherHumorDiario
    {
        private IWebDriver driver;

        public AoPreencherHumorDiario(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDevePreencherHumorDiario()
        {
            bool compara = true;

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

                        throw new Exception();
                    }

                    catch (Exception)
                    {
                        new MenuPO(driver)
                            .EfetuarLogout();
                    }

                    compara = false;
                }
            }
        }
    }
}
