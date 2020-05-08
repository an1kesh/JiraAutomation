using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraAssignment.CustomMethods;

namespace JiraPOM
{
    class ResetPassword
    {
        private IWebDriver _driver;
        public ResetPassword(IWebDriver driver) => _driver = driver;

        /// <summary>
        /// these are elemets available on the reset page which open by the link sent to the user on there mail
        /// </summary>
        public IWebElement Username => _driver.FindElement(By.Id("reset-password-user-name"));
        public IWebElement NewPasswordField => _driver.FindElement(By.Name("password"));
        public IWebElement ConfirmPasswordField => _driver.FindElement(By.Name("confirm"));
        public IWebElement ResetBtn => _driver.FindElement(By.Id("reset-password-submit"));
        public IWebElement LoginLink => _driver.FindElement(By.XPath("//a[contains(text(), 'log in')]"));


        /// <summary>
        /// custome method to enter password in both fields (new + confirm)
        /// </summary>
        /// <param name="Password"></param>
        public void EnterPassword(string Password)
        {
            NewPasswordField.EnterText(Password);
            ConfirmPasswordField.EnterText(Password);
        }


    }
}
