using System;
using TechTalk.SpecFlow;
using JiraPOM;
using JiraAssignment.CustomMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace JiraAssignment.FeatureSteps
{
    [Binding]
    public class JiraAssignmentSteps
    {
        IWebDriver driver;
        LoginPage login_page;
        Dashboard dashboard;

        // scenario: Login to the Jira Dashboard

        /// <summary>
        /// Opening the JIRA Index Page in the google chrome tab.
        /// </summary>
        [Given(@"A JIRA tab open on the browser")]
        public void GivenAJIRATabOpenOnTheBrowser()
        {
            //creating the object of chrome driver 
            driver = new ChromeDriver();

            //navigating the https://sandbox.xpand-it.com URL
            driver.Navigate().GoToUrl("https://sandbox.xpand-it.com/");

            //defining the implicite wait time for the element locator
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        

        /// <summary>
        /// Entering the Username and the Password to the login form 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        [Given(@"Enter the Username ""(.*)"" and Password ""(.*)""")]
        public void GivenEnterTheUsernameAndPassword(string Username, string Password)
        {
            //creating the oblect of the login module From the JIRA page object model
            login_page = new LoginPage(driver);
            
            //passing the values to the login form
            login_page.Login_Enter(Username, Password);
        }
        

        /// <summary>
        /// Clicking on the Login button availble on the login form
        /// </summary>
        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            //clicking login button and getting the object of the dashboard.
            dashboard = login_page.LoginSubmit();
        }
        

        /// <summary>
        /// verifying weather the dashboard is visible or not.
        /// </summary>
        [Then(@"Dashboard should be visible")]
        public void ThenDashboardShouldBeVisible()
        {
            //asserting weather the create button on dashboard visible or not.
            Assert.IsTrue(dashboard.Create.Displayed);
            Console.WriteLine(driver.Title);
        }















        [Given(@"login to the gmail")]
        public void GivenLoginToTheGmail()
        {
            gmail mail = new gmail();
            //string url = mail.gmail_test("test.anikesh@gmail.com", "qwertyanikesh");
            //Console.WriteLine(url);
        }

        [Given(@"display the content")]
        public void GivenDisplayTheContent()
        {
            Console.WriteLine("done");
        }



    }
}





