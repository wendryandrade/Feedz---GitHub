using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedz.PageObjects
{
    public class HumorDiarioPO
    {
        private IWebDriver driver;

        //Humor Diário
        private By byImagemHumorDiario;
        private By byTextoHumorDiario;
        private By byBotaoEnviarHumorDiario;

        public HumorDiarioPO(IWebDriver driver)
        {
            this.driver = driver;

            //Opções Humor Diário
            //byImagemHumorDiario = By.XPath("//*/div[1]/div/label[1]/img"); //muito triste
            //byImagemHumorDiario = By.XPath("//*/div[1]/div/label[2]/img"); //triste
            //byImagemHumorDiario = By.XPath("//*/div[1]/div/label[3]/img"); //neutro
            byImagemHumorDiario = By.XPath("//*/div[1]/div/label[4]/img"); //muito bem
            //byImagemHumorDiario = By.XPath("//*/div[1]/div/label[5]/img"); //muito feliz
            byTextoHumorDiario = By.Name("mood-message");
            byBotaoEnviarHumorDiario = By.CssSelector("button.btn.btn-primary.fdz-panel-mood-btn-submit");
        }

        public void PreencherHumorDiario()
        {
            driver.FindElement(byImagemHumorDiario).Click();
            //driver.FindElement(byTextoHumorDiario).SendKeys("Se estiver recebendo essa mensagem estou feliz, pois meu teste deu certo NOVAMENTE! KKK");
            driver.FindElement(byBotaoEnviarHumorDiario).Click();
        }
    }
}
