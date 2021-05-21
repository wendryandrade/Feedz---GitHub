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
    public class AoMarcarNotificaçõesComoLidas
    {
        private IWebDriver driver;

        public AoMarcarNotificaçõesComoLidas(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveMarcarNotificaçõesComoLidas()
        {
            bool compara = true;

            var menuPO = new MenuPO(driver);

            //Login
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("wendrya.oliveira@netviewinformatica.com.br", "24020000");

            while (compara == true)
            {
                if (driver.Url.Equals("https://app.feedz.com.br/inicio"))
                {
                    //Clicar Notificações
                    menuPO.ClicarNotificações();

                    //Marcar notificações como lidas
                    new DetalheNotificaçõesPO(driver)
                        .MarcarComoLidas();

                    //Logout
                    menuPO.EfetuarLogout();

                    compara = false;
                }
            }
        }
    }
}
