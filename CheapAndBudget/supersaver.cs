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
    public class supersaver
    {
        public string depCity, arrCity, fromDate, toDate, path = @"GrabbedPrice.txt", url, depDate, returnDate;
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
                driver.FindElement(By.Name("fromCity")).SendKeys(depCity);
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[contains(@id,'ui-id-1')]")));
                driver.FindElement(By.XPath("//ul[contains(@id,'ui-id-1')]/li")).Click();
                driver.FindElement(By.Name("toCity")).SendKeys(arrCity);
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[contains(@id,'ui-id-2')]")));
                driver.FindElement(By.XPath("//ul[contains(@id,'ui-id-2')]/li")).Click();
                js.ExecuteScript("document.getElementById('alt_outDateId').value='" + fromDate + "'");
                js.ExecuteScript("document.getElementById('alt_returnDateId').value='" + toDate + "'");

                //calling the custome data search
                driver.FindElement(By.Id("airSubmitButtonId")).Click();
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
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("airResultListContainer")));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

                //fetching top data from the result page
                count = wait.Until(driver1 => driver.FindElements(By.XPath("//div[contains(@class,'tripItemContainer')]")));
                sw.Write(depCity + "\t" + arrCity + "\t" + depDate);
                sw.Write("\t" + returnDate + "\t" + url);

                using (sw)
                {
                    foreach (IWebElement price in count)
                    {
                        if (i < 2)
                        {
                            string id = price.GetAttribute("id");
                            if (id != null)
                                sw.Write("\t" + driver.FindElement(By.XPath("//div[contains(@id,'" + id + "')]/div[contains(@class,'tripItemContent')]/div/table/tbody/tr/td[contains(@class,'tripItemRightContent')]/div/div")).Text);
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