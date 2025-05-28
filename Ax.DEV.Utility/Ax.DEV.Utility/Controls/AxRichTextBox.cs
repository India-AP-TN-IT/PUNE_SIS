using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Ax.DEV.Utility.Library;
using System.Drawing.Text;

namespace Ax.DEV.Utility.Controls
{
    //2013.05.15
    //이 클래스는 오픈된 소스를 인터넷에서 찾아 작성함.
    public partial class AxRichTextBox : UserControl, IAxControl
    {
        public AxRichTextBox()
        {
            InitializeComponent();

            cmFonts.MenuItems.Clear();
            FontFamily[] fontFamilies;
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            fontFamilies = installedFontCollection.Families;

            for (int i = 0; i < fontFamilies.Length; i++)
            {
                if (isContainHangul(fontFamilies[i].Name))
                {
                    MenuItem mi = new MenuItem();
                    mi.Index = i;
                    mi.Name = "font_" + fontFamilies[i].Name;
                    mi.Text = fontFamilies[i].Name;
                    mi.Click += new EventHandler(this.Font_Click);
                    cmFonts.MenuItems.Add(mi);
                }
            }

        }

        private RichTextBox rtbTemp = new RichTextBox();

        private bool isContainHangul(string s)
        {
            char[] charArr = s.ToCharArray();
            foreach (char c in charArr)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    return true;
                }
            }
            return false;
        }
        #region StampActions
        public enum StampActions
        {
            EditedBy = 1,
            DateTime = 2,
            Custom = 4
        }
        #endregion



        #region Selection Change event
        [Description("Occurs when the selection is changed"),
        Category("Behavior")]
        // Raised in tb1 SelectionChanged event so that user can do useful things
        public event System.EventHandler SelChanged;
        #endregion

        #region Stamp Event Stuff
        [Description("Occurs when the stamp button is clicked"),
         Category("Behavior")]
        public event System.EventHandler Stamp;

        /// <summary>
        /// OnStamp event
        /// </summary>
        protected virtual void OnStamp(EventArgs e)
        {
            if (Stamp != null)
                Stamp(this, e);

            switch (StampAction)
            {
                case StampActions.EditedBy:
                    {
                        StringBuilder stamp = new StringBuilder(""); //holds our stamp text
                        if (rtb1.Text.Length > 0) stamp.Append("\r\n\r\n"); //add two lines for space
                        stamp.Append("Edited by ");
                        //use the CurrentPrincipal name if one exsist else use windows logon username
                        if (Thread.CurrentPrincipal == null || Thread.CurrentPrincipal.Identity == null || Thread.CurrentPrincipal.Identity.Name.Length <= 0)
                            stamp.Append(Environment.UserName);
                        else
                            stamp.Append(Thread.CurrentPrincipal.Identity.Name);
                        stamp.Append(" on " + DateTime.Now.ToLongDateString() + "\r\n");

                        rtb1.SelectionLength = 0; //unselect everything basicly
                        rtb1.SelectionStart = rtb1.Text.Length; //start new selection at the end of the text
                        rtb1.SelectionColor = this.StampColor; //make the selection blue
                        rtb1.SelectionFont = new Font(rtb1.SelectionFont, FontStyle.Bold); //set the selection font and style
                        rtb1.AppendText(stamp.ToString()); //add the stamp to the richtextbox
                        rtb1.Focus(); //set focus back on the richtextbox
                    } break; //end edited by stamp
                case StampActions.DateTime:
                    {
                        StringBuilder stamp = new StringBuilder(""); //holds our stamp text
                        if (rtb1.Text.Length > 0) stamp.Append("\r\n\r\n"); //add two lines for space
                        stamp.Append(DateTime.Now.ToLongDateString() + "\r\n");
                        rtb1.SelectionLength = 0; //unselect everything basicly
                        rtb1.SelectionStart = rtb1.Text.Length; //start new selection at the end of the text
                        rtb1.SelectionColor = this.StampColor; //make the selection blue
                        rtb1.SelectionFont = new Font(rtb1.SelectionFont, FontStyle.Bold); //set the selection font and style
                        rtb1.AppendText(stamp.ToString()); //add the stamp to the richtextbox
                        rtb1.Focus(); //set focus back on the richtextbox
                    } break;
            } //end select
        }
        #endregion

        #region Toolbar button click
        /// <summary>
        ///     Handler for the toolbar button click event
        /// </summary>
        private void tb1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            // true if style to be added
            // false to remove style
            bool add = e.Button.Pushed;

            //Switch based on the tag of the button pressed
            switch (e.Button.Tag.ToString().ToLower())
            {
                case "bold":
                    ChangeFontStyle(FontStyle.Bold, add);
                    break;
                case "italic":
                    ChangeFontStyle(FontStyle.Italic, add);
                    break;
                case "underline":
                    ChangeFontStyle(FontStyle.Underline, add);
                    break;
                case "strikeout":
                    ChangeFontStyle(FontStyle.Strikeout, add);
                    break;
                case "left":
                    //change horizontal alignment to left
                    rtb1.SelectionAlignment = HorizontalAlignment.Left;
                    tbbCenter.Pushed = false;
                    tbbRight.Pushed = false;
                    break;
                case "center":
                    //change horizontal alignment to center
                    tbbLeft.Pushed = false;
                    rtb1.SelectionAlignment = HorizontalAlignment.Center;
                    tbbRight.Pushed = false;
                    break;
                case "right":
                    //change horizontal alignment to right
                    tbbLeft.Pushed = false;
                    tbbCenter.Pushed = false;
                    rtb1.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                case "edit stamp":
                    OnStamp(new EventArgs()); //send stamp event
                    break;
                case "color":
                    ColorDialog cd = new ColorDialog();
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        rtb1.SelectionColor = cd.Color;
                    }
                    //rtb1.SelectionColor = Color.Black;
                    break;
                case "undo":
                    rtb1.Undo();
                    break;
                case "redo":
                    rtb1.Redo();
                    break;
                case "open":
                    try
                    {
                        if (ofd1.ShowDialog() == DialogResult.OK && ofd1.FileName.Length > 0)
                            if (System.IO.Path.GetExtension(ofd1.FileName).ToLower().Equals(".rtf"))
                                rtb1.LoadFile(ofd1.FileName, RichTextBoxStreamType.RichText);
                            else
                                rtb1.LoadFile(ofd1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    catch (ArgumentException ae)
                    {
                        if (ae.Message == "Invalid file format.")
                            MessageBox.Show("There was an error loading the file: " + ofd1.FileName);
                    }
                    break;
                case "save":
                    if (sfd1.ShowDialog() == DialogResult.OK && sfd1.FileName.Length > 0)
                        if (System.IO.Path.GetExtension(sfd1.FileName).ToLower().Equals(".rtf"))
                            rtb1.SaveFile(sfd1.FileName);
                        else
                            rtb1.SaveFile(sfd1.FileName, RichTextBoxStreamType.PlainText);
                    break;
                case "cut":
                    {
                        if (rtb1.SelectedText.Length <= 0) break;
                        rtb1.Cut();
                        break;
                    }
                case "copy":
                    {
                        if (rtb1.SelectedText.Length <= 0) break;
                        rtb1.Copy();
                        break;
                    }
                case "paste":
                    {
                        try
                        {
                            rtb1.Paste();
                        }
                        catch
                        {
                            MessageBox.Show("Paste Failed");
                        }
                        break;
                    }
                case "image":
                    try
                    {
                        if (ofd2.ShowDialog() == DialogResult.OK && ofd2.FileName.Length > 0)
                        {
                            Image img = Image.FromFile(ofd2.FileName);
                            Clipboard.SetImage(img);
                            rtb1.Paste();
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        if (ae.Message == "Invalid file format.")
                            MessageBox.Show("There was an error loading the file: " + ofd1.FileName);
                    }
                    break;
            } //end select
        }
        #endregion

        #region Update Toolbar
        /// <summary>
        ///     Update the toolbar button statuses
        /// </summary>
        public void UpdateToolbar()
        {
            // Get the font, fontsize and style to apply to the toolbar buttons
            Font fnt = GetFontDetails();
            // Set font style buttons to the styles applying to the entire selection
            FontStyle style = fnt.Style;

            //Set all the style buttons using the gathered style
            tbbBold.Pushed = fnt.Bold; //bold button
            tbbItalic.Pushed = fnt.Italic; //italic button
            tbbUnderline.Pushed = fnt.Underline; //underline button
            tbbStrikeout.Pushed = fnt.Strikeout; //strikeout button
            tbbLeft.Pushed = (rtb1.SelectionAlignment == HorizontalAlignment.Left); //justify left
            tbbCenter.Pushed = (rtb1.SelectionAlignment == HorizontalAlignment.Center); //justify center
            tbbRight.Pushed = (rtb1.SelectionAlignment == HorizontalAlignment.Right); //justify right

            //Check the correct color
            //foreach (MenuItem mi in cmColors.MenuItems)
            //    mi.Checked = (rtb1.SelectionColor == Color.FromName(mi.Text));

            //Check the correct font
            foreach (MenuItem mi in cmFonts.MenuItems)
                mi.Checked = (fnt.FontFamily.Name == mi.Text);

            //Check the correct font size
            foreach (MenuItem mi in cmFontSizes.MenuItems)
                mi.Checked = ((int)fnt.SizeInPoints == float.Parse(mi.Text));
        }
        #endregion

        #region Update Toolbar Seperators
        private void UpdateToolbarSeperators()
        {
            //Save & Open
            if (!tbbSave.Visible && !tbbOpen.Visible)
                tbbSeparator3.Visible = false;
            else
                tbbSeparator3.Visible = true;

            //Font & Font Size
            if (!tbbFont.Visible && !tbbFontSize.Visible && !tbbColor.Visible)
                tbbSeparator5.Visible = false;
            else
                tbbSeparator5.Visible = true;

            //Bold, Italic, Underline, & Strikeout
            if (!tbbBold.Visible && !tbbItalic.Visible && !tbbUnderline.Visible && !tbbStrikeout.Visible)
                tbbSeparator1.Visible = false;
            else
                tbbSeparator1.Visible = true;

            //Left, Center, & Right
            if (!tbbLeft.Visible && !tbbCenter.Visible && !tbbRight.Visible)
                tbbSeparator2.Visible = false;
            else
                tbbSeparator2.Visible = true;

            //Undo & Redo
            if (!tbbUndo.Visible && !tbbRedo.Visible)
                tbbSeparator4.Visible = false;
            else
                tbbSeparator4.Visible = true;
        }
        #endregion

        #region RichTextBox Selection Change
        /// <summary>
        ///		Change the toolbar buttons when new text is selected
        ///		and raise event SelChanged
        /// </summary>
        private void rtb1_SelectionChanged(object sender, System.EventArgs e)
        {

            ////Update the toolbar buttons
            //UpdateToolbar();

            ////Send the SelChangedEvent
            //if (SelChanged != null)
            //    SelChanged(this, e);
        }
        #endregion

        #region Color Click
        /// <summary>
        ///     Change the richtextbox color
        /// </summary>
        private void Color_Click(object sender, System.EventArgs e)
        {
            //set the richtextbox color based on the name of the menu item
            ChangeFontColor(Color.FromName(((MenuItem)sender).Text));
        }
        #endregion

        #region Font Click
        /// <summary>
        ///     Change the richtextbox font
        /// </summary>
        private void Font_Click(object sender, System.EventArgs e)
        {
            // Set the font for the entire selection
            ChangeFont(((MenuItem)sender).Text);
        }
        #endregion

        #region Font Size Click
        /// <summary>
        ///     Change the richtextbox font size
        /// </summary>
        private void FontSize_Click(object sender, System.EventArgs e)
        {
            //set the richtextbox font size based on the name of the menu item
            ChangeFontSize(float.Parse(((MenuItem)sender).Text));
        }
        #endregion

        #region Link Clicked
        /// <summary>
        /// Starts the default browser if a link is clicked
        /// </summary>
        private void rtb1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        #endregion

        #region Public Properties

        /// <summary>
        ///     The toolbar that is contained with-in the RichTextBoxExtened control
        /// </summary>
        [Description("The internal toolbar control"),
        Category("Internal Controls"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolBar Toolbar
        {
            get { return tb1; }
        }

        /// <summary>
        ///     The RichTextBox that is contained with-in the RichTextBoxExtened control
        /// </summary>
        [Description("The internal richtextbox control"),
        Category("Internal Controls"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RichTextBox RichTextBox
        {
            get { return rtb1; }
        }

        /// <summary>
        ///     Show the save button or not
        /// </summary>
        [Description("Show the save button or not"),
        Category("Appearance")]
        public bool ShowSave
        {
            get { return tbbSave.Visible; }
            set { tbbSave.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///    Show the open button or not 
        /// </summary>
        [Description("Show the open button or not"),
        Category("Appearance")]
        public bool ShowOpen
        {
            get { return tbbOpen.Visible; }
            set { tbbOpen.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the stamp button or not
        /// </summary>
        [Description("Show the stamp button or not"),
         Category("Appearance")]
        public bool ShowStamp
        {
            get { return tbbStamp.Visible; }
            set { tbbStamp.Visible = value; }
        }

        /// <summary>
        ///     Show the color button or not
        /// </summary>
        [Description("Show the color button or not"),
        Category("Appearance")]
        public bool ShowColors
        {
            get { return tbbColor.Visible; }
            set { tbbColor.Visible = value; }
        }

        /// <summary>
        ///     Show the undo button or not
        /// </summary>
        [Description("Show the undo button or not"),
        Category("Appearance")]
        public bool ShowUndo
        {
            get { return tbbUndo.Visible; }
            set { tbbUndo.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the redo button or not
        /// </summary>
        [Description("Show the redo button or not"),
        Category("Appearance")]
        public bool ShowRedo
        {
            get { return tbbRedo.Visible; }
            set { tbbRedo.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the bold button or not
        /// </summary>
        [Description("Show the bold button or not"),
        Category("Appearance")]
        public bool ShowBold
        {
            get { return tbbBold.Visible; }
            set { tbbBold.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the italic button or not
        /// </summary>
        [Description("Show the italic button or not"),
        Category("Appearance")]
        public bool ShowItalic
        {
            get { return tbbItalic.Visible; }
            set { tbbItalic.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the underline button or not
        /// </summary>
        [Description("Show the underline button or not"),
        Category("Appearance")]
        public bool ShowUnderline
        {
            get { return tbbUnderline.Visible; }
            set { tbbUnderline.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the strikeout button or not
        /// </summary>
        [Description("Show the strikeout button or not"),
        Category("Appearance")]
        public bool ShowStrikeout
        {
            get { return tbbStrikeout.Visible; }
            set { tbbStrikeout.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the left justify button or not
        /// </summary>
        [Description("Show the left justify button or not"),
        Category("Appearance")]
        public bool ShowLeftJustify
        {
            get { return tbbLeft.Visible; }
            set { tbbLeft.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the right justify button or not
        /// </summary>
        [Description("Show the right justify button or not"),
        Category("Appearance")]
        public bool ShowRightJustify
        {
            get { return tbbRight.Visible; }
            set { tbbRight.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the center justify button or not
        /// </summary>
        [Description("Show the center justify button or not"),
        Category("Appearance")]
        public bool ShowCenterJustify
        {
            get { return tbbCenter.Visible; }
            set { tbbCenter.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Determines how the stamp button will respond
        /// </summary>
        StampActions m_StampAction = StampActions.EditedBy;
        [Description("Determines how the stamp button will respond"),
        Category("Behavior")]
        public StampActions StampAction
        {
            get { return m_StampAction; }
            set { m_StampAction = value; }
        }

        /// <summary>
        ///     Color of the stamp text
        /// </summary>
        Color m_StampColor = Color.Blue;

        [Description("Color of the stamp text"),
        Category("Appearance")]
        public Color StampColor
        {
            get { return m_StampColor; }
            set { m_StampColor = value; }
        }

        /// <summary>
        ///     Show the font button or not
        /// </summary>
        [Description("Show the font button or not"),
        Category("Appearance")]
        public bool ShowFont
        {
            get { return tbbFont.Visible; }
            set { tbbFont.Visible = value; }
        }

        /// <summary>
        ///     Show the font size button or not
        /// </summary>
        [Description("Show the font size button or not"),
        Category("Appearance")]
        public bool ShowFontSize
        {
            get { return tbbFontSize.Visible; }
            set { tbbFontSize.Visible = value; }
        }

        /// <summary>
        ///     Show the cut button or not
        /// </summary>
        [Description("Show the cut button or not"),
        Category("Appearance")]
        public bool ShowCut
        {
            get { return tbbCut.Visible; }
            set { tbbCut.Visible = value; }
        }

        /// <summary>
        ///     Show the copy button or not
        /// </summary>
        [Description("Show the copy button or not"),
        Category("Appearance")]
        public bool ShowCopy
        {
            get { return tbbCopy.Visible; }
            set { tbbCopy.Visible = value; }
        }

        /// <summary>
        ///     Show the paste button or not
        /// </summary>
        [Description("Show the paste button or not"),
        Category("Appearance")]
        public bool ShowPaste
        {
            get { return tbbPaste.Visible; }
            set { tbbPaste.Visible = value; }
        }

        /// <summary>
        ///     Detect URLs with-in the richtextbox
        /// </summary>
        [Description("Detect URLs with-in the richtextbox"),
        Category("Behavior")]
        public bool DetectURLs
        {
            get { return rtb1.DetectUrls; }
            set { rtb1.DetectUrls = value; }
        }

        /// <summary>
        /// Determines if the TAB key moves to the next control or enters a TAB character in the richtextbox
        /// </summary>
        [Description("Determines if the TAB key moves to the next control or enters a TAB character in the richtextbox"),
        Category("Behavior")]
        public bool AcceptsTab
        {
            get { return rtb1.AcceptsTab; }
            set { rtb1.AcceptsTab = value; }
        }

        /// <summary>
        /// Determines if auto word selection is enabled
        /// </summary>
        [Description("Determines if auto word selection is enabled"),
        Category("Behavior")]
        public bool AutoWordSelection
        {
            get { return rtb1.AutoWordSelection; }
            set { rtb1.AutoWordSelection = value; }
        }

        /// <summary>
        /// Determines if this control can be edited
        /// </summary>
        [Description("Determines if this control can be edited"),
        Category("Behavior")]
        public bool ReadOnly
        {
            get { return rtb1.ReadOnly; }
            set
            {
                tb1.Visible = !value;
                rtb1.ReadOnly = value;
            }
        }

        private bool _showToolBarText;

        /// <summary>
        /// Determines if the buttons on the toolbar will show there text or not
        /// </summary>
        [Description("Determines if the buttons on the toolbar will show there text or not"),
        Category("Behavior")]
        public bool ShowToolBarText
        {
            get { return _showToolBarText; }
            set
            {
                _showToolBarText = value;

                if (_showToolBarText)
                {
                    tbbSave.Text = "Save";
                    tbbOpen.Text = "Open";
                    tbbBold.Text = "Bold";
                    tbbFont.Text = "Font";
                    tbbFontSize.Text = "Font Size";
                    tbbColor.Text = "Font Color";
                    tbbItalic.Text = "Italic";
                    tbbStrikeout.Text = "Strikeout";
                    tbbUnderline.Text = "Underline";
                    tbbLeft.Text = "Left";
                    tbbCenter.Text = "Center";
                    tbbRight.Text = "Right";
                    tbbUndo.Text = "Undo";
                    tbbRedo.Text = "Redo";
                    tbbCut.Text = "Cut";
                    tbbCopy.Text = "Copy";
                    tbbPaste.Text = "Paste";
                    tbbStamp.Text = "Stamp";
                }
                else
                {
                    tbbSave.Text = "";
                    tbbOpen.Text = "";
                    tbbBold.Text = "";
                    tbbFont.Text = "";
                    tbbFontSize.Text = "";
                    tbbColor.Text = "";
                    tbbItalic.Text = "";
                    tbbStrikeout.Text = "";
                    tbbUnderline.Text = "";
                    tbbLeft.Text = "";
                    tbbCenter.Text = "";
                    tbbRight.Text = "";
                    tbbUndo.Text = "";
                    tbbRedo.Text = "";
                    tbbCut.Text = "";
                    tbbCopy.Text = "";
                    tbbPaste.Text = "";
                    tbbStamp.Text = "";
                }

                this.Invalidate();
                this.Update();
            }
        }

        #endregion

        #region Change font
        /// <summary>
        ///     Change the richtextbox font for the current selection
        /// </summary>
        public void ChangeFont(string fontFamily)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            // fontFamily - the font to be applied, eg "Courier New"

            // Reason: The reason this method and the others exist is because
            // setting these items via the selection font doen't work because
            // a null selection font is returned for a selection with more 
            // than one font!

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            // If len <= 1 and there is a selection font, amend and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionFont =
                    new Font(fontFamily, rtb1.SelectionFont.Size, rtb1.SelectionFont.Style);
                return;
            }

            // Step through the selected text one char at a time
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);
                rtbTemp.SelectionFont = new Font(fontFamily, rtbTemp.SelectionFont.Size, rtbTemp.SelectionFont.Style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font style
        /// <summary>
        ///     Change the richtextbox style for the current selection
        /// </summary>
        public void ChangeFontStyle(FontStyle style, bool add)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	style - eg FontStyle.Bold
            //	add - IF true then add else remove

            // throw error if style isn't: bold, italic, strikeout or underline
            if (style != FontStyle.Bold
                && style != FontStyle.Italic
                && style != FontStyle.Strikeout
                && style != FontStyle.Underline)
                throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyle");

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                //add or remove style 
                if (add)
                    rtb1.SelectionFont = new Font(rtb1.SelectionFont, rtb1.SelectionFont.Style | style);
                else
                    rtb1.SelectionFont = new Font(rtb1.SelectionFont, rtb1.SelectionFont.Style & ~style);

                return;
            }

            // Step through the selected text one char at a time	
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                //add or remove style 
                if (add)
                    rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont, rtbTemp.SelectionFont.Style | style);
                else
                    rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont, rtbTemp.SelectionFont.Style & ~style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font size
        /// <summary>
        ///     Change the richtextbox font size for the current selection
        /// </summary>
        public void ChangeFontSize(float fontSize)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            // fontSize - the fontsize to be applied, eg 33.5

            if (fontSize <= 0.0)
                throw new System.InvalidProgramException("Invalid font size parameter to ChangeFontSize");

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            // If len <= 1 and there is a selection font, amend and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionFont =
                    new Font(rtb1.SelectionFont.FontFamily, fontSize, rtb1.SelectionFont.Style);
                return;
            }

            // Step through the selected text one char at a time
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);
                rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont.FontFamily, fontSize, rtbTemp.SelectionFont.Style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font color
        /// <summary>
        ///     Change the richtextbox font color for the current selection
        /// </summary>
        public void ChangeFontColor(Color newColor)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	newColor - eg Color.Red

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionColor = newColor;
                return;
            }

            // Step through the selected text one char at a time	
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                //change color
                rtbTemp.SelectionColor = newColor;
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Get Font Details
        /// <summary>
        ///     Returns a Font with:
        ///     1) The font applying to the entire selection, if none is the default font. 
        ///     2) The font size applying to the entire selection, if none is the size of the default font.
        ///     3) A style containing the attributes that are common to the entire selection, default regular.
        /// </summary>		
        /// 
        public Font GetFontDetails()
        {
            //This method should handle cases that occur when multiple fonts/styles are selected

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            if (len <= 1)
            {
                // Return the selection or default font
                if (rtb1.SelectionFont != null)
                    return rtb1.SelectionFont;
                else
                    return rtb1.Font;
            }

            // Step through the selected text one char at a time	
            // after setting defaults from first char
            rtbTemp.Rtf = rtb1.SelectedRtf;

            //Turn everything on so we can turn it off one by one
            FontStyle replystyle =
                FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline;

            // Set reply font, size and style to that of first char in selection.
            rtbTemp.Select(rtbTempStart, 1);
            string replyfont = rtbTemp.SelectionFont.Name;
            float replyfontsize = rtbTemp.SelectionFont.Size;
            replystyle = replystyle & rtbTemp.SelectionFont.Style;

            // Search the rest of the selection
            for (int i = 1; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                // Check reply for different style
                replystyle = replystyle & rtbTemp.SelectionFont.Style;

                // Check font
                if (replyfont != rtbTemp.SelectionFont.FontFamily.Name)
                    replyfont = "";

                // Check font size
                if (replyfontsize != rtbTemp.SelectionFont.Size)
                    replyfontsize = (float)0.0;
            }

            // Now set font and size if more than one font or font size was selected
            if (replyfont == "")
                replyfont = rtbTemp.Font.FontFamily.Name;

            if (replyfontsize == 0.0)
                replyfontsize = rtbTemp.Font.Size;

            // generate reply font
            Font reply
                = new Font(replyfont, replyfontsize, replystyle);

            return reply;
        }
        #endregion

        #region Keyboard Handler
        private void rtb1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                ToolBarButton tbb = null;

                switch (e.KeyCode)
                {
                    case Keys.B:
                        tbb = this.tbbBold;
                        break;
                    case Keys.I:
                        tbb = this.tbbItalic;
                        break;
                    case Keys.S:
                        tbb = this.tbbStamp;
                        break;
                    case Keys.U:
                        tbb = this.tbbUnderline;
                        break;
                    case Keys.OemMinus:
                        tbb = this.tbbStrikeout;
                        break;
                }

                if (tbb != null)
                {
                    if (e.KeyCode != Keys.S) tbb.Pushed = !tbb.Pushed;
                    tb1_ButtonClick(null, new ToolBarButtonClickEventArgs(tbb));
                }
            }

            //Insert a tab if the tab key was pressed.
            /* NOTE: This was needed because in rtb1_KeyPress I tell the richtextbox not
             * to handle tab events.  I do that because CTRL+I inserts a tab for some
             * strange reason.  What was MicroSoft thinking?
             * Richard Parsons 02/08/2007
             */
            if (e.KeyCode == Keys.Tab)
                rtb1.SelectedText = "\t";

        }

        private void rtb1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 9)
                e.Handled = true; // Stops Ctrl+I from inserting a tab (char HT) into the richtextbox
        }
        #endregion

        public string GetText()
        {
            return this.rtb1.Text.Trim();
        }
        public object GetValue()
        {
            //throw new NotImplementedException();
            return this.rtb1.Rtf.Trim();
        }

        public void SetValue(object value)
        {
           //hrow new NotImplementedException();
            this.rtb1.Rtf = value.ToString();            
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
            this.rtb1.Rtf = "";
        }

        private void cmColors_Popup(object sender, EventArgs e)
        {
            //UpdateToolbar();
        }

        private void cmFontSizes_Popup(object sender, EventArgs e)
        {
            UpdateToolbar();
        }

        private void cmFonts_Popup(object sender, EventArgs e)
        {
            UpdateToolbar();
        }
    }
}
