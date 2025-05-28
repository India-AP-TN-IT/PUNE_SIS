#region ▶ Description & History
/* 
 * 프로그램명 : 메뉴 트리 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-01      배명희      프로그램 아이디 변경(XM01300P1 -> XM20002P1)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보),Popup용UserControl상속
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거
 *                                          
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 메뉴트리 팝업
    /// </summary>
    public partial class XM20002P1 : AxCommonPopupControl
	{
		// 사용 언어
		private string _language = string.Empty;

        private string _systemcode = string.Empty;
        private DialogResult _dialogresult = DialogResult.Cancel;
        // 반환 값
		private object _returnValue = null;
		// 메뉴 정보를 포함하고 있는 DataTable
		private DataTable menuTable;
		
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20002";
        private string _text;

		public XM20002P1(string text)
		{
			InitializeComponent();
            _WSCOM = new AxClientProxy();
            _text = text;
		}

        #region [프로퍼티]

        public string SystemCode
        {
            get { return _systemcode; }
            set { _systemcode = value; }
        }

		public string Language
		{
			get { return _language; }
			set { _language = value; }
		}

		public object ReturnValue
		{
			get { return _returnValue; }
			set { _returnValue = value; }
		}

        public DialogResult DialogResult
        {
            get { return _dialogresult; }
            set { _dialogresult = value; }
        }
        #endregion

        #region [초기화 설정]

        protected override void UI_Shown(EventArgs e)
        {
            ((Form)this.Parent).Text = _text;

            GetMenuInfo();
        }

        #endregion

        #region [ EVENTS ]

        /// <summary>
		/// 확인 버튼 클릭 시
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn01_CONFIRM_Click(object sender, EventArgs e)
		{
            _dialogresult = DialogResult.OK;
			// 반환값을 설정(현재 선택된 노드에 대한 정보만)
			SetReturnValue();

            ((Form)this.Parent).Close();
		}

		/// <summary>
		/// 취소 버튼 클릭 시
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn01_CANCEL_Click(object sender, EventArgs e)
		{
            _dialogresult = DialogResult.Cancel;
            ((Form)this.Parent).Close();
		}

		/// <summary>
		/// 해당 메뉴가 체크된 이후
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tv01_MENU_AfterCheck(object sender, TreeViewEventArgs e)
		{            
            if (e.Action == TreeViewAction.ByMouse)
            {
                TreeNode node = e.Node as TreeNode;
                if (node.Nodes.Count > 0)
                {
                    SetCheckChildrenNode(node, node.Checked);
                    SetCheckParentNode(node, node.Checked);
                }
                else
                    SetCheckParentNode(node, node.Checked);
            }
		}

		#endregion
        
		#region [ METHODS ]
		/// <summary>
		/// 메뉴 정보를 가져오는 메서드
		/// </summary>
		private void GetMenuInfo()
		{
			HEParameterSet paramSet = new HEParameterSet();
			paramSet["LANGUAGE"] = this._language;
            paramSet["SYSTEMCODE"] = this._systemcode;

			try
			{
                menuTable = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MENU"), paramSet).Tables[0];
				if (menuTable.Rows.Count > 0)
				{
					ConfigurationMenuTree();
				}
			}
			catch (FaultException<ExceptionDetail> ex)
			{
				// XM00-0019 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
				MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
			}
		}

		/// <summary>
		/// 최상위 메뉴 ID를 통해 트리를 구성하는 메서드
		/// </summary>
		private void ConfigurationMenuTree()
		{
			DataRow[] parentRows = menuTable.Select("PARENTID = ''");

			foreach (DataRow row in parentRows)
			{
				MakeTreeNode(row, null);
			}
		}

		/// <summary>
		/// 트리를 구성하는 메서드
		/// </summary>
		/// <param name="row">DataRow 객체</param>
		/// <param name="parentNode">부모 TreeNode</param>
		private void MakeTreeNode(DataRow row, TreeNode parentNode)
		{
			TreeNode tn = new TreeNode("[" + row["MENUID"].ToString() + "] " + row["MENUNAME"].ToString());
			tn.Tag = row;
			tn.Name = row["MENUID"].ToString();

			// 최상위 노드인 경우
			if (parentNode == null)
			{
				tv01_MENU.Nodes.Add(tn);
			}
			else
			{
				parentNode.Nodes.Add(tn);
			}

			DataRow[] childRows = menuTable.Select("PARENTID = '" + row["MENUID"].ToString() + "'");

			// 자식 데이터들이 있는 경우
			if (childRows.Length > 0)
			{
				foreach (DataRow childRow in childRows)
				{
					MakeTreeNode(childRow, tn);
				}
			}
		}

		/// <summary>
		/// 선택된 하위 항목들을 체크/언체크시키는 메서드
		/// </summary>
		/// <param name="menuID"></param>
		/// <param name="bChecked"></param>
		private void SetCheckChildrenNode(TreeNode selectedNode, bool bChecked)
		{
			// 하위 항목들을 체크
			if (selectedNode != null && selectedNode.Nodes.Count > 0)
			{
				foreach (TreeNode childNode in selectedNode.Nodes)
				{
					childNode.Checked = bChecked;

					if (childNode.Nodes.Count > 0)
					{
						SetCheckChildrenNode(childNode, bChecked);
					}
				}
			}
		}

        /// <summary>
        /// 선택된 상위 항목들을 체크/언체크시키는 메서드
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <param name="bChecked"></param>
        private void SetCheckParentNode(TreeNode selectedNode, bool bChecked)
        {
            if (selectedNode != null && selectedNode.Parent != null)
            {
                if (bChecked == true)
                {
                    selectedNode.Parent.Checked = bChecked;
                    SetCheckParentNode(selectedNode.Parent, bChecked);                    
                }
                else
                {                    
                    int cnt = 0;
                    foreach (TreeNode siblingsNode in selectedNode.Parent.Nodes)
                    {
                        if (siblingsNode.Checked == true)
                            cnt++;
                    }
                    if (cnt == 0)
                    {
                        selectedNode.Parent.Checked = bChecked;
                        SetCheckParentNode(selectedNode.Parent, bChecked);
                    }
                }
            }
        }        

		/// <summary>
		/// 현재 선택된 노드들에 대한 반환값을 설정하는 메서드
		/// </summary>
		private void SetReturnValue()
		{
			HEParameterSet paramSet = new HEParameterSet();

			foreach (TreeNode tn in this.tv01_MENU.Nodes)
			{
				AddParameterSet(tn, ref paramSet);
			}

			if (paramSet.Items.Count > 0)
			{
				this._returnValue = paramSet;
			}
		}

		/// <summary>
		/// 체크된 TreeNode를 ParameterSet 객체에 담는 메서드
		/// </summary>
		/// <param name="tn"></param>
		/// <param name="paramSet"></param>
		private void AddParameterSet(TreeNode tn, ref HEParameterSet paramSet) 
		{
			// 체크된 경우 ParameterSet에 담는다.
			if (tn.Checked)
			{
				paramSet.Add(tn.Name, tn.Text);
			}

			// 하위 노드 체크
			if (tn.Nodes != null)
			{
				foreach (TreeNode childNode in tn.Nodes)
				{
					AddParameterSet(childNode, ref paramSet);
				}
			}
		}

		#endregion
    }
}
