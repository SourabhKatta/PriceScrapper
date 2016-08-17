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

namespace CheapAndBudget
{
    [TestClass]
    public class tix
    {
        public string depCity, arrCity, path = @"GrabbedPrice.txt", url, depDate, returnDate, depMonth, arrMonth, depDay, arrDay;
        IWebDriver driver;
        IJavaScriptExecutor js;
        IReadOnlyCollection<IWebElement> count;
        int i = 2;
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
                driver.FindElement(By.Id("form-search-flights-params-main-search-box-f")).Click();
                driver.FindElement(By.XPath("//input[contains(@id,'flight-from-main-search-box-f')]")).SendKeys(depCity);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[contains(@id,'flight-from-main-search-box-f')]")).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[contains(@id,'ui-id-18')]")));
                driver.FindElement(By.XPath("//ul[contains(@id,'ui-id-18')]/li")).Click();
                driver.FindElement(By.XPath("//input[contains(@id,'flight-to-main-search-box-f')]")).SendKeys(arrCity);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[contains(@id,'flight-to-main-search-box-f')]")).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[contains(@id,'ui-id-19')]")));
                driver.FindElement(By.XPath("//ul[contains(@id,'ui-id-19')]/li")).Click();
                Thread.Sleep(1000);

                js.ExecuteScript("document.getElementById('flight-departure-date-main-search-box-f').value='" + depDate + "'");
                js.ExecuteScript("document.getElementById('flight-return-date-main-search-box-f').value='" + returnDate + "'");

                driver.FindElement(By.XPath("//*[@id='form-search-flights-params-main-search-box-f']/div[3]/div[2]/div/button")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//div[contains(@class,'departure-date')]/div[contains(@class,'date-picker-overlay')]")).Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class,'date-picker-months-list hasDatepicker')]")));
                driver.FindElement(By.XPath("//td[contains(@data-month,'" + (Convert.ToInt32(depMonth) - 1).ToString() + "')]/a[text()='" + depDay + "']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[contains(@class,'return-date')]/div[contains(@class,'date-picker invalid row')]/div[contains(@class,'date-picker-overlay')]")).Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class,'date-picker-months-list hasDatepicker')]")));
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//td[contains(@data-month,'" + (Convert.ToInt32(arrMonth) - 1).ToString() + "')]/a[text()='" + arrDay + "']")).Click();
                Thread.Sleep(2000);

                //calling the custome data search
                driver.FindElement(By.XPath("//*[@id='form-search-flights-params-left-panel-search-box-f']/div[3]/div[2]/div/button")).Click();
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
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("search-results")));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

                //fetching top data from the result page
                count = wait.Until(driver1 => driver.FindElements(By.XPath("//div[contains(@class,'row search-result-item')]")));
                sw.Write(depCity + "\t" + arrCity + "\t" + depDate);
                sw.Write("\t" + returnDate + "\t" + url);

                using (sw)
                {
                    foreach (IWebElement price in count)
                    {
                        if (i < 4)
                        {
                            string id = price.GetAttribute("data-flight-id");
                            if (id != null)
                                sw.Write("\t" + driver.FindElement(By.XPath("//div[contains(@data-flight-id,'" + id + "')]/div/div/div[contains(@class,'hide-for-small-only')]/div/div/div[contains(@class,'price')]/div/span[contains(@class,'price-custom')]")).Text);
                            i++;
                        }
                        else
                        {
                            i = 2;
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
                data = data.Replace("\r\np.p.", "");
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