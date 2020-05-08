using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using JiraAssignment;
using JiraAssignment.CustomMethods;
using OpenQA.Selenium.Remote;

namespace JiraPOM
{
    /// <summary>
    /// this class consist the POM model of the login form available on the welcome page
    /// </summary>
    class LoginPage
    { 

        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;


        /// <summary>
        /// different element available on the login form
        /// </summary>
        public IWebElement txtusername => _driver.FindElement(By.Id("login-form-username"));
        public IWebElement txtpassword => _driver.FindElement(By.Id("login-form-password"));
        public IWebElement loginbtn => _driver.FindElement(By.Id("login"));



        /// <summary>
        /// custome method to enter the username and password in one go
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login_Enter(string username, string password)
        {
            txtusername.EnterText(username);
            txtpassword.EnterText(password);
        }


        /// <summary>
        /// custome method to click on the login button and return the object of next page
        /// </summary>
        /// <returns></returns>
        public Dashboard LoginSubmit()
        {
            loginbtn.Submit();
            return new Dashboard(_driver);
        }
    }



    /// <summary>
    /// this class consist the POM model of the Registration form available on the welcome page
    /// </summary>
    class RegistrationPage
    {
        private IWebDriver _driver;
        public RegistrationPage(IWebDriver driver) => _driver = driver;


        /// <summary>
        /// different element available on the login form
        /// </summary>
        public IWebElement FirstName => _driver.FindElement(By.Id("form-firstname"));
        public IWebElement LastName => _driver.FindElement(By.Id("form-lastname"));
        public IWebElement Company => _driver.FindElement(By.Id("form-companyname"));
        public IWebElement Email => _driver.FindElement(By.XPath("(//input[@id='form-email'])[1]"));
        public IWebElement Check => _driver.FindElement(By.XPath("(//input[@id='form-email'])[2]"));
        public IWebElement SubmitBtn => _driver.FindElement(By.XPath("//input[@class='button submit']"));



        /// <summary>
        /// custome method to Fill the all the details in the regisration form in one go
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="company"></param>
        /// <param name="email"></param>
        public void FillForm(string fname, string lname, string company, string email)
        {
            FirstName.EnterText(fname);
            LastName.EnterText(lname);
            Company.EnterText(company);
            Email.EnterText(email);
            Check.Click();
        }

        public void ClickSubmit()
        {
            SubmitBtn.Submit();
        }
    }


}
