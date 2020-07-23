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

        [FindsBy(How = How.XPath, Using = "//*[@id='GMAPMainContainer']/div/div/div[1]/div[3]/div/div[3]/div/img")]

        public IWebElement PointerImg { get; set; }
                
        public DashboardPage ReturnToDashboardPage()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return new DashboardPage(driver);
        }

        public string[] GetUrlCoords()
        {

            string lat = driver.Url.Split('=', '&')[1];
            string lng = driver.Url.Substring(driver.Url.IndexOf('&') + 4);
            lng = lng.Split('=', '&')[1];
            return new string[2] {lat,lng};
                   
        }

    }
}
