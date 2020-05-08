using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraAssignment.CustomMethods;

namespace JiraPOM
{
    class Dashboard
    {
        // Selenium webdriver object
        private IWebDriver _driver;
        public Dashboard(IWebDriver driver) => _driver = driver;

        // These are top side navigation options/buttons
        public IWebElement Projects => _driver.FindElement(By.Id("browse_link"));
        public IWebElement ProjectsAAAAA => _driver.FindElement(By.XPath("(//a[@href='/browse/AAAAA'])[2]"));
        public IWebElement CreateProject => _driver.FindElement(By.Id("project_template_create_link_lnk"));
        public IWebElement Create => _driver.FindElement(By.Id("create-menu"));


        // These are the elements present in the create new project form
        public IWebElement ProjectScrumSotwareDevelopment => _driver.FindElement(By.XPath("//li[@data-name='Scrum software development']"));
        public IWebElement ProjectNextButton => _driver.FindElement(By.XPath("//button[contains(text(),'Next')]"));
        public IWebElement ProjectSelectButton => _driver.FindElement(By.XPath("//button[contains(text(),'Select')]"));
        public IWebElement ProjectNameField => _driver.FindElement(By.Id("name"));
        public IWebElement ProjectKeyField => _driver.FindElement(By.Id("key"));
        public IWebElement ProjectSubmitButton => _driver.FindElement(By.XPath("//button[contains(text(),'Submit')]"));

        
        // this is the element present in the project dashboard (heading)
        public IWebElement ProjectBoardName => _driver.FindElement(By.Id("ghx-board-name"));


        // these are the elements present under the top "create" button (create new issues)
        public IWebElement FormProjectOptions => _driver.FindElement(By.CssSelector("#project-single-select > .icon"));
        public IWebElement FormIssueOptions => _driver.FindElement(By.CssSelector("#issuetype-single-select > .icon"));
        public IWebElement FormSummary => _driver.FindElement(By.Id("summary"));
        public IWebElement FormCreateBtn => _driver.FindElement(By.Id("create-issue-submit"));





        // this method is responsible to create new Scrum project
        public string CreateNewScrumProject(String projectName)
        {
            ProjectScrumSotwareDevelopment.Click();
            ProjectNextButton.Click();
            ProjectSelectButton.Click();
            ProjectNameField.EnterText(projectName);
            String key = ProjectKeyField.GetAttribute("value");
            //ProjectSubmitButton.Click();
            return key;
        }







        // this method is responsible to create a new user stroy to given project
        public void CreateUserStory(string usrstory)
        {
            Create.MoveClick(_driver);
            Console.WriteLine(1);
            //select_project("AAAAA (AAAAA)");
            Console.WriteLine(2);
            select_issue("Story");
            Console.WriteLine(3);
            FormSummary.EnterText(usrstory);
            Console.WriteLine(4);
            FormCreateBtn.Submit();
            Console.WriteLine(5);
        }


        // this method is responsible to create a new Test plan to given project
        public void CreateTestPlan(string plan)
        {
            Create.MoveClick(_driver);
            Console.WriteLine("plan"+ 1);
            select_project("AAAAA (AAAAA)");
            Console.WriteLine(2);
            select_issue("Test Plan");
            Console.WriteLine(3);
            FormSummary.EnterText(plan);
            Console.WriteLine(4);
            FormCreateBtn.Submit();
            Console.WriteLine(5);
        }


        // This project selects the given project from drop down in create new isue option
        void select_project(string project)
        {
            try
            {
                string projectname = "AAAAA (AAAAA)";
                string all_projects = _driver.FindElement(By.Id("project-options")).GetAttribute("data-suggestions");
                string[] data = (all_projects.Split(new string[] { "{\"label\":\"" + projectname + "\"," }, StringSplitOptions.None))[1].Split('}');
                if (data[0].Contains("\"selected\":false"))
                {
                    Console.WriteLine("select the project");
                    FormProjectOptions.Click();
                    _driver.FindElement(By.LinkText(project)).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("End of select project");
        }


        // This project selects the given Issue type from drop down in create new isue option
        void select_issue(string issue)
        {
            try
            { 
                FormIssueOptions.Click();
                if (_driver.FindElement(By.LinkText(issue)).Displayed)
                {
                    _driver.FindElement(By.LinkText(issue)).Click();
                }
                else
                {
                    _driver.FindElement(By.XPath("(//span[@class='icon aui-ss-icon noloading drop-menu'])[2]")).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("End of select issue");
        }

        


    }
}
