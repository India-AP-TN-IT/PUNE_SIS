#region ▶ Description & History
/* 
* 프로그램명 : PD20010 계측유형관리 - 사출SPC
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
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
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 계측 유형 관리 - 사출 SPC
    /// </summary>
    public partial class PD20412 : AxCommonBaseControl
    {
        //private IPD20010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20412";
        
        #region [ 초기화 작업 정의 ]

        public PD20412()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20010>("PD", "PD20010_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "PART NO", "PART_NO", "PART_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "PART NAME", "PART_NAME", "PART_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "RM GRADE", "RM_GRADE", "RM_GRADE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "PART WEIGHT(KG)", "PART_WEIGHT_KG", "PART_WEIGHT_KG");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "SHIFT", "SHIFT", "SHIFT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "LUMPS(KG)", "LUMPS_KG", "LUMPS_KG");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "STARTUP REJECTION", "STARTUP_REJECTION", "STARTUP_REJECTION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "PART REJECTION", "PART_REJECTION", "PART_REJECTION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "MRN", "MRN", "MRN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "TOTAL REGRINDING(KG)", "TOTAL_REGRINDING_KG", "TOTAL_REGRINDING_KG");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "REMARK", "REMARK", "REMARK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "DATE", "WORK_DATE", "WORK_DATE");


                this.BtnQuery_Click(null, null);
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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PART_NO", this.txt01_PART_NO.GetValue());
                //set.Add("ST_DATE", dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));
               // set.Add("ED_DATE", dtp01_ED_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("ST_DATE", this.dtp01_STD_DATE.GetDateText());
                set.Add("ED_DATE", this.dtp01_ED_DATE.GetDateText());
               // set.Add("PART_NAME", this.txt01_PART_NAME.GetValue());
               /* set.Add("RM_GRADE", this.txt01_PART_NO.GetValue());
                set.Add("PART_WEIGHT_KG", this.txt01_PART_NAME.GetValue());
                set.Add("SHIFT", this.txt01_PART_NO.GetValue());
                set.Add("LUMPS_KG", this.txt01_PART_NAME.GetValue());
                set.Add("STARTUP_REJECTION", this.txt01_PART_NO.GetValue());
                set.Add("PART_REJECTION", this.txt01_PART_NAME.GetValue());
                set.Add("MRN", this.txt01_PART_NO.GetValue());
                set.Add("TOTAL_REGRINDING_KG", this.txt01_PART_NAME.GetValue());
                set.Add("REMARK", this.txt01_PART_NAME.GetValue());*/
               // set.Add("BEG_DATE", this.dtp01_BEG_DATE.GetValue());
               // set.Add("END_DATE", this.dtp01_END_DATE.GetValue());
              //  set.Add("ST_DATE", axDateEdit1.GetDateText());
              //  set.Add("ED_DATE", axDateEdit2.GetDateText());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "PART_NO", "PART_NAME", "RM_GRADE", "PART_WEIGHT_KG", "SHIFT", "LUMPS_KG", "STARTUP_REJECTION", "PART_REJECTION", "MRN", "TOTAL_REGRINDING_KG", "REMARK", "WORK_DATE");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    //rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    //source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                    //source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);                
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 계측유형관리 정보가 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.
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

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "PART_NO", "PART_NAME", "RM_GRADE", "PART_WEIGHT_KG", "SHIFT", "LUMPS_KG", "STARTUP_REJECTION", "PART_REJECTION", "MRN", "TOTAL_REGRINDING_KG", "REMARK", "WORK_DATE");
                foreach (DataRow rows in source.Tables[0].Rows)
                {                   
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //###bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //if (isSyncOK) MsgBox.Show("선택하신 계측유형관리 정보가 삭제되었습니다");                
                //###if (isSyncOK) MsgCodeBox.Show("CD00-0072");
                MsgCodeBox.Show("CD00-0072");//삭제되었습니다.
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

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 계측유형 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");//저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string PART_NO = this.grd01.GetValue(i, "PART_NO").ToString();
                    string PART_NAME = this.grd01.GetValue(i, "PART_NAME").ToString();
                    string RM_GRADE = this.grd01.GetValue(i, "RM_GRADE").ToString();
                    string PART_WEIGHT_KG = this.grd01.GetValue(i, "PART_WEIGHT_KG").ToString();
                    string SHIFT = this.grd01.GetValue(i, "SHIFT").ToString();
                    string LUMPS_KG = this.grd01.GetValue(i, "LUMPS_KG").ToString();
                    string STARTUP_REJECTION = this.grd01.GetValue(i, "STARTUP_REJECTION").ToString();
                    string PART_REJECTION = this.grd01.GetValue(i, "PART_REJECTION").ToString();
                    string MRN = this.grd01.GetValue(i, "MRN").ToString();
                    string TOTAL_REGRINDING_KG = this.grd01.GetValue(i, "TOTAL_REGRINDING_KG").ToString();
                    string REMARK = this.grd01.GetValue(i, "REMARK").ToString();
                    string WORK_DATE = this.grd01.GetValue(i, "WORK_DATE").ToString();

                    //if (this.GetByteCount(PART_NO) == 0)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측유형코드}가 입력되지 않았습니다.");
                    //    MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[2].Caption.ToString()); 
                    //    return false;
                    //}

                    //if (this.GetByteCount(PART_NO) > 4)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측유형코드}는 {4}byte 이상 입력할 수 없습니다.");
                    //    MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[2].Caption.ToString(), "4");
                    //    return false;
                    //}

                    //if (this.GetByteCount(PART_NO) == 0)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 계측유형명칭이 입력되지 않았습니다.");
                    //    MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[3].Caption.ToString()); 
                    //    return false;
                    //}

                    //if (this.GetByteCount(PART_NO) > 50)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측유형명칭}은 {50}byte 이상 입력할 수 없습니다.");
                    //    MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[3].Caption.ToString(), "50");
                    //    return false;
                    //}
                }

                //if (MsgBox.Show("입력하신 계측유형 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 계측유형 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 계측유형 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [미들서버에 코드정보 전송]
        //2014.02.10 - MES0310 계측 유형 관리 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES0310", bizcd).Tables[0].Rows[0][0].ToString();
        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;

        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }
                

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }

        //    return true;
        //}
        #endregion
    }
}
