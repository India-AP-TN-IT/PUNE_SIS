#region ▶ Description & History
/* 
 * 프로그램명 : QA30011 검사 기준정보 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *
*/
#endregion
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

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>검사 기준정보 조회 </b>
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2014-11-05 오후 2:52:52<br />
    /// - 주요 변경 사항
    ///     1) 2014-11-05 오후 2:52:52   배명희 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30011 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        #region [ 초기화 작업 정의 ]

        public QA30011()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.grp01_QA20011_MSG1.Text = this.GetLabel("QA30011_MSG1");
                this.grp01_QA30011_MSG1.Text = this.GetLabel("QA30011_MSG2");                

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;


                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();


                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
               

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                //공장구분-------------------------------------------------------------------------
                DataTable source = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                //if (this.UserInfo.PlantDiv.Equals("U902"))
                //    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, true);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
             
                this.pic01_INSPECT_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_PARTNO_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                //부품별 검사코드 목록 그리드
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드",   "CORCD",                "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD",                "BIZCD");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 080, "차종",       "VINCD",                "VIN");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 100, "품목",       "ITEMCD",               "ITEM");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 200, "품명",       "ITEMNM",               "PARTNMTITLE");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "업체코드",   "VENDCD",               "VENDCD");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 120, "업체명",     "VENDNM",               "VENDNM");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 060, "위치",       "INSTALL_POS",          "POS");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 110, "검사코드",   "INSPECT_CLASSCD",      "QA_INSPECT_BASECODE");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 140, "검사명",     "INSPECT_CLASSNM",      "QA_AINSPECT_CLASSNQA");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "검사코드",   "INSPECT_CLASSCD_BASE", "QA_INSPECT_BASECODE");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 100, "기준서",     "INSPECT_STD_PHOTO_YN", "STD_REPORT");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 050, "사진",       "PARTNO_PHOTO_YN",      "PHOTO");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 050, "사용",       "USE_YN",               "USEYN2");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 140, "유검사",     "INSPECT_YN",           "INSPECT_YN2");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 140, "상시검사",   "ALWAYS_YNNM",          "ALWAYS_YN2");                
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 150, "성적서관리", "CERTIFICATE_YNNM",     "CERTIFICATE_YN2");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 060, "구분",       "ISBASECODE",           "DIVISION");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 140, "적용수",     "CNT",                  "APP_CNT");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 080, "최종발생일", "CONV_DATE",            "CONV_DATE2");

                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 120, "공장구분",   "PLANT_DIV",            "PLANT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PLANT_DIV");
                this.grd01.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CNT");
                

                //세부정보 그리드
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AllowSorting = AllowSortingEnum.None;             
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드",   "CORCD",              "CORCD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD",              "BIZCD");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 040, "순번",       "INSPECT_SEQ",        "SEQ_NO");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 150, "검사항목",   "INSPECT_ITEMNM",     "E/TESTPART");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.R, 140, "표준치수",   "INSPECT_STD_MEAS",   "INSPECT_STD_MEAS2");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.R, 140, "상한치",     "INSPECT_MAX_MEAS",   "INSPECT_MAX_MEAS2");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.R, 140, "하한치",     "INSPECT_MIN_MEAS",   "INSPECT_MIN_MEAS2");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 110, "검사단위",   "INSPECT_UNITCD",     "INSPECT_UNITNM");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 130, "검사주기",   "INSPECT_CYCCD",      "INSPECT_CYCNM");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 070, "구분",       "CLASS_DIV",          "DIVISION");
                this.grd02.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 080, "필수",       "MAND_INPUT_ITEM_YN", "MAND_INPUT_ITEM");                
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_USE_YN, "MAND_INPUT_ITEM_YN");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "INSPECT_SEQ");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_STD_MEAS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MAX_MEAS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MIN_MEAS");

                //적용 품목 그리드
                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize();
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "차종",     "VINCD",  "VIN");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "자재품번", "PARTNO", "MAT_PARTNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "자재품명", "PARTNM", "MAT_PARTNM");
               
                
               
                this.cbo01_USE_YN.SelectedIndex = 0;
               
                this.SetRequired(lbl01_BIZNM2);

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
            try
            {
                this.grd03.InitializeDataSource();
                this.grd02.InitializeDataSource();

                this.cbo01_USE_YN.SelectedIndex = 0;

                this.pic01_INSPECT_STD_PHOTO.Initialize();
                this.pic01_PARTNO_PHOTO.Initialize();                            
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
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt01_INSPECT_CLASSCD.GetValue().ToString();
                string PARTNONM = this.txt01_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("INSPECT_CLASSCDNM", INSPECT_CLASSCD);
                paramSet.Add("PARTNONM", PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA30011", "INQUERY"), paramSet);
                
                this.AfterInvokeServer();

                this.grd01.SetValue(source);
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

        #region [ 컨트롤 이벤트]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;

                if (Row > 0)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01.GetValue(Row, "BIZCD").ToString();
                    string INSPECT_CLASSCD = this.grd01.GetValue(Row, "INSPECT_CLASSCD").ToString();
    
              
                    this.IMAGE_VIEW(BIZCD, INSPECT_CLASSCD);

                    this.Detail(BIZCD, INSPECT_CLASSCD);
                    this.ApplyList(BIZCD, INSPECT_CLASSCD);

                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_INSPECT_STD_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_INSPECT_STD_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_INSPECT_STD_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_PARTNO_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_PARTNO_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_PARTNO_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]
        
        private void Detail(string BIZCD, string INSPECT_CLASSCD)
        {
            if (this.GetByteCount(INSPECT_CLASSCD) != 0)
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}","APG_QA30011", "INQUERY_DETAIL"), paramSet);

                this.grd02.SetValue(source);
            }
        }

        private void ApplyList(string BIZCD, string INSPECT_CLASSCD)
        {
            if (this.GetByteCount(INSPECT_CLASSCD) != 0)
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA30011", "INQUERY_APPLY_LIST"), paramSet);

                this.grd03.SetValue(source);
            }
        }

        private void IMAGE_VIEW(string BIZCD, string INSPECT_CLASSCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA30011", "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["INSPECT_STD_PHOTO"]) != System.DBNull.Value)
                    {
                        byte[] _INSPECT_STD_PHOTO = null;
                        _INSPECT_STD_PHOTO = (byte[])(dr["INSPECT_STD_PHOTO"]);
                        this.pic01_INSPECT_STD_PHOTO.SetValue(_INSPECT_STD_PHOTO);
                    }

                    if ((dr["PARTNO_PHOTO"]) != System.DBNull.Value)
                    {
                        byte[] _PARTNO_PHOTO = null;
                        _PARTNO_PHOTO = (byte[])(dr["PARTNO_PHOTO"]);
                        this.pic01_PARTNO_PHOTO.SetValue(_PARTNO_PHOTO);
                    }
                }
                else
                {
                    this.pic01_INSPECT_STD_PHOTO.SetValue(null);
                    this.pic01_PARTNO_PHOTO.SetValue(null);
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
        
        #endregion

    }
}
