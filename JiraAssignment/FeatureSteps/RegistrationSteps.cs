using JiraAssignment.CustomMethods;
using JiraPOM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JiraAssignment.FeatureSteps
{
    [Binding]
    public class RegistrationSteps
    {


        



        /// Scenario: Registering Email on JIRA


        /// <summary>
        /// defining class level objects and variable to used in registraion scenarios.
        /// </summary>
        IWebDriver driver;
        RegistrationPage Registration;

        /// <summary>
        /// This method create a new chromedrier and navigate to JIRA index page.
        /// </summary>
        [Given(@"Jira tab opend for registration")]
        public void GivenJiraTabOpendForRegistration()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://sandbox.xpand-it.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            //to Switch the Registration Iframe
            driver.SwitchTo().Frame(0);
        }
        

        /// <summary>
        /// in this method we are entering the registration details from feature file to JIRA Form
        /// </summary>
        /// <param name="table"></param>
        [Given(@"fill the form with registration details")]
        public void GivenFillTheFormWithRegistrationDetails(Table table)
        {
            var Credential = table.CreateInstance<RegistrationCredential>();
            Registration = new RegistrationPage(driver);

            //here we are using custom method to fill all the details in one go.
            Registration.FillForm(Credential.FName, Credential.LName, Credential.Company, Credential.Email);
        }
        

        /// <summary>
        /// here we are simply paasing the values to server y clicking on the Submit button
        /// </summary>
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            Registration.ClickSubmit();
            //Console.WriteLine("pass");
        }
        

        /// <summary>
        /// This method verifies weather the user recieved a mail from JIRA or not for login credentials
        /// </summary>
        /// <param name="table"></param>
        [Then(@"User should recieve a mail")]
        public void ThenUserShouldRecieveAMail(Table table)
        {
            int time = 20000;
            var Credential = table.CreateInstance<GmailCredential>();
            string Url=null;

            //increasing the wait time by 20s and repesting the mailcheck until wait time limit (2min)
            while (time < 60001)
            {
                
                //recieving the confirmation may take some time for that pausing the test
                Thread.Sleep(time);
                gmail mail = new gmail();
                Url = mail.gmail_test(Credential.Email, Credential.Password, false);
                Console.WriteLine(Url);
                if (Url != null)
                    break;
                time = time + 20000;
            }


            //checking weather user got any URL or not
            Assert.IsFalse(Url == null);
            
        }
        // End of the Scenario: Registering Email on JIRA












        // Scenario: Login to new Account
        // defining class level objects and variables to use in test steps.
        string Url = null;
        ResetPassword ResetPage;
        Dashboard dashboard;
        LoginPage LoginPage;
        string UserName;
        string ProjectKey;



        /// <summary>
        /// in this method we are fetching the reset URL from Gmail to log in JIRA
        /// </summary>
        /// <param name="table"></param>
        [Given(@"Fetch the login link from gmain using following credentials")]
        public void GivenFetchTheLoginLinkFromGmainUsingFollowingCredentials(Table table)
        {
            var Credential = table.CreateInstance<GmailCredential>();

            //gmail is a seprate class for reading the unread message from the gmail
            gmail mail = new gmail();
            Url = mail.gmail_test(Credential.Email, Credential.Password, true);
            Console.WriteLine(Url);
            Assert.IsFalse(Url == null);

        }


        /// <summary>
        /// creating chrome driver and navigating to the fetched URL
        /// </summary>
        [Given(@"open the link")]
        public void GivenOpenTheLink()
        {
            driver = new ChromeDriver();

            //here URL is the one which we retrieved from the gmail
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
        }


        /// <summary>
        /// In this method we are just Entering the new password from the featurefile
        /// </summary>
        /// <param name="password"></param>
        [When(@"I Enter the new passwor ""(.*)""")]
        public void WhenIEnterTheNewPasswor(string password)
        {
            ResetPage = new ResetPassword(driver);
            UserName = ResetPage.Username.Text;
            ResetPage.EnterPassword(password);
        }


        /// <summary>
        /// in this method we are clicking on the reset buton to reset password.
        /// </summary>
        [When(@"Click Reset")]
        public void WhenClickReset()
        {
            //this is on the same reset form
            ResetPage.ResetBtn.Click();

            //this is on the next confirmation page.
            ResetPage.LoginLink.Click();
        }



        /// <summary>
        /// verifying whether login page loaded or not.
        /// </summary>
        [Then(@"login page should be visible")]
        public void ThenLoginPageShouldBeVisible()
        {
            LoginPage = new LoginPage(driver);
            
            //checking for visible username field on the login form
            Assert.IsTrue(LoginPage.txtusername.Displayed);
        }


        /// <summary>
        /// Entering the new username and the password and then clicking on the submit to login
        /// </summary>
        /// <param name="password"></param>
        [When(@"I Enter username and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string password)
        {
            LoginPage.Login_Enter(UserName, password);
            driver.FindElement(By.Id("login-form-submit")).Click();
        }


        /// <summary>
        /// verifying whether we logged in or not
        /// </summary>
        [Then(@"dashboard should be visible")]
        public void ThenDashboardShouldBeVisible()
        {
            dashboard = new Dashboard(driver);

            //checking whether create button is visible 
            Assert.IsTrue(dashboard.Create.Displayed);
        }


        /// <summary>
        /// clicking on the create project to create a new project 
        /// </summary>
        [When(@"I click on create project from projects menue")]
        public void WhenIClickOnCreateProjectFromProjectsMenue()
        {
            dashboard.Projects.MoveClick(driver);
            dashboard.CreateProject.MoveClick(driver);
        }


        /// <summary>
        /// this method checks whether the new div for creating new project is visible or not.
        /// </summary>
        [Then(@"Create project frame should visible")]
        public void ThenCreateProjectFrameShouldVisible()
        {
            //verifying visibility of the scrom project
            Assert.True(dashboard.ProjectScrumSotwareDevelopment.Displayed);
        }


        /// <summary>
        /// here in this project we are creating a new scrum project with a random project name
        /// </summary>
        [When(@"I select any project and fill the details")]
        public void WhenISelectAnyProjectAndFillTheDetails()
        {

            //here we are generating a 8 digit random project name
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz012 3456789_";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var ProjectName = new String(stringChars);

            //we are using cutome method to fill the details in the form
            ProjectKey = dashboard.CreateNewScrumProject(ProjectName);
            dashboard.ProjectSubmitButton.Click();
        }


        /// <summary>
        /// this method verifies whether the new project is created or not.
        /// </summary>
        [Then(@"new project should be created")]
        public void ThenNewProjectShouldBeCreated()
        {
            //checking for the visibilty of the project board name
            Assert.IsTrue(dashboard.ProjectBoardName.Text.Contains(ProjectKey));
        }


        /// <summary>
        /// cliking on the create button to create issues
        /// </summary>
        [When(@"I click on create button")]
        public void WhenIClickOnCreateButton()
        {
            dashboard.Create.MoveClick(driver);
        }


        /// <summary>
        /// selecting the user story and filling the summary and then clicking on the create.
        /// </summary>
        /// <param name="table"></param>
        [When(@"I select User story and fill the details and press submit")]
        public void WhenISelectUserStoryAndFillTheDetailsAndPressSubmit(Table table)
        {
            var summary = table.CreateInstance<CreatFormSummary>();
            dashboard.CreateUserStory(summary.Summary);
        }


        [Then(@"A user story must be created in backlog")]
        public void ThenAUserStoryMustBeCreatedInBacklog()
        {
            Console.WriteLine("pass");
        }

        // End of the Scenario: Login to new Account








        /// <summary>
        /// after scenario hook to close the browser
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            // AfterScenario code
            Console.WriteLine("called after");
            driver.Close();
        }


    }
}
