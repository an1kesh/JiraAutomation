using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace JiraAssignment.FeatureSteps
{
    [Binding]
    public class GoogleSearchingSteps
    {

        IWebDriver driver;

        [Given(@"a web browser is on the Google page")]
        public void GivenAWebBrowserIsOnTheGooglePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }
        
        [When(@"the search phrase ""(.*)"" is entered")]
        public void WhenTheSearchPhraseIsEntered(string p0)
        {
            driver.FindElement(By.Name("q")).SendKeys(p0 + Keys.Enter);
        }
        
        [Then(@"results for ""(.*)"" are shown")]
        public void ThenResultsForAreShown(string p0)
        {
            Assert.IsTrue(driver.Title.Contains(p0));
        }
    }
}
