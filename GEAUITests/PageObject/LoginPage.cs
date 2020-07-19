using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace GEAUITests.PageObject
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "loginfmt")]

        public IWebElement LoginTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]

        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Name, Using = "passwd")]

        public IWebElement PasswdTextBox { get; set; }
        
        public void NavigateToDashboardPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            LoginTextBox.SendKeys("GeaTest@jllaccounts.onmicrosoft.com");
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("idA_PWD_ForgotPassword")));
            PasswdTextBox.SendKeys("TestGea2020jll+");
            Thread.Sleep(1000);
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("idBtn_Back")));
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("Gea"));
        }

    }
}
