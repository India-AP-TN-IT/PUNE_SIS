#region ▶ Description & History
/* 
 * 프로그램명 : PD40020 장기재고 리스트
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 장기재고 일괄해제
    /// </summary>
    public partial class PD40020 : AxCommonBaseControl
    {
        //private IPD40020 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40020";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40020()
        {
            InitializeComponent();
            
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40020>("PD", "PD40020.svc", "CustomBinding");
                //}
                //else
                //{
                //_WSCOM = ClientFactory.CreateChannel<IPD40020>("PD", "PD40020_N.svc", "CustomBinding");
                //}

                _WSCOM_N = new AxClientProxy();

                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LotNo", "LOTNOCD", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "P/NO", "PNOCD", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "입고일자", "INDAYCD", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "장기확정일", "LONGCHECKDAY", "LONGCHECKDAY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "해제", "CLSCHECK", "CLSCHECK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "해제코드", "FREASONCD", "FREASONCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "해제사유", "FREASONDESC", "CLS_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CLSCHECK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INDAYCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "LONGCHECKDAY");

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox,
                    _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LONGSTOCKFREE"), set2).Tables[0], "FREASONDESC", true);
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, 
                //    _WSCOM_ERM.INQUERY_COMBO_LONGSTOCKFREE().Tables[0], "FREASONDESC", true);
                
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0],
                    "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0],
                //    "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명

                
                this.cbl01_INSTALL_POS.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0],
                    "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명
                //this.cbl01_INSTALL_POS.DataBind(_WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0],
                //    "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명

                this.cbo01_FREASONCD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LONGSTOCKFREE"), set2).Tables[0]);
                //this.cbo01_FREASONCD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LONGSTOCKFREE().Tables[0]);

                if( this.cbl01_LINECD.ListCount >0) this.cbl01_LINECD.SelectedIndex = 0;

                this.SetRequired(lbl01_LINE);
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
                if (this.cbl01_LINECD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("라인을 선택해 주세요.");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINE"));  //라인
                    return;
                }

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                //DataSet source = _WSCOM.INQUERY(this.UserInfo.BusinessCode, set);

                this.grd01.SetValue(source.Tables[0]);
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
                DataSet set1 = this.GetDataSourceSchema("CORCD", "BIZCD", "LOTNOCD");
                DataSet set2 = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "LOTNOCD", "EMPNO", "FREASONCD");

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    if (this.grd01.GetValue(i, "CLSCHECK").ToString().Equals("Y"))
                    {
                        string LOTNOCD   = this.grd01.GetValue(i, "LOTNOCD").ToString();
                        string FREASONCD = this.grd01.GetValue(i, "FREASONCD").ToString();

                        set1.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.UserInfo.BusinessCode, LOTNOCD);

                        set2.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.UserInfo.BusinessCode, LOTNOCD,
                            this.UserInfo.EmpNo, FREASONCD);
                    }


                if (!this.IsSaveValid(set1, set2)) return;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_UPDATE"), set1);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_INSERT"), set2);

                //_WSCOM.SAVE(this.UserInfo.BusinessCode, set1, set2);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //MsgBox.Show("선택하신 장기재고 내역을 일괄해제 하였습니다.");
                MsgCodeBox.Show("PD00-0012");
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

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet set1, DataSet set2)
        {
            if (set1.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("일괄 해제할 장기재고 내역을 선택하세요.");
                MsgCodeBox.Show("PD00-0013");
                return false;
            }

            for (int i = 0; i < set2.Tables[0].Rows.Count; i++)
            {
                string LOTNOCD   = set2.Tables[0].Rows[i]["LOTNOCD"].ToString();
                string FREASONCD = set2.Tables[0].Rows[i]["FREASONCD"].ToString();

                if (LOTNOCD.Length == 0)
                {
                    //MsgBox.Show("일괄 해제할 장기재고 내역에 LOTNO가 없습니다.");
                    MsgCodeBox.Show("PD00-0014");
                    return false;
                }

                if (FREASONCD.Length == 0)
                {
                    //MsgBox.Show("일괄 해제할 장기재고 내역에 해제사유를 선택하지 않았습니다.");
                    MsgCodeBox.Show("PD00-0015");
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void chk01_SELECTED_CheckedChanged(object sender, EventArgs e)
        {
            this.chk01_ALL_CHK.Text = this.chk01_ALL_CHK.Checked ? this.GetLabel("IN_SELECTCANCEL") : this.GetLabel("IN_SELECTALL");  //"전체취소":전체선택

            int col0 = this.grd01.Cols["CLSCHECK"].Index;
            int col1 = this.grd01.Cols["FREASONCD"].Index;
            int col2 = this.grd01.Cols["FREASONDESC"].Index;
            if (this.chk01_ALL_CHK.Checked)
            {
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                    this.grd01.SetValue(i, col0, true);
            }
            else
            {
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.SetValue(i, col0, false);
                    this.grd01.SetValue(i, col1, "");
                    this.grd01.SetValue(i, col2, "");
                }
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == this.grd01.Cols["FREASONDESC"].Index)
            {
                this.grd01.SetValue(e.Row, "FREASONCD", this.grd01.GetValue(e.Row, "FREASONDESC"));
                this.grd01.SetValue(e.Row, "CLSCHECK", true);
            }
        }

        private void cbo01_FREASONCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FREASONDESC = this.cbo01_FREASONCD.GetValue().ToString();
            for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                if (this.grd01.GetValue(i, "CLSCHECK").ToString().Equals("Y"))
                {
                    this.grd01.SetValue(i, this.grd01.Cols["FREASONCD"].Index, FREASONDESC);
                    this.grd01.SetValue(i, this.grd01.Cols["FREASONDESC"].Index, FREASONDESC);
                }
        }

        #endregion
    }
}
