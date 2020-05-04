using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAssignment.CustomMethods
{
    public static class SetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void Clicks(this IWebElement element, string value)
        {
            element.Click();
        }

        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void MoveClick(this IWebElement element)
        {
            new Actions(Properties.driver).MoveToElement(element).Click().Perform();
        }
    }
}
