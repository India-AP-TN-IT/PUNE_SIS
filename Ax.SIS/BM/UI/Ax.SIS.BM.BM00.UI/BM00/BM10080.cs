#region ▶ Description & History
/* 
 * 프로그램명 : 제조P/NO S/W현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23      배명희     cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *
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
using System.Collections.Generic;
using System.Drawing;
namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-08-19 오전 9:33:49<br />
    /// - 주요 변경 사항
    ///     1) 2010-08-19 오전 9:33:49   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM10080 : AxCommonBaseControl
    {

        private AxClientProxy _WSCOM_N;
        
        public BM10080()
        {
            InitializeComponent();
            
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //사업장
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

               
                this.grd01.PopMenuVisible = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "C/CODE", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "B/CODE", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part NO.", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Name", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "CAR", "VINNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "E/O NO.", "EONO", "EONO");

                this.grd01.Cols.Frozen = grd01.Cols["PARTNM"].Index;
                this.grd01.Cols["EONO"].Style.BackColor = Color.LightGoldenrodYellow;


                // dtp01_STD_DATE.SetValue("1990-01-01");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string GetPRDT_DIV()
        {
            if(radioButton1.Checked)
            {
                return "A0A";
            }
            else if (radioButton2.Checked)
            {
                return "A0S";
            }
            return "A0M";
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsQueryValid())
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("LANG_SET", UserInfo.Language);
                    paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());

                    paramSet.Add("PARTNO", Txt_PartNo.Text);
                    paramSet.Add("VINCD", cdx01_VINCD.GetValue());
                    paramSet.Add("ITEMCD", "");
                    paramSet.Add("PRDT_DIV", GetPRDT_DIV());
                    paramSet.Add("STD_DATE", dtp01_STD_DATE.GetDateText());


                    DataTable dt = _WSCOM_N.ExecuteDataSet("APG_BM10080.GET_DATA", paramSet, "OUT_CURSOR").Tables[0];


                    this.grd01.SetValue(dt);
                }
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
               
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {

        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <2)
            {
                return;
            }
            if (MsgBox.Show("Do you want to save?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                                
                DataSet ds = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD","BIZCD", "PARTNO", "EONO");

                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    
                    ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                }
                _WSCOM_N.ExecuteNonQueryTx("APG_BM10080.SET_DATA", ds);
                BtnQuery_Click(null, null);
            }

        }
        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            if (GetPRDT_DIV() != "A0A")
            {
                if (Txt_PartNo.Text.ToString().Length == 0)
                {
                    MsgBox.Show("Part NO is mandatory.");
                    return false;
                }
            }
            else
            {
                if (Txt_PartNo.Text.ToString().Length == 0 && string.IsNullOrEmpty(cdx01_VINCD.GetValue().ToString()) ==true)
                {
                    MsgBox.Show("Part NO or Car Kind is mandatory.");
                    return false;
                }
            }

            return true;
        }

        #endregion
        

        private void button1_Click(object sender, EventArgs e)
        {
            PopupHelper helper = null;
            BM10010P0 _bm1 = new BM10010P0();
           
            _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            _bm1.HEUserParameterSetValue("PARTNO", Txt_PartNo.Text);
            _bm1.HEUserParameterSetValue("PARTNM", "");
            _bm1.HEUserParameterSetValue("STD_DATE", dtp01_STD_DATE.GetDateText());
            helper = new PopupHelper(_bm1, "Part NO. Search");
            helper.ShowDialog();

            DataRow row = (DataRow)helper.SelectedData;
            if (row != null)
            {
                Txt_PartNo.Text = row["PARTNO"].ToString();
            }
            
        }


    }
}

