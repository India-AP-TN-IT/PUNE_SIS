using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ax.DEV.Utility.Library
{
	public partial class AxExcelDownloadPopup : Form
	{
		public AxExcelDownloadPopup()
		{
			InitializeComponent();
		}

		public FlowLayoutPanel FlpCtrl 
		{
			get { return this.flp01; }
		}
	}
}
