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

namespace JiraPOM
{
    class LoginPage
    {

        public LoginPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "login-form-username")]
        public IWebElement txtusername { get; set; }

        [FindsBy(How = How.Id, Using = "login-form-password")]
        public IWebElement txtpassword { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement loginbtn { get; set; }


        public void Login_Enter(string username, string password)
        {
            
            txtusername.EnterText(username);
            txtpassword.EnterText(password);
        }
    }


}
