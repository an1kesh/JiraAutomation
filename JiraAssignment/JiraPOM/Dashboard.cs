using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using JiraAssignment;
using JiraAssignment.CustomMethods;

namespace JiraPOM
{
    class Dashboard
    {

        public Dashboard()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "browse_link")]
        public IWebElement Projects { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@href='/browse/AAAAA'])[2]")]
        public IWebElement ProjectsAAAAA { get; set; }

        [FindsBy(How = How.Id, Using = "create-menu")]
        public IWebElement Create { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#project-single-select > .icon")]
        public IWebElement ProjectOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#issuetype-single-select > .icon")]
        public IWebElement IssueOptions { get; set; }

        [FindsBy(How = How.Id, Using = "summary")]
        public IWebElement Summary { get; set; }

        [FindsBy(How = How.Id, Using = "create-issue-submit")]
        public IWebElement CreateBtn { get; set; }


        public void CreateUserStory(string usrstory)
        {
            Create.MoveClick();
            select_project("AAAAA (AAAAA)");
            select_issue("Story");
            Summary.EnterText(usrstory);
            CreateBtn.Submit();
        }

        public void CreateTestPlan(string plan)
        {
            Create.MoveClick();
            //select_project("AAAAA (AAAAA)");
            select_issue("Test Plan");
            Summary.EnterText(plan);
            CreateBtn.Submit();
        }


        void select_project(string project)
        {
            try
            {
                string projectname = "AAAAA (AAAAA)";
                string all_projects = Properties.driver.FindElement(By.Id("project-options")).GetAttribute("data-suggestions");
                string[] data = (all_projects.Split(new string[] { "{\"label\":\"" + projectname + "\"," }, StringSplitOptions.None))[1].Split('}');
                if (data[0].Contains("\"selected\":false"))
                {
                    Console.WriteLine("select the project");
                    ProjectOptions.Click();
                    Properties.driver.FindElement(By.LinkText(project)).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void select_issue(string issue)
        {
            try
            {
                //Console.WriteLine("the selected issue option = " + new SelectElement(IssueOptions).AllSelectedOptions.SingleOrDefault().Text);
                IssueOptions.Click();
                Properties.driver.FindElement(By.LinkText(issue)).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        


    }
}
