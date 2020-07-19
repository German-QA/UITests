using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GEAUITests.PageObject
{
    public class MapPage
    {
        IWebDriver driver;
        public MapPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public DashboardPage ReturnToDashboardPage()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return new DashboardPage(driver);
        }

    }
}
