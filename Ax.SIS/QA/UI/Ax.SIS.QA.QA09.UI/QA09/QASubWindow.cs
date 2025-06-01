#region ▶ Description & History
/* 
 * 프로그램명 : QASubWindow 품질팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-27      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA09.UI
{
    /// <summary>
    /// <b>검사코드 서브창</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-09 오후 3:31:40<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-09 오후 3:31:40   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QASubWindow : AxCommonPopupControl, IAxPopupHelper
    {
        //private IQASubWindow _WSCOM;
        private string _TITLE;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME_SUBWINDOW = "APG_QASUBWINDOW";
        
        #region [ 생성자 정의 ]
        
        public QASubWindow()    :base()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            _TITLE = this.CodeBox.CodeParameterName;

            try
            {
                if (!this.IsCreated)
                {
                    SubWindow_Setting();

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_CODE.SetValue(this.CodeBox.GetValue());
            this.txt01_NAME.SetValue(this.CodeBox.GetText());

            this.btn01_Inquery_Click(null, null);
        }

        #endregion

        #region [ IHEPopupHelper 멤버 ]

        public object SelectedValue
        {
            get { return this.SelectedData; }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            DataTable dt = new DataTable();

            _TITLE = set.Items[0].Key;

            switch (_TITLE)
            {
                case "INSPECT_CLASSCD":
                    //dt = _WSCOM.Inquery_INSPECT_CLASSCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_INSPECT_CLASSCD"), set).Tables[0];
                    break;
                case "MODULE_INSPECT_CLASSCD":
                    //dt = _WSCOM.Inquery_INSPECT_CLASSCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_MODULE_INSPECT_CLASSCD"), set).Tables[0];
                    break;
                case "INSPECT_CLASSCDR":
                    //dt = _WSCOM.Inquery_INSPECT_CLASSCDR(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_INSPECT_CLASSCDR"), set).Tables[0];
                    break;
                case "LINECD":
                    //dt = _WSCOM.Inquery_LINECD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_LINECD"), set).Tables[0];
                    break;
                case "VENDCD":
                    //dt = _WSCOM.Inquery_VENDCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_VENDCD"), set).Tables[0];
                    break;
                case "CUSTCD":
                    //dt = _WSCOM.Inquery_CUSTCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_CUSTCD"), set).Tables[0];
                    break;
                case "EMPNO":
                    //dt = _WSCOM.Inquery_EMPNO(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_EMPNO"), set).Tables[0];
                    break;
                case "INSPECT_EMPNO_LINECD":
                    //dt = _WSCOM.Inquery_INSPECT_EMPNO_LINECD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_INSPECT_EMPNO_LINECD"), set).Tables[0];
                    break;
                case "INSPECT_CLASSCD_BASE":
                    //dt = _WSCOM.Inquery_INSPECT_BASECODE(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_INSPECT_BASECODE"), set).Tables[0];
                    break;
                case "XD_CODE":
                    //dt = _WSCOM.Inquery_XD_CODE(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_XD_CODE"), set).Tables[0];
                    break;
                case "CLASSCD":
                    //dt = _WSCOM.Inquery_CLASSCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_CLASSCD"), set).Tables[0];
                    break;
                case "INSPECT_EMPNO":
                    //dt = _WSCOM.Inquery_INSPECT_EMPNO(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_INSPECT_EMPNO"), set).Tables[0];
                    break;
                case "DEFCD":
                    //dt = _WSCOM.Inquery_DEFCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_DEFCD"), set).Tables[0];
                    break;
                case "DEFPOSCD":
                    //dt = _WSCOM.Inquery_DEFPOSCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_DEFPOSCD"), set).Tables[0];
                    break;
                case "ALCCD":
                    //dt = _WSCOM.Inquery_ALCCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ALCCD"), set).Tables[0];
                    break;
                case "ASSYPNO":
                    //dt = _WSCOM.Inquery_ASSYPNO(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ASSYPNO"), set).Tables[0];
                    break;
                case "PARTNO_OF_ASSYPNO":
                    //dt = _WSCOM.Inquery_PARTNO_OF_ASSYPNO(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_PARTNO_OF_ASSYPNO"), set).Tables[0];
                    break;
                case "PARTNO_OF_INSPECTCD":
                    //dt = _WSCOM.Inquery_PARTNO_OF_INSPECTCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_PARTNO_OF_INSPECTCD"), set).Tables[0];
                    break;
                case "ITEMCD_OF_VINCD":
                    //dt = _WSCOM.Inquery_ITEMCD_OF_VINCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ITEMCD_OF_VINCD"), set).Tables[0];
                    break;
                case "ALCCD_OF_ITEMCD":
                    //dt = _WSCOM.Inquery_ALCCD_OF_ITEMCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ALCCD_OF_ITEMCD"), set).Tables[0];
                    break;
                case "ASSYNO_OF_ALCCD":
                    //dt = _WSCOM.Inquery_ASSYNO_OF_ALCCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ASSYNO_OF_ALCCD"), set).Tables[0];
                    break;
                case "ALCCD_OF_CUSTCD":
                    //dt = _WSCOM.Inquery_ALCCD_OF_CUSTCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ALCCD_OF_CUSTCD"), set).Tables[0];
                    break;
                case "ALCCD_OF_VINCD":
                    //dt = _WSCOM.Inquery_ALCCD_OF_VINCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ALCCD_OF_VINCD"), set).Tables[0];
                    break;
                case "PARTNO_OF_VENDCD":
                    //dt = _WSCOM.Inquery_PARTNO_OF_VENDCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_PARTNO_OF_VENDCD"), set).Tables[0];
                    break;
                case "NATIONCD":
                    //dt = _WSCOM.Inquery_PARTNO_OF_VENDCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_NATIONCD"), set).Tables[0];
                    break;
                case "PRESCD":
                    //dt = _WSCOM.Inquery_PARTNO_OF_VENDCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_PRESCD"), set).Tables[0];
                    break;
                case "APPLICD":
                    //dt = _WSCOM.Inquery_PARTNO_OF_VENDCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_APPLICD"), set).Tables[0];
                    break;
                case "DOCRPTNO":
                    //dt = _WSCOM.Inquery_DOCRPTNO(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_DOCRPTNO"), set).Tables[0];
                    break;
                case "VINCD":
                    //dt = _WSCOM.Inquery_VINCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_VINCD"), set).Tables[0];
                    break;
                case "ITEMCD":
                    //dt = _WSCOM.Inquery_ITEMCD(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ITEMCD"), set).Tables[0];
                    break;
                case "CODE":
                    //dt = _WSCOM.Inquery_ITEMNM(set).Tables[0];
                    dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_ITEMNM"), set).Tables[0];
                    break;
                default:
                    break;
            }

            return dt;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                switch (_TITLE)
                {
                    case "INSPECT_CLASSCD":
                        set.Add("INSPECT_CLASSCD", this.txt01_CODE.GetValue());
                        set.Add("INSPECT_CLASSNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());//ADDED
                        lbl01_CODE.Value = this.GetLabel("INSPECCD");               // "검사코드";
                        lbl01_NAME.Value = this.GetLabel("QA_AINSPECT_CLASSNQA");   // "검사명";

                        break;

                    case "MODULE_INSPECT_CLASSCD":
                        set.Add("MODULE_INSPECT_CLASSCD", this.txt01_CODE.GetValue());
                        set.Add("ITEMNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());//ADDED
                        lbl01_CODE.Value = this.GetLabel("INSPECCD");           //"검사코드";
                        lbl01_NAME.Value = this.GetLabel("INSPECT_PARTNM");     //"검사품명";

                        break;

                    case "INSPECT_CLASSCDR":
                        set.Add("INSPECT_CLASSCDR", this.txt01_CODE.GetValue());
                        set.Add("INSPECT_CLASSNMR", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("PLANT_DIV", this.UserInfo.PlantDiv);

                        lbl01_CODE.Value = this.GetLabel("INSPECCD");               //"검사코드";
                        lbl01_NAME.Value = this.GetLabel("QA_AINSPECT_CLASSNQA");   //"검사명";

                        break;

                    case "LINECD":
                        set.Add("LINECD", this.txt01_CODE.GetValue());
                        set.Add("LINENM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("LINECD");     // "라인코드";
                        lbl01_NAME.Value = this.GetLabel("LINENM");     // "라인명";

                        break;

                    case "VENDCD":
                        set.Add("VENDCD", this.txt01_CODE.GetValue());
                        set.Add("VENDNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("EI21540_VENDCD");     //"협력사코드";
                        lbl01_NAME.Value = this.GetLabel("EI21540_VENDNM");     //"협력사명";

                        break;

                    case "CUSTCD":
                        set.Add("CUSTCD", this.txt01_CODE.GetValue());
                        set.Add("CUSTNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("CUSTCD");             // "고객사코드";
                        lbl01_NAME.Value = this.GetLabel("CUSTNM2");            // "고객사명";

                        break;

                    case "EMPNO":
                        set.Add("EMPNO", this.txt01_CODE.GetValue());
                        set.Add("EMPNONM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("HR_EMPCD");       //"사원코드";
                        lbl01_NAME.Value = this.GetLabel("EMPNAME");        // "사원명";

                        break;

                    case "INSPECT_EMPNO_LINECD":
                        set.Add("INSPECT_EMPNO_LINECD", this.txt01_CODE.GetValue());
                        set.Add("INSPECT_EMPNO_LINENM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("INSPECTOR_LINECD");   //"검사원라인코드";
                        lbl01_NAME.Value = this.GetLabel("INSPECTOR_LINENM");   // "검사원라인명";

                        break;

                    case "INSPECT_CLASSCD_BASE":
                        set.Add("INSPECT_CLASSCD_BASE", this.txt01_CODE.GetValue());
                        set.Add("INSPECT_CLASSNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = this.GetLabel("INSPECTCD");      //"검사유형코드";
                        lbl01_NAME.Value = this.GetLabel("INSPECTNM");      //"검사유형명";

                        break;

                    case "XD_CODE":
                        set.Add("XD_CODE", this.txt01_CODE.GetValue());
                        set.Add("XD_NAME", this.txt01_NAME.GetValue());
                        set.Add("XD_CLASS", this.CodeBox.HEUserParameterGetValue("XD_CLASS").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("USE_YN", this.CodeBox.HEUserParameterGetValue("USE_YN").ToString());
                        set.Add("GROUPCD", this.CodeBox.HEUserParameterGetValue("GROUPCD").ToString());

                    switch (this.CodeBox.HEUserParameterGetValue("XD_CLASS").ToString())
                        {
                            case "A7":
                                lbl01_CODE.Value = this.GetLabel("POSCODE");    //"장착위치코드";
                                lbl01_NAME.Value = this.GetLabel("POSNM");      //"장착위치명";

                                break;

                            case "FB":
                                lbl01_CODE.Value = this.GetLabel("MGRT_CNTTCD");    //"조치내용코드";
                                lbl01_NAME.Value = this.GetLabel("MGRT_CNTTNM");    //"조치내용명";

                                break;

                            case "I3":
                                lbl01_CODE.Value = this.GetLabel("NATIONCD");       //"국가코드";
                                lbl01_NAME.Value = this.GetLabel("NATIONNM");       //"국가명";

                                break;

                            case "FT":
                                lbl01_CODE.Value = this.GetLabel("DEF_PLACE_CODE");     //"불량장소코드";
                                lbl01_NAME.Value = this.GetLabel("DEF_PLACE_NAME");     //"불량장소명";

                                break;

                            default:
                                break;
                        }

                        break;

                    case "CLASSCD":
                        set.Add("CLASSCD", this.txt01_CODE.GetValue());
                        set.Add("CLASSNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("PLANT_DIV", this.CodeBox.HEUserParameterGetValue("PLANT_DIV").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = this.GetLabel("SAMPLE_DIV_CODE");    //"한도견본분류코드";
                        lbl01_NAME.Value = this.GetLabel("SAMPLE_DIV_NAME");    //"한도견본분류명";

                        break;

                    case "INSPECT_EMPNO":
                        set.Add("INSPECT_EMPNO", this.txt01_CODE.GetValue());
                        set.Add("INSPECT_EMPNONM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("PLANT_DIV", this.CodeBox.HEUserParameterGetValue("PLANT_DIV").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = this.GetLabel("INSPECT_EMPNO");  // "검사원코드";
                        lbl01_NAME.Value = this.GetLabel("INSPECT_EMPNM");  //"검사원명";

                        break;

                    case "DEFCD":
                        set.Add("DEFCD", this.txt01_CODE.GetValue());
                        set.Add("DEFNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("USE_YN", "Y");
                        lbl01_CODE.Value = this.GetLabel("DEF_CNTT_CD");    // "불량내용코드";
                        lbl01_NAME.Value = this.GetLabel("DEF_CNTT");       // "불량내용명";

                        break;

                    case "DEFPOSCD":
                        set.Add("DEFPOSCD", this.txt01_CODE.GetValue());
                        set.Add("DEFPOSNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("DEFPOSCD2");  // "불량부위코드";
                        lbl01_NAME.Value = this.GetLabel("DEFPOSNM2");  // "불량부위명";

                        break;

                    case "ALCCD":
                        set.Add("ALCCD", this.txt01_CODE.GetValue());
                        set.Add("ALCNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("LINECD", this.CodeBox.HEUserParameterGetValue("LINECD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = "ALC CODE";
                        lbl01_NAME.Value = "ALC NAME";

                        break;

                    case "ASSYPNO":
                        set.Add("ASSYPNO", this.txt01_CODE.GetValue());
                        set.Add("ASSYPNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("ALCCD", this.CodeBox.HEUserParameterGetValue("ALCCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("LINECD", this.CodeBox.HEUserParameterGetValue("LINECD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("ASSYPCD");    //"완제품코드";
                        lbl01_NAME.Value = this.GetLabel("ASSYPNM2");   //"완제품명";

                        break;

                    case "PARTNO_OF_ASSYPNO":
                        set.Add("PARTNO_OF_ASSYPNO", this.txt01_CODE.GetValue());
                        set.Add("PARTNO_OF_ASSYPNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("ASSYPNO", this.CodeBox.HEUserParameterGetValue("ASSYPNO").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("PARTNO3");        // "품번";
                        lbl01_NAME.Value = this.GetLabel("PARTNMTITLE");    //"품명";

                        break;

                    case "VENDCD_OF_PARTNO":
                        set.Add("VENDCD_OF_PARTNO", this.txt01_CODE.GetValue());
                        set.Add("VENDCD_OF_PARTNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("PARTNO", this.CodeBox.HEUserParameterGetValue("PARTNO").ToString());
                        set.Add("ASSYPNO", this.CodeBox.HEUserParameterGetValue("ASSYPNO").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("VENDCD");     // "업체코드";
                        lbl01_NAME.Value = this.GetLabel("VENDNM");     //"업체명";

                        break;

                    case "PARTNO_OF_INSPECTCD":
                        set.Add("PARTNO_OF_INSPECTCD", this.txt01_CODE.GetValue());
                        set.Add("PARTNO_OF_INSPECTNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VENDCD", this.CodeBox.HEUserParameterGetValue("VENDCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("PARTNO3");        //"품번";
                        lbl01_NAME.Value = this.GetLabel("PARTNMTITLE");    //"품명";

                        break;

                    case "ITEMCD_OF_VINCD":
                        set.Add("ITEMCD_OF_VINCD", this.txt01_CODE.GetValue());
                        set.Add("ITEMCD_OF_VINNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("ITEM");   //"품목";
                        lbl01_NAME.Value = this.GetLabel("ITEMNM3");   //"품목명";

                        break;

                    case "ALCCD_OF_ITEMCD":
                        set.Add("ALCCD_OF_ITEMCD", this.txt01_CODE.GetValue());
                        set.Add("ALCCD_OF_ITEMNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = "ALCCD";
                        lbl01_NAME.Value = this.GetLabel("ALCNM");   // "ALC명";

                        break;

                    case "ASSYNO_OF_ALCCD":
                        set.Add("ASSYNO_OF_ALCCD", this.txt01_CODE.GetValue());
                        set.Add("ASSYNO_OF_ALCNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("ALCCD", this.CodeBox.HEUserParameterGetValue("ALCCD").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("ASSYPNO2");   // "완제품번";
                        lbl01_NAME.Value = this.GetLabel("ASSYPNM2");   // "완제품명";

                        break;

                    case "ALCCD_OF_CUSTCD":
                        set.Add("ALCCD_OF_CUSTCD", this.txt01_CODE.GetValue());
                        set.Add("ALCCD_OF_CUSTNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("CUSTCD", this.CodeBox.HEUserParameterGetValue("CUSTCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = "ALCCD";
                        lbl01_NAME.Value = this.GetLabel("ALCNM");  //"ALC명";

                        break;

                    case "ALCCD_OF_VINCD":
                        set.Add("ALCCD_OF_VINCD", this.txt01_CODE.GetValue());
                        set.Add("ALCCD_OF_VINNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("RCV_DATE", this.CodeBox.HEUserParameterGetValue("RCV_DATE").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        lbl01_CODE.Value = "ALCCD";
                        lbl01_NAME.Value = this.GetLabel("ALCNM");  //"ALC명";

                        break;

                    case "PARTNO_OF_VENDCD":
                        set.Add("PARTNO_OF_VENDCD", this.txt01_CODE.GetValue());
                        set.Add("PARTNO_OF_VENDNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VENDCD", this.CodeBox.HEUserParameterGetValue("VENDCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("PARTNO3");        //"품번";
                        lbl01_NAME.Value = this.GetLabel("PARTNMTITLE");    //"품명";

                        break;

                    case "NATIONCD":
                        set.Add("NATIONCD", this.txt01_CODE.GetValue());
                        set.Add("NATIONNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value =  this.GetLabel("OCCUR_NATIONCD2");    //"발생국가코드";
                        lbl01_NAME.Value = this.GetLabel("OCCUR_NATIONNM");     //"발생국가명";

                        break;

                    case "PRESCD":
                        set.Add("PRESCD", this.txt01_CODE.GetValue());
                        set.Add("PRESNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("PRESCD"); // "현상코드";
                        lbl01_NAME.Value = this.GetLabel("PRESNM"); //"현상코드명";

                        break;

                    case "APPLICD":
                        set.Add("APPLICD", this.txt01_CODE.GetValue());
                        set.Add("APPLINM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("APPLICD");    // "원인코드";
                        lbl01_NAME.Value = this.GetLabel("APPLI_CNTT"); // "원인코드명";

                        break;

                    case "DOCRPTNO":
                        set.Add("DOCRPTNO", this.txt01_CODE.GetValue());
                        set.Add("DOCRPTNM", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("SAL_VENDCD", this.CodeBox.HEUserParameterGetValue("SAL_VENDCD").ToString());
                        set.Add("PROC_DATE", this.CodeBox.HEUserParameterGetValue("PROC_DATE").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("DOCRPTNO");   // "통보서번호";
                        lbl01_NAME.Value = this.GetLabel("DOCRPTNO");   //"통보서번호";

                        break;

                    case "VINCD":
                        set.Add("VINCD", this.txt01_CODE.GetValue());
                        set.Add("VINCDNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("VINCD");  // "차종코드";
                        lbl01_NAME.Value = this.GetLabel("VINNM");  //"차종명";

                        break;

                    case "ITEMCD":
                        set.Add("ITEMCD", this.txt01_CODE.GetValue());
                        set.Add("ITEMNM", this.txt01_NAME.GetValue());
                        set.Add("LANG_SET", this.UserInfo.Language);

                        lbl01_CODE.Value = this.GetLabel("ITEMCD");     // "품목코드";
                        lbl01_NAME.Value = this.GetLabel("ITEMNM3");    //"품목명";

                        break;

                    case "CODE":
                        set.Add("CODE", this.txt01_CODE.GetValue());
                        set.Add("NAME", this.txt01_NAME.GetValue());
                        set.Add("CORCD", this.CodeBox.HEUserParameterGetValue("CORCD").ToString());
                        set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                        set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD").ToString());
                        set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD").ToString());
                        set.Add("LANG_SET", this.UserInfo.Language);
                        set.Add("PLANT_DIV", this.CodeBox.HEUserParameterGetValue("PLANT_DIV").ToString());

                        lbl01_CODE.Value = this.GetLabel("ITEMCD");         //"품목코드";
                        lbl01_NAME.Value = this.GetLabel("PARTNMTITLE");    //"품명";

                        break;

                    default:
                        break;
                }

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);

                this.AfterInvokeServer();

                this.grd01.SetValue(table);
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
                
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRow;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void SubWindow_Setting()
        {
            lbl01_NAME.Visible = true;
            txt01_NAME.Visible = true;
            
            this.grd01.AllowEditing = false;
            this.grd01.Initialize();

            //공장구분-------------------------------------------------------------------------
            this.cbo01_PLANT_DIV.Visible = false;
            this.lbl01_PLANT_DIV.Visible = false;
            this.btn01_Inquery.Left = this.lbl01_PLANT_DIV.Left;
            //---------------------------------------------------------------------------------

            switch (_TITLE)
            {
                case "INSPECT_CLASSCD":

                    //공장구분-------------------------------------------------------------------------
                    DataTable source = this.GetTypeCode("U9").Tables[0];
                    foreach (DataRow dr in source.Rows)
                    {
                        dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                    }
                    this.cbo01_PLANT_DIV.DataBind(source, true);
                    this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                    if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                        this.cbo01_PLANT_DIV.SetReadOnly(true);
                    //---------------------------------------------------------------------------------

                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "검사코드", "INSPECT_CLASSCD", "INSPECCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 130, "검사코드", "INSPECT_CLASSTYPE", "INSPECCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "검사명", "INSPECT_CLASSNM", "QA_AINSPECT_CLASSNQA");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VIN");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINTYPE", "VIN");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMCD", "ITEM");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMTYPE", "ITEM");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "PARTNMTITLE");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "위치", "POSCD", "POS");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "유검사", "INSPECT_YN", "INSPECT_Y");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "상태", "STATE", "STATE");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "업체코드", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDNM", "VENDNM");

                    //공장구분-------------------------------------------------------------------------
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "공장코드", "PLANT_DIV", "PLANT_DIV");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PLANT_DIV");
                    this.grd01.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                    this.btn01_Inquery.Left = this.cbo01_PLANT_DIV.Left + this.cbo01_PLANT_DIV.Width + 3;
                    this.cbo01_PLANT_DIV.Visible = true;
                    this.lbl01_PLANT_DIV.Visible = true;
                    
                    //---------------------------------------------------------------------------------
                    break;

                case "MODULE_INSPECT_CLASSCD":

                    //공장구분-------------------------------------------------------------------------
                    DataTable ds = this.GetTypeCode("U9").Tables[0];
                    foreach (DataRow dr in ds.Rows)
                    {
                        dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                    }
                    this.cbo01_PLANT_DIV.DataBind(ds, true);
                    this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                    //if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    //    this.cbo01_PLANT_DIV.SetReadOnly(true);
                    //---------------------------------------------------------------------------------

                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "검사코드", "MODULE_INSPECT_CLASSCD", "INSPECCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "검사품명", "ITEMNM", "INSPECT_PARTNM");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "검사코드", "INSPECT_CLASSTYPE", "INSPECCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "검사명", "INSPECT_CLASSNM", "QA_AINSPECT_CLASSNQA");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE", "VIN");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "품목", "ITEMCD", "ITEM");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMTYPE", "ITEM");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "위치", "POSCD", "POS");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "유검사", "INSPECT_YN", "INSPECT_Y");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "상태", "STATE", "STATE");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "업체코드", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDNM", "VENDNM");

                    //공장구분-------------------------------------------------------------------------
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "공장코드", "PLANT_DIV", "PLANT_DIV");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds, "PLANT_DIV");
                    this.grd01.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                    this.btn01_Inquery.Left = this.cbo01_PLANT_DIV.Left + this.cbo01_PLANT_DIV.Width + 3;
                    this.cbo01_PLANT_DIV.Visible = true;
                    this.lbl01_PLANT_DIV.Visible = true;

                    //---------------------------------------------------------------------------------
                    break;

                case "INSPECT_CLASSCDR":
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCDR", "INSPECCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "검사코드", "INSPECT_CLASSTYPE", "INSPECCD");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 150, "검사명", "INSPECT_CLASSNMR", "QA_AINSPECT_CLASSNQA");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINTYPE", "VIN");
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMCD", "ITEM");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMTYPE", "ITEM");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "ITEMNM3");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "상태", "STATE", "STATE");

                    break;

                case "LINECD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "라인코드", "LINECD", "LINECD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "라인명", "LINENM", "LINENM");

                    break;

                case "VENDCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "협력사코드", "VENDCD", "EI21540_VENDCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "협력사명", "VENDNM", "EI21540_VENDNM");

                    break;

                case "CUSTCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "고객사코드", "CUSTCD", "CUSTCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "고객사명", "CUSTNM", "CUSTNM2");

                    break;

                case "EMPNO":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "부서", "LINENM", "DEPART");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "사원번호", "EMPNO", "EMPNO2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "성명", "EMPNONM", "EMPNM");

                    break;

                case "INSPECT_EMPNO_LINECD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사원라인코드", "INSPECT_EMPNO_LINECD", "INSPECTOR_LINECD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "검사원라인명", "INSPECT_EMPNO_LINENM", "INSPECTOR_LINENM");

                    break;

                case "INSPECT_CLASSCD_BASE":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사유형코드", "INSPECT_CLASSCD_BASE", "INSPECTCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "검사유형명", "INSPECT_CLASSNM", "INSPECTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 230, "정렬순서", "SORT_SEQ", "DISP_SEQ");

                    break;

                case "XD_CODE":
                    switch (this.CodeBox.HEUserParameterGetValue("XD_CLASS").ToString())
                    {
                        case "A7":
                            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "장착위치코드", "XD_CODE", "POSCODE");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "장착위치코드", "XD_TYPE", "POSCODE");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "장착위치명", "XD_NAME", "POSNM");

                            break;

                        case "FB":
                            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "조치내용코드", "XD_CODE", "MGRT_CNTTCD");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "조치내용코드", "XD_TYPE", "MGRT_CNTTCD");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "조치내용명", "XD_NAME", "MGRT_CNTTNM");

                            break;

                        case "I3":
                            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "국가코드", "XD_CODE", "NATIONCD");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "국가코드", "XD_TYPE", "NATIONCD");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "국가명", "XD_NAME", "NATIONNM");

                            break;

                        case "FT":
                            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량장소코드", "XD_CODE", "DEF_PLACE_CODE");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "불량장소코드", "XD_TYPE", "DEF_PLACE_CODE");
                            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "불량장소명", "XD_NAME", "DEF_PLACE_NAME");

                            break;

                        default:
                            break;
                    }
                    break;

                case "CLASSCD":
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "한도견본분류코드", "CLASSCD", "SAMPLE_DIV_CODE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "한도견본분류명", "CLASSNM", "SAMPLE_DIV_NAME");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "점검관리주기사용여부", "CHK_MGMTCYCLE_USE", "CHK_MGMTCYCLE_USE_YN");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "비고", "REMARK", "REMARK");

                    break;

                case "INSPECT_EMPNO":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "검사원사원번호", "INSPECT_EMPNO", "INSPECT_EMPNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "검사원성명", "INSPECT_EMPNONM", "INSPECT_EMPNM");

                    break;

                case "DEFCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량내용코드", "DEFCD", "DEF_CNTT_CD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "불량내용명", "DEFNM", "DEF_CNTT");

                    break;

                case "DEFPOSCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "불량부위코드", "DEFPOSCD", "DEFPOSCD2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "불량부위명", "DEFPOSNM", "DEFPOSNM2");

                    break;

                case "ALCCD":
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "ALC CODE", "ALCCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ALC CODE", "ALCNM");

                    break;

                case "ASSYPNO":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "완제품번", "ASSYPNO", "ASSYPNO2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "완제품명", "ASSYPNM", "ASSYPNM2");

                    break;

                case "PARTNO_OF_ASSYPNO":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO_OF_ASSYPNO", "PARTNO3");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNO_OF_ASSYPNM", "PARTNMTITLE");

                    break;

                case "PARTNO_OF_INSPECTCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO_OF_INSPECTCD", "PARTNO3");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNO_OF_INSPECTNM", "PARTNMTITLE");

                    break;

                case "ITEMCD_OF_VINCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMCD_OF_VINCD", "ITEM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품목명", "ITEMCD_OF_VINNM", "ITEMNM3");

                    break;

                case "ALCCD_OF_ITEMCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ALC CD", "ALCCD_OF_ITEMCD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "ALC CD", "ALCCD_OF_ITEMNM");

                    break;

                case "ASSYNO_OF_ALCCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "완제품번", "ASSYNO_OF_ALCCD", "ASSYPNO2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "완제품명", "ASSYNO_OF_ALCNM", "ASSYPNM2");

                    break;

                case "ALCCD_OF_CUSTCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ALC CD", "ALCCD_OF_CUSTCD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "ALC CD", "ALCCD_OF_CUSTNM");

                    break;

                case "ALCCD_OF_VINCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ALC CD", "ALCCD_OF_VINCD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "ALC CD", "ALCCD_OF_VINNM");

                    break;

                case "PARTNO_OF_VENDCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO_OF_VENDCD", "PARTNO3");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNO_OF_VENDNM", "PARTNMTITLE");

                    break;

                case "NATIONCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "발생국가코드", "NATIONCD", "OCCUR_NATIONCD2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "발생국가명", "NATIONNM", "OCCUR_NATIONNM");

                    break;

                case "PRESCD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "현상코드", "PRESCD", "PRESCD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "현상코드명", "PRESNM", "PRESNM"); //현상명

                    break;

                case "APPLICD":
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "원인코드", "APPLICD", "APPLICD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "원인코드명", "APPLINM", "APPLI_CNTT"); //원인

                    break;

                case "DOCRPTNO":

                    lbl01_NAME.Visible = false;
                    txt01_NAME.Visible = false;

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "통보서번호", "DOCRPTNO", "DOCRPTNO");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "통보서번호", "DOCRPTNM", "DOCRPTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "고객사", "SAL_VENDCD", "CUSTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "고객사통보서번호", "CUST_DOCRPTNO", "CUST_DOCRPTNO"); //고객통보서번호
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "발생구분", "OCCUR_DIV", "OCCUR_DIV");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "처리일자", "PROC_DATE", "PROC_DATE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "건수", "DATA_CNTT", "COUNT");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "완료여부", "COM_YN", "COM_YN");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "통보일자", "DOCRPT_DATE", "DOCRPT_DATE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "정산일자", "ADJUST_DATE", "ADJUST_DATE");

                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DOCRPT_DATE");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ADJUST_DATE");
                    break;

                case "VINCD":
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "차종코드", "VINCD", "VINCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "차종코드", "VINCDNM", "VINCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "차종명", "VINNM", "VINNM");

                    break;
                    
                case "ITEMCD":
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "품목코드", "ITEMCD", "ITEMCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "품목코드", "ITEMTYPE", "ITEMCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품목명", "ITEMNM", "ITEMNM3");

                    break;

                case "CODE":
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 000, "품목코드", "CODE", "ITEMCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품목명", "NAME", "ITEMNM3");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 000, "업체코드", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "업체명", "VENDNM", "VENDNM");

                    break;

                default:
                    break;
            }

        }

        #endregion

    }
}
