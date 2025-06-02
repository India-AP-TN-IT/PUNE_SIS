#region ▶ Description & History
/* 
 * 프로그램명 : 생산라인 정보 등록
 * 설      명 : 
 * 최초작성자 : 김선환
 * 최초작성일 : 2010-05-07
 * 최종수정자 : 배명희
 * 최종수정일 : 2014-01-06
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-01-06	    배명희		[#001] 공장구분 항목 - 관리자만 수정할수 있도록 되어 있는 구문 제거함.
 *				2014-07-23      배명희      cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *				                            cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using System.Drawing;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>생산 Line 정보 등록</b>    
    /// </summary>
    public partial class BM20011 : AxCommonBaseControl
    {
        //private IBM20011 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_BM20011";
        DataSet source;
        public BM20011()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IBM20011>("PM00", "BM20011.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
            //this.grd01.DataSourceChanged += grd01_DataBindingComplete;
            //this.grd01.AfterDataRefresh += grd01_DataBindingComplete;
            //this.grd01.GridChanged += grd01_DataBindingComplete;     
            source = new DataSet();
      
        }
        

        void grd01_DataBindingComplete(object sender, EventArgs e)
        {
            AxFlexGrid grid = sender as AxFlexGrid;
            foreach (C1.Win.C1FlexGrid.Column col in grid.Cols)
            {
                if (col.DataType != null &&  col.DataType.Name.Equals("DateTime"))
                {
                    for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++ )
                    {
                        if (grid.Cols[col.Name][i] != null && !string.IsNullOrEmpty(grid.Cols[col.Name][i].ToString()))
                            grid.Cols[col.Name][i] = DateTime.Parse(grid.Cols[col.Name][i].ToString()).ToString(grid.Cols[col.Name].Format);
                    }
                }
            }
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                /* Note : 유형코드 정리
                 *  0.  AD : 라인코드구분 ( LINECD_DIV )
                 *  1.  AF : 직간접구분   ( DIRE_DIV )
                 *  2.  D6 : 서열/비서열  ( JIS_DIV )
                 *  3.  AH : 운영형태구분 ( OPR_FORM_DIV )
                 *  4.  A0 : 제품구분     ( PRDT_DIV )
                 *  5.  AG : 간식구분     ( SNACK_DIV )
                 *  6.  A3 : 차종코드     ( VINCD )
                 *  7.  A4 : 품목코드     ( ITEMCD ) */
                source = this.GetTypeCode("U9");

                this.grd01.AllowEditing = false;

                this.grd01.Initialize();
                this.grd01.AllowEditing = true;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "라인코드", "LINECD","LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "라인명", "LINENM","LINENM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 230, "라인단축명", "SHORT_DESC", "LINENM_SHORT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 090, "적용시작일", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 090, "적용종료일", "END_DATE", "END_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 150, "라인코드 구분", "LINECD_DIV","LINECD_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "장착위치통합", "INSTALL_POS_INTE_YN", "INSTALL_POS_INTE_YN");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "저장위치", "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "저장위치명", "STR_LOCNM", "STR_LOCNM2");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "서열/비서열", "JIS_DIV","JIS_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "제품구분", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VINCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "LEVEL", "PRDHA", "PRDHA");                
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 090, "C/CENTER", "KOSTL", "KOSTL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "UPH", "UPH", "UPH");
                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 070, "MAN(DIR)", "DIR_MAN_COUNT", "DIR_MAN_COUNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 070, "MAN(I/DIR)", "INDIR_MAN_COUNT", "INDIR_MAN_COUNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "삭제여부", "DELETE_YN", "DEL_YN");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                

                this.grd01.Cols["BEG_DATE"].Format = "yyyy-MM-dd";
                this.grd01.Cols["END_DATE"].Format = "yyyy-MM-dd";



                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AD", "LINECD_DIV");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "D6", "JIS_DIV");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A0", "PRDT_DIV");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");                
                
                //공장구분
                source.Tables[0].DefaultView.RowFilter = "GROUPCD = '" + this.UserInfo.BusinessCode + "'";
                DataTable dtPlant_Div = source.Tables[0].DefaultView.ToTable().Copy();
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPlant_Div, "PLANT_DIV");

                this.grd01.Cols["SHORT_DESC"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["PLANT_DIV"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["KOSTL"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["PRDT_DIV"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["JIS_DIV"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["UPH"].StyleDisplay.BackColor = Color.LightYellow;

                this.grd01.Cols["INDIR_MAN_COUNT"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["PGN"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["DIR_MAN_COUNT"].StyleDisplay.BackColor = Color.LightYellow;

                //사업장 조건 변경시 - 공장구분 재바인딩
                this.cbo01_BIZCD.SelectedValueChanged += new EventHandler(cbo01_BIZCD_SelectedValueChanged);
                

                this.cbo01_LINECD_DIV.DataBind("AD");
                
               
                
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        //사업장은 pk 이므로 사업장 조회조건 변경시 그리드 초기화 및 "공장구분" 목록 재바인딩
        void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                source.Tables[0].DefaultView.RowFilter = "GROUPCD = '" + bizcd + "'";
                DataTable dtPlant_Div = source.Tables[0].DefaultView.ToTable().Copy();

                this.grd01.InitializeDataSource();
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPlant_Div, "PLANT_DIV");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }

        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "LINECD", "PLANT_DIV", "UPH", "KOSTL", "PRDT_DIV", "SHORT_DESC", "PGN", "DIR_MAN_COUNT", "INDIR_MAN_COUNT");
                
                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.AfterInvokeServer();

                //MsgBox.Show("정상적으로 저장되었습니다.");
                MsgCodeBox.Show("CD00-0009");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }            
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                set.Add("LINECD",   this.txt01_LINECD.GetValue());
                set.Add("LINENM",   this.txt01_LINENM.GetValue());
                set.Add("LINECD_DIV", this.cbo01_LINECD_DIV.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("DELETE_YN", this.chk01DELETE_YN.Checked ? "Y" : "N");
                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.grd01.SetValue(dsInquery.Tables[0]);
                ShowDataCount(dsInquery);
                
                

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {

                this.cbo01_LINECD_DIV.Initialize();
                this.txt01_LINECD.Initialize();
                this.txt01_LINENM.Initialize();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

       
     
        #endregion

        #region [ 유효성 검사 ]

        public bool IsSaveValid(DataSet source)
        {
            try
            {                
                if(source.Tables[0].Rows.Count <= 0)
                {
                    //MsgBox.Show("저장 할 라인코드 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                

                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

 

     

        #endregion

    }
}
