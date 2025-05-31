#region ▶ Description & History
/* 
 * 프로그램명 : QA30511 품질 AUDIT 조회
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-28      배명희      통합WCF로 변경
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>품질 AUDIT 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 7:09:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 7:09:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30511 : AxCommonBaseControl
    {
        //private IQA30511 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30511";

        #region [ 초기화 작업 정의 ]

        public QA30511()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30511>("QA01", "QA30511.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.lbl01_DEFPOSCD.Visible = false;
                this.cdx01_DEFPOSCD.Visible = false;


                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                DataSet source = this.GetTypeCode("F6", "F1");
                this.cbo01_AUDIT_TYPE.DataBind(source.Tables[0], true);
                this.cbo01_AUDIT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_VER_4M_TYPE.DataBind(source.Tables[1], true);
                this.cbo01_VER_4M_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx01_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx01_DEFCD.CodeParameterName = "DEFCD";
                this.cdx01_DEFCD.NameParameterName = "DEFNM";
                this.cdx01_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                //this.cdx01_DEFCD.CodePixedLength = 5;
                this.cdx01_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx01_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx01_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx01_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.grd01_QA30511.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                this.grd01_QA30511.AllowEditing = false;
                this.grd01_QA30511.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30511.Initialize();
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "문서그룹", "FILENO","DOC_GROUP");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "업무유형", "AUDIT_TYPECD","JOB_TYPE");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "업무유형", "AUDIT_TYPENM", "JOB_TYPE");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "발표일자", "PPT_DATE", "PPT_DATE");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 30, "S", "SEQ");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "불량장소", "DEF_PLACECD", "DEF_PLACE");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량장소", "DEF_PLACENM", "DEF_PLACE");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "협력사", "VENDCD", "COOPER_NM");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "협력사", "VENDNM", "COOPER_NM");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINNM", "VIN");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "불량명", "DEFCD", "DEFNM");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량명", "DEFNM", "DEFNM");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "부위명", "DEFPOSCD", "DEFPOSNM");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "부위명", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "4M구분", "VER_4M_TYPE", "VER_4M_TYPE");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "조치내용", "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 30, "첨부파일", "FILE_NAME1", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 30, "첨부파일", "FILE_NAME2", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 30, "첨부파일", "FILE_NAME3", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 30, "첨부파일", "FILE_NAME4", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 30, "첨부파일", "FILE_NAME5", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "첨부파일", "FILE_VIEW1", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "첨부파일", "FILE_VIEW2", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "첨부파일", "FILE_VIEW3", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "첨부파일", "FILE_VIEW4", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "첨부파일", "FILE_VIEW5", "ATT_FILE_NAME");
                this.grd01_QA30511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30511.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA30511.SetColumnType(AxFlexGrid.FCellType.ComboBox, "F1", "VER_4M_TYPE");
                this.grd01_QA30511.SetColumnType(AxFlexGrid.FCellType.Date, "PPT_DATE");
                this.grd01_QA30511.Rows[0].AllowMerging = true;

                this.SetRequired(lbl01_BIZNM, lbl01_ATN_QUITT_TERM);

                this.BtnReset_Click(null, null);

                //this.dte01_PPT_DATE_FROM.SetMMFromStart();
                this.dte01_PPT_DATE_FROM.SetValue(this.dte01_PPT_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


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
                this.grd01_QA30511.InitializeDataSource();

                this.cdx_SETTING();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PPT_DATE_FROM = this.dte01_PPT_DATE_FROM.GetDateText().ToString();
                string PPT_DATE_TO = this.dte01_PPT_DATE_TO.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string AUDIT_TYPE = this.cbo01_AUDIT_TYPE.GetValue().ToString();
                string DEFCD = this.cdx01_DEFCD.GetValue().ToString();
                string DEFPOSCD = this.cdx01_DEFPOSCD.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string PARTNO_NAME = this.txt01_PARTNO_NAME.GetValue().ToString();
                string VER_4M_TYPE = this.cbo01_VER_4M_TYPE.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PPT_DATE_FROM", PPT_DATE_FROM);
                paramSet.Add("PPT_DATE_TO", PPT_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("AUDIT_TYPE", AUDIT_TYPE);
                paramSet.Add("DEFCD", DEFCD);
                paramSet.Add("DEFPOSCD", DEFPOSCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("PARTNO_NAME", PARTNO_NAME);
                paramSet.Add("VER_4M_TYPE", VER_4M_TYPE);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30511.SetValue(source);
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

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA30511_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30511.SelectedRowIndex;
                int Col = this.grd01_QA30511.Col;

                if (Row >= this.grd01_QA30511.Rows.Fixed)
                {
                    int startColIndex = this.grd01_QA30511.Cols["FILE_VIEW1"].Index;

                    if (Row > 0)
                    {
                        if (Col >= startColIndex && Col <= startColIndex + 4 && Col != 0)
                        {
                            if (this.grd01_QA30511.GetValue(Row, Col).ToString() != "")
                            {
                                string CORCD = this.grd01_QA30511.GetValue(Row, "CORCD").ToString();
                                string BIZCD = this.grd01_QA30511.GetValue(Row, "BIZCD").ToString();
                                string FILENO = this.grd01_QA30511.GetValue(Row, "FILENO").ToString();

                                HEParameterSet paramSet = new HEParameterSet();
                                paramSet.Add("CORCD", CORCD);
                                paramSet.Add("BIZCD", BIZCD);
                                paramSet.Add("FILENO", FILENO);
                                paramSet.Add("FILE_SEQ",  (Col - startColIndex + 1).ToString());
                                paramSet.Add("LANG_SET", this.UserInfo.Language);
                                this.BeforeInvokeServer(true);

                                //DataSet source = _WSCOM.Inquery_GET_FILE(paramSet);
                                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE"), paramSet);

                                this.AfterInvokeServer();

                                if (source.Tables[0].Rows.Count > 0)
                                {
                                    DataRow dr = source.Tables[0].Rows[0];

                                    if ((dr["FILE_DATA"]) != System.DBNull.Value)
                                    {
                                        byte[] _FILE_DATA = null;
                                        _FILE_DATA = (byte[])(dr["FILE_DATA"]);

                                        string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["FILE_NAME"].ToString();
                                        System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                        TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                        TEMP_FILE.Close();
                                        TEMP_FILE.Dispose();

                                        System.Diagnostics.Process.Start(FILE_NAME);
                                    }
                                }
                            }
                        }
                        else
                        {
                            string BIZCD = this.grd01_QA30511.GetValue(Row, "BIZCD").ToString();
                            string PPT_DATE_FROM = this.grd01_QA30511.GetValue(Row, "PPT_DATE").ToString();
                            string PPT_DATE_TO = this.grd01_QA30511.GetValue(Row, "PPT_DATE").ToString();
                            string VENDCD = this.grd01_QA30511.GetValue(Row, "VENDCD").ToString();
                            string AUDIT_TYPE = this.grd01_QA30511.GetValue(Row, "AUDIT_TYPECD").ToString();
                            string VINCD = this.grd01_QA30511.GetValue(Row, "VINCD").ToString();
                            string FILENO = this.grd01_QA30511.GetValue(Row, "FILENO").ToString();
                            string PLANT_DIV = this.grd01_QA30511.GetValue(Row, "PLANT_DIV").ToString();

                            ShowPopup(new QA20511(BIZCD, PPT_DATE_FROM, PPT_DATE_TO, VENDCD, AUDIT_TYPE, VINCD, FILENO, PLANT_DIV));
                        }
                    }
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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
