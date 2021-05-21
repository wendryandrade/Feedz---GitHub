using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class MenuPO
    {
        private IWebDriver driver;
        
        //Menu
        private By byBotaoMenu;
        
        //Logout
        private By byLogoutLink;
        
        //Organograma
        private By byOrganogramaLink;

        //Colaboradores
        private By byColaboradoresLink;

        //Comunicados
        private By byComunicadosLink;

        //Notificações
        private By byNotificaçõesLink;
        
        public MenuPO(IWebDriver driver)
        {
            this.driver = driver;

            //Menu
            byBotaoMenu = By.CssSelector("button#dropdownMenuMobile");

            //Logout
            byLogoutLink = By.CssSelector("i.fa.fa-sign-out.menu-icon");
            
            //Organograma
            byOrganogramaLink = By.CssSelector("i.fa.fa-cubes.menu-icon");

            //Colaboradores
            byColaboradoresLink = By.CssSelector("i.fa.fa-users.menu-icon");

            //Comunicados
            byComunicadosLink = By.CssSelector("i.fa.fa-bullhorn.menu-icon");

            //Notificações
            byNotificaçõesLink = By.CssSelector("i.fa.fa-bell-o");
        }

        public void ClicarNotificações()
        {
            driver.FindElement(byNotificaçõesLink).Click();
        }
        
        public void ClicarOrganograma()
        {
            var linkBotaoMenu = driver.FindElement(byBotaoMenu);
            var linkOrganograma = driver.FindElement(byOrganogramaLink);

            IAction acaoOrganograma = new Actions(driver)

                //mover para o elemento do botao menu e clicar
                .MoveToElement(linkBotaoMenu).Click()

                //mover para o link de organograma e clicar
                .MoveToElement(linkOrganograma).Click().Build();

            acaoOrganograma.Perform();
        }

        public void ClicarColaboradores()
        {
            var linkBotaoMenu = driver.FindElement(byBotaoMenu);
            var linkColaboradores = driver.FindElement(byColaboradoresLink);

            IAction acaoColaboradores = new Actions(driver)

                //mover para o elemento do botao menu e clicar
                .MoveToElement(linkBotaoMenu).Click()

                //mover para o link de colaboradores e clicar
                .MoveToElement(linkColaboradores).Click().Build();

            acaoColaboradores.Perform();
        }

        public void ClicarComunicados()
        {
            var linkBotaoMenu = driver.FindElement(byBotaoMenu);
            var linkComunicados = driver.FindElement(byComunicadosLink);

            IAction acaoComunicados = new Actions(driver)

                //mover para o elemento do botao menu e clicar
                .MoveToElement(linkBotaoMenu).Click()

                //mover para o link de organograma e clicar
                .MoveToElement(linkComunicados).Click().Build();

            acaoComunicados.Perform();
        }

        public void EfetuarLogout()
        {
            var linkBotaoMenu = driver.FindElement(byBotaoMenu);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(driver)

                //mover para o elemento do botao menu e clicar
                .MoveToElement(linkBotaoMenu).Click()

                //mover para o link de logout e clicar
                .MoveToElement(linkLogout).Click().Build();

            acaoLogout.Perform();
        }
    }
}
