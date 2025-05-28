namespace Ax.SIS.SD.UI
{
    partial class ZSD02500_IRN_MANUAL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIRNACK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIRNDATE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEWB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "IRN NO :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(277, 31);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 263);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(542, 111);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 66);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(182, 85);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(277, 31);
            this.txtOld.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tally Invoice :";
            // 
            // txtIRNACK
            // 
            this.txtIRNACK.Location = new System.Drawing.Point(182, 134);
            this.txtIRNACK.Name = "txtIRNACK";
            this.txtIRNACK.Size = new System.Drawing.Size(485, 31);
            this.txtIRNACK.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "IRN ACK NO :";
            // 
            // txtIRNDATE
            // 
            this.txtIRNDATE.Location = new System.Drawing.Point(182, 171);
            this.txtIRNDATE.Name = "txtIRNDATE";
            this.txtIRNDATE.Size = new System.Drawing.Size(277, 31);
            this.txtIRNDATE.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "IRN DATE :";
            // 
            // txtEWB
            // 
            this.txtEWB.Location = new System.Drawing.Point(182, 208);
            this.txtEWB.Name = "txtEWB";
            this.txtEWB.Size = new System.Drawing.Size(277, 31);
            this.txtEWB.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "EWB NO :";
            // 
            // ZSD02500_IRN_MANUAL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(713, 499);
            this.Controls.Add(this.txtEWB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIRNDATE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIRNACK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ZSD02500_IRN_MANUAL";
            this.Text = "IRN Manual Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIRNACK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIRNDATE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEWB;
        private System.Windows.Forms.Label label6;
    }
}