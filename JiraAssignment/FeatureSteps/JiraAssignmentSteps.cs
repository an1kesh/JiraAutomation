using System;
using TechTalk.SpecFlow;
using JiraPOM;
using JiraAssignment;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace JiraAssignment.FeatureSteps
{
    [Binding]
    public class JiraAssignmentSteps
    {
        LoginPage login_page = new LoginPage();

        [Given(@"A JIRA tab open on the browser")]
        public void GivenAJIRATabOpenOnTheBrowser()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://sandbox.xpand-it.com/");
        }
        
        [Given(@"Enter the Username ""(.*)"" and Password ""(.*)""")]
        public void GivenEnterTheUsernameAndPassword(string Username, string Password)
        {
            login_page.Login_Enter(Username, Password);
        }
        
        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            login_page.loginbtn.Submit();
        }
        
        [Then(@"Dashboard should be visible")]
        public void ThenDashboardShouldBeVisible()
        {
            Assert.IsTrue(Properties.driver.Title == "Global - Sandbox Environment");
        }
    }
}





