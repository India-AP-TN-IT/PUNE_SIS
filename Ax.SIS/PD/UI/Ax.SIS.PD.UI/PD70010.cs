#region ▶ Description & History
/* 
 * 프로그램명 : PD70010 LM반제품 울산공장 입고
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
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
using Ax.DEV.Utility.Controls;
using System.Drawing;

using System.Windows.Forms;
using C1.Win.C1FlexGrid;

using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>PD70010 LM반제품 울산공장 입고</b>
    /// 두서공장에서 출고한 LM 반제품을 울산공장에 입고 처리하는 프로그램
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2013-04-23<br />
    /// </summary>    
    public partial class PD70010 : AxCommonBaseControl
    {
            //private IPD70010 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_MES _WSCOM_MES;
        private string PACKAGE_NAME = "APG_PD70010";
        
        
        public PD70010()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //this._WSCOM = ClientFactory.CreateChannel<IPD70010>("PD", "PD70010.svc", "CustomBinding");
            //this._WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //테스트용 
                //gbPortSettings.Enabled = true;
                //txt01_barcode.Enabled = true;

                //this.txt01_JIS_CNT.Enabled = false;
                //this.dte01_INPUT_DATE.Enabled = false;
                //this.txt01_LINECD.Enabled = false;
                //this.txt01_VINCD.Enabled = false;
                //this.txt01_INSTALL_POS.Enabled = false;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue("5210");  //울산공장 only
                this.cbo01_BIZCD.SetReadOnly(true);

                this.grd01.AllowEditing = true;
                this.grd01.AutoClipboard = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "납품일자",  "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "납품차수", "DELI_CNT", "DELI_CNT");
                //this.grd01.AddColumn(true, false, HEFlexGrid.FtextAlign.L, 070, "차종",      "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "조립라인", "LINECD", "LINE5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                //this.grd01.AddColumn(true, false, HEFlexGrid.FtextAlign.L, 150, "Part Name", "PARTNM");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "납품량", "QTY", "DELIQTY");
                //this.grd01.AddColumn(true, false, HEFlexGrid.FtextAlign.L, 100,"바코드",    "NOTE_BARCODE");
                this.grd01.Cols["QTY"].Format = "#,##0";
              
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;
                               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        
        protected void BtnSave_Click()
        {
            try
            {
                string corporationCode = this.UserInfo.CorporationCode;
                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", corporationCode);
                param.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
                param.Add("NOTE_BARCODE", txt01_barcode.Text);

                if (this.IsSaveValid())
                {
                    this.BeforeInvokeServer(true);
                    this.BtnQuery_Click(param);         //ERM 조회
                    //this._WSCOM.SAVE("5210", param);    //MES 업데이트
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), param);

                }
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
        
        protected void BtnQuery_Click(HEParameterSet param)
        {
            try
            {
                //DataSet source = this._WSCOM.INQUERY("5210", param);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), param, "OUT_CURSOR");

                grd01.SetValue(source.Tables[0]);

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    //dte01_INPUT_DATE.SetValue(dr["INPUT_DATE"]);
                    //txt01_LINECD.SetValue(dr["LINENM"]);
                    //txt01_VINCD.SetValue(dr["VINCD"]);
                    //txt01_INSTALL_POS.SetValue(dr["INSTALL_POS"]);
                    //txt01_JIS_CNT.SetValue(dr["JIS_CNT"]);
                }
                else
                {
                    BtnReset_Click(null, null);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region [ 유효성 체크 ]

        private bool IsSaveValid()
        {
            try
            {
                //if (MsgBox.Show("입력하신 자재입고 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //{
                //    return false;
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        
        #endregion

        #region [COM port 설정(바코드리딩)관련]


        private SerialPort comport = new SerialPort();
        private void PD70010_Load(object sender, EventArgs e)
        {
            comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);

            cmbParity.Items.Clear(); 
            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear(); 
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbPortName.SelectedItem = "None";
            cmbStopBits.SelectedItem = "One";
            cmbDataBits.SelectedItem = "8";
            cmbParity.SelectedItem   = "None";
            cmbBaudRate.SelectedItem = "9600";

            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }

            EnableControls();

            if (comport.IsOpen)
                comport.Close();
        }

        private void comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!comport.IsOpen) return;

            System.Threading.Thread.Sleep(200);
            string data = comport.ReadExisting();
            this.Log(data);
        }

        private void EnableControls()
        {
            gbPortSettings.Enabled = !comport.IsOpen;
            if (comport.IsOpen) btnOpenPort.Text = "&Close Port";
            else btnOpenPort.Text = "&Open Port";
        }

        private string[] OrderedPortNames()
        {
            int num;
            string[] temp = SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
            string[] new_temp = new string[temp.Length];
            for (int i = temp.Length - 1; i >= 0; i--)
                new_temp[(temp.Length - 1) - i] = temp[i];

            return new_temp;
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            string selected = null;
            string[] ports = SerialPort.GetPortNames();
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            if (updated)
            {
                ports = OrderedPortNames();

                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            return selected;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (comport.IsOpen)
            {
                comport.Close();
                txt01_barcode.Text = "";
            }
            else
            {
                comport.BaudRate = int.Parse(cmbBaudRate.Text);
                comport.DataBits = int.Parse(cmbDataBits.Text);
                comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                comport.PortName = cmbPortName.Text;

                try
                {
                    comport.Open();
                }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            EnableControls();
        }

        private void txt01_barcode_TextChanged(object sender, EventArgs e)
        {
            if ( (this.txt01_barcode.Text.StartsWith("NS") && this.txt01_barcode.Text.Length >= 17) ||
                 (this.txt01_barcode.Text.StartsWith("P")  && this.txt01_barcode.Text.Length >= 16))
            {
                string barcode_no = this.txt01_barcode.Text.Trim();
               
                //this.BtnQuery_Click(null, null);
                this.BtnSave_Click();
            }
        }

        private void Log(string msg)
        {
            this.txt01_barcode.Invoke(new EventHandler(delegate
            {
                if (this.txt01_barcode.Text.StartsWith("NS") && this.txt01_barcode.Text.Length >= 17)
                    this.txt01_barcode.Text = "";

                if (this.txt01_barcode.Text.StartsWith("P") && this.txt01_barcode.Text.Length >= 16)
                    this.txt01_barcode.Text = "";

                this.txt01_barcode.AppendText(msg);
            }));
        }

        protected override void BtnClose_Click(object sender, EventArgs e)
        {
            if (comport.IsOpen)
                comport.Close();

            base.BtnClose_Click(sender, e);
        }

        #endregion
    }
}