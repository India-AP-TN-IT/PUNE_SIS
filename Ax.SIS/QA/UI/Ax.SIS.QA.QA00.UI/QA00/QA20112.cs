#region ▶ Description & History
/* 
 * 프로그램명 : 개선대책서 품질확인 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-10-10      배명희      신규 추가    
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

namespace Ax.SIS.QA.QA00.UI
{

    public partial class QA20112 : AxCommonBaseControl
    {

        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        
        #endregion

        #region [생성자에 대한 정의]

        public QA20112()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

        }

        #endregion

        #region [초기화에 대한 정의]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;
                              
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                #region [콤보박스 초기화]

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

                
                //조회구분(공정불량, 수입검사)
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY_INSPECT_DIV", set);
                this.cbo01_INS_DIV.DataBind(source.Tables[0], false);
                this.cbo01_INS_DIV.DropDownStyle = ComboBoxStyle.DropDownList;


                //공장구분-------------------------------------------------------------------------
                DataTable dtPlantDiv = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPlantDiv.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(dtPlantDiv, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------

                #endregion

                #region [코드박스 초기화]

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//업체코드
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VIN"); //"차종";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD_OF_VINCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMCD_OF_VINNM";
                this.cdx01_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

                #endregion
                
                #region [수입검사 그리드 grd01]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(1,1);
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "업체코드",     "VENDCD",         "VENDCD");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 150, "업체명",       "VENDNM",         "VENDNM");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 200, "문서발생번호", "DOCNO",          "DOCNO02");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "업체상태",     "VEND_STATUS",    "VEND_STATUS");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "업체상태",     "VEND_STATUSNM",  "VEND_STATUSNM");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 120, "당사상태",     "FIRM_STATUS",    "FIRM_STATUS02");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 150, "업체담당",     "VEND_MGR",       "VEND_MGR");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "수신일자",     "RECEIPT_DATE",   "WKDATE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "불량번호",     "DEFNO",          "DEFNO");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "입고일자",     "RCV_DATE",       "RCV_DATE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 070, "차종",         "VINCD",          "VIN");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 120, "품번",         "PARTNO",         "PARTNO3");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 180, "품명",         "PARTNM",         "PARTNMTITLE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.R, 080, "불량수량",     "DEF_QTY",        "DEF_QTY");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 140, "불량내용",     "DEFNM",          "DEF_CNTT");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 110, "불량장소",     "DEF_PLACENM",    "DEF_PLACE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 070, "작성자",       "INSPECT_NM",     "WRITE_EMP");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 140, "회신요구일",   "REPLY_DEM_DATE", "REPLY_DEM_DATE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "수신확인",     "RECEIPT_YN",     "RECEIPT_YN02");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 060, "시간",         "RECEIPT_TIME",   "TIME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "품질확인",     "CONF_YN",        "QA_CONF_YN");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 100, "사원명",       "CONF_MGRNM",     "EMPNAME");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 120, "확인일자",     "CONF_DATE",      "CONF_DATE");
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 080, "확인시간",     "CONF_TIME",      "CONF_TIME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드",     "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장",       "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "DOCNO2",       "DOCNO2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "IMG여부",      "IMG_LEN");
                
                this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 090, "공장구분",     "PLANT_DIV",      "PLANT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPlantDiv, "PLANT_DIV");
                this.grd01.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RECEIPT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "REPLY_DEM_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CONF_DATE");
                
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Decimal, "VER2_RET_TIME");
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true); //공장구분 추가 2013.04.15(배명희)

                #endregion

                #region [공정불량 그리드 grd02]
                // 공정불량 그리드
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize(1, 1);
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "업체코드",         "VENDCD",           "VENDCD");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 150, "업체명",           "VENDNM",           "VENDNM");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 200, "문서발생번호",     "DEFNO",            "DOCNO02");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 120, "반입일자",         "RCV_DATE",         "EQUIP_DATE");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 080, "차종",             "VINTYPE",          "VIN");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 130, "불량품번",         "DEF_PNO",          "DEF_PNO");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 200, "품명",             "PARTNM",           "PARTNMTITLE");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 140, "귀책구분",         "IMPUT_DIVCDNM",    "RESPONSTITLE");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 140, "불량내용",         "DEFNM",            "DEF_CNTT");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 100, "발생장소",         "DEF_PLACECD",      "DEF_PLACENM");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.R, 090, "불량단가",         "DEF_UCOST",        "DEF_UCOST");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.R, 080, "불량수량",         "DEF_QTY",          "DEF_QTY");                
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 140, "검사원",           "NAME_KOR",         "INSPECT_EMP");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 080, "라인코드",         "LINECD",           "LINECD");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 070, "ALC코드",          "ALCCD",            "ALCCD");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 120, "완제품품번",       "ASSYPNO",          "ASSYPNO02");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 110, "생산등록일",       "PROD_REG_DATE",    "PROD_REG_DATE02");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 140, "생산등록자",       "PROD_REG_EMPNO",   "PROD_REG_EMPNO02");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 170, "불량귀책업체",     "DEF_IMPUT_VENDCD", "DEF_IMPUT_VENDCD02");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 150, "자재재사용여부",   "MAT_REUSE_YN",     "MAT_REUSE_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "SHIFT", "DN_DIV", "SHIFT");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 120, "발생구분",         "OCCUR_DIV",        "OCCUR_DIV");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 130, "원본참조전표번호", "REF_NOTENO",       "REF_NOTENO");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 110, "확인일자",         "RECEIPT_DATE",     "CONF_DATE");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.C, 080, "확인시간",         "RECEPT_TIME",      "CONF_TIME");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "GUBUN", "GUBUN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "IMG여부", "IMG_LEN");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPlantDiv, "PLANT_DIV");
                this.grd02.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_REG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "RECEIPT_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_UCOST");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");


                #endregion
                
                this.SetRequired(lbl01_BIZNM2, lbl01_DEAD_STD);

                this.BtnReset_Click(null, null);

                this.dte01_CLOSE_MONTH.SetMMFromStart();

                this.cbo01_INS_DIV.SelectedValueChanged += new EventHandler(cbo01_INS_DIV_SelectedValueChanged);
                
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
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
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
                string RCV_DATE = this.dte01_CLOSE_MONTH.GetDateText().ToString().Substring(0,7);
            
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string INS_DIV = this.cbo01_INS_DIV.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMID = this.cdx01_ITEMCD.GetValue().ToString();
              
                string INSPECT_DIV = this.cbo01_INS_DIV.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2015.06.29 공장구분 조회조건 추가 (배명희)
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("REV_DATE", RCV_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMID", ITEMID);
                
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("INSPECT_DIV", INSPECT_DIV);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                          //2015.06.29 공장구분 조회조건 추가 (배명희)
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY", paramSet);

                this.AfterInvokeServer();

                if (INSPECT_DIV.Equals("FNINS01"))
                    this.grd01.SetValue(source);
                else
                    this.grd02.SetValue(source);

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

        #region [사용자 정의 메서드]
        /// <summary>
        /// 불량사진 조회
        /// </summary>
        /// <param name="bizcd"></param>
        /// <param name="defno"></param>
        private void GetDefPhoto(string bizcd, string defno)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", bizcd);
                if (this.cbo01_INS_DIV.GetValue().ToString().Equals("FNINS01"))
                    paramSet.Add("DEFNO", defno);
                else
                    paramSet.Add("NOTENO", defno);

                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                if (this.cbo01_INS_DIV.GetValue().ToString().Equals("FNINS01"))
                    source = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY_DEF_PHOTO", paramSet);
                else
                    source = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY_DEF_PHOTO_QA1060", paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["DEF_PHOTO"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA = null;
                        _FILE_DATA = (byte[])(dr["DEF_PHOTO"]);

                        string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\DEF_PHOTO" + DateTime.Now.Ticks.ToString() + ".jpg";
                        System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                        TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                        TEMP_FILE.Close();
                        TEMP_FILE.Dispose();

                        System.Diagnostics.Process.Start(FILE_NAME);
                    }
                }
            }
            catch
                //(Exception ex)
            {

                this.AfterInvokeServer();
                
            }
        }

        #endregion

        #region [컨트롤 이벤트]

        private void cbo01_INS_DIV_SelectedValueChanged(object sender, EventArgs e)
        {
            string inspect_div = this.cbo01_INS_DIV.GetValue().ToString();
            if (inspect_div.Equals("FNINS01"))
            {
                //FNINS01 -- 수입검사
                this.grd01.Visible = true;
                this.grd02.Visible = false;
            }
            else
            {
                //FNINS03 -- 공정불량
                this.grd01.Visible = false;
                this.grd02.Visible = true;
            }
        }

        //수입검사 그리드 더블클릭인 경우
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;
                int Col = this.grd01.Col;

                if (Row >= this.grd01.Rows.Fixed)
                {
                    string BIZCD = this.grd01.GetValue(Row, "BIZCD").ToString();
                    string VENDCD = this.grd01.GetValue(Row, "VENDCD").ToString();
                    string DEFNO = this.grd01.GetValue(Row, "DEFNO").ToString();
                    string DOCNO = this.grd01.GetValue(Row, "DOCNO").ToString();
                    string VEND_STATUS = this.grd01.GetValue(Row, "VEND_STATUS").ToString();
                    
                    switch (this.grd01.Cols[Col].Name.ToString().ToUpper().Trim())
                    {
                        case "DOCNO":
                            string IMG_LEN = this.grd01.GetValue(Row, "IMG_LEN").ToString();

                            //이미지 파일이 있을때만 이미지 표시
                            if (IMG_LEN != "0")
                            {
                                this.GetDefPhoto(BIZCD, DEFNO);
                            }

                            break;

                        default:
                            if (DOCNO.Equals(string.Empty))
                            {
                                //MsgBox.Show("대책서 발행이 되지 않았습니다. 확인하십시오.!!");
                                MsgCodeBox.Show("QA00-030");
                                break;
                            }
                            if (VEND_STATUS.Equals("FHY"))  //VEND_STATUS : FHY-작성, FHN-회신
                            {
                                //MsgBox.Show("대책서발행서 회신 처리가 되지 않았습니다. 확인하십시요!!");
                                MsgCodeBox.Show("QA00-031");

                                break;
                            
                            }
                            if (VEND_STATUS.Equals(string.Empty))  
                            {
                               //MsgBox.Show("대책서발행서가 작성이 되지 않았습니다. 확인하십시요!!");
                                MsgCodeBox.Show("QA00-032");
                                break;
                            }

                            QA20112P1 control = new QA20112P1(BIZCD, VENDCD, DOCNO, DEFNO);
                            //PopupHelper helper = new PopupHelper(control, "입고불량 대책서 검토결과(당사)");
                            PopupHelper helper = new PopupHelper(control, this.GetLabel("QA20112P1"));
                            helper.ShowDialog(false);
                            break;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //공정불량 그리드 더블클릭인 경우
        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd02.SelectedRowIndex;
                int Col = this.grd02.Col;

                if (Row >= this.grd02.Rows.Fixed)
                {
                    string BIZCD = this.grd02.GetValue(Row, "BIZCD").ToString();
                    string DEFNO = this.grd02.GetValue(Row, "DEFNO").ToString();
                    string IMG_LEN = this.grd02.GetValue(Row, "IMG_LEN").ToString();

                    if (IMG_LEN == "0")
                    {
                        //이미지 파일이 없으면 리턴
                        return;
                    }

                    switch (this.grd02.Cols[Col].Name.ToString().ToUpper().Trim())
                    {
                        case "DEFNO":
                            this.GetDefPhoto(BIZCD, DEFNO);
                            break;
                       
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
        
    }
}
