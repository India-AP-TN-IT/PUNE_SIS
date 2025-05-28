namespace Ax.SIS.SD.UI
{
    partial class ZSDE6000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSDE6000));
            this.grpSearch01 = new System.Windows.Forms.GroupBox();
            this.cbl01_VALIDATION_STATUS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_INVOICE_STATUS = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_Search = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_Search = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_INVOICE_STATUS = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbl01_CustCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_VALIDATION_FLAG = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CUSTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grdDet = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelEWayBill = new Ax.DEV.Utility.Controls.AxButton();
            this.btnCancelIRN = new Ax.DEV.Utility.Controls.AxButton();
            this.btnGetIRNDetails = new Ax.DEV.Utility.Controls.AxButton();
            this.btnGetEWayBillDetails = new Ax.DEV.Utility.Controls.AxButton();
            this.grpSearch01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VALIDATION_STATUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INVOICE_STATUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INVOICE_STATUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VALIDATION_FLAG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Location = new System.Drawing.Point(0, 83);
            this._buttonsControl.Size = new System.Drawing.Size(1327, 34);
            // 
            // grpSearch01
            // 
            this.grpSearch01.Controls.Add(this.cbl01_VALIDATION_STATUS);
            this.grpSearch01.Controls.Add(this.cbl01_INVOICE_STATUS);
            this.grpSearch01.Controls.Add(this.lbl01_Search);
            this.grpSearch01.Controls.Add(this.txt01_Search);
            this.grpSearch01.Controls.Add(this.lbl01_INVOICE_STATUS);
            this.grpSearch01.Controls.Add(this.axLabel1);
            this.grpSearch01.Controls.Add(this.lbl01_DASH);
            this.grpSearch01.Controls.Add(this.dte01_EDATE);
            this.grpSearch01.Controls.Add(this.dte01_SDATE);
            this.grpSearch01.Controls.Add(this.cbl01_CustCD);
            this.grpSearch01.Controls.Add(this.lbl01_VALIDATION_FLAG);
            this.grpSearch01.Controls.Add(this.lbl01_CUSTCD);
            this.grpSearch01.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch01.Location = new System.Drawing.Point(0, 0);
            this.grpSearch01.Name = "grpSearch01";
            this.grpSearch01.Size = new System.Drawing.Size(1327, 83);
            this.grpSearch01.TabIndex = 9;
            this.grpSearch01.TabStop = false;
            // 
            // cbl01_VALIDATION_STATUS
            // 
            this.cbl01_VALIDATION_STATUS.AddItemSeparator = ';';
            this.cbl01_VALIDATION_STATUS.Caption = "";
            this.cbl01_VALIDATION_STATUS.CaptionHeight = 17;
            this.cbl01_VALIDATION_STATUS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_VALIDATION_STATUS.ColumnCaptionHeight = 18;
            this.cbl01_VALIDATION_STATUS.ColumnFooterHeight = 18;
            this.cbl01_VALIDATION_STATUS.ContentHeight = 19;
            this.cbl01_VALIDATION_STATUS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_VALIDATION_STATUS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_VALIDATION_STATUS.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_VALIDATION_STATUS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_VALIDATION_STATUS.EditorHeight = 19;
            this.cbl01_VALIDATION_STATUS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_VALIDATION_STATUS.Images"))));
            this.cbl01_VALIDATION_STATUS.ItemHeight = 15;
            this.cbl01_VALIDATION_STATUS.Location = new System.Drawing.Point(437, 52);
            this.cbl01_VALIDATION_STATUS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_VALIDATION_STATUS.MaxDropDownItems = ((short)(5));
            this.cbl01_VALIDATION_STATUS.MaxLength = 32767;
            this.cbl01_VALIDATION_STATUS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_VALIDATION_STATUS.Name = "cbl01_VALIDATION_STATUS";
            this.cbl01_VALIDATION_STATUS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_VALIDATION_STATUS.Size = new System.Drawing.Size(140, 25);
            this.cbl01_VALIDATION_STATUS.TabIndex = 148;
            this.cbl01_VALIDATION_STATUS.Visible = false;
            this.cbl01_VALIDATION_STATUS.PropBag = resources.GetString("cbl01_VALIDATION_STATUS.PropBag");
            // 
            // cbl01_INVOICE_STATUS
            // 
            this.cbl01_INVOICE_STATUS.AddItemSeparator = ';';
            this.cbl01_INVOICE_STATUS.Caption = "";
            this.cbl01_INVOICE_STATUS.CaptionHeight = 17;
            this.cbl01_INVOICE_STATUS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INVOICE_STATUS.ColumnCaptionHeight = 18;
            this.cbl01_INVOICE_STATUS.ColumnFooterHeight = 18;
            this.cbl01_INVOICE_STATUS.ContentHeight = 19;
            this.cbl01_INVOICE_STATUS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INVOICE_STATUS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INVOICE_STATUS.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INVOICE_STATUS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INVOICE_STATUS.EditorHeight = 19;
            this.cbl01_INVOICE_STATUS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INVOICE_STATUS.Images"))));
            this.cbl01_INVOICE_STATUS.ItemHeight = 15;
            this.cbl01_INVOICE_STATUS.Location = new System.Drawing.Point(112, 50);
            this.cbl01_INVOICE_STATUS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INVOICE_STATUS.MaxDropDownItems = ((short)(5));
            this.cbl01_INVOICE_STATUS.MaxLength = 32767;
            this.cbl01_INVOICE_STATUS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INVOICE_STATUS.Name = "cbl01_INVOICE_STATUS";
            this.cbl01_INVOICE_STATUS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INVOICE_STATUS.Size = new System.Drawing.Size(142, 25);
            this.cbl01_INVOICE_STATUS.TabIndex = 147;
            this.cbl01_INVOICE_STATUS.PropBag = resources.GetString("cbl01_INVOICE_STATUS.PropBag");
            // 
            // lbl01_Search
            // 
            this.lbl01_Search.AutoFontSizeMaxValue = 9F;
            this.lbl01_Search.AutoFontSizeMinValue = 9F;
            this.lbl01_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_Search.Location = new System.Drawing.Point(685, 14);
            this.lbl01_Search.Name = "lbl01_Search";
            this.lbl01_Search.Size = new System.Drawing.Size(102, 21);
            this.lbl01_Search.TabIndex = 145;
            this.lbl01_Search.Tag = null;
            this.lbl01_Search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_Search.Value = "Search";
            // 
            // txt01_Search
            // 
            this.txt01_Search.Location = new System.Drawing.Point(802, 14);
            this.txt01_Search.Name = "txt01_Search";
            this.txt01_Search.Size = new System.Drawing.Size(329, 24);
            this.txt01_Search.TabIndex = 144;
            this.txt01_Search.Tag = null;
            this.txt01_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt01_Search_KeyUp);
            // 
            // lbl01_INVOICE_STATUS
            // 
            this.lbl01_INVOICE_STATUS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INVOICE_STATUS.AutoFontSizeMinValue = 9F;
            this.lbl01_INVOICE_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INVOICE_STATUS.Location = new System.Drawing.Point(6, 51);
            this.lbl01_INVOICE_STATUS.Name = "lbl01_INVOICE_STATUS";
            this.lbl01_INVOICE_STATUS.Size = new System.Drawing.Size(101, 21);
            this.lbl01_INVOICE_STATUS.TabIndex = 140;
            this.lbl01_INVOICE_STATUS.Tag = null;
            this.lbl01_INVOICE_STATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INVOICE_STATUS.Value = "IRN Status";
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(331, 14);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(102, 21);
            this.axLabel1.TabIndex = 137;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "DATE";
            // 
            // lbl01_DASH
            // 
            this.lbl01_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl01_DASH.AutoFontSizeMinValue = 9F;
            this.lbl01_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DASH.Location = new System.Drawing.Point(540, 16);
            this.lbl01_DASH.Name = "lbl01_DASH";
            this.lbl01_DASH.Size = new System.Drawing.Size(19, 21);
            this.lbl01_DASH.TabIndex = 136;
            this.lbl01_DASH.Tag = null;
            this.lbl01_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DASH.Value = "~";
            // 
            // dte01_EDATE
            // 
            this.dte01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_EDATE.Location = new System.Drawing.Point(563, 15);
            this.dte01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_EDATE.Name = "dte01_EDATE";
            this.dte01_EDATE.OriginalFormat = "";
            this.dte01_EDATE.Size = new System.Drawing.Size(102, 24);
            this.dte01_EDATE.TabIndex = 135;
            // 
            // dte01_SDATE
            // 
            this.dte01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_SDATE.Location = new System.Drawing.Point(437, 15);
            this.dte01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_SDATE.Name = "dte01_SDATE";
            this.dte01_SDATE.OriginalFormat = "";
            this.dte01_SDATE.Size = new System.Drawing.Size(102, 24);
            this.dte01_SDATE.TabIndex = 134;
            // 
            // cbl01_CustCD
            // 
            this.cbl01_CustCD.AddItemSeparator = ';';
            this.cbl01_CustCD.Caption = "";
            this.cbl01_CustCD.CaptionHeight = 17;
            this.cbl01_CustCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_CustCD.ColumnCaptionHeight = 18;
            this.cbl01_CustCD.ColumnFooterHeight = 18;
            this.cbl01_CustCD.ContentHeight = 19;
            this.cbl01_CustCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_CustCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_CustCD.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_CustCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_CustCD.EditorHeight = 19;
            this.cbl01_CustCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_CustCD.Images"))));
            this.cbl01_CustCD.ItemHeight = 15;
            this.cbl01_CustCD.Location = new System.Drawing.Point(112, 14);
            this.cbl01_CustCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_CustCD.MaxDropDownItems = ((short)(5));
            this.cbl01_CustCD.MaxLength = 32767;
            this.cbl01_CustCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_CustCD.Name = "cbl01_CustCD";
            this.cbl01_CustCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_CustCD.Size = new System.Drawing.Size(213, 25);
            this.cbl01_CustCD.TabIndex = 82;
            this.cbl01_CustCD.PropBag = resources.GetString("cbl01_CustCD.PropBag");
            // 
            // lbl01_VALIDATION_FLAG
            // 
            this.lbl01_VALIDATION_FLAG.AutoFontSizeMaxValue = 9F;
            this.lbl01_VALIDATION_FLAG.AutoFontSizeMinValue = 9F;
            this.lbl01_VALIDATION_FLAG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VALIDATION_FLAG.Location = new System.Drawing.Point(331, 53);
            this.lbl01_VALIDATION_FLAG.Name = "lbl01_VALIDATION_FLAG";
            this.lbl01_VALIDATION_FLAG.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VALIDATION_FLAG.TabIndex = 8;
            this.lbl01_VALIDATION_FLAG.Tag = null;
            this.lbl01_VALIDATION_FLAG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VALIDATION_FLAG.Value = "Validation Status";
            this.lbl01_VALIDATION_FLAG.Visible = false;
            // 
            // lbl01_CUSTCD
            // 
            this.lbl01_CUSTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CUSTCD.Location = new System.Drawing.Point(6, 15);
            this.lbl01_CUSTCD.Name = "lbl01_CUSTCD";
            this.lbl01_CUSTCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CUSTCD.TabIndex = 4;
            this.lbl01_CUSTCD.Tag = null;
            this.lbl01_CUSTCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUSTCD.Value = "Customer";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,105,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 21;
            this.grd01.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible;
            this.grd01.Size = new System.Drawing.Size(1313, 481);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick_1);
            // 
            // grdDet
            // 
            this.grdDet.AllowHeaderMerging = false;
            this.grdDet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDet.AutoGenerateColumns = false;
            this.grdDet.ColumnInfo = "0,0,0,0,0,105,Columns:";
            this.grdDet.EnabledActionFlag = true;
            this.grdDet.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grdDet.LastRowAdd = false;
            this.grdDet.Location = new System.Drawing.Point(3, 3);
            this.grdDet.Name = "grdDet";
            this.grdDet.OriginalFormat = null;
            this.grdDet.PopMenuVisible = true;
            this.grdDet.Rows.DefaultSize = 21;
            this.grdDet.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible;
            this.grdDet.Size = new System.Drawing.Size(1317, 256);
            this.grdDet.StyleInfo = resources.GetString("grdDet.StyleInfo");
            this.grdDet.TabIndex = 0;
            this.grdDet.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grd01);
            this.panel1.Location = new System.Drawing.Point(6, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 486);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.grdDet);
            this.panel2.Location = new System.Drawing.Point(3, 625);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1320, 262);
            this.panel2.TabIndex = 10;
            // 
            // btnCancelEWayBill
            // 
            this.btnCancelEWayBill.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelEWayBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelEWayBill.ForeColor = System.Drawing.Color.Black;
            this.btnCancelEWayBill.Location = new System.Drawing.Point(601, 84);
            this.btnCancelEWayBill.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelEWayBill.Name = "btnCancelEWayBill";
            this.btnCancelEWayBill.Size = new System.Drawing.Size(141, 29);
            this.btnCancelEWayBill.TabIndex = 94;
            this.btnCancelEWayBill.Text = "Cancel EWay Bill";
            this.btnCancelEWayBill.UseVisualStyleBackColor = false;
            this.btnCancelEWayBill.Click += new System.EventHandler(this.btnCancelEWayBill_Click);
            // 
            // btnCancelIRN
            // 
            this.btnCancelIRN.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelIRN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelIRN.ForeColor = System.Drawing.Color.Black;
            this.btnCancelIRN.Location = new System.Drawing.Point(437, 84);
            this.btnCancelIRN.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelIRN.Name = "btnCancelIRN";
            this.btnCancelIRN.Size = new System.Drawing.Size(143, 29);
            this.btnCancelIRN.TabIndex = 95;
            this.btnCancelIRN.Text = "Cancel IRN";
            this.btnCancelIRN.UseVisualStyleBackColor = false;
            this.btnCancelIRN.Click += new System.EventHandler(this.btnCancelIRN_Click);
            // 
            // btnGetIRNDetails
            // 
            this.btnGetIRNDetails.BackColor = System.Drawing.Color.Lime;
            this.btnGetIRNDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetIRNDetails.ForeColor = System.Drawing.Color.Black;
            this.btnGetIRNDetails.Location = new System.Drawing.Point(91, 88);
            this.btnGetIRNDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetIRNDetails.Name = "btnGetIRNDetails";
            this.btnGetIRNDetails.Size = new System.Drawing.Size(143, 29);
            this.btnGetIRNDetails.TabIndex = 96;
            this.btnGetIRNDetails.Text = "Get IRN Details";
            this.btnGetIRNDetails.UseVisualStyleBackColor = false;
            this.btnGetIRNDetails.Click += new System.EventHandler(this.btnGetIRNDetails_Click);
            // 
            // btnGetEWayBillDetails
            // 
            this.btnGetEWayBillDetails.BackColor = System.Drawing.Color.Lime;
            this.btnGetEWayBillDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetEWayBillDetails.ForeColor = System.Drawing.Color.Black;
            this.btnGetEWayBillDetails.Location = new System.Drawing.Point(256, 88);
            this.btnGetEWayBillDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetEWayBillDetails.Name = "btnGetEWayBillDetails";
            this.btnGetEWayBillDetails.Size = new System.Drawing.Size(150, 29);
            this.btnGetEWayBillDetails.TabIndex = 97;
            this.btnGetEWayBillDetails.Text = "Get EwayBill Details";
            this.btnGetEWayBillDetails.UseVisualStyleBackColor = false;
            this.btnGetEWayBillDetails.Click += new System.EventHandler(this.btnGetEWayBillDetails_Click);
            // 
            // ZSDE6000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGetEWayBillDetails);
            this.Controls.Add(this.btnGetIRNDetails);
            this.Controls.Add(this.btnCancelIRN);
            this.Controls.Add(this.btnCancelEWayBill);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grpSearch01);
            this.Controls.Add(this.panel1);
            this.Name = "ZSDE6000";
            this.Size = new System.Drawing.Size(1327, 920);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grpSearch01, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.btnCancelEWayBill, 0);
            this.Controls.SetChildIndex(this.btnCancelIRN, 0);
            this.Controls.SetChildIndex(this.btnGetIRNDetails, 0);
            this.Controls.SetChildIndex(this.btnGetEWayBillDetails, 0);
            this.grpSearch01.ResumeLayout(false);
            this.grpSearch01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VALIDATION_STATUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INVOICE_STATUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INVOICE_STATUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VALIDATION_FLAG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch01;
        private DEV.Utility.Controls.AxLabel lbl01_Search;
        private DEV.Utility.Controls.AxTextBox txt01_Search;
        private DEV.Utility.Controls.AxLabel lbl01_INVOICE_STATUS;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxLabel lbl01_DASH;
        private DEV.Utility.Controls.AxDateEdit dte01_EDATE;
        private DEV.Utility.Controls.AxDateEdit dte01_SDATE;
        private DEV.Utility.Controls.AxComboList cbl01_CustCD;
        private DEV.Utility.Controls.AxLabel lbl01_VALIDATION_FLAG;
        private DEV.Utility.Controls.AxLabel lbl01_CUSTCD;
        private DEV.Utility.Controls.AxComboList cbl01_INVOICE_STATUS;
        private DEV.Utility.Controls.AxComboList cbl01_VALIDATION_STATUS;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxFlexGrid grdDet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxButton btnCancelEWayBill;
        private DEV.Utility.Controls.AxButton btnCancelIRN;
        private DEV.Utility.Controls.AxButton btnGetIRNDetails;
        private DEV.Utility.Controls.AxButton btnGetEWayBillDetails;
    }
}