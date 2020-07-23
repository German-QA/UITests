using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace GEAUITests.PageObject
{
    public class DashboardPage
    {
        IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "dashboard-search-input")]

        public IWebElement SearchTextbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dashboard-myActiveJobs-section>h2")]

        public IWebElement MyActiveJobs { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-myActiveJobs-section']/div[2]/div[1]/div/nav/ul/li[3]/a")]

        public IWebElement PaginationNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-myActiveJobs-section']/div[2]/div[1]/div/nav/ul/li[4]/a")]

        public IWebElement ForwardArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='table-active-jobs']/div[1]/a/div/div[2]/div[2]")]

        public IWebElement IconReference { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='table-active-jobs']/div[1]/a/div/div[1]")]

        public IWebElement ActiveJobLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-addJob-section']/button/span[2]")]

        public IWebElement AddJobButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-dismiss='modal']")]

        public IWebElement NewJobCloseButton { get; set; }

        public MapPage SearchLocation()
        {
            SearchTextbox.SendKeys("Los ");
            Thread.Sleep(1000);
            SearchTextbox.SendKeys(Keys.Down + Keys.Enter);
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            return new MapPage(driver);
        }

        public int GetMyActiveJobsNumber()
        {
            string myActiveJobsText = MyActiveJobs.Text;
            myActiveJobsText = myActiveJobsText.Substring(myActiveJobsText.IndexOf("(") + 1);
            myActiveJobsText = myActiveJobsText.Substring(0, myActiveJobsText.IndexOf(")"));
            return int.Parse(myActiveJobsText);
        }

        public int GetMyActiveJobsCount(int myActiveJobsNumber)
        {
            int myActiveJobsCount = driver.FindElements(By.ClassName("dashboard-myActiveJobs-icon")).Count;
            
            if (myActiveJobsNumber > 12)
            {
                while (myActiveJobsCount < myActiveJobsNumber)
                {
                    ForwardArrow.Click();
                    Thread.Sleep(1000);
                    myActiveJobsCount = myActiveJobsCount + driver.FindElements(By.ClassName("dashboard-myActiveJobs-icon")).Count;
                }
            }

            return myActiveJobsCount;

        }

        public ActiveJobPage NavigateToActiveJobLink()
        {
            ActiveJobLink.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            return new ActiveJobPage(driver);
        }

        public void OpenNewJobTab()
        {
            AddJobButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-dismiss='modal']")));
        }

        public bool IsAddJobButtonPresent()
        {

            if (driver.FindElements(By.XPath("//*[@id='dashboard-addJob-section']/button/span[2]")).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsForwardArrowPresent()
        {

            if (driver.FindElements(By.XPath("//*[@id='dashboard-myActiveJobs-section']/div[2]/div[1]/div/nav/ul/li[4]/a")).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
