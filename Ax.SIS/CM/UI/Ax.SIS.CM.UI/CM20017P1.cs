﻿using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.CM.UI
{
    /// <summary>
    /// <b>업체코드 헬퍼</b>
    /// - 작 성 자 : 이명희<br />
    /// - 작 성 일 : 2015-02-03<br />
    /// </summary>
    public partial class CM20017P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM20017P1";
        private bool m_bHR = false;
        #region [ 생성자 정의 ]

        public CM20017P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy(); 
        }

        public CM20017P1(AxCodeBox sender) 
            : this()
        {
            this.CodeBox = sender;
            this.Init();
            
        }
        public CM20017P1(AxCodeBox sender, bool bHR)
            : this()
        {
            this.CodeBox = sender;
            this.Init();
            m_bHR = bHR;
        }

        private void Init()
        {
            if (this.CodeBox != null)
            {
                this.CodeBox.CodeParameterName = "VENDCD";
                this.CodeBox.NameParameterName = "VENDNM";
                this.CodeBox.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.CodeBox.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
            }
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_업체코드", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "_업체명", "VENDNM", "VENDNM");

                    this.txt01_VENDCD.SetValid(AxTextBox.TextType.UAlphabet);

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_VENDCD.SetValue(this.CodeBox.GetValue());
            this.txt01_VENDNM.SetValue(this.CodeBox.GetText());

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
            //return _WSCOM.Inquery_VENDCD(set).Tables[0];
            if (m_bHR)
            {
                return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD_HR"), set).Tables[0];
            }
            else
            {
                return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD"), set).Tables[0];
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.CodeBox.HEUserParameterGetValue("CORCD"));
                set.Add("VENDCD", this.txt01_VENDCD.GetValue());
                set.Add("VENDNM", this.txt01_VENDNM.GetValue());
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));
                //set.Add("PURC_TYPE", this.CodeBox.HEUserParameterGetValue("PURC_TYPE"));

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
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

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Row < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRow;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
