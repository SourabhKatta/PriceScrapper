namespace PriceGrabber
{
    partial class frm_priceGrabber
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_passengers = new System.Windows.Forms.Label();
            this.lbl_ticketMode = new System.Windows.Forms.Label();
            this.lbl_toDate = new System.Windows.Forms.Label();
            this.cal_toDate = new System.Windows.Forms.MonthCalendar();
            this.cal_fromDate = new System.Windows.Forms.MonthCalendar();
            this.lbl_fromDate = new System.Windows.Forms.Label();
            this.txt_arrCity = new System.Windows.Forms.TextBox();
            this.lbl_arrCity = new System.Windows.Forms.Label();
            this.txt_depCity = new System.Windows.Forms.TextBox();
            this.lbl_depCity = new System.Windows.Forms.Label();
            this.grpbox_flightDetails = new System.Windows.Forms.GroupBox();
            this.btn_grabPrice = new System.Windows.Forms.Button();
            this.grpbox_flightFilters = new System.Windows.Forms.GroupBox();
            this.chkbox_tix = new System.Windows.Forms.CheckBox();
            this.chkbox_vliegBE = new System.Windows.Forms.CheckBox();
            this.chkbox_supersaver = new System.Windows.Forms.CheckBox();
            this.chkbox_cheaptickets = new System.Windows.Forms.CheckBox();
            this.chkbox_budgetair = new System.Windows.Forms.CheckBox();
            this.chkbox_schipholtickets = new System.Windows.Forms.CheckBox();
            this.chkbox_wtc = new System.Windows.Forms.CheckBox();
            this.chkbox_vliegtickets = new System.Windows.Forms.CheckBox();
            this.grpbox_result = new System.Windows.Forms.GroupBox();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.grpbox_filters = new System.Windows.Forms.GroupBox();
            this.btn_refreshResults = new System.Windows.Forms.Button();
            this.btn_newSearch = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_modifySearch = new System.Windows.Forms.Button();
            this.grpbox_finalResult = new System.Windows.Forms.GroupBox();
            this.lbl_pleaseWait = new System.Windows.Forms.Label();
            this.grpbox_flightDetails.SuspendLayout();
            this.grpbox_flightFilters.SuspendLayout();
            this.grpbox_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.grpbox_filters.SuspendLayout();
            this.grpbox_finalResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_clear.Location = new System.Drawing.Point(1037, 133);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(120, 34);
            this.btn_clear.TabIndex = 11;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_passengers
            // 
            this.lbl_passengers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_passengers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_passengers.Location = new System.Drawing.Point(1056, 93);
            this.lbl_passengers.Name = "lbl_passengers";
            this.lbl_passengers.Size = new System.Drawing.Size(81, 16);
            this.lbl_passengers.TabIndex = 10;
            this.lbl_passengers.Text = "Persons: 1";
            // 
            // lbl_ticketMode
            // 
            this.lbl_ticketMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ticketMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ticketMode.Location = new System.Drawing.Point(1033, 63);
            this.lbl_ticketMode.Name = "lbl_ticketMode";
            this.lbl_ticketMode.Size = new System.Drawing.Size(117, 20);
            this.lbl_ticketMode.TabIndex = 9;
            this.lbl_ticketMode.Text = "Return Ticket";
            // 
            // lbl_toDate
            // 
            this.lbl_toDate.AutoSize = true;
            this.lbl_toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_toDate.Location = new System.Drawing.Point(393, 63);
            this.lbl_toDate.Name = "lbl_toDate";
            this.lbl_toDate.Size = new System.Drawing.Size(74, 20);
            this.lbl_toDate.TabIndex = 7;
            this.lbl_toDate.Text = "To Date :";
            // 
            // cal_toDate
            // 
            this.cal_toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_toDate.Location = new System.Drawing.Point(489, 66);
            this.cal_toDate.MinDate = this.cal_toDate.TodayDate;
            this.cal_toDate.Name = "cal_toDate";
            this.cal_toDate.ShowTodayCircle = false;
            this.cal_toDate.TabIndex = 6;
            // 
            // cal_fromDate
            // 
            this.cal_fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_fromDate.Location = new System.Drawing.Point(149, 66);
            this.cal_fromDate.MinDate = this.cal_fromDate.TodayDate;
            this.cal_fromDate.Name = "cal_fromDate";
            this.cal_fromDate.ShowTodayCircle = false;
            this.cal_fromDate.TabIndex = 5;
            this.cal_fromDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal_fromDate_DateChanged);
            // 
            // lbl_fromDate
            // 
            this.lbl_fromDate.AutoSize = true;
            this.lbl_fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fromDate.Location = new System.Drawing.Point(24, 63);
            this.lbl_fromDate.Name = "lbl_fromDate";
            this.lbl_fromDate.Size = new System.Drawing.Size(93, 20);
            this.lbl_fromDate.TabIndex = 4;
            this.lbl_fromDate.Text = "From Date :";
            // 
            // txt_arrCity
            // 
            this.txt_arrCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_arrCity.Location = new System.Drawing.Point(489, 31);
            this.txt_arrCity.Name = "txt_arrCity";
            this.txt_arrCity.Size = new System.Drawing.Size(227, 26);
            this.txt_arrCity.TabIndex = 3;
            // 
            // lbl_arrCity
            // 
            this.lbl_arrCity.AutoSize = true;
            this.lbl_arrCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arrCity.Location = new System.Drawing.Point(393, 34);
            this.lbl_arrCity.Name = "lbl_arrCity";
            this.lbl_arrCity.Size = new System.Drawing.Size(90, 20);
            this.lbl_arrCity.TabIndex = 2;
            this.lbl_arrCity.Text = "Arrival City :";
            // 
            // txt_depCity
            // 
            this.txt_depCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_depCity.Location = new System.Drawing.Point(149, 31);
            this.txt_depCity.Name = "txt_depCity";
            this.txt_depCity.Size = new System.Drawing.Size(227, 26);
            this.txt_depCity.TabIndex = 1;
            // 
            // lbl_depCity
            // 
            this.lbl_depCity.AutoSize = true;
            this.lbl_depCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_depCity.Location = new System.Drawing.Point(24, 34);
            this.lbl_depCity.Name = "lbl_depCity";
            this.lbl_depCity.Size = new System.Drawing.Size(119, 20);
            this.lbl_depCity.TabIndex = 0;
            this.lbl_depCity.Text = "Departure City :";
            // 
            // grpbox_flightDetails
            // 
            this.grpbox_flightDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_flightDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbox_flightDetails.Controls.Add(this.btn_grabPrice);
            this.grpbox_flightDetails.Controls.Add(this.grpbox_flightFilters);
            this.grpbox_flightDetails.Controls.Add(this.btn_clear);
            this.grpbox_flightDetails.Controls.Add(this.lbl_depCity);
            this.grpbox_flightDetails.Controls.Add(this.lbl_passengers);
            this.grpbox_flightDetails.Controls.Add(this.txt_depCity);
            this.grpbox_flightDetails.Controls.Add(this.lbl_ticketMode);
            this.grpbox_flightDetails.Controls.Add(this.lbl_arrCity);
            this.grpbox_flightDetails.Controls.Add(this.lbl_toDate);
            this.grpbox_flightDetails.Controls.Add(this.txt_arrCity);
            this.grpbox_flightDetails.Controls.Add(this.cal_toDate);
            this.grpbox_flightDetails.Controls.Add(this.lbl_fromDate);
            this.grpbox_flightDetails.Controls.Add(this.cal_fromDate);
            this.grpbox_flightDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbox_flightDetails.Location = new System.Drawing.Point(12, 12);
            this.grpbox_flightDetails.Name = "grpbox_flightDetails";
            this.grpbox_flightDetails.Size = new System.Drawing.Size(1186, 321);
            this.grpbox_flightDetails.TabIndex = 1;
            this.grpbox_flightDetails.TabStop = false;
            this.grpbox_flightDetails.Text = "Flight Details";
            // 
            // btn_grabPrice
            // 
            this.btn_grabPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_grabPrice.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_grabPrice.Location = new System.Drawing.Point(1037, 171);
            this.btn_grabPrice.Name = "btn_grabPrice";
            this.btn_grabPrice.Size = new System.Drawing.Size(120, 34);
            this.btn_grabPrice.TabIndex = 12;
            this.btn_grabPrice.Text = "Grab Price";
            this.btn_grabPrice.UseVisualStyleBackColor = false;
            this.btn_grabPrice.Click += new System.EventHandler(this.btn_grabPrice_Click);
            // 
            // grpbox_flightFilters
            // 
            this.grpbox_flightFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_flightFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbox_flightFilters.Controls.Add(this.chkbox_tix);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_vliegBE);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_supersaver);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_cheaptickets);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_budgetair);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_schipholtickets);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_wtc);
            this.grpbox_flightFilters.Controls.Add(this.chkbox_vliegtickets);
            this.grpbox_flightFilters.Location = new System.Drawing.Point(6, 240);
            this.grpbox_flightFilters.Name = "grpbox_flightFilters";
            this.grpbox_flightFilters.Size = new System.Drawing.Size(1174, 68);
            this.grpbox_flightFilters.TabIndex = 8;
            this.grpbox_flightFilters.TabStop = false;
            this.grpbox_flightFilters.Text = "Flight Sources";
            // 
            // chkbox_tix
            // 
            this.chkbox_tix.AutoSize = true;
            this.chkbox_tix.Location = new System.Drawing.Point(941, 28);
            this.chkbox_tix.Name = "chkbox_tix";
            this.chkbox_tix.Size = new System.Drawing.Size(63, 24);
            this.chkbox_tix.TabIndex = 7;
            this.chkbox_tix.Text = "Tix.nl";
            this.chkbox_tix.UseVisualStyleBackColor = true;
            this.chkbox_tix.CheckedChanged += new System.EventHandler(this.chkbox_tix_CheckedChanged);
            // 
            // chkbox_vliegBE
            // 
            this.chkbox_vliegBE.AutoSize = true;
            this.chkbox_vliegBE.Location = new System.Drawing.Point(804, 28);
            this.chkbox_vliegBE.Name = "chkbox_vliegBE";
            this.chkbox_vliegBE.Size = new System.Drawing.Size(131, 24);
            this.chkbox_vliegBE.TabIndex = 6;
            this.chkbox_vliegBE.Text = "Vliegtickets.be";
            this.chkbox_vliegBE.UseVisualStyleBackColor = true;
            this.chkbox_vliegBE.CheckedChanged += new System.EventHandler(this.chkbox_vliegBE_CheckedChanged);
            // 
            // chkbox_supersaver
            // 
            this.chkbox_supersaver.AutoSize = true;
            this.chkbox_supersaver.Location = new System.Drawing.Point(674, 28);
            this.chkbox_supersaver.Name = "chkbox_supersaver";
            this.chkbox_supersaver.Size = new System.Drawing.Size(125, 24);
            this.chkbox_supersaver.TabIndex = 5;
            this.chkbox_supersaver.Text = "Supersaver.nl";
            this.chkbox_supersaver.UseVisualStyleBackColor = true;
            this.chkbox_supersaver.CheckedChanged += new System.EventHandler(this.chkbox_supersaver_CheckedChanged);
            // 
            // chkbox_cheaptickets
            // 
            this.chkbox_cheaptickets.AutoSize = true;
            this.chkbox_cheaptickets.Location = new System.Drawing.Point(531, 28);
            this.chkbox_cheaptickets.Name = "chkbox_cheaptickets";
            this.chkbox_cheaptickets.Size = new System.Drawing.Size(137, 24);
            this.chkbox_cheaptickets.TabIndex = 4;
            this.chkbox_cheaptickets.Text = "Cheaptickets.nl";
            this.chkbox_cheaptickets.UseVisualStyleBackColor = true;
            this.chkbox_cheaptickets.CheckedChanged += new System.EventHandler(this.chkbox_cheaptickets_CheckedChanged);
            // 
            // chkbox_budgetair
            // 
            this.chkbox_budgetair.AutoSize = true;
            this.chkbox_budgetair.Location = new System.Drawing.Point(412, 28);
            this.chkbox_budgetair.Name = "chkbox_budgetair";
            this.chkbox_budgetair.Size = new System.Drawing.Size(113, 24);
            this.chkbox_budgetair.TabIndex = 3;
            this.chkbox_budgetair.Text = "Budgetair.nl";
            this.chkbox_budgetair.UseVisualStyleBackColor = true;
            this.chkbox_budgetair.CheckedChanged += new System.EventHandler(this.chkbox_budgetair_CheckedChanged);
            // 
            // chkbox_schipholtickets
            // 
            this.chkbox_schipholtickets.AutoSize = true;
            this.chkbox_schipholtickets.Location = new System.Drawing.Point(253, 28);
            this.chkbox_schipholtickets.Name = "chkbox_schipholtickets";
            this.chkbox_schipholtickets.Size = new System.Drawing.Size(151, 24);
            this.chkbox_schipholtickets.TabIndex = 2;
            this.chkbox_schipholtickets.Text = "Schipholtickets.nl";
            this.chkbox_schipholtickets.UseVisualStyleBackColor = true;
            this.chkbox_schipholtickets.CheckedChanged += new System.EventHandler(this.chkbox_schipholtickets_CheckedChanged);
            // 
            // chkbox_wtc
            // 
            this.chkbox_wtc.AutoSize = true;
            this.chkbox_wtc.Location = new System.Drawing.Point(156, 28);
            this.chkbox_wtc.Name = "chkbox_wtc";
            this.chkbox_wtc.Size = new System.Drawing.Size(79, 24);
            this.chkbox_wtc.TabIndex = 1;
            this.chkbox_wtc.Text = "WTC.nl";
            this.chkbox_wtc.UseVisualStyleBackColor = true;
            this.chkbox_wtc.CheckedChanged += new System.EventHandler(this.chkbox_wtc_CheckedChanged);
            // 
            // chkbox_vliegtickets
            // 
            this.chkbox_vliegtickets.AutoSize = true;
            this.chkbox_vliegtickets.Location = new System.Drawing.Point(21, 28);
            this.chkbox_vliegtickets.Name = "chkbox_vliegtickets";
            this.chkbox_vliegtickets.Size = new System.Drawing.Size(125, 24);
            this.chkbox_vliegtickets.TabIndex = 0;
            this.chkbox_vliegtickets.Text = "Vliegtickets.nl";
            this.chkbox_vliegtickets.UseVisualStyleBackColor = true;
            this.chkbox_vliegtickets.CheckedChanged += new System.EventHandler(this.chkbox_vliegtickets_CheckedChanged);
            // 
            // grpbox_result
            // 
            this.grpbox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_result.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbox_result.Controls.Add(this.dgv_result);
            this.grpbox_result.Location = new System.Drawing.Point(6, 19);
            this.grpbox_result.Name = "grpbox_result";
            this.grpbox_result.Size = new System.Drawing.Size(974, 354);
            this.grpbox_result.TabIndex = 2;
            this.grpbox_result.TabStop = false;
            this.grpbox_result.Text = "Grab Price Result";
            // 
            // dgv_result
            // 
            this.dgv_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_result.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_result.BackgroundColor = System.Drawing.Color.White;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(6, 25);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(962, 313);
            this.dgv_result.TabIndex = 0;
            // 
            // grpbox_filters
            // 
            this.grpbox_filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbox_filters.Controls.Add(this.btn_refreshResults);
            this.grpbox_filters.Controls.Add(this.btn_newSearch);
            this.grpbox_filters.Controls.Add(this.btn_export);
            this.grpbox_filters.Controls.Add(this.btn_modifySearch);
            this.grpbox_filters.Location = new System.Drawing.Point(986, 19);
            this.grpbox_filters.Name = "grpbox_filters";
            this.grpbox_filters.Size = new System.Drawing.Size(194, 354);
            this.grpbox_filters.TabIndex = 3;
            this.grpbox_filters.TabStop = false;
            this.grpbox_filters.Text = "Available Options";
            // 
            // btn_refreshResults
            // 
            this.btn_refreshResults.Location = new System.Drawing.Point(26, 152);
            this.btn_refreshResults.Name = "btn_refreshResults";
            this.btn_refreshResults.Size = new System.Drawing.Size(145, 32);
            this.btn_refreshResults.TabIndex = 3;
            this.btn_refreshResults.Text = "Refresh Results";
            this.btn_refreshResults.UseVisualStyleBackColor = true;
            this.btn_refreshResults.Click += new System.EventHandler(this.btn_refreshResults_Click);
            // 
            // btn_newSearch
            // 
            this.btn_newSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_newSearch.Location = new System.Drawing.Point(26, 35);
            this.btn_newSearch.Name = "btn_newSearch";
            this.btn_newSearch.Size = new System.Drawing.Size(145, 32);
            this.btn_newSearch.TabIndex = 2;
            this.btn_newSearch.Text = "New Search";
            this.btn_newSearch.UseVisualStyleBackColor = false;
            this.btn_newSearch.Click += new System.EventHandler(this.btn_newSearch_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_export.Location = new System.Drawing.Point(26, 113);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(145, 32);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "Export as CSV";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_modifySearch
            // 
            this.btn_modifySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_modifySearch.AutoSize = true;
            this.btn_modifySearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_modifySearch.Location = new System.Drawing.Point(26, 73);
            this.btn_modifySearch.Name = "btn_modifySearch";
            this.btn_modifySearch.Size = new System.Drawing.Size(145, 34);
            this.btn_modifySearch.TabIndex = 0;
            this.btn_modifySearch.Text = "Modify Search";
            this.btn_modifySearch.UseVisualStyleBackColor = false;
            this.btn_modifySearch.Click += new System.EventHandler(this.btn_modifySearch_Click);
            // 
            // grpbox_finalResult
            // 
            this.grpbox_finalResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_finalResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpbox_finalResult.Controls.Add(this.grpbox_filters);
            this.grpbox_finalResult.Controls.Add(this.grpbox_result);
            this.grpbox_finalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbox_finalResult.Location = new System.Drawing.Point(12, 339);
            this.grpbox_finalResult.Name = "grpbox_finalResult";
            this.grpbox_finalResult.Size = new System.Drawing.Size(1186, 379);
            this.grpbox_finalResult.TabIndex = 4;
            this.grpbox_finalResult.TabStop = false;
            // 
            // lbl_pleaseWait
            // 
            this.lbl_pleaseWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_pleaseWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_pleaseWait.Font = new System.Drawing.Font("Script MT Bold", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pleaseWait.ForeColor = System.Drawing.Color.Blue;
            this.lbl_pleaseWait.Location = new System.Drawing.Point(-6, 200);
            this.lbl_pleaseWait.Name = "lbl_pleaseWait";
            this.lbl_pleaseWait.Size = new System.Drawing.Size(1215, 330);
            this.lbl_pleaseWait.TabIndex = 0;
            this.lbl_pleaseWait.Text = "Please wait... While we get the data!";
            this.lbl_pleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_priceGrabber
            // 
            this.AcceptButton = this.btn_grabPrice;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 730);
            this.Controls.Add(this.lbl_pleaseWait);
            this.Controls.Add(this.grpbox_finalResult);
            this.Controls.Add(this.grpbox_flightDetails);
            this.Name = "frm_priceGrabber";
            this.Text = "Price Grabber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_priceGrabber_Load);
            this.grpbox_flightDetails.ResumeLayout(false);
            this.grpbox_flightDetails.PerformLayout();
            this.grpbox_flightFilters.ResumeLayout(false);
            this.grpbox_flightFilters.PerformLayout();
            this.grpbox_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.grpbox_filters.ResumeLayout(false);
            this.grpbox_filters.PerformLayout();
            this.grpbox_finalResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_depCity;
        private System.Windows.Forms.TextBox txt_depCity;
        private System.Windows.Forms.TextBox txt_arrCity;
        private System.Windows.Forms.Label lbl_arrCity;
        private System.Windows.Forms.Label lbl_fromDate;
        private System.Windows.Forms.MonthCalendar cal_fromDate;
        private System.Windows.Forms.Label lbl_toDate;
        private System.Windows.Forms.MonthCalendar cal_toDate;
        private System.Windows.Forms.Label lbl_ticketMode;
        private System.Windows.Forms.Label lbl_passengers;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.GroupBox grpbox_flightDetails;
        private System.Windows.Forms.GroupBox grpbox_flightFilters;
        private System.Windows.Forms.CheckBox chkbox_vliegtickets;
        private System.Windows.Forms.CheckBox chkbox_supersaver;
        private System.Windows.Forms.CheckBox chkbox_cheaptickets;
        private System.Windows.Forms.CheckBox chkbox_budgetair;
        private System.Windows.Forms.CheckBox chkbox_schipholtickets;
        private System.Windows.Forms.CheckBox chkbox_wtc;
        private System.Windows.Forms.Button btn_grabPrice;
        private System.Windows.Forms.GroupBox grpbox_result;
        private System.Windows.Forms.GroupBox grpbox_filters;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button btn_modifySearch;
        private System.Windows.Forms.GroupBox grpbox_finalResult;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.CheckBox chkbox_vliegBE;
        private System.Windows.Forms.CheckBox chkbox_tix;
        private System.Windows.Forms.Button btn_newSearch;
        private System.Windows.Forms.Button btn_refreshResults;
        private System.Windows.Forms.Label lbl_pleaseWait;
    }
}

