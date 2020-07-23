using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GEAUITests.BaseClass
{
    public class BaseTest
    {

        public IWebDriver driver;
        
        [SetUp]
        public void Open()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://geadev.qrmjll.com/TalosArea/Dashboard");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }

    }
}
