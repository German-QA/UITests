using NUnit.Framework;
using GEAUITests.BaseClass;
using GEAUITests.PageObject;

namespace GEAUITests
 {
    [TestFixture]
    public class Test : BaseTest
    {

        int myActiveJobsNumber = 0;

        [Test, Category("Functional Testing"), Description("After hitting 3 or more letters, the list of address suggestions appears. After selecting one of them, a new tab is opened with the general map url"), Order(0)]
        public void SeachBoxTest()
        {
            var dashboardPage = new DashboardPage(driver);
            var mapPage = dashboardPage.SearchLocation();
            Assert.AreEqual("Gea | Map", mapPage.getTitle());
            mapPage.ReturnToDashboardPage();
        }
        
        [Test, Category("Functional Testing"), Description("If there are more than 12 jobs there is a pagination component"), Order(1)]
        public void MyActiveJobsSectionTest1()
        {

            var dashboardPage = new DashboardPage(driver);
            myActiveJobsNumber = dashboardPage.GetMyActiveJobsNumber();

            if (myActiveJobsNumber > 12)
            {
                Assert.IsNotNull(dashboardPage.ForwardArrow);
            }

        }

        [Test, Category("Functional Testing"), Description("The number in the title reflects the total number of jobs"), Order(2)]
        public void MyActiveJobsSectionTest2()
        {
            var dashboardPage = new DashboardPage(driver);
            int myActiveJobsCount = dashboardPage.GetMyActiveJobsCount(myActiveJobsNumber);
            Assert.AreEqual(myActiveJobsNumber, myActiveJobsCount);
        }

        [Test, Category("Functional Testing"), Description("A new tab is opened with the job detail page after clicking on job link"), Order(3)]
        public void MyActiveJobsSectionTest3()
        {
            var dashboardPage = new DashboardPage(driver);
            string activeJobReferenceNumber = dashboardPage.IconReference.Text.Trim();
            var activeJobPage = dashboardPage.NavigateToActiveJobLink();
            Assert.AreEqual(activeJobReferenceNumber, activeJobPage.ReferenceNumber.Text);
            activeJobPage.ReturnToDashboardPage();
        }


        [Test, Category("Functional Testing"), Description("Add Job popup is shown after clicking Add Job button"), Order(4)]
        public void AddJobButtonTest()
        {
            var dashboardPage = new DashboardPage(driver);
            dashboardPage.OpenNewJobTab();
            Assert.IsTrue(dashboardPage.NewJobCloseButton.Displayed);
            dashboardPage.NewJobCloseButton.Click();
        }

    }
}
