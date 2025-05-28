using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;

using Ax.SIS.QA.QA09.UI;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    public partial class ZQA30017 : AxCommonBaseControl
    {
        //private IZQA30017 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "ZPG_ZQA30017";

        private CellStyle CS1;
        private CellStyle CS2;
        private CellStyle CS3;
        

        #region [ 초기화 작업 정의 ]
        public ZQA30017()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                DataSet source_PLANT_DIV = this.GetTypeCode("U9");
                this.cbo01_PLANT_DIV.DataBindCodeName(source_PLANT_DIV.Tables[0], false);

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_VINCD.SetCodePixedLength();

                this.grd01_ZQA30017.AllowEditing = false;
                this.grd01_ZQA30017.AllowDragging = AllowDraggingEnum.None;
                this.grd01_ZQA30017.Initialize();

                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Supplier", "VENDCD", "VENDCD");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "Vehicle", "VINNM", "VINNM");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 255, "Part Name", "PARTNM", "PARTNM");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 95, "Plant", "PLANT_DIVNM", "PLANT_DIVNM");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Visual", "C_VISUAL", "C_VISUAL");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Dimension", "C_DIMENSION", "C_DIMENSION");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Function", "C_FUNCTION", "C_FUNCTION");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Atest", "C_ATEST", "C_ATEST");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Description", "DESCRIPTION", "DESCRIPTION");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Inspection Date", "APP_DATE", "APP_DATE");
                this.grd01_ZQA30017.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 10, "Inspection Level", "INSPECTION_LEVEL", "INSPECTION_LEVEL");
                this.grd01_ZQA30017.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "Inspection Level", "INSPECTION_LEVELNM", "INSPECTION_LEVELNM");

                this.grd01_ZQA30017.Cols["APP_DATE"].Format = "yyyy-MM-dd";
                this.grd01_ZQA30017.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");

                this.dte01_APP_BEG_DATE.SetValue(DateTime.Now.ToString("yyyy-01-01"));
                this.dte01_APP_END_DATE.SetValue(DateTime.Now);

                CS1 = grd01_ZQA30017.Styles.Add("CS1");
                CS2 = grd01_ZQA30017.Styles.Add("CS2");
                CS3 = grd01_ZQA30017.Styles.Add("CS3");

                CS1.BackColor = axLabel1.BackColor;
                CS2.BackColor = axLabel5.BackColor;
                CS3.BackColor = axLabel6.BackColor;

                this.BtnReset_Click(null, null);
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
            this.grd01_ZQA30017.InitializeDataSource();
        }
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("APP_BEG_DATE", this.dte01_APP_BEG_DATE.GetDateText().ToString());
                paramSet.Add("APP_END_DATE", this.dte01_APP_END_DATE.GetDateText().ToString());
                paramSet.Add("VENDCD",  this.cdx01_VENDCD.GetValue().ToString());
                paramSet.Add("VINCD",  this.cdx01_VINCD.GetValue().ToString());
                paramSet.Add("PLANT_DIV",  this.cbo01_PLANT_DIV.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_ZQA30017.SetValue(source);

                this.setColor();
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

        //protected override void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
               
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        
        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
              
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}
        

        #endregion

        #region [ 기타 이벤트 정의 ]

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
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

        private bool IsDeleteValid(DataSet source)
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

        private void grd01_ZQA30017_AfterSort(object sender, SortColEventArgs e)
        {
            this.setColor();
        }

        private void setColor()
        {
            for (int i = 0; i < this.grd01_ZQA30017.Rows.Count; i++)
            {
                switch (this.grd01_ZQA30017.Rows[i]["INSPECTION_LEVEL"].ToString())
                {
                    case "1":
                        this.grd01_ZQA30017.Rows[i].Style = CS1;
                        break;
                    case "2":
                        this.grd01_ZQA30017.Rows[i].Style = CS2;
                        break;
                    default:
                        this.grd01_ZQA30017.Rows[i].Style = CS3;
                        break;
                }
            }
        }

        #region [사용자 정의 메서드]

       
        #endregion

    }
}
