using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Cas_30_zadatak_2_Sign_in
{
    class Selenium_tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        public void Navigate(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();

        }
        [Test]
        public void TestLogin()
        {
            Navigate("http://shop.qa.rs");
            IWebElement LinkLogIn = driver.FindElement(By.XPath("//a[@href='/login']"));
            if (LinkLogIn.Displayed && LinkLogIn.Enabled)
            {
                LinkLogIn.Click();
            }
            IWebElement userName = wait.Until(EC.ElementIsVisible(By.Name("username")));
            if (userName.Displayed && userName.Enabled)
            {
                userName.SendKeys("Pera");
            }
            IWebElement inputLozinka = driver.FindElement(By.Name("password"));
            if (inputLozinka.Displayed && inputLozinka.Enabled)
            {
                inputLozinka.SendKeys("Peric");
            }
            IWebElement buttonLogin = driver.FindElement(By.Name("password"));
            if (buttonLogin.Displayed && buttonLogin.Enabled)
            {
                buttonLogin.Click();
            }


        }
    }
}

