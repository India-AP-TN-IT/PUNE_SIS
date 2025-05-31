#region ▶ Description & History
/* 
 * 프로그램명 : QA30111 수입검사업무종합현황조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>수입검사업무종합현황조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:22:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:22:28   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30111 : AxCommonBaseControl
    {
        //private IQA30111 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30111";

        #region [ 초기화 작업 정의 ]

        public QA30111()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30111>("QA00", "QA30111.svc", "CustomBinding");
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
                this.groupBox_main.Text = this.GetLabel("QA30111_MSG2");                

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.grd01_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA30111.AllowEditing = false;
                this.grd01_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30111.Initialize(3, 3);
                this.grd01_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");            //100
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  150, "업체", "VENDCD", "VENDCD");      //100
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  220, "업체명", "VENDNM", "VENDNM");    //150
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "입고량", "IN_QTY", "IN_QTY");    //120
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "불량수량", "DEF_QTY", "DEF_QTY");//90 
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "불량금액", "DEF_AMT", "DEF_AMT");//100
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량율", "DEF_PS", "BAD_RATE");  //80 
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "건수", "DEF_COUNT", "NO_CASE");  //80
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd01_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "공장구분", "PLANT_DIV", "PLANT_DIV");    //공장구분 추가 2013.04.16(배명희)
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd01_QA30111.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true);              //공장구분 추가 2013.04.16(배명희)

                this.grd01_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd01_QA30111.AddMerge(0, 2, "VENDCD", "VENDCD");
                this.grd01_QA30111.AddMerge(0, 2, "VENDNM", "VENDNM");
                this.grd01_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd01_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd01_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd01_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd01_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd01_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd01_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd01_QA30111.AddMerge(0, 2, "PLANT_DIV", "PLANT_DIV");                                            //공장구분 추가 2013.04.16(배명희)

                this.grd01_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));// "순번");
                this.grd01_QA30111.SetHeadTitle(0, "VENDCD", this.GetLabel("VENDCD"));// "업체");
                this.grd01_QA30111.SetHeadTitle(0, "VENDNM", this.GetLabel("VENDNM"));// "업체명");
                this.grd01_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd01_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd01_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd01_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd01_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd01_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd01_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd01_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd02_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd02_QA30111.AllowEditing = false;
                this.grd02_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30111.Initialize(3, 3);
                this.grd02_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");             //100
                this.grd02_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70 , "차종", "VINCD", "VINCD");         //70 
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  120, "차종", "VINTYPE", "VIN");         //70 
                this.grd02_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80 , "품목", "ITEMCD", "ITEMCD");       //80 
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  160, "품목", "ITEMTYPE", "ITEMNM3");    //80 
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");     //120
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량수량", "DEF_QTY", "DEF_QTY"); //90 
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "불량금액", "DEF_AMT", "DEF_AMT"); //100
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량율", "DEF_PS", "BAD_RATE");   //80 
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "건수", "DEF_COUNT", "NO_CASE");   //80 
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd02_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  130, "공장구분", "PLANT_DIV", "PLANT_DIV");    //공장구분 추가 2013.04.16(배명희)
                
                this.grd02_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd02_QA30111.AddMerge(0, 2, "VINCD", "VINCD");
                this.grd02_QA30111.AddMerge(0, 2, "VINTYPE", "VINTYPE");
                this.grd02_QA30111.AddMerge(0, 2, "ITEMCD", "ITEMCD");
                this.grd02_QA30111.AddMerge(0, 2, "ITEMTYPE", "ITEMTYPE");
                this.grd02_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd02_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd02_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd02_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd02_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd02_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd02_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd02_QA30111.AddMerge(0, 2, "PLANT_DIV", "PLANT_DIV");                                        //공장구분 추가 2013.04.16(배명희)
                this.grd02_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));// "순번");
                this.grd02_QA30111.SetHeadTitle(0, "VINCD", this.GetLabel("VINCD"));// "차종");
                this.grd02_QA30111.SetHeadTitle(0, "VINTYPE", this.GetLabel("VIN"));// "차종");
                this.grd02_QA30111.SetHeadTitle(0, "ITEMCD", this.GetLabel("ITEMCD"));// "품목");
                this.grd02_QA30111.SetHeadTitle(0, "ITEMTYPE", this.GetLabel("ITEMNM3"));// "품목");
                this.grd02_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd02_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd02_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd02_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd02_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd02_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd02_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd02_QA30111.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true);           //공장구분 추가 2013.04.16(배명희)

                this.grd03_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd03_QA30111.AllowEditing = false;
                this.grd03_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA30111.Initialize(3, 3);
                this.grd03_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 120, "순번", "SEQ", "SEQ");            //100
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  90 , "유형", "DEFCD", "DEFCD");        //50 
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  140, "유형명", "DEFNM", "DEFNM");      //100
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  160, "입고량", "IN_QTY", "IN_QTY");    //90 
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량수량", "DEF_QTY", "DEF_QTY");//90 
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "불량금액", "DEF_AMT", "DEF_AMT");//100
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량율", "DEF_PS", "BAD_RATE");  //80 
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  90 , "건수", "DEF_COUNT", "NO_CASE");  //50 
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd03_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  130, "공장구분", "PLANT_DIV", "PLANT_DIV");    //공장구분 추가 2013.04.16(배명희)
                this.grd03_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd03_QA30111.AddMerge(0, 2, "DEFCD", "DEFCD");
                this.grd03_QA30111.AddMerge(0, 2, "DEFNM", "DEFNM");
                this.grd03_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd03_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd03_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd03_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd03_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd03_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd03_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd03_QA30111.AddMerge(0, 2, "PLANT_DIV", "PLANT_DIV");                                        //공장구분 추가 2013.04.16(배명희)
                this.grd03_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));// "순번");
                this.grd03_QA30111.SetHeadTitle(0, "DEFCD", this.GetLabel("DEFCD"));// "유형");
                this.grd03_QA30111.SetHeadTitle(0, "DEFNM", this.GetLabel("DEFNM"));// "유형명");
                this.grd03_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd03_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd03_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd03_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd03_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd03_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");


                //this.grd03_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd03_QA30111.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true);           //공장구분 추가 2013.04.16(배명희)

                this.grd04_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd04_QA30111.AllowEditing = false;
                this.grd04_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd04_QA30111.Initialize(3, 3);
                this.grd04_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");                  //100
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  240, "장소", "DEF_PLACECD", "DEF_PLACECD");  //140
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  200, "장소명", "DEF_PLACENM", "DEF_PLACENM");//100
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");          //90 
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량수량", "DEF_QTY", "DEF_QTY");      //90 
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  140, "불량금액", "DEF_AMT", "DEF_AMT");      //100
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량율", "DEF_PS", "BAD_RATE");        //90 
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  90 , "건수", "DEF_COUNT", "NO_CASE");        //60 
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd04_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  130, "공장구분", "PLANT_DIV", "PLANT_DIV");    //공장구분 추가 2013.04.16(배명희)
                this.grd04_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd04_QA30111.AddMerge(0, 2, "DEF_PLACECD", "DEF_PLACECD");
                this.grd04_QA30111.AddMerge(0, 2, "DEF_PLACENM", "DEF_PLACENM");
                this.grd04_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd04_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd04_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd04_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd04_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd04_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd04_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd04_QA30111.AddMerge(0, 2, "PLANT_DIV", "PLANT_DIV");                                        //공장구분 추가 2013.04.16(배명희)
                this.grd04_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));// "순번");
                this.grd04_QA30111.SetHeadTitle(0, "DEF_PLACECD", this.GetLabel("DEF_PLACECD"));// "장소");
                this.grd04_QA30111.SetHeadTitle(0, "DEF_PLACENM", this.GetLabel("DEF_PLACENM"));// "장소명");
                this.grd04_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd04_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd04_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd04_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd04_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd04_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd04_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                this.grd04_QA30111.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true);           //공장구분 추가 2013.04.16(배명희)
                this.grd05_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd05_QA30111.AllowEditing = false;
                this.grd05_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd05_QA30111.Initialize(3, 3);
                this.grd05_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");             //100
                this.grd05_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40 , "차종", "VINCD", "VINCD");         //40 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  70 , "차종", "VINTYPE", "VIN");         //70 
                this.grd05_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80 , "품목", "ITEMCD", "ITEMCD");       //80 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  120, "품목", "ITEMTYPE", "ITEMNM3");    //80 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  150, "품번", "PARTNO", "PARTNO");       //120
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  180, "품명", "PARTNM", "PARTNM");       //150
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");     //90 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량수량", "DEF_QTY", "DEF_QTY"); //90 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  130, "불량금액", "DEF_AMT", "DEF_AMT"); //100
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량율", "DEF_PS", "BAD_RATE");   //70 
                this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "건수", "DEF_COUNT", "NO_CASE");   //50 
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd05_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd05_QA30111.AddMerge(0, 2, "VINCD", "VINCD");
                this.grd05_QA30111.AddMerge(0, 2, "VINTYPE", "VINTYPE");
                this.grd05_QA30111.AddMerge(0, 2, "ITEMCD", "ITEMCD");
                this.grd05_QA30111.AddMerge(0, 2, "ITEMTYPE", "ITEMTYPE");
                this.grd05_QA30111.AddMerge(0, 2, "PARTNO", "PARTNO");
                this.grd05_QA30111.AddMerge(0, 2, "PARTNM", "PARTNM");
                this.grd05_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd05_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd05_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd05_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd05_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd05_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd05_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd05_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));// "순번");
                this.grd05_QA30111.SetHeadTitle(0, "VINCD", this.GetLabel("VINCD"));// "차종");
                this.grd05_QA30111.SetHeadTitle(0, "VINTYPE", this.GetLabel("VIN"));// "차종");
                this.grd05_QA30111.SetHeadTitle(0, "ITEMCD", this.GetLabel("ITEMCD"));// "품목");
                this.grd05_QA30111.SetHeadTitle(0, "ITEMTYPE", this.GetLabel("ITEMNM3"));// "품목");
                this.grd05_QA30111.SetHeadTitle(0, "PARTNO", this.GetLabel("PARTNO"));// "품번");
                this.grd05_QA30111.SetHeadTitle(0, "PARTNM", this.GetLabel("PARTNM"));// "품명");
                this.grd05_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd05_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd05_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd05_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd05_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd05_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd05_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd05_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd06_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd06_QA30111.AllowEditing = false;
                this.grd06_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd06_QA30111.Initialize(3, 3);
                this.grd06_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");            //100
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  120 , "업체", "VENDCD", "VENDCD");      //80 
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "업체명", "VENDNM", "VENDNM");    //150
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "품번", "PARTNO", "PARTNO");      //120
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  220, "품명", "PARTNM", "PARTNM");      //160
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");    //90 
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량수량", "DEF_QTY", "DEF_QTY");//90 
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량금액", "DEF_AMT", "DEF_AMT");//100
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량율", "DEF_PS", "BAD_rATE");  //70 
                this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "건수", "DEF_COUNT", "NO_CASE");  //50 
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd06_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd06_QA30111.AddMerge(0, 2, "VENDCD", "VENDCD");
                this.grd06_QA30111.AddMerge(0, 2, "VENDNM", "VENDNM");
                this.grd06_QA30111.AddMerge(0, 2, "PARTNO", "PARTNO");
                this.grd06_QA30111.AddMerge(0, 2, "PARTNM", "PARTNM");
                this.grd06_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd06_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd06_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd06_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd06_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd06_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd06_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd06_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));//"순번");
                this.grd06_QA30111.SetHeadTitle(0, "VENDCD", this.GetLabel("VENDCD"));// "업체");
                this.grd06_QA30111.SetHeadTitle(0, "VENDNM", this.GetLabel("VENDNM"));// "업체명");
                this.grd06_QA30111.SetHeadTitle(0, "PARTNO", this.GetLabel("PARTNO"));// "품번");
                this.grd06_QA30111.SetHeadTitle(0, "PARTNM", this.GetLabel("PARTNM"));// "품명");
                this.grd06_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd06_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd06_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd06_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd06_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd06_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd06_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd06_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd07_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd07_QA30111.AllowEditing = false;
                this.grd07_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd07_QA30111.Initialize(3, 3);
                this.grd07_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");            //100
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  120, "업체", "VENDCD", "VENDCD");      //100
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "업체명", "VENDNM", "VENDNM");    //150
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "품번", "PARTNO", "PARTNO");      //120
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  220, "품명", "PARTNM", "PARTNM");      //160
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");    //90 
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량수량", "DEF_QTY", "DEF_QTY");//90 
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량금액", "DEF_AMT", "DEF_AMT");//100
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량율", "DEF_PS", "BAD_RATE");  //70 
                this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "건수", "DEF_COUNT", "NO_CASE");  //50 
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd07_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd07_QA30111.AddMerge(0, 2, "VENDCD", "VENDCD");
                this.grd07_QA30111.AddMerge(0, 2, "VENDNM", "VENDNM");
                this.grd07_QA30111.AddMerge(0, 2, "PARTNO", "PARTNO");
                this.grd07_QA30111.AddMerge(0, 2, "PARTNM", "PARTNM");
                this.grd07_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd07_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd07_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd07_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd07_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd07_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd07_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd07_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));//"순번");
                this.grd07_QA30111.SetHeadTitle(0, "VENDCD", this.GetLabel("VENDCD"));// "업체");
                this.grd07_QA30111.SetHeadTitle(0, "VENDNM", this.GetLabel("VENDNM"));// "업체명");
                this.grd07_QA30111.SetHeadTitle(0, "PARTNO", this.GetLabel("PARTNO"));// "품번");
                this.grd07_QA30111.SetHeadTitle(0, "PARTNM", this.GetLabel("PARTNM"));// "품명");
                this.grd07_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));// "입고불량");
                this.grd07_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));// "입고량");
                this.grd07_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));// "불량수량");
                this.grd07_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));// "불량금액");
                this.grd07_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));// "불량율");
                this.grd07_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));// "건수");

                //this.grd07_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));// "라인불량");  //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));// "자체불량"); //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));// "업체불량");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));// "재투입");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));// "금액");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));// "수량");        //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));// "금액");        //SEAP_DEPRECATED 2019.04.12

                this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd07_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd08_QA30111.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd08_QA30111.AllowEditing = false;
                this.grd08_QA30111.AllowDragging = AllowDraggingEnum.None;
                this.grd08_QA30111.Initialize(3, 3);
                this.grd08_QA30111.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ");            //100
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.C,  120, "업체", "VENDCD", "VENDCD");      //120
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "업체명", "VENDNM", "VENDNM");    //150
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  160, "품번", "PARTNO", "PARTNO");      //120
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.L,  220, "품명", "PARTNM", "PARTNM");      //160
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "입고량", "IN_QTY", "IN_QTY");    //90 
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량수량", "DEF_QTY", "DEF_QTY");//90 
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  120, "불량금액", "DEF_AMT", "DEF_AMT");//100
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "불량율", "DEF_PS", "BAD_RATE");  //70 
                this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R,  100, "건수", "DEF_COUNT", "NO_CASE");  //50 
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_L", "DEF_QTY_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_V", "DEF_QTY_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY_J", "DEF_QTY_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "DEF_AMT_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd08_QA30111.AddMerge(0, 2, "SEQ", "SEQ");
                this.grd08_QA30111.AddMerge(0, 2, "VENDCD", "VENDCD");
                this.grd08_QA30111.AddMerge(0, 2, "VENDNM", "VENDNM");
                this.grd08_QA30111.AddMerge(0, 2, "PARTNO", "PARTNO");
                this.grd08_QA30111.AddMerge(0, 2, "PARTNM", "PARTNM");
                this.grd08_QA30111.AddMerge(0, 0, "IN_QTY", "DEF_COUNT");
                this.grd08_QA30111.AddMerge(1, 2, "IN_QTY", "IN_QTY");
                this.grd08_QA30111.AddMerge(1, 2, "DEF_QTY", "DEF_QTY");
                this.grd08_QA30111.AddMerge(1, 2, "DEF_AMT", "DEF_AMT");
                this.grd08_QA30111.AddMerge(1, 2, "DEF_PS", "DEF_PS");
                this.grd08_QA30111.AddMerge(1, 2, "DEF_COUNT", "DEF_COUNT");

                //this.grd08_QA30111.AddMerge(0, 0, "DEF_QTY_L", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddMerge(1, 1, "DEF_QTY_L", "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddMerge(1, 1, "DEF_QTY_V", "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.AddMerge(1, 1, "DEF_QTY_J", "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.grd08_QA30111.SetHeadTitle(0, "SEQ", this.GetLabel("SEQ"));//"순번");
                this.grd08_QA30111.SetHeadTitle(0, "VENDCD", this.GetLabel("VENDCD"));//"업체");
                this.grd08_QA30111.SetHeadTitle(0, "VENDNM", this.GetLabel("VENDNM"));//"업체명");
                this.grd08_QA30111.SetHeadTitle(0, "PARTNO", this.GetLabel("PARTNO"));//"품번");
                this.grd08_QA30111.SetHeadTitle(0, "PARTNM", this.GetLabel("PARTNM"));//"품명");
                this.grd08_QA30111.SetHeadTitle(0, "IN_QTY", this.GetLabel("INCOM_DEFECT"));//"입고불량");
                this.grd08_QA30111.SetHeadTitle(1, "IN_QTY", this.GetLabel("IN_QTY"));//"입고량");
                this.grd08_QA30111.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));//"불량수량");
                this.grd08_QA30111.SetHeadTitle(1, "DEF_AMT", this.GetLabel("DEF_AMT"));//"불량금액");
                this.grd08_QA30111.SetHeadTitle(1, "DEF_PS", this.GetLabel("BAD_RATE"));//"불량율");
                this.grd08_QA30111.SetHeadTitle(1, "DEF_COUNT", this.GetLabel("NO_CASE"));//"건수");

                //this.grd08_QA30111.SetHeadTitle(0, "DEF_QTY_L", this.GetLabel("LINE_DEFECT"));//"라인불량");               //SEAP_DEPRECATED 2019.04.12 
                //this.grd08_QA30111.SetHeadTitle(1, "DEF_QTY_L", this.GetLabel("PLANT_DEFECT"));//"자체불량");              //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(1, "DEF_QTY_V", this.GetLabel("VENDER_DEFECT"));//"업체불량");             //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(1, "DEF_QTY_J", this.GetLabel("REINPUT"));//"재투입");                     //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_QTY_L", this.GetLabel("DEF_QTY_L"));//this.GetLabel(""));//"수량");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_AMT_L", this.GetLabel("DEF_AMT_L"));//"금액");                     //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_QTY_V", this.GetLabel("DEF_QTY_V"));//"수량");                     //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_AMT_V", this.GetLabel("DEF_AMT_V"));//"금액");                     //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_QTY_J", this.GetLabel("DEF_QTY_J"));//"수량");                     //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetHeadTitle(2, "DEF_AMT_J", this.GetLabel("DEF_AMT_J"));//"금액");                     //SEAP_DEPRECATED 2019.04.12

                this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PS");
                this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_L");    //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_L");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_V");    //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_V");//SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY_J");    //SEAP_DEPRECATED 2019.04.12
                //this.grd08_QA30111.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT_J");//SEAP_DEPRECATED 2019.04.12

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                DataTable combo_source_SELECT_GUBN = new DataTable();
                combo_source_SELECT_GUBN.Columns.Add("CODE");
                combo_source_SELECT_GUBN.Columns.Add("NAME");
                combo_source_SELECT_GUBN.Rows.Add("1", this.GetLabel("BY_VENDER"));//"업체별");
                combo_source_SELECT_GUBN.Rows.Add("2", this.GetLabel("BY_VEHICLE"));//"차종별");
                combo_source_SELECT_GUBN.Rows.Add("3", this.GetLabel("BY_BAD_TYPE"));//"불량유형별");
                combo_source_SELECT_GUBN.Rows.Add("4", this.GetLabel("BY_OCCUR_PLACE"));//"발생장소별");
                this.cbo01_SELECT_GUBN.DataBind(combo_source_SELECT_GUBN, false);
                this.cbo01_SELECT_GUBN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.SetRequired(lbl01_BIZNM, lbl01_SELECT_GUBN, lbl01_OCCUR_DATE);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
               

                //this.dte01_PROC_DATE_FROM.SetMMFromStart();
                this.dte01_PROC_DATE_FROM.SetValue(this.dte01_PROC_DATE_FROM.Value.ToString("yyyy-MM-dd").Substring(0, 8) + "01");

                this.cbo01_SELECT_GUBN.SelectedIndexChanged += new System.EventHandler(this.cbo01_SELECT_GUBN_SelectedIndexChanged);
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
                this.grd01_QA30111.InitializeDataSource();
                this.grd02_QA30111.InitializeDataSource();
                this.grd03_QA30111.InitializeDataSource();
                this.grd04_QA30111.InitializeDataSource();
                this.grd05_QA30111.InitializeDataSource();
                this.grd06_QA30111.InitializeDataSource();
                this.grd07_QA30111.InitializeDataSource();
                this.grd08_QA30111.InitializeDataSource();
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
                string PROC_DATE_FROM = this.dte01_PROC_DATE_FROM.GetDateText().ToString();
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.GetDateText().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.16 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE_FROM", PROC_DATE_FROM);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);        //공장구분 추가 2013.04.16 (배명희)
                
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();
                switch (this.cbo01_SELECT_GUBN.GetValue().ToString())
                {
                    case "1":
                        //source = _WSCOM.Inquery_M1(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_M1"), paramSet);
                        this.grd01_QA30111.SetValue(source);
                        grd = this.grd01_QA30111;
                        break;
                    case "2":
                        //source = _WSCOM.Inquery_M2(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_M2"), paramSet);
                        this.grd02_QA30111.SetValue(source);
                        grd = this.grd02_QA30111;
                        break;
                    case "3":
                        //source = _WSCOM.Inquery_M3(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_M3"), paramSet);
                        this.grd03_QA30111.SetValue(source);
                        grd = this.grd03_QA30111;
                        break;
                    case "4":
                        //source = _WSCOM.Inquery_M4(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_M4"), paramSet);
                        this.grd04_QA30111.SetValue(source);
                        grd = this.grd04_QA30111;
                        break;
                    default:
                        break;
                }

                this.AfterInvokeServer();

                this.grd_COROL(grd);
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

        private void grd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.grd05_QA30111.InitializeDataSource();
                this.grd06_QA30111.InitializeDataSource();
                this.grd07_QA30111.InitializeDataSource();
                this.grd08_QA30111.InitializeDataSource();

                this.BeforeInvokeServer(true);

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PROC_DATE_FROM = this.dte01_PROC_DATE_FROM.GetDateText().ToString();
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.GetDateText().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE_FROM", PROC_DATE_FROM);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();
                int ROW = 0;
                switch (this.cbo01_SELECT_GUBN.GetValue().ToString())
                {
                    case "1":
                        ROW = this.grd01_QA30111.SelectedRowIndex;
                        if (this.grd01_QA30111.GetValue(ROW, "VENDCD").ToString() != "")
                        {

                            this.groupBox_detail.Text = string.Format(this.GetLabel("QA30111_MSG1"), this.GetLabel("VENDORCD"), this.grd01_QA30111.GetValue(ROW, "VENDCD").ToString(), " - ", this.grd01_QA30111.GetValue(ROW, "VENDNM").ToString());
                            //this.groupBox_detail.Text = "상세데이터 (거래처 : " + this.grd01_QA30111.GetValue(ROW, "VENDCD").ToString() + " - " + this.grd01_QA30111.GetValue(ROW, "VENDNM").ToString() + ")";
                            paramSet.Add("VENDCD", this.grd01_QA30111.GetValue(ROW, "VENDCD"));
                            paramSet.Add("LANG_SET", _LANG_SET);
                            paramSet.Add("PLANT_DIV", this.grd01_QA30111.GetValue(ROW, "PLANT_DIV").ToString());
                            //source = _WSCOM.Inquery_D1(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_D1"), paramSet);
                            this.grd05_QA30111.SetValue(source);
                        }
                        grd = this.grd05_QA30111;
                        break;
                    case "2":
                        ROW = this.grd02_QA30111.SelectedRowIndex;
                        if (this.grd02_QA30111.GetValue(ROW, "VINCD").ToString() != "" && this.grd02_QA30111.GetValue(ROW, "ITEMCD").ToString() != "")
                        {
                            this.groupBox_detail.Text = string.Format(this.GetLabel("QA30111_MSG1"), this.GetLabel("VINCD"), this.grd02_QA30111.GetValue(ROW, "VINCD").ToString(), this.GetLabel("ITEMCD") + " : ", this.grd02_QA30111.GetValue(ROW, "ITEMCD").ToString());
                            //this.groupBox_detail.Text = "상세데이터 (차종 : " + this.grd02_QA30111.GetValue(ROW, "VINCD").ToString() + " 품목 : " + this.grd02_QA30111.GetValue(ROW, "ITEMCD").ToString() + ")";
                            paramSet.Add("VINCD", this.grd02_QA30111.GetValue(ROW, "VINCD"));
                            paramSet.Add("ITEMCD", this.grd02_QA30111.GetValue(ROW, "ITEMCD"));
                            paramSet.Add("LANG_SET", _LANG_SET);
                            paramSet.Add("PLANT_DIV", this.grd02_QA30111.GetValue(ROW, "PLANT_DIV").ToString());
                            //source = _WSCOM.Inquery_D2(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_D2"), paramSet);
                            this.grd06_QA30111.SetValue(source);
                        }
                        grd = this.grd06_QA30111;
                        break;
                    case "3":
                        ROW = this.grd03_QA30111.SelectedRowIndex;
                        if (this.grd03_QA30111.GetValue(ROW, "DEFCD").ToString() != "")
                        {
                            this.groupBox_detail.Text = string.Format(this.GetLabel("QA30111_MSG1"), this.GetLabel("DEFCD"), this.grd03_QA30111.GetValue(ROW, "DEFCD").ToString(), " - ", this.grd03_QA30111.GetValue(ROW, "DEFNM").ToString());
                            //this.groupBox_detail.Text = "상세데이터 (불량유형 : " + this.grd03_QA30111.GetValue(ROW, "DEFCD").ToString() + " - " + this.grd03_QA30111.GetValue(ROW, "DEFNM").ToString() + ")";
                            paramSet.Add("DEFCD", this.grd03_QA30111.GetValue(ROW, "DEFCD"));
                            paramSet.Add("LANG_SET", _LANG_SET);
                            paramSet.Add("PLANT_DIV", this.grd03_QA30111.GetValue(ROW, "PLANT_DIV").ToString());
                            //source = _WSCOM.Inquery_D3(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_D3"), paramSet);
                            this.grd07_QA30111.SetValue(source);
                        }
                        grd = this.grd07_QA30111;
                        break;
                    case "4":
                        ROW = this.grd04_QA30111.SelectedRowIndex;
                        if (this.grd04_QA30111.GetValue(ROW, "DEF_PLACECD").ToString() != "")
                        {
                            this.groupBox_detail.Text = string.Format(this.GetLabel("QA30111_MSG1"), this.GetLabel("DEF_PLACECD"), this.grd04_QA30111.GetValue(ROW, "DEF_PLACECD").ToString(), " - ", this.grd04_QA30111.GetValue(ROW, "DEF_PLACENM").ToString());
                            //this.groupBox_detail.Text = "상세데이터 (불량장소 : " + this.grd04_QA30111.GetValue(ROW, "DEF_PLACECD").ToString() + " - " + this.grd04_QA30111.GetValue(ROW, "DEF_PLACENM").ToString() + ")";
                            paramSet.Add("DEF_PLACECD", this.grd04_QA30111.GetValue(ROW, "DEF_PLACECD"));
                            paramSet.Add("LANG_SET", _LANG_SET);
                            paramSet.Add("PLANT_DIV", this.grd04_QA30111.GetValue(ROW, "PLANT_DIV").ToString());
                            //source = _WSCOM.Inquery_D4(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_D4"), paramSet);
                            this.grd08_QA30111.SetValue(source);
                        }
                        grd = this.grd08_QA30111;
                        break;
                    default:
                        break;
                }

                this.AfterInvokeServer();

                this.grd_COROL(grd);
                this.Set_Merging();
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

        private void cbo01_SELECT_GUBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BtnReset_Click(null, null);

            this.grd01_QA30111.Visible = false;
            this.grd02_QA30111.Visible = false;
            this.grd03_QA30111.Visible = false;
            this.grd04_QA30111.Visible = false;
            this.grd05_QA30111.Visible = false;
            this.grd06_QA30111.Visible = false;
            this.grd07_QA30111.Visible = false;
            this.grd08_QA30111.Visible = false;

            switch (this.cbo01_SELECT_GUBN.GetValue().ToString())
            {
                case "1":
                    this.grd01_QA30111.Visible = true;
                    this.grd05_QA30111.Visible = true;
                    break;
                case "2":
                    this.grd02_QA30111.Visible = true;
                    this.grd06_QA30111.Visible = true;
                    break;
                case "3":
                    this.grd03_QA30111.Visible = true;
                    this.grd07_QA30111.Visible = true;
                    break;
                case "4":
                    this.grd04_QA30111.Visible = true;
                    this.grd08_QA30111.Visible = true;
                    break;
                default:
                    break;
            }

            this.BtnQuery_Click(null, null);
        }
        
        #endregion


        #region [ 사용자 정의 메서드 ]

        private void grd_COROL(AxFlexGrid grd)
        {
            grd.Styles.Add("COLOR_W").BackColor = Color.FromArgb(255, 255, 255);
            grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
            grd.Styles.Add("COLOR_G").BackColor = Color.FromArgb(200, 255, 200);
            grd.Styles.Add("COLOR_Y").BackColor = Color.FromArgb(255, 255, 200);

            CellRange cr = new CellRange();
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                switch (grd.GetValue(i, "SEQ").ToString())
                {
                    case "2":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_B"];
                        break;
                    case "3":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_G"];
                        break;
                    case "4":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_Y"];
                        break;
                    default:
                        break;
                }
            }
        }

        private void Set_Merging()
        {
            this.grd02_QA30111.Cols["VINCD"].AllowMerging = true;
            this.grd02_QA30111.Cols["VINTYPE"].AllowMerging = true;
            this.grd02_QA30111.Cols["ITEMCD"].AllowMerging = true;
            this.grd02_QA30111.Cols["ITEMTYPE"].AllowMerging = true;
            this.grd05_QA30111.Cols["VINCD"].AllowMerging = true;
            this.grd05_QA30111.Cols["VINTYPE"].AllowMerging = true;
            this.grd05_QA30111.Cols["ITEMCD"].AllowMerging = true;
            this.grd05_QA30111.Cols["ITEMTYPE"].AllowMerging = true;
            this.grd06_QA30111.Cols["VENDCD"].AllowMerging = true;
            this.grd06_QA30111.Cols["VENDNM"].AllowMerging = true;
            this.grd07_QA30111.Cols["VENDCD"].AllowMerging = true;
            this.grd07_QA30111.Cols["VENDNM"].AllowMerging = true;
            this.grd08_QA30111.Cols["VENDCD"].AllowMerging = true;
            this.grd08_QA30111.Cols["VENDNM"].AllowMerging = true;
        }

        #endregion
    }
}
