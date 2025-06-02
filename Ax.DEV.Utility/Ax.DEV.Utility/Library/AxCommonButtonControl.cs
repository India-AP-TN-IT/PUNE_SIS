using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1Input;
using HE.Framework.Windows.Forms;
using HE.Framework.Core;
using C1.Win.C1FlexGrid;
using System.Data.OleDb;
using TheOne.Windows.Forms;
using C1.Win.C1Command;
using TheOne.Security;

namespace Ax.DEV.Utility.Library
{
	[ToolboxItem(false)]
    public partial class AxCommonButtonControl : UserControl
    {
        // 부모 컨트롤
        HEUserControlBase _parentControl = null;

        // 버튼 관련 이벤트 핸들러 정의
        public event EventHandler SaveClick;
        public event EventHandler DeleteClick;
        public event EventHandler QueryClick;
        public event EventHandler PrintClick;
        public event EventHandler ProcessClick;
        public event EventHandler ResetClick;
        public event EventHandler CloseClick;


        // 부모 컨트롤에서 해당 버튼에 접근할 수 있도록 속성 정의
        public C1Button BtnSave 
        { 
            get { return btn01_SAVE; }
        }

        public C1Button BtnDelete
        {
            get { return btn01_DELETE; }
        }

        public C1Button BtnQuery
        {
            get { return btn01_QUERY; }
        }

        public C1Button BtnPrint
        {
            get { return btn01_PRINT; }
        }

        public C1Button BtnProcess
        {
            get { return btn01_PROCESS; }
        }

        public C1Button BtnReset
        {
            get { return btn01_RESET; }
        }

        public C1Button BtnDownload
        {
            get { return btn01_DOWNLOAD; }
        }

        public C1Button BtnUpload
        {
            get { return btn01_UPLOAD; }
        }

        public C1Button BtnClose
        {
            get { return btn01_CLOSE; }
        }

        public HEUserControlBase ParentControl
        {
            set { _parentControl = value; }
        }

        public AxCommonButtonControl()
        {
            InitializeComponent();

			SetButtonStyle();
        }

		//protected override void OnLoad(EventArgs e)
		//{
		//    base.OnLoad(e);

			
		//}

		/// <summary>
		/// C1Button에 스타일을 적용하기 위해 사용되는 메서드
		/// </summary>
		private void SetButtonStyle() 
		{
			foreach (Control ctrl in this.flpArea.Controls)
			{
				if (ctrl.Name.StartsWith("btn"))
				{
                    ////원본 
                    //C1Button btn = ctrl as C1Button;
                    //btn.VisualStyle = C1.Win.C1Input.VisualStyle.System;
                    //btn.FlatStyle = FlatStyle.Flat;
                    //btn.FlatAppearance.BorderSize = 0;
                    //btn.Size = new System.Drawing.Size(55, 25);
                    
                    //버튼 마우스 오버기능 추가
                    C1Button btn = ctrl as C1Button;
                    btn.VisualStyle = C1.Win.C1Input.VisualStyle.Custom;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Size = new System.Drawing.Size(55, 25);

                    btn.MouseEnter += delegate
                    {
                        btn.ForeColor = Color.Orange;
                    };
                    btn.MouseLeave += delegate {
                        btn.ForeColor = Color.White;
                    };
				}
			}
		}

        #region [ 공통 버튼 이벤트 ]

        /// <summary>
        /// 저장 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SaveClick != null)
            {
                this.SaveClick(sender, e);
            }
        }

        /// <summary>
        /// 삭제 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteClick != null)
            {
                this.DeleteClick(sender, e);
            }
        }

        /// <summary>
        /// 조회 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.QueryClick != null)
            {
                this.QueryClick(sender, e);
            }
        }

        /// <summary>
        /// 출력 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.PrintClick != null)
            {
                this.PrintClick(sender, e);
            }
        }

        /// <summary>
        /// 처리 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.ProcessClick != null)
            {
                this.ProcessClick(sender, e);
            }
        }

        /// <summary>
        /// 초기화 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.ResetClick != null)
            {
                this.ResetClick(sender, e);
            }
        }


        /// <summary>
        /// 다운 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
			int flexGridCount = 0;
			List<C1FlexGrid> flexGrids = new List<C1FlexGrid>();
			string saveFileName = string.Empty;

			FindFlexGrid(this.Parent.Controls, ref flexGridCount, ref flexGrids);

			// 그리드가 2개 이상 있는 경우 선택할 수 있는 화면 팝업
			if (flexGridCount > 1)
			{
				if (flexGrids.Count > 1)
				{
					AxExcelDownloadPopup popup = new AxExcelDownloadPopup();

					for (int i = flexGrids.Count - 1; i >= 0; i--)
					{
						RadioButton rdoGridInfo = new RadioButton();
						rdoGridInfo.Text = flexGrids[i].Name;
						rdoGridInfo.Checked = (i == flexGrids.Count - 1) ? true : false;
						rdoGridInfo.Click += delegate(object obj, EventArgs ea) 
						{
							saveFileName = rdoGridInfo.Text;
						};
						popup.FlpCtrl.Controls.Add(rdoGridInfo);
					}

					if (popup.ShowDialog() == DialogResult.OK)
					{
                        string gridName = saveFileName;
						saveFileName = ShowDialogPopup(CoreHelper.GetFileFilter(FILETYPE.EXCEL), saveFileName);

						// 팝업창을 띄워준 후 엑셀 출력
						if (! string.IsNullOrEmpty(saveFileName))
						{
                            for (int i = flexGrids.Count - 1; i >= 0; i--)
                            {
                                if (flexGrids[i].Name == gridName)
                                {
                                    if (saveFileName.ToUpper().EndsWith("XLS")) //확장자에 따라 옵션 다르게 함. 
                                    {
                                        flexGrids[i].SaveExcel(saveFileName, FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges); //office 2003 포맷
                                    }
                                    else
                                    {
                                        flexGrids[i].SaveExcel(saveFileName, FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges | FileFlags.OpenXml); //office 2007 포맷
                                    }
                                    break;
                                }
                            }
						}
					}
				}
			}
			else if (flexGridCount == 1)
			{
				try
				{
					// 엑셀 파일 확장자가 포함되어 있는지 확인해야 함
					saveFileName = flexGrids[0].Name;
					saveFileName = ShowDialogPopup(CoreHelper.GetFileFilter(FILETYPE.EXCEL), saveFileName);
					// 팝업창을 띄워준 후 엑셀 출력
					if (!string.IsNullOrEmpty(saveFileName))
					{
                        if (saveFileName.ToUpper().EndsWith("XLS")) //확장자에 따라 옵션 다르게 함. 
                        {
                            flexGrids[0].SaveExcel(saveFileName, FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges); //office 2003 포맷
                        }
                        else
                        {
                            flexGrids[0].SaveExcel(saveFileName, FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges | FileFlags.OpenXml); ////office 2007 포맷
                        }

                        
					}
				}
				catch (Exception ex)
				{
					throw;					
				}
			}
        }

		/// <summary>
        /// 업 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
			int flexGridCount = 0;
			List<C1FlexGrid> flexGrids = new List<C1FlexGrid>();

			FindFlexGrid(this.Parent.Controls, ref flexGridCount, ref flexGrids);

			// 그리드가 2개 이상 있는 경우 선택할 수 있는 화면 팝업
			if (flexGridCount > 1)
			{
				if (flexGrids.Count > 1)
				{
					AxExcelDownloadPopup popup = new AxExcelDownloadPopup();

					//for (int i = flexGrids.Count - 1; i >= 0; i--)
					//{
					//    RadioButton rdoGridInfo = new RadioButton();
					//    rdoGridInfo.Text = flexGrids[i].Name;
					//    rdoGridInfo.Checked = (i == flexGrids.Count - 1) ? true : false;
					//    rdoGridInfo.Click += delegate(object obj, EventArgs ea)
					//    {
					//        saveFileName = rdoGridInfo.Text;
					//    };
					//    popup.FlpCtrl.Controls.Add(rdoGridInfo);
					//}

					//if (popup.ShowDialog() == DialogResult.OK)
					//{
					//    // 팝업창을 띄워준 후 엑셀 출력
					//    if (ShowDialogPopup(CoreHelper.GetFileFilter(FILETYPE.EXCEL), saveFileName))
					//    {
					//        flexGrids[0].SaveExcel(saveFileName + ".xls", FileFlags.IncludeFixedCells);
					//    }
					//}
				}
			}
			else if (flexGridCount == 1)
			{
				string filePath = string.Empty;
				string fileName = string.Empty;

				// 파일을 선택한 경우
				if (ReadExcelFile(out filePath, out fileName)) 
				{
					ImportExcelFile(filePath, fileName, flexGrids[0]);
				}

				// 팝업창을 띄워준 후 엑셀 출력
				//if (ShowDialogPopup(CoreHelper.GetFileFilter(FILETYPE.EXCEL), saveFileName))
				//{
				//    flexGrids[0].SaveExcel(saveFileName, FileFlags.IncludeFixedCells);
				//}
			}
        }

        /// <summary>
        /// 종료 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.CloseClick != null)
            {
                this.CloseClick(sender, e);
            }

            CloseUIScreen();
        }

		/// <summary>
        /// 도움말 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
			ShowHelpWindow();
        }

		#endregion

		#region [ 별도 메서드들]

		/// <summary>
		/// FlexGrid 찾기
		/// </summary>
		/// <param name="ctrlCol"></param>
		/// <param name="cnt"></param>
		/// <param name="flexGrids"></param>
		private void FindFlexGrid(ControlCollection ctrlCol, ref int cnt, ref List<C1FlexGrid> flexGrids)
		{
			foreach (Control ctrl in ctrlCol)
			{
				string ctrlName = (ctrl.GetType()).Name.ToUpper();

                if ((string.Compare(ctrlName, "C1FLEXGRID", true) == 0) || (string.Compare(ctrlName, "HEFLEXGRID", true) == 0) || (string.Compare(ctrlName, "AXFLEXGRID", true) == 0))
				{
					cnt++;
					flexGrids.Add(ctrl as C1FlexGrid);
				}

				if (ctrl.HasChildren)
				{
					FindFlexGrid(ctrl.Controls, ref cnt, ref flexGrids);
				}
			}
		}

		/// <summary>
		/// 저장 대화 상자를 띄워주는 메서드
		/// </summary>
		/// <param name="filter">적용할 필터 정보</param>
		/// <returns></returns>
		private string ShowDialogPopup(string filter)
		{
			return ShowDialogPopup(filter, string.Empty);
		}

		/// <summary>
		/// 저장 대화 상자를 띄워주는 메서드
		/// </summary>
		/// <param name="filter">적용할 필터 정보</param>
		/// <param name="fileName">저장할 파일명</param>
		/// <returns></returns>
		private string ShowDialogPopup(string filter, string fileName)
		{
			string saveFileName = string.Empty;
			SaveFileDialog dialog = new SaveFileDialog();

			if (!string.IsNullOrEmpty(filter))
			{
				dialog.Filter = filter;
			}

			if (!string.IsNullOrEmpty(fileName))
			{
				dialog.FileName = fileName;
			}

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				saveFileName = dialog.FileName;
			}
			else 
			{
				saveFileName = string.Empty;
			}

			return saveFileName;
		}

		/// <summary>
		/// 로컬에 있는 엑셀 파일을 읽기 위해 대화 상자를 띄운다.
		/// </summary>
		private bool ReadExcelFile(out string filePath, out string fileName)
		{
			bool bRead = true;
			string strFilePath = string.Empty;
			string strFileName = string.Empty;

			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.Filter = CoreHelper.GetFileFilter(FILETYPE.EXCEL);
			fileDialog.RestoreDirectory = true;

			if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.OpenFile() != null)
			{
				strFilePath = fileDialog.FileName;
				strFileName = fileDialog.SafeFileName;
			}
			else 
			{
				bRead = false;
			}

			filePath = strFilePath;
			fileName = strFileName;

			return bRead;
		}

		/// <summary>
		/// 읽어온 엑셀 파일을 그리드에 채운다.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="fileName"></param>
		private void ImportExcelFile(string filePath, string fileName, C1FlexGrid fxGrid)
		{
			try
			{
				DataTable excelTable = new DataTable();
				excelTable.TableName = "EXCELTABLE";

				// SHEET1이라는 이름도 때에 따라서는 안될수도 있기에 고려할 점이다.
				string strQuery = "SELECT * FROM [SHEET1$]";
				string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"", filePath);

				OleDbConnection connection = null;
				OleDbDataAdapter adapter = null;

				try
				{
					connection = new OleDbConnection(connectionString);
					connection.Open();

					// 그리드의 필드와 읽어온 엑셀 정보의 필드를 비교하여
					// 같은 경우에만, 그리드의 필드로 엑셀의 헤더 정보를 변경하여
					// 채워놓을 수 있게 하자.

					adapter = new OleDbDataAdapter(strQuery, connection);
					adapter.Fill(excelTable);

					//SetAddedDataRowState();
					//InitializeButtonStyle(true);

					fxGrid.DataSource = excelTable;
					MsgBox.Show(string.Format("{0}개의 행을 추가하였습니다.", excelTable.Rows.Count));
				}
				catch (Exception ex)
				{
					MsgBox.Show("파일을 읽는 도중 오류가 발생하였습니다 : " + ex.Message);
				}
				finally
				{
					connection.Close();
					connection.Dispose();
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show("파일을 읽는 도중 오류가 발생하였습니다 : " + ex.Message);
			}
		}

		/// <summary>
		/// 도움말 창을 보여주는 메서드
		/// </summary>
		public void ShowHelpWindow()
		{
			//string menuID = (this.Parent as HECommonUserControl).Name;
            string menuID = (this.Parent as AxCommonBaseControl).Name;

			AxHelperForm helperForm = new AxHelperForm(menuID);
			helperForm.Show();
		}

		/// <summary>
		/// 현재의 화면을 종료하는 메서드
		/// </summary>
		public void CloseUIScreen()
		{
            try
            {
                Form parentForm = this.ParentForm;
                Control[] ctrls = parentForm.Controls.Find("tab01", true);

                if (ctrls.Length == 1)
                {
                    if (ctrls[0] is C1DockingTab)
                    {
                        C1DockingTab tab = ctrls[0] as C1DockingTab;
                        C1DockingTabPage tabPage = tab.SelectedTab;
                        tab.Close(tabPage);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
		}

		#endregion

		protected SecurityContext SecurityContext
		{
			get
			{
				SecurityContext scx;
				UserControlBase ucb = this.Parent as UserControlBase;
				//UI가 UserControlBase가 아니라면 읽기 권한만을 가진 컨텍스트를 반환
				if (ucb == null)
				{
					scx = new SecurityContext(false, true, false, false);
				}
				else
				{
					scx = ucb.SecurityContext;
				}

				return scx;
			}
		}
	}
}
