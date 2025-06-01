#region ▶ Description & History
/* 
 * 프로그램명 : 일일 클레임 수신자료 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-08-18      배명희      신규 생성
 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using System.IO;
using System.Data.OleDb;

using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>일일 클레임 수신자료 관리</b>   
    /// </summary>
    public partial class QA21411 : AxCommonBaseControl
    {

        #region [필드에 대한 정의]

        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME= "APG_QA21411";
        #endregion

        #region [생성자에 대한 정의]
        
        public QA21411()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

        }
        #endregion

        #region [초기화 작업에 대한 정의]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {   

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);                
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                //if (this.UserInfo.IsAdmin == "Y")                
                //    this.cbo01_BIZCD.Enabled = true;                
                //else                
                //    this.cbo01_BIZCD.Enabled = false;

                DataSet source = this.GetTypeCode("QA", "QD", "QE");
                this.cbo01_TYPE.DataBind(source.Tables[1], true);
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
                this.cbo01_FILENO.DataBind(source.Tables[2], true);

                this.SetBindComboBox();


                this.dte01_PROD_SAL_SDATE.DataType = typeof(int);
                this.dte01_PROD_SAL_SDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_PROD_SAL_SDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_SDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.EditFormat.CustomFormat = "########";
                this.dte01_PROD_SAL_SDATE.EditFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_EDATE.DataType = typeof(int);
                this.dte01_PROD_SAL_EDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_PROD_SAL_EDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_EDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.EditFormat.CustomFormat = "########";
                this.dte01_PROD_SAL_EDATE.EditFormat.EmptyAsNull = true;

                this.dte01_REPR_CONF_SDATE.DataType = typeof(int);
                this.dte01_REPR_CONF_SDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_REPR_CONF_SDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_SDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.EditFormat.CustomFormat = "########";
                this.dte01_REPR_CONF_SDATE.EditFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_EDATE.DataType = typeof(int);
                this.dte01_REPR_CONF_EDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_REPR_CONF_EDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_EDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.EditFormat.CustomFormat = "########";
                this.dte01_REPR_CONF_EDATE.EditFormat.EmptyAsNull = true;


                #region [grd01]
                this.grd01.AllowEditing = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.CurrentContextMenu.Items[0].Visible = false;

                this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);                

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "Type", "CTYPE2", "CTYPE2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "차종", "VEHICLE", "VEHICLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINCD", "VINCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "차종", "VINNM", "VINNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO3", "PARTNO3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO2", "PARTNO2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "부품명", "PARTNAME", "PARTNAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "시스템", "SYSTEM", "SYSTEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "현상코드", "PRESCD", "PRESCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "현상명", "PRESNM", "PRESNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "특이사항", "ISSUE", "ISSUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC1", "DTC1", "DTC1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC2", "DTC2", "DTC2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC3", "DTC3", "DTC3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매일", "SAL_DATE", "SAL_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "보증시작일", "WARR_BEG_DATE", "WARR_BEG_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수리일", "REPAIR_DATE", "REPAIR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "확정일", "CONF_DATE2", "CONF_DATE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "재고일수", "STOCK_DAY", "STOCK_DAY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "사용일수", "USE_DAY", "USE_DAY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 070, "사용일수", "USE_MONTH", "USE_MONTH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "주행거리", "USE_DISTANCE", "USE_DISTANCE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "부품비", "PART_COST", "PART_COST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "총비용", "TOT_COST", "TOT_COST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "R/O NO", "RONO", "RONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매국가", "SAL_NATION", "SAL_NATION");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "판매국가", "CLAIM_REGIONCD", "CLAIM_REGIONCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "판매국가", "CLAIM_NATIONCD", "CLAIM_NATIONCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수리업체코드", "MAINT_VENDCD", "MAINT_VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "수리업체명", "MAINT_VENDNM", "MAINT_VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "수리업체전화", "MAINT_TELNO", "MAINT_TELNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "귀책업체", "IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "정비업체", "PROD_VENDOR2", "PROD_VENDOR2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "정비업체", "PROD_VENDCD", "PROD_VENDCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "정비업체", "PROD_VENDNM", "PROD_VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "최종개발", "LAST_DEV_VENDOR", "LAST_DEV_VENDOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "MOB변제", "MOB_PAY_VENDOR", "MOB_PAY_VENDOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "GLV변제", "GLV_PAY_VENDOR", "GLV_PAY_VENDOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업코드", "MWORKDCD", "MWORKDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매구분", "SAL_TYPE", "SAL_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "VIN NO", "VINNO", "VINNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "MI 코드", "MICODE", "MICODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "OP 코드", "OPCODE", "OPCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Version", "VERSION", "VERSION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "엔진", "ENGINE_NO2", "ENGINE_NO2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "변속기번호", "TRANS_MS_NO", "TRANS_MS_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "C/10000구분", "C10000_TYPE", "C10000_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "CS10000구분", "CS10000_TYPE", "CS10000_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "확정전(1) 확정(2)", "CONFIRM_TYPE2", "CONFIRM_TYPE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "생산법인", "PROD_CUST", "PROD_CUST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "공장", "CUST_PLANT2", "CUST_PLANT2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "엔진명", "ENGINE_NM", "ENGINE_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "변속기 프로젝트 코드", "TRANS_MS_PJTCD2", "TRANS_MS_PJTCD2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "비품질 클레임 여부", "NON_QC_CLAIM_TYPE2", "NON_QC_CLAIM_TYPE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "DTC4", "DTC4", "DTC4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "DTC5", "DTC5","DTC5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "대책서", "FILENAME", "FILENAME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 160, "대책서번호", "FILENO", "FILENO");
                
                this.grd01.Rows[0].Height = 50;

                //this.grd01.SetValue(0, this.grd01.Cols["CONFIRM_TYPE2"].Index, "확정전(1)\r\n확정(2)");
                //this.grd01.SetValue(0, this.grd01.Cols["TRANS_MS_PJTCD2"].Index, "변속기\r\n프로젝트\r\n코드");
                //this.grd01.SetValue(0, this.grd01.Cols["NON_QC_CLAIM_TYPE2"].Index, "비품질\r\n클레임\r\n여부");

                #endregion

                #region [grd02-숨김그리드]

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "Type", "CTYPE2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "차종", "VEHICLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "품번", "PARTNO3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "부품명", "PARTNAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "시스템", "SYSTEM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "현상코드", "PRESCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "현상명", "PRESNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "특이사항", "ISSUE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC1", "DTC1");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC2", "DTC2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "DTC3", "DTC3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "생산일자", "PROD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매일자", "SAL_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "보증시작일", "WARR_BEG_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수리일자", "REPAIR_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "확정일", "CONF_DATE2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "재고일수", "STOCK_DAY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "사용일수", "USE_DAY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "주행거리", "USE_DISTANCE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "부품비", "PART_COST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "공임비", "WAGE_COST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "외주비용", "SUBCON_COST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "총비용", "TOT_COST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "RO번호", "RONO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매국가", "SAL_NATION");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수리업체코드", "MAINT_VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "수리업체명", "MAINT_VENDNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "수리업체전화", "MAINT_TELNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "귀책업체", "IMPUT_VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "정비업체", "PROD_VENDOR2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "최종개발", "LAST_DEV_VENDOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "MOB변제", "MOB_PAY_VENDOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "GLV변제", "GLV_PAY_VENDOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업코드", "MWORKDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매구분", "SAL_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "VIN번호", "VINNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "MI코드", "MICODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "OP코드", "OPCODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "버전", "VERSION");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "엔진", "ENGINE_NO2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "변속기번호", "TRANS_MS_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "C10000구분", "C10000_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "CS10000구분", "CS10000_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "확정전(1)확정(2)", "CONFIRM_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "생산법인", "PROD_CUST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "공장", "CUST_PLANT2");//V
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "엔진명", "ENGINE_NM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "변속기프로젝트코드", "TRANS_MS_PJTCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "비품질클레임여부", "NON_QC_CLAIM_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "DTC4", "DTC4");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "DTC5", "DTC5");
                this.AddRow();
                #endregion

                this.BtnReset_Click(null, null);
                //this.BtnQuery_Click(null, null);

                this.cbo01_BIZCD.SelectedIndexChanged += new EventHandler(cbo01_BIZCD_SelectedIndexChanged);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        # endregion

        #region [공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach (Control ctl in groupBox_upload.Controls)
                //{
                //    if (ctl is IHEControl)
                //    {
                //        ((IHEControl)ctl).Initialize();
                //    }
                //}
                txt01_EXCEL.Initialize();
                this.grd01.InitializeDataSource();
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

                if (!this.IsQueryValid())
                    return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                //string STD_YYYYMM = this.dte01_STD_YYYYMM.GetValue().ToString();
                //string COMP_DIV = this.cbo01_COMP_DIV.GetValue().ToString();

                
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD",           this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD",           this.cbo01_BIZCD.GetValue());
                paramSet.Add("PROD_CUST",       this.cbo01_PROD_CUST.GetValue());
                paramSet.Add("SAL_NATION",      this.cbo01_SAL_NATION.GetValue());
                paramSet.Add("SAL_REGION",      this.cbo01_SAL_REGION.GetValue());
                paramSet.Add("VINCD",           this.cbo01_VINCD.GetValue());
                paramSet.Add("PROD_SAL_DIV",    this.rdo01_PROD.Checked ? "PROD" : "SAL");
                paramSet.Add("PROD_SAL_SDATE",  this.dte01_PROD_SAL_SDATE.GetValue());
                paramSet.Add("PROD_SAL_EDATE",  this.dte01_PROD_SAL_EDATE.GetValue());
                paramSet.Add("PROD_VENDOR",     this.cbo01_PROD_VENDOR.GetValue());
                paramSet.Add("REPR_CONF_DIV",   this.rdo01_REPAIR.Checked ? "REPAIR" : "CONF");
                paramSet.Add("REPR_CONF_SDATE", this.dte01_REPR_CONF_SDATE.GetValue());
                paramSet.Add("REPR_CONF_EDATE", this.dte01_REPR_CONF_EDATE.GetValue());
                paramSet.Add("TYPE",            this.cbo01_TYPE.GetValue());
                paramSet.Add("USE_MONTH",       this.cbo01_USE_MONTH.GetValue());
                paramSet.Add("VINNO",           this.txt01_VINNO.GetValue());
                paramSet.Add("RONO",            this.txt01_RONO.GetValue());
                paramSet.Add("PNO",             this.txt01_PARTNO.GetValue());
                paramSet.Add("ISSUE",           this.txt01_ISSUE.GetValue());
                paramSet.Add("FILE_YN",         this.cbo01_FILENO.GetValue());
                paramSet.Add("LANG_SET",        this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                this.ShowDataCount(source);
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
                                            "CORCD", "BIZCD", "CTYPE2", "VEHICLE", "PARTNO3", "PARTNAME", "SYSTEM", 
                                            "PRESCD", "PRESNM", "ISSUE", "DTC1", "DTC2", "DTC3", "PROD_DATE",
                                            "SAL_DATE", "WARR_BEG_DATE", "REPAIR_DATE", "CONF_DATE2", "STOCK_DAY", 
                                            "USE_DAY", "USE_DISTANCE", "PART_COST", "WAGE_COST", "SUBCON_COST", 
                                            "TOT_COST", "RONO", "SAL_NATION", "MAINT_VENDCD", "MAINT_VENDNM", 
                                            "MAINT_TELNO", "IMPUT_VENDCD", "PROD_VENDOR2", "LAST_DEV_VENDOR",
                                            "MOB_PAY_VENDOR", "GLV_PAY_VENDOR", "MWORKDCD", "SAL_TYPE", "VINNO", 
                                            "MICODE", "OPCODE", "VERSION", "ENGINE_NO2", "TRANS_MS_NO", "C10000_TYPE",
                                            "CS10000_TYPE", "CONFIRM_TYPE","CONFIRM_TYPE2", "PROD_CUST", "CUST_PLANT2", 
                                            "ENGINE_NM", "TRANS_MS_PJTCD", "TRANS_MS_PJTCD2", "NON_QC_CLAIM_TYPE", 
                                            "NON_QC_CLAIM_TYPE2", "DTC4", "DTC5", "EMPNO");


                foreach (DataRow dr in source.Tables[0].Rows)
                {   
                    dr["EMPNO"] = this.UserInfo.EmpNo;
                    dr["CONFIRM_TYPE"] = dr["CONFIRM_TYPE2"].ToString();
                    dr["TRANS_MS_PJTCD"] = dr["TRANS_MS_PJTCD2"].ToString();
                    dr["NON_QC_CLAIM_TYPE"] = dr["NON_QC_CLAIM_TYPE2"].ToString();
                }

                if (!IsSaveValid(source)) return;

                source.Tables[0].Columns.Remove("CONFIRM_TYPE2");
                source.Tables[0].Columns.Remove("TRANS_MS_PJTCD2");
                source.Tables[0].Columns.Remove("NON_QC_CLAIM_TYPE2");

                this.BeforeInvokeServer(true);

                this.Save(source);

                this.AfterInvokeServer();

                //MsgBox.Show("정상적으로 저장 되었습니다.");
                MsgCodeBox.Show("CD00-0009");

                
                this.BtnQuery_Click(null, null);

               
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                            "CORCD", "BIZCD", "RONO", "VINNO");



                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                //MsgBox.Show("정상적으로 삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0010");

               
                this.BtnQuery_Click(null, null);

                
                
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

        #region [기타 컨트롤에 대한 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 this.SetBindComboBox();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void chk01_ACC_YN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_ACC_YN.Checked)
            {
                DataSet source = this.GetTypeCode("QB");
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
            }
            else
            {
                DataSet source = this.GetTypeCode("QA");
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.grd01.MouseCol == this.grd01.Cols["FILENAME"].Index)
            {
                this.btn01_FILENO_VIEW_Click(null, null);
            }

        }

        private void btn01_FILE_UPLOAD_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = this.txt01_EXCEL.GetValue().ToString();

                string[] FileNames = filename.Split('.');
                int EndFile = FileNames.Length - 1;

                StringBuilder connectionString = new StringBuilder();

                string FType = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();
                switch (FType)
                {
                    case "XLS":                       
                    case "XLSX":
                        connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=""Excel 12.0;HDR=YES"";");
                        break;

                    case "":
                        //MsgBox.Show("파일이 선택 되지 않았습니다.");
                        MsgCodeBox.Show("QA01-0001");
                        return;

                    default:
                        //MsgBox.Show("확장자가 XLS, XLSX이 아닙니다.");
                        MsgCodeBox.Show("QA01-0002");
                        return;
                }

                //if (MsgBox.Show("일클레임자료를 업로드하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                if (MsgCodeBox.Show("QA01-0003", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                connectionString.AppendFormat(@"Data Source={0}", filename);

                OleDbConnection oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();


                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string temp = "";
                for (int i = this.grd02.Cols.Fixed; i < this.grd02.Cols.Count; i++)
                {
                    if (!this.grd02.Cols[i].Name.Equals(string.Empty))
                    {  
                        temp += " TRIM([" + this.grd02.Cols[i].Caption + "])  AS " + this.grd02.Cols[i].Name + ",";
                    }
                }

                string commandString = "SELECT " + temp +
                                        "       '{0}' AS CORCD, '{1}' AS BIZCD, '{2}' AS EMPNO" +
                                        " FROM [" + worksheets.Rows[0]["TABLE_NAME"].ToString() + "] " + 
                                        "WHERE TRIM([Type]) <> ''" +
                                        "  AND TRIM([Type]) <> 'AAAAA'";

                commandString = string.Format(commandString, this.UserInfo.CorporationCode, this.cbo01_BIZCD.GetValue(), this.UserInfo.EmpNo);

                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                this.BeforeInvokeServer(true);


                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                this.Save(ds);

                this.AfterInvokeServer();

                //MsgBox.Show("파일업로드가 완료 되었습니다.");
                MsgCodeBox.Show("QA01-0004");

                this.BtnQuery_Click(null, null);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
         
        }

        private void btn01_EXCEL_SELECT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "EXCEL");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    this.txt01_EXCEL.SetValue(fs.Name);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd02.Rows.Count > 0)
                {
                    this.saveFileDialog1.DefaultExt = "xls";
                    this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                    this.saveFileDialog1.FileName = this.GetLabel("QA21411_LBL_1");

                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string temp_file = this.saveFileDialog1.FileName;

                        this.grd02.SaveExcel(temp_file);

                        FileFlags flags = FileFlags.IncludeFixedCells;
                        this.grd02.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                        //MsgBox.Show("세부내역 다운로드가 완료 되었습니다.");
                        MsgCodeBox.Show("QA01-0005");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void btn01_FILENO_REGIST_Click(object sender, EventArgs e)
        {

            
            FileStream stream = null;
            try
            {
                if (this.grd01.Row < this.grd01.Rows.Fixed || this.grd01.Row >= this.grd01.Rows.Count)
                {
                    //MsgBox.Show("행이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0006");
                    return;
                }

                string fileno = this.grd01.GetValue(this.grd01.Row, "FILENO").ToString();
                if (!fileno.Equals(string.Empty))
                {
                    //if (MsgBox.Show("이미 대책서가 존재합니다. 대체하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    if (MsgCodeBox.Show("QA01-0007", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel) return;

                string filename = ofd.FileName;

                if (filename.Equals(string.Empty)) return;

                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                string rono = this.grd01.GetValue(this.grd01.Row, "RONO").ToString();
                string vinno = this.grd01.GetValue(this.grd01.Row, "VINNO").ToString();
                string owner_pgmig = this.Name;
                string empno = this.UserInfo.EmpNo;


                string fname = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];
                

                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] filedata = new byte[(int)stream.Length];
                stream.Read(filedata, 0, filedata.Length);
                stream.Close();

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD"
                                                                , "BIZCD"
                                                                , "RONO"
                                                                , "VINNO"
                                                                , "FILENAME"
                                                                , "BLOB$FILEDATA"
                                                                , "FILENO"
                                                                , "OWNER_PGMIG"
                                                                , "EMPNO");

                source.Tables[0].Rows.Add(corcd
                                        , bizcd
                                        , rono
                                        , vinno
                                        , fname
                                        , filedata
                                        , fileno
                                        , owner_pgmig
                                        , empno);

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_FILE"), source);
                this.AfterInvokeServer();
                
                //재조회
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            
        }

        private void btn01_FILENO_VIEW_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (this.grd01.Row < this.grd01.Rows.Fixed || this.grd01.Row >= this.grd01.Rows.Count)
                {
                    //MsgBox.Show("행이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0006");
                    return;
                }

                string fileno = this.grd01.GetValue(this.grd01.Row, "FILENO").ToString();

                if (fileno.Equals(string.Empty))
                {
                    //MsgBox.Show("대책서가 등록되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0008");
                    return;
                }

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                param.Add("FILENO", fileno);
                param.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE"), param);

                if (source.Tables[0].Rows.Count <= 0)
                {
                    this.AfterInvokeServer();
                    //MsgBox.Show("대책서 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("QA01-0009");
                    return;
                }

                string fname = source.Tables[0].Rows[0]["FILENAME"].ToString();
                string fileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + fname;
                byte[] filedata = (byte[])source.Tables[0].Rows[0]["FILEDATA"];

                if (File.Exists(fileName))
                    File.Delete(fileName);

                int ArraySize = filedata.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(filedata, 0, ArraySize + 1);
                stream.Close();

                this.AfterInvokeServer();

                System.Diagnostics.Process.Start(fileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            
        }

        private void btn01_FILENO_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Row < this.grd01.Rows.Fixed || this.grd01.Row >= this.grd01.Rows.Count)
                {
                    //MsgBox.Show("행이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0006");
                    return;
                }

                string fileno = this.grd01.GetValue(this.grd01.Row, "FILENO").ToString();

                if (fileno.Equals(string.Empty))
                {
                    //MsgBox.Show("대책서가 등록되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0008");
                    return;
                }

                
                //if (MsgBox.Show("대책서를 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                if (MsgCodeBox.Show("QA01-0010", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
               

                string rono = this.grd01.GetValue(this.grd01.Row, "RONO").ToString();
                string vinno = this.grd01.GetValue(this.grd01.Row, "VINNO").ToString();

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                param.Add("FILENO", fileno);
                param.Add("RONO", rono);
                param.Add("VINNO", vinno);
                param.Add("EMPNO", this.UserInfo.EmpNo);

                this.BeforeInvokeServer(true);
                 _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_FILE"), param);
                 this.AfterInvokeServer();

                //MsgBox.Show("대책서가 삭제되었습니다.");
                 MsgCodeBox.Show("QA01-0011");

                //재조회
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            
        }
        
        private void dte01_Leave(object sender, EventArgs e)
        {
            Ax.DEV.Utility.Controls.AxTextBox txt = (Ax.DEV.Utility.Controls.AxTextBox)sender;
            if (txt.GetValue().ToString().Length == 8)
            {
                DateTime CHK_DATE;

                if (DateTime.TryParse(Int32.Parse(txt.GetValue().ToString()).ToString("####-##-##"), out CHK_DATE) == false)
                {
                    txt.Focus();
                    txt.SetValue("");
                }
            }
            else if (txt.GetValue().ToString().Length != 0)
            {
                txt.Focus();
                txt.SetValue("");
            }
            else
            {
                txt.SetValue("");
            }
        }
        
        #endregion

        #region [사용자 정의 메서드]

        /// <summary>
        /// 사업장코드 변경시 해당 bizcd에 따른 콤보상자 재바인딩 처리.
        /// </summary>
        private void SetBindComboBox()
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                DataSet source = new DataSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                param.Add("LANG_SET", this.UserInfo.Language);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PROD_CUST"), param);
                this.cbo01_PROD_CUST.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SAL_NATION"), param);
                this.cbo01_SAL_NATION.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VINCD"), param);
                this.cbo01_VINCD.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PROD_VENDOR"), param);
                this.cbo01_PROD_VENDOR.DataBind(source.Tables[0], true);
                
                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SAL_REGION"), param);
                this.cbo01_SAL_REGION.DataBind(source.Tables[0], true);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 데이터 저장 처리.
        /// </summary>
        /// <param name="source"></param>
        private void Save(DataSet source)
        {
            try
            {
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 양식다운로드용 그리드에 행 추가. (엑셀 데이터 읽어들일때, 데이터 타입을 문자로 인식하도록 하기 위해)
        /// </summary>
        private void AddRow()
        {
            this.grd02.Rows.Add();
            this.grd02.SetValue(1, "CTYPE2", "AAAAA");
            this.grd02.SetValue(1, "VEHICLE", this.GetLabel("QA21411_LBL_2"));
            this.grd02.SetValue(1, "PARTNO3", "A");
            this.grd02.SetValue(1, "PARTNAME", "A");
            this.grd02.SetValue(1, "SYSTEM", "A");
            this.grd02.SetValue(1, "PRESCD", "A");
            this.grd02.SetValue(1, "PRESNM", "A");
            this.grd02.SetValue(1, "ISSUE", "A");
            this.grd02.SetValue(1, "DTC1", "A");
            this.grd02.SetValue(1, "DTC2", "A");
            this.grd02.SetValue(1, "DTC3", "A");
            this.grd02.SetValue(1, "PROD_DATE", "A");
            this.grd02.SetValue(1, "SAL_DATE", "A");
            this.grd02.SetValue(1, "WARR_BEG_DATE", "A");
            this.grd02.SetValue(1, "REPAIR_DATE", "A");
            this.grd02.SetValue(1, "CONF_DATE2", "A");
            this.grd02.SetValue(1, "RONO", "A");
            this.grd02.SetValue(1, "SAL_NATION", "A");
            this.grd02.SetValue(1, "MAINT_VENDCD", "A");
            this.grd02.SetValue(1, "MAINT_VENDNM", "A");
            this.grd02.SetValue(1, "MAINT_TELNO", "A");
            this.grd02.SetValue(1, "IMPUT_VENDCD", "A");
            this.grd02.SetValue(1, "PROD_VENDOR2", "A");
            this.grd02.SetValue(1, "LAST_DEV_VENDOR", "A");
            this.grd02.SetValue(1, "MOB_PAY_VENDOR", "A");
            this.grd02.SetValue(1, "GLV_PAY_VENDOR", "A");
            this.grd02.SetValue(1, "MWORKDCD", "A");
            this.grd02.SetValue(1, "SAL_TYPE", "A");
            this.grd02.SetValue(1, "VINNO", "A");
            this.grd02.SetValue(1, "MICODE", "A");
            this.grd02.SetValue(1, "OPCODE", "A");
            this.grd02.SetValue(1, "VERSION", "A");
            this.grd02.SetValue(1, "ENGINE_NO2", "A");
            this.grd02.SetValue(1, "TRANS_MS_NO", "A");
            this.grd02.SetValue(1, "C10000_TYPE", "A");
            this.grd02.SetValue(1, "CS10000_TYPE", "A");
            this.grd02.SetValue(1, "CONFIRM_TYPE", "A");
            this.grd02.SetValue(1, "PROD_CUST", "A");
            this.grd02.SetValue(1, "CUST_PLANT2", "A");
            this.grd02.SetValue(1, "ENGINE_NM", "A");
            this.grd02.SetValue(1, "TRANS_MS_PJTCD", "A");
            this.grd02.SetValue(1, "NON_QC_CLAIM_TYPE", "A");
            this.grd02.SetValue(1, "DTC4", "A");
            this.grd02.SetValue(1, "DTC5", "A");
            this.grd02.Rows[1].Visible = false;
        }
        #endregion

        #region [유효성 검사]
        /// <summary>
        /// 조회시 조회조건 필수 입력 여부 검사
        /// </summary>
        /// <returns></returns>
        private bool IsQueryValid()
        {
            try
            {

                if (this.GetByteCount(this.dte01_PROD_SAL_SDATE.GetValue().ToString()) <= 0 &&
                    this.GetByteCount(this.dte01_PROD_SAL_EDATE.GetValue().ToString()) <= 0 &&
                    this.GetByteCount(this.dte01_REPR_CONF_SDATE.GetValue().ToString()) <= 0 &&
                    this.GetByteCount(this.dte01_REPR_CONF_EDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_PROD_SAL_SDATE.Focus();
                    return false;
                }


                if (this.GetByteCount(this.dte01_PROD_SAL_SDATE.GetValue().ToString()) > 0 &&
                    this.GetByteCount(this.dte01_PROD_SAL_EDATE.GetValue().ToString()) <= 0 )
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_PROD_SAL_EDATE.Focus();
                    return false;
                }
                else if (this.GetByteCount(this.dte01_PROD_SAL_EDATE.GetValue().ToString()) > 0 &&
                    this.GetByteCount(this.dte01_PROD_SAL_SDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_PROD_SAL_SDATE.Focus();
                    return false;
                }

                if (this.GetByteCount(this.dte01_REPR_CONF_SDATE.GetValue().ToString()) > 0 &&
                   this.GetByteCount(this.dte01_REPR_CONF_EDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_REPR_CONF_EDATE.Focus();
                    return false;
                }
                else if (this.GetByteCount(this.dte01_REPR_CONF_EDATE.GetValue().ToString()) > 0 &&
                   this.GetByteCount(this.dte01_REPR_CONF_SDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_REPR_CONF_SDATE.Focus();
                    return false;
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 저장시 유효성 검사
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count <= 0)
                {
                    //MsgBox.Show("저장할 데이터가 없습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }
                
                //string VENDCD = this.cdx03_VENDCD.GetValue().ToString();

                //if (this.GetByteCount(VENDCD) == 0)
                //{
                //    MsgBox.Show("고객사 코드이 입력되지 않았습니다.");
                //    return false;
                //} 

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 엑셀 업로드시 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool IsExcelSaveValid()
        {
            try
            {
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 삭제시 유효성 검사
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsDeleteValid(DataSet source)
        {
            try
            {

                if (source.Tables[0].Rows.Count <= 0)
                {
                    //MsgBox.Show("삭제 할 데이터가 선택 되지 않았습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //string SELECT_ROW = this.txt02_SELECT_ROW.GetValue().ToString();

                //if (this.GetByteCount(SELECT_ROW) == 0)
                //{
                //    MsgBox.Show("삭제 할 데이터가 선택 되지 않았습니다.");
                //    return false;
                //}

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion
    }
}
