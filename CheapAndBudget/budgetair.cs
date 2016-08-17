using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace CheapAndBudget
{
    [TestClass]
    public class budgetair
    {
        public string depCity, arrCity, path = @"GrabbedPrice.txt", url, depDate, returnDate, depMonth, arrMonth, depDay, arrDay;
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
                driver.FindElement(By.XPath("//input[contains(@tabindex,'1')]")).Click();
                driver.FindElement(By.XPath("//input[contains(@tabindex,'1')]")).SendKeys(depCity);
                //need to put some wait
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@data-reactid,'.0.0.2.2.0.2.4.0')]/ul/li")));
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[contains(@data-reactid,'.0.0.2.2.0.2.4.0')]/ul/li")).Click();
                driver.FindElement(By.XPath("//input[contains(@tabindex,'2')]")).Click();
                driver.FindElement(By.XPath("//input[contains(@tabindex,'2')]")).SendKeys(arrCity);
                //need to put some wait
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@data-reactid,'.0.0.2.2.1.2.4.0')]/ul/li")));
                driver.FindElement(By.XPath("//div[contains(@data-reactid,'.0.0.2.2.1.2.4.0')]/ul/li")).Click();

                //TODO: date from calender
                driver.FindElement(By.Id("sb_homeMain-departureBtn")).Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.0.1.1')]/tbody//td[contains(@data-day,'" + depDay + "')]")));
                string currDepMonth = driver.FindElement(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.0.1.1')]/tbody/tr[2]/td")).GetAttribute("data-month");
                if (Convert.ToInt32(currDepMonth) != (Convert.ToInt32(depMonth) - 1))
                {
                    driver.FindElement(By.XPath("//button[contains(@data-reactid,'.0.0.2.3.2.4.0.0.1.0.2')]")).Click();
                    driver.FindElement(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.0.1.1')]/tbody//td[contains(@data-day,'" + depDay + "')]")).Click();
                }
                else
                    driver.FindElement(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.0.1.1')]/tbody//td[contains(@data-day,'" + depDay + "')]")).Click();
                //driver.FindElement(By.Id("sb_homeMain-destinationBtn")).Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.1')]/tbody//td[contains(@data-day,'" + arrDay + "')]")));
                string currArrMonth = driver.FindElement(By.XPath("//div[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1')]//table[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.1')]/tbody/tr[2]/td")).GetAttribute("data-month");
                if (Convert.ToInt32(currArrMonth) != (Convert.ToInt32(arrMonth) - 1))
                {
                    driver.FindElement(By.XPath("//button[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.0.2')]")).Click();
                    driver.FindElement(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.1')]/tbody//td[contains(@data-month,'"+ (Convert.ToInt32(arrMonth) - 1) + "')][contains(@data-day,'" + arrDay + "')]")).Click();
                }
                else
                    driver.FindElement(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.1')]/tbody//td[contains(@data-month,'" + (Convert.ToInt32(arrMonth) - 1) + "')][contains(@data-day,'" + arrDay + "')]")).Click();

                //calling the custome data search
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[contains(@data-reactid,'.0.0.2.3.2.4.0.1.1.1')]")));
                driver.FindElement(By.XPath("//button[contains(@class,'submit-button')]")).Click();
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
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("flight-results-section")));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));

                //fetching top data from the result page
                count = wait.Until(driver1 => driver.FindElements(By.XPath("//div[contains(@class,'flight-card flight-card--has-promotion')]")));
                sw.Write(depCity + "\t" + arrCity + "\t" + depDate);
                sw.Write("\t" + returnDate + "\t" + url);

                using (sw)
                {
                    foreach (IWebElement price in count)
                    {
                        if (i < 2)
                        {
                            string id = price.GetAttribute("data-reactid");
                            if (id != null)
                                sw.Write("\t" + driver.FindElement(By.XPath("//div[contains(@data-reactid,'" + id + "')]/div/div[contains(@class,'flight-card__fares')]/div[contains(@class,'flight-card__price-wrapper')]/div[contains(@class,'price price-underlined')]")).Text);
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

        //Replacing the char ',' to ';'
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