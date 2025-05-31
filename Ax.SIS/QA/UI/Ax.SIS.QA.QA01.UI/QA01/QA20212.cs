using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.IO;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>완제품 파견 불량 등록</b>
    /// </summary>
    public partial class QA20212 : AxCommonBaseControl
    {
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD_T;
        private String _SAL_VENDCD_T;
        private String _CUST_PLANT_T;
        private String _PROC_DATE_T;
        private String _IMPUT_VENDCD_T;
        private String _PARTNO_T;
        private String _DPTNO;
        private String _GUBN;
        private String _PLANT_DIV;

        private AttachFileInfo _PHOTO;
        private AttachFileInfo _FILE;

        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_QA20212";
        private string PACKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        public QA20212()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = "";
            _SAL_VENDCD_T = "";
            _CUST_PLANT_T = "";
            _PROC_DATE_T = "";
            _IMPUT_VENDCD_T = "";
            _PARTNO_T = "";
            _DPTNO = "";
            _GUBN = "N";
            _PLANT_DIV = "";
        }

        public QA20212(string BIZCD, string SAL_VENDCD, string CUST_PLANT, string PROC_DATE, string IMPUT_VENDCD, string PARTNO, string DPTNO, string PLANT_DIV)
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = BIZCD;
            _SAL_VENDCD_T = SAL_VENDCD;
            _CUST_PLANT_T = CUST_PLANT;
            _PROC_DATE_T = PROC_DATE;
            _IMPUT_VENDCD_T = IMPUT_VENDCD;
            _PARTNO_T = PARTNO;
            _DPTNO = DPTNO;
            _GUBN = "Y";
            _PLANT_DIV = PLANT_DIV;
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _PHOTO = new AttachFileInfo();
                _FILE = new AttachFileInfo();

                this.groupBox3.Text = this.GetLabel("QA20212_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20212_MSG2");

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_IMPUT_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_IMPUT_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx01_IMPUT_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_IMPUT_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_IMPUT_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_IMPUT_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_IMPUT_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx02_IMPUT_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_IMPUT_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_IMPUT_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx02_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx02_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx02_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ASSYNO.HEPopupHelper = new QASubWindow();
                this.cdx02_ASSYNO.PopupTitle = this.GetLabel("ASSYPNO");//"완제품코드";
                this.cdx02_ASSYNO.CodeParameterName = "ASSYNO_OF_ALCCD";
                this.cdx02_ASSYNO.NameParameterName = "ASSYNO_OF_ALCNM";
                this.cdx02_ASSYNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ASSYNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("RCV_DATE", this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd"));
                this.cdx02_ASSYNO.HEParameterAdd("ALCCD", this.txt02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("ITEMCD", string.Empty);
                this.cdx02_ASSYNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("DIS_PARTNO");//"폐기품번";
                this.cdx02_PARTNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_PARTNO.NameParameterName = "PARTNO_OF_VENDNM";
                this.cdx02_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("VENDCD", string.Empty);
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_APPLY_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_APPLY_PARTNO.PopupTitle = this.GetLabel("DIS_PARTNO");//"원인품번";
                this.cdx02_APPLY_PARTNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_APPLY_PARTNO.NameParameterName = "PARTNO_OF_VENDNM";
                this.cdx02_APPLY_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_APPLY_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_APPLY_PARTNO.HEParameterAdd("VENDCD", string.Empty);
                this.cdx02_APPLY_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx02_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx02_DEFCD.CodeParameterName = "DEFCD";
                this.cdx02_DEFCD.NameParameterName = "DEFNM";
                this.cdx02_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx02_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx02_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx02_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet sourceShift = this.GetDataSourceSchema("CODE", "NAME");
                sourceShift.Tables[0].Rows.Add("1", "1 Shift");
                sourceShift.Tables[0].Rows.Add("2", "2 Shift");
                sourceShift.Tables[0].Rows.Add("3", "3 Shift");
                this.cbo02_DN_DIV.DataBind(sourceShift.Tables[0], true);
                this.cbo02_DN_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet source = this.GetTypeCode("FY", "FK", "FZ", "A1");
                this.cbo02_MGRT_CD.DataBind(source.Tables[0], true);
                this.cbo02_MGRT_CD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo02_IMPUT_DIVCD.DataBind(source.Tables[2], true);
                this.cbo02_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_JOB_TYPE.DataBind(source.Tables[3], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_JOB_TYPE.DataBind(source.Tables[3], true);
                this.cbo02_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                #region [ grd01 ]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "_법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "_사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "_발생일자", "PROC_DATE", "OCCUR_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_파견번호", "DPTNO", "DPTNO");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 070, "_업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "Job Type", "JOB_TYPENM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "_차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 70, "Item Div", "ITEM_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "Item Div", "ITEM_DIVNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "ALC", "ALCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "A'SSY NO", "ASSYNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "A'SSY NAME", "ASSYPNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "_PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "조치구분코드", "MGRT_CD", "MGRT_CD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "조치구분", "MGRT_NM", "MGRT_NM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "귀책구분코드", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "귀책구분", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "귀책업체코드", "IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "귀책업체", "IMPUT_VENDNM", "IMPUT_VENDNM");                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "Def Qty.", "DIS_QTY");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "U/Cost", "DIS_UCOST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "Def Amt.", "DIS_AMT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "Currency", "COINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Def Code", "DEFCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Def Name", "DEFNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "Def PosCd", "DEFPOSCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "Def Pos", "DEFPOSNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "원인품번", "APPLY_PARTNO", "APPLY_PARTNO");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 120, "원인품번", "APPLY_PARTNM", "APPLY_PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "Shift", "DN_DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 110, "_PRDT_DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "고객사코드", "SAL_VENDCD", "CUSTCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "고객사명", "SAL_VENDNM", "CUSTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "고객공장", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 250, "Attached File", "DEF_FILE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Plant Div", "PLANT_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "Remark", "REMARK", "REMARK");


                this.grd01.Cols["PROC_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DIS_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_UCOST");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMT");

                this.grd01.Cols["DIS_QTY"].Format = "#,###,##0";
                this.grd01.Cols["DIS_UCOST"].Format = "#,###,##0.##";
                this.grd01.Cols["DIS_AMT"].Format = "#,###,##0.##";

                #endregion 

                this.pic02_DOCUMENT.SizeMode = PictureBoxSizeMode.Zoom;

                this.SetRequired(lbl01_BIZNM, /*lbl01_CUSTNM, */lbl01_OCCUR_DATE, lbl02_BIZNM, lbl02_OCCUR_DATE, lbl02_CUSTNM, lbl02_VIN, lbl02_ITEM_DIV, 
                    lbl02_JOB_TYPE, lbl02_ASSYPNO, lbl02_MGRT_CD, lbl02_IMPUT_VENDNM, lbl02_DIS_PARTNO, lbl02_DN_DIV, lbl02_IMPUT_DIVCD);

                this.cdx01_SAL_VENDCD.SetValue(this.GetSysEnviroment("SALES", "VENDCD_" + this.UserInfo.BusinessCode));
                this.cbo02_ITEM_DIV.DataBind("4I", true);
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true);
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", true);


                txt01_FILE_PATH.ReadOnly = true;

                this.BtnReset_Click(null, null);
                cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);

                this.dte01_PROC_DATE.SetValue(this.dte01_PROC_DATE.GetDateText().ToString().Substring(0, 8) + "01");

                if (_GUBN == "Y")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD_T);
                    this.cdx01_SAL_VENDCD.SetValue(_SAL_VENDCD_T);
                    this.cbo01_CUST_PLANT.SetValue(_CUST_PLANT_T);
                    this.dte01_PROC_DATE.SetValue(_PROC_DATE_T);
                    this.dte01_PROC_DATE_TO.SetValue(_PROC_DATE_T);
                    this.cdx01_IMPUT_VENDCD.SetValue(_IMPUT_VENDCD_T);
                    this.txt01_PARTNO.SetValue(_DPTNO);
                }

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if(ctl is IAxControl)
                    {
                        if (ctl.Name != "cbo02_CUST_PLANT" && ctl.Name != "cbo02_PLANT_DIV" && ctl.Name != "dte02_PROC_DATE")
                        {
                            ((IAxControl)ctl).Initialize();
                        } 
                        else 
                        {
                            if (cbo02_CUST_PLANT.Items.Count != 0)
                            {
                                cbo02_CUST_PLANT.Initialize();
                            } 
                        }
                    }
                }

                foreach (Control ctl in pnl02_SUB.Controls)
                {
                    if(ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.pic02_DOCUMENT.Initialize(); 
                this.cdx02_SAL_VENDCD.SetValue(string.Empty);

                this.nme02_DIS_QTY.SetValue("0");
                this.nme02_DIS_UCOST.SetValue("0");
                this.nme02_DIS_AMT.SetValue("0");

                cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.dte02_PROC_DATE.Enabled = true;
                this.cdx02_VINCD.Enabled = true;
                this.txt02_ALCCD.Enabled = true;
                this.cdx02_ASSYNO.Enabled = true;
                this.cdx02_SAL_VENDCD.Enabled = true;

                _FILE.Clear();
                _PHOTO.Clear();
                btn01_ADD_FILE.Enabled = false;
                btn01_OPEN_FILE.Enabled = false;
                btn01_REMOVE_FILE.Enabled = false;
                txt01_FILE_PATH.SetValue("");

                this.cdx_SETTING();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                base.BtnClose_Click(sender, e);
                ((Form)this.Parent).Close();
            }
            catch
            {
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSelectValid()) return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();
                string CUST_PLANT = this.cbo01_CUST_PLANT.GetValue().ToString();
                string PROC_DATE = this.dte01_PROC_DATE.Value.ToString("yyyy-MM-dd");
                string IMPUT_VENDCD = this.cdx01_IMPUT_VENDCD.GetValue().ToString();
                string JOB_TYPE = this.cbo01_JOB_TYPE.GetValue().ToString();
                string PARTNO_PARTNM = this.txt01_PARTNO.GetValue().ToString();
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.Value.ToString("yyyy-MM-dd");

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);
                paramSet.Add("IMPUT_VENDCD", IMPUT_VENDCD);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("PARTNO_PARTNM", PARTNO_PARTNM);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("CUST_PLANT", CUST_PLANT);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("DPTNO", _DPTNO);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM_N.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                if(_GUBN == "Y")
                {
                    if (((DataTable)this.grd01.DataSource).Rows.Count > 0)
                        this.grd_SELECT(this.grd01.Rows.Fixed);

                    _DPTNO = "";
                    _GUBN = "";
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                string IMPUT_VENDCD = this.cdx02_IMPUT_VENDCD.GetValue().ToString();

                DataSet paramSet = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DPTNO", "PROC_DATE", "LINECD", "JOB_TYPE", "ASSYNO",
                    "PARTNO", "DEFCD", "DEFPOSCD", "DN_DIV", "ALCCD", "DIS_QTY",
                    "IMPUT_DIVCD", "SAL_VENDCD", "CUST_PLANT", "PRDT_DIV", "MGRT_CD", "IMPUT_VENDCD",
                    "APPLY_PARTNO", "PLANT_DIV", "BLOB$DEF_PHOTO", "DEF_PHOTO_FILEID", "REMARK", 
                    "DIS_UCOST", "DIS_AMT", "DEF_FILE", "ITEM_DIV");

                string _defPartno = this.cdx02_PARTNO.GetValue().ToString();


                paramSet.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_DPTNO.GetValue(),
                    this.dte02_PROC_DATE.GetDateText(),
                    string.Empty,
                    this.cbo02_JOB_TYPE.GetValue(),
                    this.cdx02_ASSYNO.GetValue(),
                    _defPartno,
                    this.cdx02_DEFCD.GetValue(),
                    this.cdx02_DEFPOSCD.GetValue(),
                    this.cbo02_DN_DIV.GetValue(),
                    this.txt02_ALCCD.GetValue(),
                    this.nme02_DIS_QTY.GetDBValue(),
                    this.cbo02_IMPUT_DIVCD.GetValue(),
                    this.cdx02_SAL_VENDCD.GetValue(),
                    this.cbo02_CUST_PLANT.GetValue(),
                    this.txt02_PRDT_DIV.GetValue(),
                    this.cbo02_MGRT_CD.GetValue(),
                    IMPUT_VENDCD,
                    this.cdx02_APPLY_PARTNO.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue(),
                    null,
                    string.Empty,
                    this.txt02_REMARK.GetValue(),
                    this.nme02_DIS_UCOST.GetDBValue(),
                    this.nme02_DIS_AMT.GetDBValue(),
                    string.Empty,
                    this.cbo02_ITEM_DIV.GetValue());                

                if (!IsSaveValid()) return;

                //PHOTO-------------------------------------------------------------------------------------
                string newFileId = string.Empty;
                byte[] blob = null;

                if (_PHOTO.FLAG == AttachFileInfo.FileStatus.None)
                {
                    //변경없음.
                    newFileId = _PHOTO.FILEID;
                    blob = _PHOTO.BLOB;
                }
                else if (_PHOTO.FLAG == AttachFileInfo.FileStatus.Delete)
                {
                    //삭제시
                    if (_PHOTO.FILEID != string.Empty) RemoteFileHandler.FileRemove(_PHOTO.FILEID);
                    newFileId = string.Empty;
                    blob = null;

                    //초기화
                    _PHOTO.FILEID = string.Empty;
                }
                else
                {
                    //파일변경했거나 신규로 파일선택시
                    newFileId = RemoteFileHandler.FileUpload(_PHOTO.NEWFILEPATH, this.Name, _PHOTO.FILEID);
                    blob = _PHOTO.BLOB;

                    //FILEID 업데이트
                    _PHOTO.FILEID = newFileId;
                }
                paramSet.Tables[0].Rows[0]["DEF_PHOTO_FILEID"] = newFileId;
                paramSet.Tables[0].Rows[0]["$DEF_PHOTO"] = blob;
                //-------------------------------------------------------------------------------------------

                //FILE---------------------------------------------------------------------------------------
                string newFileId2 = string.Empty;

                if (_FILE.FLAG == AttachFileInfo.FileStatus.None)
                {
                    //변경없음.
                    newFileId2 = _FILE.FILEID;
                }
                else if (_FILE.FLAG == AttachFileInfo.FileStatus.Delete)
                {
                    //삭제시
                    if (_FILE.FILEID != string.Empty) RemoteFileHandler.FileRemove(_FILE.FILEID);
                    newFileId2 = string.Empty;

                    //초기화
                    _FILE.FILEID = string.Empty;
                }
                else
                {
                    this.BeforeInvokeServer(true);
                    //파일변경했거나 신규로 파일선택시
                    newFileId2 = RemoteFileHandler.FileUpload(_FILE.NEWFILEPATH, this.Name, _FILE.FILEID);

                    //FILEID 업데이트
                    _FILE.FILEID = newFileId2;
                    this.AfterInvokeServer();
                }
                paramSet.Tables[0].Rows[0]["DEF_FILE"] = newFileId2;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), paramSet);
                //_WSCOM.Save(paramSet, source_IMAGE);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("완제품 파견 불량 등록이 저장되었습니다.");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "DPTNO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_DPTNO.GetValue()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);

                if (_PHOTO.FILEID != "") RemoteFileHandler.FileRemove(_PHOTO.FILEID);
                if (_FILE.FILEID != "") RemoteFileHandler.FileRemove(_FILE.FILEID);

                //_WSCOM_N.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx("APG_QA20212.REMOVE", source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("완제품 파견 불량 등록이 삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0072");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_QA20212_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;

                if (Row >= this.grd01.Rows.Fixed)
                {
                    this.grd_SELECT(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd_SELECT(int Row)
        {
            try
            {
                this.BtnReset_Click(null, null);

                string BIZCD = this.grd01.GetValue(Row, "BIZCD").ToString();
                string PROC_DATE = this.grd01.GetValue(Row, "PROC_DATE").ToString();
                string SAL_VENDCD = this.grd01.GetValue(Row, "SAL_VENDCD").ToString();
                string SAL_VENDNM = this.grd01.GetValue(Row, "SAL_VENDNM").ToString();
                string CUST_PLANT = this.grd01.GetValue(Row, "CUST_PLANT").ToString();
                string VINCD = this.grd01.GetValue(Row, "VINCD").ToString();
                string ITEM_DIV = this.grd01.GetValue(Row, "ITEM_DIV").ToString();
                string JOB_TYPE = this.grd01.GetValue(Row, "JOB_TYPE").ToString();
                string JOB_TYPENM = this.grd01.GetValue(Row, "JOB_TYPENM").ToString();
                string ALCCD = this.grd01.GetValue(Row, "ALCCD").ToString();
                string ASSYNO = this.grd01.GetValue(Row, "ASSYNO").ToString();
                string ASSYPNM = this.grd01.GetValue(Row, "ASSYPNM").ToString();
                string MGRT_CD = this.grd01.GetValue(Row, "MGRT_CD").ToString();
                string MGRT_NM = this.grd01.GetValue(Row, "MGRT_NM").ToString();
                string DPTNO = this.grd01.GetValue(Row, "DPTNO").ToString();
                string IMPUT_VENDCD = this.grd01.GetValue(Row, "IMPUT_VENDCD").ToString();
                string IMPUT_VENDNM = this.grd01.GetValue(Row, "IMPUT_VENDNM").ToString();
                string PARTNO = this.grd01.GetValue(Row, "PARTNO").ToString();
                string PARTNM = this.grd01.GetValue(Row, "PARTNM").ToString();
                string APPLY_PARTNO = this.grd01.GetValue(Row, "APPLY_PARTNO").ToString();
                string APPLY_PARTNM = this.grd01.GetValue(Row, "APPLY_PARTNM").ToString();
                string DIS_QTY = this.grd01.GetValue(Row, "DIS_QTY").ToString();
                string DIS_UCOST = this.grd01.GetValue(Row, "DIS_UCOST").ToString();
                string DIS_AMT = this.grd01.GetValue(Row, "DIS_AMT").ToString();
                string DEFCD = this.grd01.GetValue(Row, "DEFCD").ToString();
                string DEFNM = this.grd01.GetValue(Row, "DEFNM").ToString();
                string DEFPOSCD = this.grd01.GetValue(Row, "DEFPOSCD").ToString();
                string DEFPOSNM = this.grd01.GetValue(Row, "DEFPOSNM").ToString();
                string DN_DIV = this.grd01.GetValue(Row, "DN_DIV").ToString();
                string IMPUT_DIVCD = this.grd01.GetValue(Row, "IMPUT_DIVCD").ToString();
                string IMPUT_DIVNM = this.grd01.GetValue(Row, "IMPUT_DIVNM").ToString();
                string PRDT_DIV = this.grd01.GetValue(Row, "PRDT_DIV").ToString();
                string REMARK = this.grd01.GetValue(Row, "REMARK").ToString();
                string PLANT_DIV = this.grd01.GetValue(Row, "PLANT_DIV").ToString();

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_PROC_DATE.SetValue(PROC_DATE);
                this.cdx02_SAL_VENDCD.SetValue(SAL_VENDNM, SAL_VENDCD);
                this.cbo02_CUST_PLANT_View();
                this.cbo02_CUST_PLANT.SetValue(CUST_PLANT);
                this.cdx02_VINCD.SetValue(VINCD);
                this.cbo02_ITEM_DIV.SetValue(ITEM_DIV);
                this.cbo02_JOB_TYPE.SetValue(JOB_TYPE);
                this.txt02_DPTNO.SetValue(DPTNO);
                this.txt02_ALCCD.SetValue(ALCCD);

                this.cdx02_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd"));
                this.cdx02_ASSYNO.HEUserParameterSetValue("ALCCD", this.txt02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ITEMCD", string.Empty);
                this.cdx02_ASSYNO.SetValue(ASSYPNM, ASSYNO);
                this.cbo02_MGRT_CD.SetValue(MGRT_CD);
                this.cdx02_PARTNO.SetValue(PARTNM, PARTNO);
                this.cdx02_IMPUT_VENDCD.SetValue(IMPUT_VENDCD);
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.SetValue(DEFNM, DEFCD);
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.SetValue(DEFPOSNM, DEFPOSCD);
                this.cbo02_DN_DIV.SetValue(DN_DIV);
                this.cbo02_IMPUT_DIVCD.SetValue(IMPUT_DIVCD);
                this.txt02_PRDT_DIV.SetValue(PRDT_DIV);
                this.cdx02_APPLY_PARTNO.SetValue(APPLY_PARTNM, APPLY_PARTNO);
                this.txt02_REMARK.SetValue(REMARK);
                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);

                this.nme02_DIS_QTY.SetValue(DIS_QTY);
                this.nme02_DIS_UCOST.SetValue(DIS_UCOST);
                this.nme02_DIS_AMT.SetValue(DIS_AMT);

                if (string.IsNullOrEmpty(PRDT_DIV)) this.grd02_QA20212_View();

                this.cbo02_BIZCD.Enabled = false;
                this.dte02_PROC_DATE.Enabled = false;
                this.cdx02_VINCD.Enabled = false;
                this.txt02_ALCCD.Enabled = false;
                this.cdx02_ASSYNO.Enabled = false;
                this.cdx02_SAL_VENDCD.Enabled = false;

                this.IMAGE_VIEW(BIZCD, DPTNO);
                this.FILE_VIEW(BIZCD, DPTNO);             

                this.btn01_ADD_FILE.Enabled = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void IMAGE_VIEW(string BIZCD, string DPTNO)
        {
            try
            {
                _PHOTO.Clear();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DPTNO", DPTNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                byte[] DOCUMENT = null;
                if ((dr["DEF_PHOTO_FILEID"]) != System.DBNull.Value)
                {
                    _PHOTO.FILEID = dr["DEF_PHOTO_FILEID"].ToString();
                    RemoteFileInfo file = RemoteFileHandler.FileDownload(_PHOTO.FILEID);
                    if (file != null)
                    {
                        DOCUMENT = file.FileContent;
                        _PHOTO.BLOB = file.FileContent;
                    }
                }
                else if ((dr["DEF_PHOTO"]) != System.DBNull.Value)
                {
                    DOCUMENT = (byte[])(dr["DEF_PHOTO"]);
                    _PHOTO.BLOB = DOCUMENT;
                }

                this.pic02_DOCUMENT.SetValue(DOCUMENT);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void FILE_VIEW(string BIZCD, string DPTNO)
        {
            try
            {
                _FILE.Clear();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DPTNO", DPTNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_FILE_LOAD"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                //byte[] DOCUMENT = null;
                if ((dr["DEF_FILE"]) != System.DBNull.Value)
                {
                    this.BeforeInvokeServer(true);
                    _FILE.FILEID = dr["DEF_FILE"].ToString();
                    RemoteFileInfo file = RemoteFileHandler.FileDownload(_FILE.FILEID);
                    //if (file != null) DOCUMENT = file.FileContent;
                    txt01_FILE_PATH.SetValue(file.DBFileName);
                    btn01_OPEN_FILE.Enabled = true;
                    btn01_REMOVE_FILE.Enabled = true;
                    this.AfterInvokeServer();
                }
                else
                {
                    btn01_OPEN_FILE.Enabled = false;
                    btn01_REMOVE_FILE.Enabled = false;
                }

                //this.pic02_DOCUMENT.SetValue(DOCUMENT);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void cdx_SETTING()
        {
            try
            {
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());

                this.cdx02_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd"));
                this.cdx02_ASSYNO.HEUserParameterSetValue("ALCCD", this.txt02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ITEMCD", string.Empty);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_SAL_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            HEParameterSet paramSet_CUST_PLANT = new HEParameterSet();
            paramSet_CUST_PLANT.Add("CORCD", _CORCD);
            paramSet_CUST_PLANT.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            paramSet_CUST_PLANT.Add("VENDORCD", this.cdx01_SAL_VENDCD.GetValue().ToString());
            paramSet_CUST_PLANT.Add("LANG_SET", _LANG_SET);

            this.BeforeInvokeServer(true);
            //DataSet source_CUST_PLANT = _WSCOMBOBOX.Inquery_CUST_PLANT(paramSet_CUST_PLANT);
            DataSet source_CUST_PLANT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_COMBOBOX, "INQUERY_CUST_PLANT"), paramSet_CUST_PLANT);
            this.cbo01_CUST_PLANT.DataBind(source_CUST_PLANT.Tables[0]);
            this.cbo01_CUST_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AfterInvokeServer();
        }

        private void cdx02_SAL_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();

            this.cbo02_CUST_PLANT_View();
        }

        private void grd02_QA20212_View()
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd");
                string ASSYNO = this.cdx02_ASSYNO.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("ASSYNO", ASSYNO);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_ASSYNO_PRDT_DIV"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                {
                    this.txt02_PRDT_DIV.SetValue(source.Tables[0].Rows[0]["PRDT_DIV"].ToString());
                   // this.nme02_DIS_UCOST_M.SetValue(source.Tables[0].Rows[0]["PART_UCOST"].ToString());
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void cbo02_CUST_PLANT_View()
        {
            try
            {
                HEParameterSet paramSet_CUST_PLANT = new HEParameterSet();
                paramSet_CUST_PLANT.Add("CORCD", _CORCD);
                paramSet_CUST_PLANT.Add("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("VENDORCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_CUST_PLANT = _WSCOMBOBOX.Inquery_CUST_PLANT(paramSet_CUST_PLANT);
                DataSet source_CUST_PLANT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_COMBOBOX, "INQUERY_CUST_PLANT"), paramSet_CUST_PLANT);

                this.AfterInvokeServer();

                this.cbo02_CUST_PLANT.DataBind(source_CUST_PLANT.Tables[0]);
                this.cbo02_CUST_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void cbo02_MGRT_CD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.cdx02_PARTNO.SetValue("");
                this.cdx02_APPLY_PARTNO.SetValue("");
                this.nme02_DIS_UCOST.SetValue("0");
                string MGRT_CD = this.cbo02_MGRT_CD.GetValue().ToString();
                this.grd02_QA20212_View();

                if (MGRT_CD == "FYB" || MGRT_CD == "FYC")
                    this.nme02_DIS_QTY.SetValue("1");
                else
                    this.nme02_DIS_QTY.SetValue("0");

                if (MGRT_CD == "FYA" || MGRT_CD == "FYB" || MGRT_CD == "FYD")
                    this.cdx02_PARTNO.SetValue(this.cdx02_ASSYNO.GetText(), this.cdx02_ASSYNO.GetValue().ToString());

                if (MGRT_CD == "FYB" || MGRT_CD == "FYD")
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                    paramSet.Add("PROC_DATE", this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd"));
                    paramSet.Add("JOB_TYPE", this.cbo02_JOB_TYPE.GetValue().ToString());
                    paramSet.Add("ASSYNO", this.cdx02_ASSYNO.GetValue().ToString());

                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_VENDCD_OF_ASSYCD"), paramSet);
                    this.AfterInvokeServer();

                    if (source.Tables[0].Rows.Count != 0)
                        this.cdx02_IMPUT_VENDCD.SetValue(source.Tables[0].Rows[0]["VENDCD"].ToString());
                    
                    if (MGRT_CD == "FYB")
                    {
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", _CORCD);
                        paramSet.Add("VENDCD", this.cdx02_IMPUT_VENDCD.GetValue().ToString());
                        paramSet.Add("PARTNO", this.cdx02_ASSYNO.GetValue().ToString());
                        paramSet.Add("BEG_DATE", this.dte02_PROC_DATE.GetValue().ToString());

                        this.BeforeInvokeServer(true);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_UCOST"), paramSet);
                        this.AfterInvokeServer();

                        if (source.Tables[0].Rows.Count > 0)
                            this.nme02_DIS_UCOST.SetValue(source.Tables[0].Rows[0]["PART_UCOST"].ToString());
                    }
                }

                this.nme02_DIS_AMT.SetValue(Math.Round(double.Parse(nme02_DIS_UCOST.GetValue().ToString()) * double.Parse(this.nme02_DIS_QTY.GetValue().ToString()),2));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void btn01_DOCUMENT_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    _PHOTO.NEWFILEPATH = file.FileName;
                    _PHOTO.FLAG = AttachFileInfo.FileStatus.Change;
                    _PHOTO.BLOB = _DOCUMENT;

                    this.pic02_DOCUMENT.SetValue(_DOCUMENT);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn01_DOCUMENT_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_DOCUMENT.Initialize();
                this._PHOTO.FLAG = AttachFileInfo.FileStatus.Delete;
                this._PHOTO.BLOB = null;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void dte02_PROC_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_SAL_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cbo02_ITEM_DIV_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cbo02_ITEM_DIV_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void pic02_DOCUMENT_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_DOCUMENT.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_DOCUMENT.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void nme02_DIS_QTY_ValueChanged(object sender, EventArgs e)
        {
            string dis_ucost = nme02_DIS_UCOST.GetValue().ToString() == null || nme02_DIS_UCOST.GetValue().ToString() == "" ? "0" : nme02_DIS_UCOST.GetValue().ToString();
            string dis_qty = nme02_DIS_QTY.GetValue().ToString() == null || nme02_DIS_QTY.GetValue().ToString() == "" ? "0" : nme02_DIS_QTY.GetValue().ToString();

            this.nme02_DIS_AMT.SetValue(Math.Round(double.Parse(dis_ucost) * double.Parse(dis_qty),2));
        }

        private void nme02_DIS_UCOST_TextChanged(object sender, EventArgs e)
        {
            this.nme02_DIS_QTY_ValueChanged(sender, e);
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte02_PROC_DATE.Value.ToString("yyyy-MM-dd");
                string SAL_VENDCD = this.cdx02_SAL_VENDCD.GetValue().ToString();
                string CUST_PLANT = this.cbo02_CUST_PLANT.GetValue().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEM_DIV = this.cbo02_ITEM_DIV.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string ALCCD = this.txt02_ALCCD.GetValue().ToString();
                string ASSYNO = this.cdx02_ASSYNO.GetValue().ToString();
                string MGRT_CD = this.cbo02_MGRT_CD.GetValue().ToString();

                string IMPUT_VENDCD = this.cdx02_IMPUT_VENDCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();

                string DIS_QTY = this.nme02_DIS_QTY.GetValue().ToString();
                
                string DN_DIV = this.cbo02_DN_DIV.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo02_IMPUT_DIVCD.GetValue().ToString();
                string REMARK = this.txt02_REMARK.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(PROC_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(SAL_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CUSTNM.Text);
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_VIN.Text);
                    return false;
                }

                if (this.GetByteCount(JOB_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_JOB_TYPE.Text);
                    return false;
                }

                if (this.GetByteCount(ASSYNO) == 0)
                {
                    //MsgBox.Show("완제품 PNO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ASSYPNO.Text);
                    return false;
                }

                if (this.GetByteCount(MGRT_CD) == 0)
                {
                    //MsgBox.Show("조치구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRT_CD.Text);
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("폐기품번 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_DIS_PARTNO.Text);
                    return false;
                }

                if (this.nme02_DIS_QTY.GetValue().ToString() != "")
                {
                    this.nme02_DIS_AMT.SetValue(Math.Round(double.Parse(this.nme02_DIS_QTY.GetValue().ToString()) * double.Parse(this.nme02_DIS_UCOST.GetValue().ToString()), 2));
                }

                if (this.GetByteCount(IMPUT_DIVCD) == 0)
                {
                    //MsgBox.Show("귀책구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_IMPUT_DIVCD.Text);
                    return false;
                }

                if (this.GetByteCount(REMARK) > 100)
                {
                    MsgCodeBox.ShowFormat("QA01-0014", this.lbl02_REMARK.Text, 100);
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DPTNO = this.txt02_DPTNO.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(DPTNO) == 0)
                {
                    //MsgBox.Show("삭제할 데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsSelectValid()
        {
            try
            {
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        private void cdx02_PARTNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("VENDCD", this.cdx02_IMPUT_VENDCD.GetValue().ToString());
                paramSet.Add("PARTNO", this.cdx02_PARTNO.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dte02_PROC_DATE.GetValue().ToString());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_UCOST"), paramSet);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.nme02_DIS_UCOST.SetValue(source.Tables[0].Rows[0]["PART_UCOST"].ToString());
                    this.cdx02_IMPUT_VENDCD.SetValue(source.Tables[0].Rows[0]["VENDCD"]);
                }
                this.nme02_DIS_AMT.SetValue(Math.Round(double.Parse(nme02_DIS_UCOST.GetValue().ToString()) * double.Parse(this.nme02_DIS_QTY.GetValue().ToString()),2));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void cdx02_ASSYNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                string MGRT_CD = this.cbo02_MGRT_CD.GetValue().ToString();

                if (MGRT_CD == "FYA" || MGRT_CD == "FYB" || MGRT_CD == "FYD")
                    this.cdx02_PARTNO.SetValue(this.cdx02_ASSYNO.GetText(), this.cdx02_ASSYNO.GetValue().ToString());

                if (MGRT_CD == "FYB")
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("VENDCD", this.cdx02_IMPUT_VENDCD.GetValue().ToString());
                    paramSet.Add("PARTNO", this.cdx02_ASSYNO.GetValue().ToString());
                    paramSet.Add("BEG_DATE", this.dte02_PROC_DATE.GetValue().ToString());

                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_UCOST"), paramSet);
                    this.AfterInvokeServer();

                    if (source.Tables[0].Rows.Count > 0)
                    {
                        this.nme02_DIS_UCOST.SetValue(source.Tables[0].Rows[0]["PART_UCOST"].ToString());
                        this.cdx02_IMPUT_VENDCD.SetValue(source.Tables[0].Rows[0]["VENDCD"]);
                    }
                }

                this.nme02_DIS_AMT.SetValue(Math.Round(double.Parse(nme02_DIS_UCOST.GetValue().ToString()) * double.Parse(this.nme02_DIS_QTY.GetValue().ToString()),2));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void btn01_ADD_FILE_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                //file.Filter = this.GetSysEnviroment("FILTER", "PDF");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    _FILE.NEWFILEPATH = file.FileName;
                    _FILE.FLAG = AttachFileInfo.FileStatus.Change;

                    this.txt01_FILE_PATH.SetValue(file.SafeFileName);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn01_REMOVE_FILE_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgCodeBox.ShowFormat("QA01-0057", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this._FILE.FLAG = AttachFileInfo.FileStatus.Delete;
                    this.txt01_FILE_PATH.SetValue("");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_OPEN_FILE_Click(object sender, EventArgs e)
        {
            if (this._FILE.FILEID != null)
            {
                string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString();

                RemoteFileInfo file = RemoteFileHandler.FileDownload(_FILE.FILEID);
                FILE_NAME = FILE_NAME + file.DBFileName;
                file.SaveAs(FILE_NAME);
                System.Diagnostics.Process.Start(FILE_NAME);
            }
        }
    }

    public class AttachFileInfo
    {
        private string fileid;
        private string filepath;
        private byte[] blob;
        private FileStatus flag;
        public enum FileStatus { None = 0, Change = 1, Delete = 2 }


        public string FILEID
        {
            get { return fileid; }
            set { fileid = value; }
        }

        public string NEWFILEPATH
        {
            get { return filepath; }
            set
            {

                filepath = value;

                if (value == "") return;

                flag = FileStatus.Change;

            }
        }


        public byte[] BLOB
        {
            get { return blob; }
            set { blob = value; }
        }

        public FileStatus FLAG
        {
            get { return flag; }
            set { flag = value; }
        }

        public void Clear()
        {
            this.fileid = "";
            this.filepath = "";
            this.blob = null;
            this.flag = FileStatus.None;
        }



    }
}
