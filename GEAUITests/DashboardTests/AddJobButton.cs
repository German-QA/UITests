using NUnit.Framework;
using GEAUITests.PageObject;
using System.Collections;
using GEAUITests.BaseClass;

namespace GEAUITests
 {
    [TestFixture]
    public class AddJobButton : BaseTest
    {

        public string[] authUsers = {"PF_TALOS_VALUER", "PF_TALOS_SR_ANALYST", "PF_TALOS_MANAGER", "PF_TALOS_PROJ_COORD", "PF_TALOS_SYS_ADMIN"};

        [Test]
        [Category("Functional Testing")]
        [Description("Add Job popup is shown after clicking Add Job button")]
        [Order(2)]
        [TestCaseSource("Users")]
        public void AddJobButtonTest(string[] user)
        {
            bool auth = false;
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToDashboardPage(user[0],user[1]);
            var dashboardPage = new DashboardPage(driver);

            foreach (string authUser in authUsers)
            {
                if (user[2].Equals(authUser))
                {
                    auth = true;
                    break;
                }
            }

            if (auth)
            {
                Assert.IsTrue(dashboardPage.IsAddJobButtonPresent());
                dashboardPage.OpenNewJobTab();
                Assert.IsTrue(dashboardPage.NewJobCloseButton.Displayed);
                dashboardPage.NewJobCloseButton.Click();
            }
            else
            {
                Assert.IsFalse(dashboardPage.IsAddJobButtonPresent());
            }

        }

        static IList Users()
        {
            ArrayList list = new ArrayList();
            list.Add(new string[] { "VasTest_Valuer@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_VALUER" });
            list.Add(new string[] { "VasTest_SrAnalyst@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_SR_ANALYST" });
            list.Add(new string[] { "VasTest_Manager@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_MANAGER" });
            list.Add(new string[] { "VasTest_ProjCoord@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_PROJ_COORD" });
            list.Add(new string[] { "VasTest_SysAdmin@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_SYS_ADMIN" });
            list.Add(new string[] { "VasTest_JrAnalyst@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_JR_ANALYST" });
            list.Add(new string[] { "VasTest_VAST@jllaccounts.onmicrosoft.com", "Ambitions2020", "PF_TALOS_VAST" });
            return list;
        }

    }
}
