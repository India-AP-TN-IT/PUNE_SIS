//using System.Windows.Forms;
//using System.Drawing;
//using System.IO;

//namespace Ax.DEV.Utility.Controls
//{
//    /// <summary>
//    /// UserControl 클래스를 상속받아 구현된 오피스뷰어입니다.
//    /// 오피스 관련 파일, 브라우저, 아크로벳, 이미지를 모두 볼 수 있습니다.
//    /// </summary>
//    public partial class HEOfficeViewer : UserControl
//    {
//        private string _FullPath;

//        public HEOfficeViewer()
//        {
//            InitializeComponent();

//            _FullPath = "";
//        }

//        private void Control_VisibleFalse()
//        {
//            _Office.Visible     = false;
//            _Browser.Visible    = false;
//            _AcroPDF.Visible    = false;
//            _PictureBox.Visible = false;
//        }

//        /// <summary>
//        /// 이미지의 물리적 경로를 지정하면 파일의 확장자에 맞는 뷰어를 실행하여 표시합니다.
//        /// </summary>
//        public void SetValue(string fullPath)
//        {
//            if (!File.Exists(fullPath))
//            {
//                MessageBox.Show("해당 파일이 존재하지 않습니다.");
//                return;
//            }
//            _FullPath = fullPath;

//            FileInfo file = new FileInfo(fullPath);
//            string ext = file.Extension.ToLower().Replace(".", "");

//            if (!this.SetTypeSetting(ext))
//            {
//                MessageBox.Show("컨트롤 구동 중 오류가 발생하였습니다.");
//                return;
//            }
//            switch (ext)
//            {
//                case "doc":
//                case "docx":
//                case "ppt":
//                case "pptx":
//                case "xls":
//                case "xlsx":
//                    _Office.Visible = true;
//                    _Office.Open(fullPath);
//                    break;
//                case "txt":
//                    _Browser.Navigate(fullPath);
//                    _Browser.Visible = true;
//                    break;
//                case "jpg":
//                case "jpeg":
//                case "bmp":
//                case "gif":
//                case "tiff":
//                case "png":
//                    _PictureBox.Image = new Bitmap(fullPath);
//                    _PictureBox.Visible = true;
//                    break;
//                case "pdf":
//                    _AcroPDF.src = fullPath;
//                    _AcroPDF.Visible = true;
//                    break;
//                default:
//                    MessageBox.Show("정의된 파일 포맷이 아닙니다.");
//                    break;
//            }
//        }

//        private void _PictureBox_DoubleClick(object sender, System.EventArgs e)
//        {
//            if (_FullPath.Length == 0) return;
//            System.Diagnostics.Process.Start(_FullPath);
//        }

//        private bool SetTypeSetting(string ext)
//        {
//            string type = "";
//            switch (ext)
//            {
//                case "doc":
//                case "docx":
//                case "ppt":
//                case "pptx":
//                case "xls":
//                case "xlsx":
//                    type = "o";
//                    break;
//                case "txt":
//                    type = "b";
//                    break;
//                case "jpg":
//                case "jpeg":
//                case "bmp":
//                case "gif":
//                case "tiff":
//                case "png":
//                    type = "p";
//                    break;
//                case "pdf":
//                    type = "a";
//                    break;
//            }

//            if (type.Length == 0) return false;

//            System.ComponentModel.ComponentResourceManager resources =
//                new System.ComponentModel.ComponentResourceManager(typeof(HEOfficeViewer));
//            switch (type)
//            {
//                case "o":
//                    this._Office = new AxDSOFramer.AxFramerControl();
//                    ((System.ComponentModel.ISupportInitialize)(this._Office)).BeginInit();
//                    this._Office.SuspendLayout();
//                    this.SuspendLayout();

//                    this._Office.Dock = System.Windows.Forms.DockStyle.Fill;
//                    this._Office.Enabled = true;
//                    this._Office.Location = new System.Drawing.Point(0, 0);
//                    this._Office.Name = "_Office";
//                    this._Office.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_Office.OcxState")));
//                    this._Office.Size = this.Size;
//                    this._Office.TabIndex = 0;

//                    this.Controls.Add(this._Office);
//                    ((System.ComponentModel.ISupportInitialize)(this._Office)).EndInit();
//                    this._Office.ResumeLayout(false);
//                    this.ResumeLayout(false);

//                    this._Office.Titlebar = false;
//                    this._Office.Menubar = false;
//                    break;
//                case "b":
//                    this._Browser = new System.Windows.Forms.WebBrowser();
//                    ((System.ComponentModel.ISupportInitialize)(this._Browser)).BeginInit();
//                    this._Browser.SuspendLayout();
//                    this.SuspendLayout();

//                    this._Browser.Dock = System.Windows.Forms.DockStyle.Fill;
//                    this._Browser.Location = new System.Drawing.Point(0, 0);
//                    this._Browser.MinimumSize = new System.Drawing.Size(20, 20);
//                    this._Browser.Name = "_Browser";
//                    this._Browser.Size = this.Size;
//                    this._Browser.TabIndex = 2;

//                    this.Controls.Add(this._Browser);
//                    ((System.ComponentModel.ISupportInitialize)(this._Browser)).EndInit();
//                    this._Browser.ResumeLayout(false);
//                    this.ResumeLayout(false);
//                    break;
//                case "p":
//                    this._PictureBox = new System.Windows.Forms.PictureBox();
//                    ((System.ComponentModel.ISupportInitialize)(this._PictureBox)).BeginInit();
//                    this._PictureBox.SuspendLayout();
//                    this.SuspendLayout();

//                    this._PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
//                    this._PictureBox.Location = new System.Drawing.Point(0, 0);
//                    this._PictureBox.Name = "_PictureBox";
//                    this._PictureBox.Size = this.Size;
//                    this._PictureBox.TabIndex = 1;
//                    this._PictureBox.TabStop = false;
//                    this._PictureBox.DoubleClick += new System.EventHandler(this._PictureBox_DoubleClick);

//                    this.Controls.Add(this._PictureBox);
//                    ((System.ComponentModel.ISupportInitialize)(this._PictureBox)).EndInit();
//                    this._PictureBox.ResumeLayout(false);
//                    this.ResumeLayout(false);
//                    break;
//                case "a":
//                    this._AcroPDF = new AxAcroPDFLib.AxAcroPDF();
//                    ((System.ComponentModel.ISupportInitialize)(this._AcroPDF)).BeginInit();
//                    this._AcroPDF.SuspendLayout();
//                    this.SuspendLayout();

//                    this._AcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
//                    this._AcroPDF.Enabled = true;
//                    this._AcroPDF.Location = new System.Drawing.Point(0, 0);
//                    this._AcroPDF.Name = "_AcroPDF";
//                    this._AcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_AcroPDF.OcxState")));
//                    this._AcroPDF.Size = this.Size;
//                    this._AcroPDF.TabIndex = 3;

//                    this.Controls.Add(this._AcroPDF);
//                    ((System.ComponentModel.ISupportInitialize)(this._AcroPDF)).EndInit();
//                    this._AcroPDF.ResumeLayout(false);
//                    this.ResumeLayout(false);
//                    break;
//            }

//            return true;
//        }

//        private void HEOfficeViewer_Paint(object sender, PaintEventArgs e)
//        {
//            this.ControlRefresh();
//        }

//        private void HEOfficeViewer_Resize(object sender, System.EventArgs e)
//        {
//            this.ControlRefresh();
//        }

//        private void ControlRefresh()
//        {
//            if (_Office != null)
//                _Office.Refresh();

//            if (_Browser != null)
//                _Browser.Refresh();

//            if (_AcroPDF != null)
//                _AcroPDF.Refresh();

//            if (_PictureBox != null)
//                _PictureBox.Refresh();
//        }
//    }
//}
