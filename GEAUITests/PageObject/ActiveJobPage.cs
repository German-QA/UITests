using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GEAUITests.PageObject
{
    public class ActiveJobPage
    {
        IWebDriver driver;
        public ActiveJobPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[1]/div[1]/div[2]/div[2]/span[2]")]

        public IWebElement ReferenceNumber { get; set; }

        public DashboardPage ReturnToDashboardPage()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return new DashboardPage(driver);
        }

    }
}
