using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Interactions;
using JiraPOM;

namespace JiraAssignment
{
    class Program
    {

        [SetUp]
        public void initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Properties.driver.Navigate().GoToUrl("https://sandbox.xpand-it.com/");
        }

        [Test]
        public void testEx()
        {
            LoginPage page = new LoginPage();
            page.Login_Enter("user15", "anikesh");
            page.loginbtn.Submit();
            Dashboard dashboard = new Dashboard();
            /*dashboard.Projects.MoveClick();
            dashboard.ProjectsAAAAA.MoveClick();
            dashboard.Create.MoveClick();*/
            dashboard.CreateUserStory("as a user i should be able to log in.");
            Thread.Sleep(1000);
            dashboard.CreateTestPlan("test plan to test something.");

        }

        [TearDown]
        public void End()
        {
            //Properties.driver.Quit();
        }
    }
}
