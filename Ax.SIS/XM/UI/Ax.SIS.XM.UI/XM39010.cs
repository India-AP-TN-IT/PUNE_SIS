#region ▶ Description & History
/* 
 * 프로그램명 : 주요 ITEM 수불 현황 (H.Q)
 * 설      명 : 
 * 최초작성자 :
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              
 * 
 *  
 * 
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.SIS.CM.UI;


namespace Ax.SIS.XM.UI
{

    public partial class XM39010 : AxCommonBaseControl
    {
        //private IXM39010 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_XM39010";

        
        public XM39010()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IXM39010>("PM00", "XM39010.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
         
        }

        #region [ 초기화 작업 정의 ]

        private void XM39010_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;

                this.axDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                DataSet source = this.GetTypeCode("1F");
                source.Tables[0].DefaultView.RowFilter = "OBJECT_ID IN ('1F3000','1F3001','1F3100','1F7920','1F7900')"; //평가클래스, 1F3000 원자재, 1F3001 부자재, 1F3100 상품, 1F7920 완제품, 1F7900 반제품

                this.cbo01_ESTI_CLASS.DataBind(source.Tables[0].DefaultView.ToTable().Copy());


                DataTable cboDiv = AxFlexGrid.GetDataSourceSchema("CODE", "NAME").Tables[0];
                cboDiv.Rows.Add("DIV1", this.GetLabel("DIV1") == string.Empty ? "기초" : this.GetLabel("DIV1")); //기초
                cboDiv.Rows.Add("DIV2", this.GetLabel("DIV2") == string.Empty ? "입고" : this.GetLabel("DIV2")); //입고
                cboDiv.Rows.Add("DIV3", this.GetLabel("DIV3") == string.Empty ? "출고" : this.GetLabel("DIV3")); //출고
                cboDiv.Rows.Add("DIV4", this.GetLabel("DIV4") == string.Empty ? "기말" : this.GetLabel("DIV4")); //기말

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "제품구분", "ESTI_CLASS", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "구분", "DIV", "DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "비고", "REMARK", "REMARK");


                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D0", "D0", "D0");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D1", "D1", "D1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D2", "D2", "D2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D3", "D3", "D3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D4", "D4", "D4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D5", "D5", "D5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D6", "D6", "D6");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D7", "D7", "D7");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D8", "D8", "D8");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D9", "D9", "D9");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D10", "D10", "D10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D11", "D11", "D11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D12", "D12", "D12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D13", "D13", "D13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D14", "D14", "D14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D15", "D15", "D15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D16", "D16", "D16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D17", "D17", "D17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D18", "D18", "D18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D19", "D19", "D19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D20", "D20", "D20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D21", "D21", "D21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D22", "D22", "D22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D23", "D23", "D23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D24", "D24", "D24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D25", "D25", "D25");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D26", "D26", "D26");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D27", "D27", "D27");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D28", "D28", "D28");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D29", "D29", "D29");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "D30", "D30", "D30");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "1F", "ESTI_CLASS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, cboDiv, "DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D5");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D6");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D7");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D8");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D9");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D10");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D11");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D12");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D13");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D14");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D15");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D16");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D17");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D18");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D19");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D20");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D21");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D22");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D23");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D24");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D25");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D26");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D27");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D28");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D29");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D30");
                
                this.grd01.Cols["D0"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D1"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D2"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D3"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D4"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D5"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D6"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D7"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D8"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D9"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D10"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D11"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D12"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D13"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D14"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D15"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D16"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D17"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D18"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D19"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D20"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D21"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D22"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D23"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D24"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D25"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D26"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D27"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D28"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D29"].Format = "#,###,###,###,##0";
                this.grd01.Cols["D30"].Format = "#,###,###,###,##0";

                this.grd01.Cols["ESTI_CLASS"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.Cols["DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd01.Cols["PARTNO"].AllowMerging = true;
                this.grd01.Cols["ESTI_CLASS"].AllowMerging = true;
                this.grd01.Cols["PARTNM"].AllowMerging = true;
                this.grd01.AllowMerging = AllowMergingEnum.RestrictCols;

                
                CellStyle csRed = this.grd01.Styles.Add("csPink");
                csRed.BackColor = Color.Pink;

                //한줄 단위로 배경색 변경하는 기능 사용X
                this.grd01.Styles.Alternate.Clear();
                //구분 컬럼까지 틀고정.
                this.grd01.Cols.Frozen = this.grd01.Cols["DIV"].Index;
                
                //날짜에 따라 그리드 컬럼명 설정.
                this.SetGridTitle();


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("DATE", this.dte01_DATE.GetValue().ToString());
                paramSet.Add("ESTI_CLASS", this.cbo01_ESTI_CLASS.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                string where = "";
                int chkCnt = 0;

                if (this.chk01_BASIC_ONLY.Checked)
                {
                    where += "DIV = 'DIV1' ";
                    chkCnt++;


                }
                if (this.chk01_VIEW_RCV_INV.Checked)
                {
                    where += where.Equals("") ? "DIV = 'DIV2' " : "OR DIV = 'DIV2' ";
                    chkCnt++;

                }
                if (this.chk01_VIEW_OUT_INV.Checked)
                {
                    where += where.Equals("") ? "DIV = 'DIV3' " : "OR DIV = 'DIV3' ";
                    chkCnt++;
                }
                if (this.chk01_VIEW_END_INV.Checked)
                {
                    where += where.Equals("") ? "DIV = 'DIV4' " : "OR DIV = 'DIV4' ";
                    chkCnt++;
                }
                source.Tables[0].DefaultView.RowFilter = where;
                DataTable dt = source.Tables[0].DefaultView.ToTable().Copy();
                this.grd01.SetValue(dt);
                this.SetGridStyle(chkCnt);

                ShowDataCount(source);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                int cnt = 0;
                if (this.chk01_BASIC_ONLY.Checked) cnt++;
                if (this.chk01_VIEW_RCV_INV.Checked) cnt++;
                if (this.chk01_VIEW_OUT_INV.Checked) cnt++;
                if (this.chk01_VIEW_END_INV.Checked) cnt++;

                if (cnt <= 0)
                {
                    MsgCodeBox.Show("XM00-0149");// Please select Inv. type!!
                    this.chk01_BASIC_ONLY.Focus();
                    return false;
                }
                //if (this.GetByteCount(cbo01_ESTI_CLASS.GetValue().ToString())<=0)
                //{
                //    //{0}이 입력되지 않았습니다.
                //    MsgCodeBox.ShowFormat("CD00-0082", this.lbl01_ESTI_CLASS.GetValue());
                //    return false;
                //}

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        //날짜변경시 컬럼헤더에 날짜 다시 표시한다, 표시중인 데이터는 초기화 한다. 
        private void dte01_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.SetGridTitle();
            this.grd01.InitializeDataSource();
        }

        #endregion
        
        #region [ 사용자 정의 메서드 ]

        private void SetGridTitle()
        {
            try
            {

                DateTime dtDATE = DateTime.Parse(dte01_DATE.GetValue().ToString());
                string format = this.UserInfo.Language == "KO" ? "MM-dd" : "dd-MM";
                for (int i = 0; i <= 30; i++)
                {
                    this.grd01.Cols["D" + i.ToString()].Caption = dtDATE.AddDays(i).ToString(format);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SetGridStyle(int cnt)
        {
            try
            {
                this.grd01.Styles.Alternate.Clear();

                /* 하나의 품번당 아래와 같은 규칙으로 데이터가 표시됨.(한 품번당 4줄씩)
                 * -----------------------------------------
                   구분   날짜1 날짜2 날짜3 ....    날짜31
                 * -----------------------------------------
                 * 기초      
                 * 입고
                 * 출고
                 * 기말
                 * -----------------------------------------
                 */
                bool isEvenRow = false;

                for (int r = this.grd01.Rows.Fixed; r < this.grd01.Rows.Count; r = r + cnt)
                {
                    //품번단위로 BACKCOLOR 지정한다.(한 품번당 cnt줄씩 있음)
                    if (isEvenRow)
                    {
                        for (int idx = 0; idx < cnt; idx++)
                        {
                            this.grd01.Rows[r + idx].StyleNew.BackColor = Color.FromArgb(222, 245, 250);
                        }
                    }                    
                    else
                    {
                        for (int idx = 0; idx < cnt; idx++)
                        {
                            this.grd01.Rows[r + idx].StyleNew.BackColor = Color.White;
                        }    
                    }
                    isEvenRow = !isEvenRow;


                    for (int i = this.grd01.Cols["D0"].Index; i <= this.grd01.Cols["D30"].Index; i++)
                    {
                        string div = "";
                        int end_qty = 0;
                        int tmr_base_qty = 0;
                        for (int idx = 0; idx < cnt; idx++)
                        {
                            //기말재고가 마이너스 이면 배경색 핑크로 표시.
                            div = this.grd01.GetValue(r + idx, "DIV").ToString();
                            if (div.Equals("DIV4")) //기말재고
                            {
                                end_qty = Convert.ToInt32(this.grd01.GetValue(r + idx, i));
                                if (end_qty < 0)
                                    this.grd01.SetCellStyle(r + idx, i, "csPink");


                                //기초재고 수량이 표시되는 경우에만 스타일 처리함.
                                //오늘의 기말재고가 다음날의 기초재고와 다르면 다음날 기초재고의 배경색을 핑크로 표시함.
                                if (this.chk01_BASIC_ONLY.Checked && i < this.grd01.Cols["D30"].Index)
                                {
                                    if (this.grd01[r, i + 1] != DBNull.Value) //null값이 아닌 경우에만.
                                    {
                                        tmr_base_qty = Convert.ToInt32(this.grd01.GetValue(r, i + 1)); //기초재고수량은 존재한다면 무조건 품번별로 첫번째 행에 있으므로 r 임.
                                        if (end_qty != tmr_base_qty)
                                        {
                                            this.grd01.SetCellStyle(r, i + 1, "csPink");
                                        }
                                    }
                                }
                            }
                      
                        }

                    }
                }

                //품번단위로 BACKCOLOR 지정하면서 고정컬럼 배경색이 덮어씀. 고정컬럼 배경색 다시 지정함.
                this.grd01.Cols["PARTNO"].StyleNew.BackColor = this.grd01.Styles.Frozen.BackColor;
                this.grd01.Cols["PARTNM"].StyleNew.BackColor = this.grd01.Styles.Frozen.BackColor;
                this.grd01.Cols["ESTI_CLASS"].StyleNew.BackColor = this.grd01.Styles.Frozen.BackColor;
                this.grd01.Cols["DIV"].StyleNew.BackColor = this.grd01.Styles.Frozen.BackColor;


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
    