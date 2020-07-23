using NUnit.Framework;
using GEAUITests.PageObject;
using System.Collections;
using GEAUITests.BaseClass;
using System;

namespace GEAUITests
 {
    [TestFixture]
    public class MyActiveJobsSection : BaseTest
    {

        [Test]
        [Category("Functional Testing")]
        [Description("If there are more than 12 jobs there is a pagination component. The number in the title reflects the total number of jobs. A new tab is opened with the job detail page after clicking on job link")]
        [Order(1)]
        [TestCaseSource("Users")]
        public void MyActiveJobsSectionTest(string[] user)
        {

            var loginPage = new LoginPage(driver);
            loginPage.NavigateToDashboardPage(user[0], user[1]);
            var dashboardPage = new DashboardPage(driver);
            int myActiveJobsNumber = dashboardPage.GetMyActiveJobsNumber();

            Console.WriteLine("myActiveJobsNumber: {0}", myActiveJobsNumber); 

            //If there are more than 12 jobs there is a pagination component
            if (myActiveJobsNumber > 12)
            {
                Assert.IsTrue(dashboardPage.IsForwardArrowPresent());
            }
            else
            {
                Assert.IsFalse(dashboardPage.IsForwardArrowPresent());
            }

            int myActiveJobsCount = dashboardPage.GetMyActiveJobsCount(myActiveJobsNumber);
            //The number in the title reflects the total number of jobs
            Assert.AreEqual(myActiveJobsNumber, myActiveJobsCount);

            if (myActiveJobsNumber > 0)
            {
                string activeJobReferenceNumber = dashboardPage.IconReference.Text.Trim();
                var activeJobPage = dashboardPage.NavigateToActiveJobLink();
                //A new tab is opened with the job detail page after clicking on job link
                Assert.AreEqual(activeJobReferenceNumber, activeJobPage.ReferenceNumber.Text);
                activeJobPage.ReturnToDashboardPage();
            }

        }

        static IList Users()
        {
            ArrayList list = new ArrayList();
            list.Add(new string[] { "VasTest_Valuer@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_VALUER" }); //0 jobs
            list.Add(new string[] { "VasTest_SysAdmin@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_SYS_ADMIN" }); //1 job
            list.Add(new string[] { "VasTest_Manager@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_MANAGER" }); //12 jobs
            list.Add(new string[] { "VasTest_ProjCoord@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_PROJ_COORD" });//13 jobs
            return list;
        }

    }
}
