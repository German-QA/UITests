using NUnit.Framework;
using GEAUITests.BaseClass;
using GEAUITests.PageObject;
using System.Collections;

namespace GEAUITests
 {
    [TestFixture]
    public class SearchBox : BaseTest
    {

        [Test]
        [Category("Functional Testing")]
        [Description("After hitting 3 or more letters, the list of address suggestions appears. After selecting one of them, a new tab is opened with the general map url")]
        [Order(0)]
        [TestCaseSource("Users")]
        public void SeachBoxTest(string[] user)
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToDashboardPage(user[0], user[1]);
            var dashboardPage = new DashboardPage(driver);
            var mapPage = dashboardPage.SearchLocation();
            Assert.IsTrue(mapPage.PointerImg.Enabled);
            string[] coords = mapPage.GetUrlCoords();
            string lat = "34.0522342";
            string lng = "-118.2436849";
            Assert.AreEqual(lat, coords[0]);
            Assert.AreEqual(lng, coords[1]);
            mapPage.ReturnToDashboardPage();
        }

        static IList Users()
        {
            ArrayList list = new ArrayList();
            list.Add(new string[] { "GeaTest@jllaccounts.onmicrosoft.com", "TestGea2020jll+", "PF_TALOS_SYS_ADMIN" });
            return list;
        }

    }

}
