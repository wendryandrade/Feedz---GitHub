using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("login_email");
            byInputSenha = By.Name("login_password");
            byBotaoLogin = By.CssSelector("button.btn.btn-default.login-button.gradient");
        }

        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl("https://app.feedz.com.br/");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            return InformarEmail(login)
                .InformarSenha(senha);
        }

        public LoginPO InformarEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO EfetuarLogin()
        {
            return SubmeteFormulario();
        }

        public LoginPO SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
            return this;
        }

        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar()
                .PreencheFormulario(login, senha)
                .SubmeteFormulario();
        }
    }
}
