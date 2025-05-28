using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheOne.Configuration;

namespace Ax.DEV.Utility.Library
{
	public partial class AxHelperForm : Form
	{
		private string _menuID = string.Empty;
	
		public AxHelperForm()
		{
			InitializeComponent();
		}

		public AxHelperForm(string menuID) : this()
		{
			this._menuID = menuID;
		}

		private void AxHelperForm_Load(object sender, EventArgs e)
		{
			// _menuID가 없는 경우
			if (string.IsNullOrEmpty(_menuID))
			{
				// 도움말 화면을 닫거나 빈 화면을 보여준다.
				this.Close();
			}
			else 
			{
				//string uriString = string.Format("URL", _menuID);
				// config 파일에 다음과 같은 설정이 추가되어야 한다.
				//<add name="BaseUrl" value="http://deverm.hanileh.com/"/>
				string helpUrl = "ERM/HELP/";
				string uriString = AppSectionFactory.AppSection["BaseUrl"] + helpUrl + _menuID + ".mht";
                
				this.wbrHelp.Url = new Uri(uriString);
			}
		}
	}
}
