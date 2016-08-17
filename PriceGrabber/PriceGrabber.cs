using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Otravo;
using CheapAndBudget;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace PriceGrabber
{
    public partial class frm_priceGrabber : Form
    {
        public string departureCity = string.Empty, arrivalCity = string.Empty, fromDate = string.Empty, toDate = string.Empty;
        string[] textData;
        public List<string> webSource = new List<string>();
        DataTable dt = new DataTable();

        public frm_priceGrabber()
        {
            InitializeComponent();
        }

        /*
        ** 
        Calling clearAllFields() method.
        **
        */
        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        /*
        ** 
        Clear the information filled by user for the flight price search.
        **
        */
        private void clearAllFields()
        {
            txt_depCity.Text = "";
            txt_arrCity.Text = "";
            cal_fromDate.SelectionStart = cal_fromDate.TodayDate;
            cal_fromDate.SelectionEnd = cal_fromDate.TodayDate;
            cal_toDate.SelectionStart = cal_toDate.TodayDate;
            cal_toDate.SelectionEnd = cal_toDate.TodayDate;
            chkbox_budgetair.Checked = false;
            chkbox_cheaptickets.Checked = false;
            chkbox_schipholtickets.Checked = false;
            chkbox_supersaver.Checked = false;
            chkbox_wtc.Checked = false;
            chkbox_vliegtickets.Checked = false;
            chkbox_vliegBE.Checked = false;
            chkbox_tix.Checked = false;
            webSource.Clear();
        }

        /*
        ** 
        Setting the minimum date for return calender as selection of from calenders date.
        **
        */
        private void cal_fromDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            cal_toDate.MinDate = Convert.ToDateTime(cal_fromDate.SelectionRange.Start.ToShortDateString());
        }

        /*
        ** 
        Main Entry Point: 
        Getting the price from different-different web sources
        **
        */
        private void btn_grabPrice_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                MessageBox.Show("Please fill all the details!", "Invalid form sumbittion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Wait screen
                lbl_pleaseWait.Visible = true;
                Thread.Sleep(2000);

                getDataForSearch();

                //making groupbox enable and disable for the result
                grpbox_flightDetails.Enabled = false;

                //Visible the modify search option
                btn_modifySearch.Visible = true;
                btn_newSearch.Visible = true;

                //Actual processing for the data fetch.
                processData();
            }
        }
        
        private void processData()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                for (int x = 0; x < webSource.Count; x++)
                {
                    if (webSource[x].ToString() == "vliegtickets.nl")
                    {
                        var testClass = new vliegtickets() { arrCity = arrivalCity, depCity = departureCity, fromDate = fromDate, toDate = toDate, url = "http://www.vliegtickets.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "wtc.nl")
                    {
                        var testClass = new wtc() { arrCity = arrivalCity, depCity = departureCity, fromDate = fromDate, toDate = toDate, url = "http://www.wtc.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "schipholtickets.nl")
                    {
                        var testClass = new schipholtickets() { arrCity = arrivalCity, depCity = departureCity, fromDate = fromDate, toDate = toDate, url = "http://www.schipholtickets.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "cheaptickets.nl")
                    {
                        var testClass = new cheaptickets() { arrCity = arrivalCity, depCity = departureCity, depDay = cal_fromDate.SelectionRange.Start.Day.ToString(), arrDay = cal_toDate.SelectionRange.Start.Day.ToString(), depMonth = cal_fromDate.SelectionRange.Start.Month.ToString(), arrMonth = cal_toDate.SelectionRange.Start.Month.ToString(), depDate = fromDate, returnDate = toDate, url = "http://www.cheaptickets.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "budgetair.nl")
                    {
                        var testClass = new budgetair() { arrCity = arrivalCity, depCity = departureCity, depDay = cal_fromDate.SelectionRange.Start.Day.ToString(), arrDay = cal_toDate.SelectionRange.Start.Day.ToString(), depMonth = cal_fromDate.SelectionRange.Start.Month.ToString(), arrMonth = cal_toDate.SelectionRange.Start.Month.ToString(), depDate = fromDate, returnDate = toDate, url = "http://www.budgetair.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "supersaver.nl")
                    {
                        var testClass = new supersaver() { arrCity = arrivalCity, depCity = departureCity, fromDate = cal_fromDate.SelectionRange.Start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), toDate = cal_toDate.SelectionRange.Start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), depDate = fromDate, returnDate = toDate, url = "http://www.supersaver.nl" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "vliegtickets.be")
                    {
                        var testClass = new vliegtickets() { arrCity = arrivalCity, depCity = departureCity, fromDate = fromDate, toDate = toDate, url = "http://www.vliegtickets.be" };
                        testClass.GetLowestPrice();
                    }
                    else if (webSource[x].ToString() == "tix.nl")
                    {
                        var testClass = new tix() { arrCity = arrivalCity, depCity = departureCity, depDay = cal_fromDate.SelectionRange.Start.Day.ToString(), depMonth = cal_fromDate.SelectionRange.Start.Month.ToString(), arrDay = cal_toDate.SelectionRange.Start.Day.ToString(), arrMonth =cal_toDate.SelectionRange.Start.Month.ToString(), depDate = fromDate, returnDate = toDate, url = "http://www.tix.nl" };
                        testClass.GetLowestPrice();
                    }
                }

                lbl_pleaseWait.Visible = false;
                MessageBox.Show("Thank you for waiting! Here is the updated result...", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;

                //Refreshing the result
                getBestPrice();
            }
            catch (Exception ex)
            {
                //Popup wait screen and error message
                MessageBox.Show("Oops! Something went wrong during search.", "Invalid search!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;

                //Force closing all opened chrome windows.
                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
                foreach (var chromeDriver in chromeDriverProcesses)
                    chromeDriver.Kill();

                //making groupbox enable and disable for the result
                grpbox_flightDetails.Enabled = true;

                //Visible the modify search option
                btn_modifySearch.Visible = false;
                btn_newSearch.Visible = false;
                lbl_pleaseWait.Visible = false;

                //Clear all the fields
                clearAllFields();
            }
        }

        /*
        ** 
        Modify Search button functionality
        **
        */
        private void btn_modifySearch_Click(object sender, EventArgs e)
        {
            grpbox_flightDetails.Enabled = true;
            grpbox_finalResult.Enabled = false;
        }

        /*
        ** 
        Showcasing the data: Reading information from file and binding the information with dataGridView control.
        **
        */
        private void getBestPrice()
        {
            try
            {
                //Clearing old data of the dataTable
                dt.Clear();

                //Reading data from file
                textData = File.ReadAllLines(@"GrabbedPrice.txt");

                //Adding data from file to Datatable
                for (int i = (textData.Length - 1); i >= 0; i--)
                    dt.Rows.Add(textData[i].Split('\t'));

                //Updating DataGridView
                dgv_result.Update();
                dgv_result.Refresh();
            }
            catch (Exception ex)
            {
                //Popup wait screen and error message
                MessageBox.Show("Oops! File is not ready for providing data.", "Data Fetch Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                
                //making groupbox enable and disable for the result
                grpbox_flightDetails.Enabled = true;

                //Visible the modify search option
                btn_modifySearch.Visible = false;
                btn_newSearch.Visible = false;
                lbl_pleaseWait.Visible = false;

                //Clear all the fields
                clearAllFields();
            }
        }

        /*
        ** 
        Validation check before the grab price button clicked
        **
        */
        private bool checkValidation()
        {
            if (txt_depCity.Text.Equals("") && txt_arrCity.Text.Equals("") && (!chkbox_vliegtickets.Checked && !chkbox_wtc.Checked && !chkbox_supersaver.Checked && !chkbox_schipholtickets.Checked && !chkbox_cheaptickets.Checked && !chkbox_budgetair.Checked && !chkbox_vliegBE.Checked && !chkbox_tix.Checked))
                return true;
            else if (txt_arrCity.Text.Equals("") && (!chkbox_vliegtickets.Checked && !chkbox_wtc.Checked && !chkbox_supersaver.Checked && !chkbox_schipholtickets.Checked && !chkbox_cheaptickets.Checked && !chkbox_budgetair.Checked && !chkbox_vliegBE.Checked && !chkbox_tix.Checked))
                return true;
            else if (txt_depCity.Text.Equals("") && (!chkbox_vliegtickets.Checked && !chkbox_wtc.Checked && !chkbox_supersaver.Checked && !chkbox_schipholtickets.Checked && !chkbox_cheaptickets.Checked && !chkbox_budgetair.Checked && !chkbox_vliegBE.Checked && !chkbox_tix.Checked))
                return true;
            else if (!chkbox_vliegtickets.Checked && !chkbox_wtc.Checked && !chkbox_supersaver.Checked && !chkbox_schipholtickets.Checked && !chkbox_cheaptickets.Checked && !chkbox_budgetair.Checked && !chkbox_vliegBE.Checked && !chkbox_tix.Checked)
                return true;
            else
                return false;
        }

        private void chkbox_vliegtickets_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_vliegtickets.Text.ToLower().ToString());
        }

        private void chkbox_wtc_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_wtc.Text.ToLower().ToString());
        }

        private void chkbox_schipholtickets_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_schipholtickets.Text.ToLower().ToString());
        }

        private void chkbox_budgetair_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_budgetair.Text.ToLower().ToString());
        }

        private void chkbox_cheaptickets_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_cheaptickets.Text.ToLower().ToString());
        }

        private void chkbox_supersaver_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_supersaver.Text.ToLower().ToString());
        }

        /*
        ** 
        WinForm load method.
        **
        */
        private void frm_priceGrabber_Load(object sender, EventArgs e)
        {
            //Preloading the searched data
            loadOldSearchRecords();
            
            //Hiding the modify search and new search button on form load 
            btn_modifySearch.Visible = false;
            btn_newSearch.Visible = false;
            lbl_pleaseWait.Visible = false;
        }

        /*
        ** 
        Preloading the searched Data.
        **
        */
        private void loadOldSearchRecords()
        {
            try
            {
                //Reading data from file
                textData = File.ReadAllLines(@"GrabbedPrice.txt");

                //Adding columns to the DataGridView
                dt.Columns.Add("Departure City");
                dt.Columns.Add("Arrival City");
                dt.Columns.Add("From Date");
                dt.Columns.Add("To Date");
                dt.Columns.Add("Source");
                dt.Columns.Add("Best Price");
                dt.Columns.Add("II Best Price");

                //Adding data from file to Datatable
                for (int i = (textData.Length - 1); i >= 0; i--)
                    dt.Rows.Add(textData[i].Split('\t'));

                //Binding dataTable to DataGridView
                dgv_result.DataSource = dt;
            }
            catch(Exception)
            {
                MessageBox.Show("No search history!", "Search History!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkbox_vliegBE_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_vliegBE.Text.ToLower().ToString());
        }

        private void chkbox_tix_CheckedChanged(object sender, EventArgs e)
        {
            getWebSource(chkbox_tix.Text.ToLower().ToString());
        }

        /*
        ** 
        Making new search
        **
        */
        private void btn_newSearch_Click(object sender, EventArgs e)
        {
            clearAllFields();
            grpbox_flightDetails.Enabled = true;
            grpbox_finalResult.Enabled = false;
        }

        /*
        ** 
        Refreshing the records after search.
        **
        */
        private void btn_refreshResults_Click(object sender, EventArgs e)
        {
            getBestPrice();
        }

        /*
        ** 
        Exporting dataGridView Information to CSV format.
        **
        */
        private void btn_export_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Data will be exported and you will be notified when it is ready.");
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                int columnCount = dgv_result.ColumnCount;
                string columnNames = "";
                string[] output = new string[dgv_result.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += dgv_result.Columns[i].Name.ToString() + ",";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < (dgv_result.RowCount - 1); i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += dgv_result.Rows[i - 1].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Your file was generated and its ready for use.");
            }
        }

        /*
        **
        Checking the website sources which are checked during the search. 
        On base of all checked webSources, the price grabber will be called. 
        **
        */
        private void getWebSource(string flightSource)
        {
            if (webSource.Exists(x => x == flightSource))
                webSource.Remove(flightSource);
            else
                webSource.Add(flightSource);
        }

        /*
        **
        Get and set the information for search criteia filled by user.
        **
        */
        private void getDataForSearch()
        {
            departureCity = txt_depCity.Text;
            arrivalCity = txt_arrCity.Text;
            fromDate = cal_fromDate.SelectionRange.Start.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            toDate = cal_toDate.SelectionRange.Start.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
