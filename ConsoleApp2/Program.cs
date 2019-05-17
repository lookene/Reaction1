using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace toomasReaction1
{
    class Reaction
    {
        static void Main(string[] args)
        {
            EdgeDriver driver = new EdgeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


            driver.Navigate().GoToUrl("https://www.humanbenchmark.com/tests/reactiontime");
            driver.FindElement(By.XPath("//h1[contains(text(), 'Reaction Time Test')]")).Click();

            // i dont no why block
            Thread.Sleep(1000);
            driver.FindElement(By.Id("root")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("root")).Click();

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 15000; i++)
                {
                    if (driver.FindElements(By.CssSelector("#root > div > div:nth-child(4) > div.test-standard.reaction-time-test.view-waiting > div > div:nth-child(1) > h1 > div")).Count == 0)
                    {
                        driver.FindElement(By.Id("root")).Click();

                        break;
                    }
                }
                Thread.Sleep(2700);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='root']/div/div[4]/div[1]/div/div[1]/h2"))).Click();
            }
            Thread.Sleep(7000);
            driver.Close();
        }
    }
}
