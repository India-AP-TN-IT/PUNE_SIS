#region ▶ Description & History
/* 
 * 프로그램명 : PD33110 실사 생산실적 수정 내역 조회
 * 설      명 : 
 * 최초작성자 : 진승모
 * 최초작성일 : 2014-10-07 
 * 최종수정자 : 진승모
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014-10-07    진승모     다국어 적용   
 *              2017-07~09    배명희     SIS 이관
 *              
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>실사 생산실적 수정 내역 조회</b>
    /// - 작 성 자 : 김선환<br />
    /// - 작 성 일 : 2010-06-25 오전 10:24:12<br />
    /// </summary>
    public partial class PD33110 : AxCommonBaseControl
    {
        //private IPD33110 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD33110";

        public PD33110()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD33110>("PM03", "PD33110.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD33110_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel2;
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
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "일자", "RSLT_DATE", "RSLT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "업무", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "주야", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "완반", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "실적수량", "SUM_QTY", "RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "합계", "TOT_QTY", "SUMTOT");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SUM_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY");

                this.grd01.Cols["RSLT_DATE"].AllowMerging = true;
                this.grd01.Cols["RSLT_DATE"].TextAlign = TextAlignEnum.LeftTop;
                this.grd01.Cols["JOB_TYPE"].AllowMerging = true;
                this.grd01.Cols["JOB_TYPE"].TextAlign = TextAlignEnum.LeftTop;
                this.grd01.Cols["SHIFT"].AllowMerging = true;
                this.grd01.Cols["SHIFT"].TextAlign = TextAlignEnum.LeftTop;
                this.grd01.Cols["PRDT_DIV"].AllowMerging = true;
                this.grd01.Cols["PRDT_DIV"].TextAlign = TextAlignEnum.LeftTop;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_PRDT_DIV.DataBind("A0", false);
                this.cbo01_PRDT_DIV.SelectedItem = 0;
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
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                paramSet.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue().ToString());
                paramSet.Add("LINECD", this.cbo01_LINECD.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                grd01.MergedRanges.Clear();

                this.grd01.SetValue(source.Tables[0]);
                this.AfterInvokeServer();
                if (source.Tables[0].Rows.Count == 0)
                    return;

                grd01.setSumStyle(5, 7, AxFlexGrid.eSumStyle.RowColMode);

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
            this.grd01.InitializeDataSource();
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]


        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0A")
                {
                    Get_LineCD("A0A");
                }

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0S")
                {
                    Get_LineCD("A0S");
                }

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0M")
                {
                    Get_LineCD("A0M");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //private enum eSumStyle { RowColMode, RowOnlyMode };

        //private void setSumStyle(AxFlexGrid grd, int iSumLevel, int iMergeTo)
        //{
        //    try
        //    {
        //        setSumStyle(grd, iSumLevel, iMergeTo, eSumStyle.RowColMode, null);
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void setSumStyle(AxFlexGrid grd, int iSumLevel, int iMergeTo, eSumStyle sumStyle)
        //{
        //    try
        //    {
        //        setSumStyle(grd, iSumLevel, iMergeTo, sumStyle, null);
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void setSumStyle(AxFlexGrid grd, int iSumLevel, int iMergeTo, eSumStyle sumStyle, string[] exSumLable)
        //{
        //    try{
        //        int iColsLength = iSumLevel - 1;
        //        string[] sSumLable = { "계", "소계", "중계", "합계", "총계" };
        //        String[] preTitele = new String[iColsLength];
        //        int[] prePos = new int[iColsLength];

        //        if (exSumLable != null && exSumLable.Length>1)
        //        {
        //            sSumLable = exSumLable;
        //        }

        //        grd.AllowMerging = AllowMergingEnum.Custom;
        //        for (int i = grd.Cols.Fixed; i < grd.Cols.Count; i++)
        //        {
        //            grd.Cols[i].AllowMerging = true;
        //        }
        //        for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
        //        {
        //            grd.Rows[i].AllowMerging = true;
        //        }

        //        for (int i = 0; i < preTitele.Length; i++)
        //        {
        //            preTitele[i] = grd.GetData(1, i + 1).ToString();
        //            prePos[i] = 1;
        //        }

        //        CellRange cr = new CellRange();
        //        bool isCategorized = false;

        //        for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
        //        {
        //            grd.Rows[i].AllowMerging = true;

        //            if (sumStyle == eSumStyle.RowColMode)
        //            {
        //                for (int j = 0; j < preTitele.Length; j++)
        //                {
        //                    if (preTitele[j] != grd.GetData(i, j + grd.Cols.Fixed).ToString())
        //                    {
        //                        isCategorized = false;
        //                        cr = grd.GetCellRange(prePos[j], j + grd.Cols.Fixed, i - 1, j + grd.Cols.Fixed);

        //                        for (int k = 0; k < sSumLable.Length; k++)
        //                        {
        //                            if (preTitele[j].Equals(sSumLable[k]))
        //                            {
        //                                isCategorized = true;
        //                                break;
        //                            }
        //                        }

        //                        if (!isCategorized)
        //                        {
        //                            cr.Style = grd.Styles["SumLevel" + (iSumLevel - (j + grd.Cols.Fixed)).ToString() + "C"];
        //                        }

        //                        grd.MergedRanges.Add(cr);
        //                        preTitele[j] = grd.GetData(i, j + grd.Cols.Fixed).ToString();
        //                        prePos[j] = i;
        //                    }
        //                }
        //            }

        //            if (sumStyle == eSumStyle.RowColMode)
        //            {
        //                for (int k = 0; k < sSumLable.Length; k++)
        //                {
        //                    if (grd.GetData(i, iMergeTo).ToString().Equals(sSumLable[k]))
        //                    {
        //                        cr = grd.GetCellRange(i, iSumLevel - (k + 1) + grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
        //                        cr.Style = grd.Styles["SumLevel" + (k + 1).ToString() + "R"];
        //                        grd.AddMerge(i, i, iSumLevel - (k + 1) + grd.Cols.Fixed, iMergeTo);
        //                        break;
        //                    }
        //                }
        //            }
        //            else if (sumStyle == eSumStyle.RowOnlyMode)
        //            {
        //                {
        //                    for (int k = 0; k < sSumLable.Length; k++)
        //                    {
        //                        if (grd.GetData(i, iMergeTo).ToString().Equals(sSumLable[k]))
        //                        {
        //                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
        //                            cr.Style = grd.Styles["SumLevel" + (k + 1).ToString() + "R"];
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                DateTime t1 = DateTime.Parse(dtp01_BEG_DATE.GetValue().ToString());
                DateTime t2 = DateTime.Parse(dtp01_END_DATE.GetValue().ToString());

                TimeSpan t3 = t2 - t1;

                if (t3.Days < 0)
                {
                    //MsgBox.Show("날짜 지정이 올바르지 않습니다.");
                    MsgCodeBox.Show("PD00-0080");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void Get_LineCD(string Line_Div)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("PRDT_DIV", Line_Div);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("DATE", this.dtp01_BEG_DATE.GetDateText());

                //DataSet source = _WSCOM.Get_Linecd(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_LINECD"), paramSet);
                this.cbo01_LINECD.DataBind(source.Tables[0]);

                this.cbo01_LINECD.SelectedIndex = 0;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

    }
}
