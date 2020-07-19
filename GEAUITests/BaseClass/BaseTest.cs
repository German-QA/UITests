using GEAUITests.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GEAUITests.BaseClass
{
    public class BaseTest
    {

        public IWebDriver driver;
        
        [OneTimeSetUp]
        public void Open()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://geadev.qrmjll.com/TalosArea/Dashboard");
            driver.Manage().Window.Maximize();
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToDashboardPage();
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
