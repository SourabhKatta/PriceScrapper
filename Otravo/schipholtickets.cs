using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace Otravo
{
    [TestClass]
    public class schipholtickets
    {
        public string depCity, arrCity, fromDate, toDate, path = @"GrabbedPrice.txt", url;
        IWebDriver driver;
        IJavaScriptExecutor js;
        IReadOnlyCollection<IWebElement> count;
        int i = 0;
        WebDriverWait wait;
        StreamWriter sw;

        [TestInitialize]
        public void TestSetup()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArguments("--window-position=-32000,-32000");
            options.AddArguments("--disable-extensions");
            Thread.Sleep(1000);
            driver = new ChromeDriver(chromeDriverService, options);
            driver.Manage().Window.Size = new Size(1600,900);
            Thread.Sleep(1000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl(url);
            if (!File.Exists(path))
                sw = new StreamWriter(path);
            else if (File.Exists(path))
            {
                sw = File.AppendText(path);
                sw.WriteLine();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GetLowestPrice()
        {
            TestSetup();
            GetPrice(url, driver, wait, js, count, sw);
            Cleanup();
        }

        private void GetPrice(string bookingEngine, IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor js, IReadOnlyCollection<IWebElement> count, StreamWriter sw)
        {
            try
            {
                //setting search criteria
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.TagName("body")));

                if (depCity.Length == 3 && arrCity.Length == 3)
                {
                    driver.FindElement(By.Id("1")).Click();
                    driver.FindElement(By.Id("1")).SendKeys(depCity);
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@data-order,'1')]/div[contains(@class,'main-tickets_airports')]/ul/li")));
                    int depAirportCounts = driver.FindElements(By.XPath("//div[contains(@data-order,'1')]/div[contains(@class,'main-tickets_airports')]/ul/li")).Count;
                    for (int i = 1; i <= depAirportCounts; i++)
                    {
                        string iataCode = driver.FindElement(By.XPath("//div[contains(@data-order,'1')]/div[contains(@class,'main-tickets_airports')]/ul/li[" + i + "]/a")).GetAttribute("data-iatacode");
                        if (iataCode.Equals(depCity))
                        {
                            driver.FindElement(By.XPath("//div[contains(@data-order,'1')]/div[contains(@class,'main-tickets_airports')]/ul/li[" + i + "]")).Click();
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                    driver.FindElement(By.Id("2")).Click();
                    driver.FindElement(By.Id("2")).SendKeys(arrCity);
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@data-order,'2')]/div[contains(@class,'main-tickets_airports')]/ul/li")));
                    int arrAirportCounts = driver.FindElements(By.XPath("//div[contains(@data-order,'2')]/div[contains(@class,'main-tickets_airports')]/ul/li")).Count;
                    for (int i = 1; i <= arrAirportCounts; i++)
                    {
                        string iataCode = driver.FindElement(By.XPath("//div[contains(@data-order,'2')]/div[contains(@class,'main-tickets_airports')]/ul/li[" + i + "]/a")).GetAttribute("data-iatacode");
                        if (iataCode.Equals(arrCity))
                        {
                            driver.FindElement(By.XPath("//div[contains(@data-order,'2')]/div[contains(@class,'main-tickets_airports')]/ul/li[" + i + "]")).Click();
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    driver.FindElement(By.Id("1")).Click();
                    driver.FindElement(By.Id("1")).SendKeys(depCity);
                    Thread.Sleep(500);
                    driver.FindElement(By.Id("1")).SendKeys(OpenQA.Selenium.Keys.Tab);
                    driver.FindElement(By.Id("2")).Click();
                    driver.FindElement(By.Id("2")).SendKeys(arrCity);
                    Thread.Sleep(500);
                    driver.FindElement(By.Id("2")).SendKeys(OpenQA.Selenium.Keys.Tab);
                }
                driver.FindElement(By.Id("3")).Click();
                driver.FindElement(By.Id("3")).SendKeys(OpenQA.Selenium.Keys.Escape);
                driver.FindElement(By.Id("3")).SendKeys(fromDate);
                driver.FindElement(By.Id("4")).Click();
                driver.FindElement(By.Id("4")).SendKeys(OpenQA.Selenium.Keys.Escape);
                driver.FindElement(By.Id("4")).SendKeys(OpenQA.Selenium.Keys.Delete);
                driver.FindElement(By.Id("4")).SendKeys(toDate);
                driver.FindElement(By.Id("4")).SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch (Exception)
            {
                MessageBox.Show("Not valid information or No such element found!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                closeFile();
                Cleanup();
                driver.Dispose();
            }

            try
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("b-results")));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

                //fetching top data from the result page
                count = wait.Until(driver1 => driver.FindElements(By.XPath("//div[contains(@class,'b-results__item-wr new')]")));
                sw.Write(depCity + "\t" + arrCity + "\t" + fromDate);
                sw.Write("\t" + toDate + "\t" + url);

                using (sw)
                {
                    foreach (IWebElement price in count)
                    {
                        if (i < 2)
                        {
                            string id = price.GetAttribute("id");
                            if (id != null)
                                sw.Write("\t" + driver.FindElement(By.XPath("//div[contains(@id,'" + id + "')]/form/div/div/h3/span")).Text);
                            i++;
                        }
                        else
                        {
                            i = 0;
                            break;
                        }
                    }
                }

                replaceChar();
            }
            catch (Exception)
            {
                MessageBox.Show("No Result Found or May be something went wrong!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                closeFile();
                Cleanup();
                driver.Dispose();
            }
        }

        //Replacing the char ',' to '.'
        private void replaceChar()
        {
            try
            {
                string data = File.ReadAllText(path);
                data = data.Replace(",", ";");
                File.WriteAllText(path, data);
            }
            catch (Exception)
            {
                MessageBox.Show("File does not exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeFile();
                Cleanup();
                driver.Dispose();
            }
        }

        //Closing file at the time of exception in application
        private void closeFile()
        {
            List<string> data = File.ReadAllLines(path).ToList(); ;
            File.WriteAllLines(path, data.GetRange(0, data.Count - 1).ToArray());
            sw.Close();
        }
    }
}