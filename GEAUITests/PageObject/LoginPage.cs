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
        
        public DashboardPage NavigateToDashboardPage(string user, string pwd)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("loginfmt")));
            LoginTextBox.SendKeys(user);
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("idA_PWD_ForgotPassword")));
            PasswdTextBox.SendKeys(pwd);
            Thread.Sleep(1000);
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("DontShowAgain")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@type='submit']")));
            SubmitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("Gea"));
            return new DashboardPage(driver);
        }

    }
}
