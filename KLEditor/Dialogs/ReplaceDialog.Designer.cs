namespace KLEditor.Dialogs
{
    partial class ReplaceDialog
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
            this.patternTxt = new System.Windows.Forms.TextBox();
            this.caseCheck = new System.Windows.Forms.CheckBox();
            this.whiteSpaceCheck = new System.Windows.Forms.CheckBox();
            this.repOne = new System.Windows.Forms.Button();
            this.repAll = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.replaceTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patternTxt
            // 
            this.patternTxt.Location = new System.Drawing.Point(65, 25);
            this.patternTxt.Name = "patternTxt";
            this.patternTxt.Size = new System.Drawing.Size(215, 22);
            this.patternTxt.TabIndex = 0;
            // 
            // caseCheck
            // 
            this.caseCheck.AutoSize = true;
            this.caseCheck.Location = new System.Drawing.Point(37, 107);
            this.caseCheck.Name = "caseCheck";
            this.caseCheck.Size = new System.Drawing.Size(104, 21);
            this.caseCheck.TabIndex = 1;
            this.caseCheck.Text = "Match Case";
            this.caseCheck.UseVisualStyleBackColor = true;
            // 
            // whiteSpaceCheck
            // 
            this.whiteSpaceCheck.AutoSize = true;
            this.whiteSpaceCheck.Location = new System.Drawing.Point(147, 107);
            this.whiteSpaceCheck.Name = "whiteSpaceCheck";
            this.whiteSpaceCheck.Size = new System.Drawing.Size(110, 21);
            this.whiteSpaceCheck.TabIndex = 2;
            this.whiteSpaceCheck.Text = "White Space";
            this.whiteSpaceCheck.UseVisualStyleBackColor = true;
            // 
            // repOne
            // 
            this.repOne.Location = new System.Drawing.Point(37, 158);
            this.repOne.Name = "repOne";
            this.repOne.Size = new System.Drawing.Size(104, 31);
            this.repOne.TabIndex = 3;
            this.repOne.Text = "replaceOne";
            this.repOne.UseVisualStyleBackColor = true;
            this.repOne.Click += new System.EventHandler(this.repOne_Click);
            // 
            // repAll
            // 
            this.repAll.Location = new System.Drawing.Point(176, 158);
            this.repAll.Name = "repAll";
            this.repAll.Size = new System.Drawing.Size(97, 31);
            this.repAll.TabIndex = 4;
            this.repAll.Text = "replaceAll";
            this.repAll.UseVisualStyleBackColor = true;
            this.repAll.Click += new System.EventHandler(this.repAll_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(291, 96);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 32);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "cancel";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // replaceTxt
            // 
            this.replaceTxt.Location = new System.Drawing.Point(65, 67);
            this.replaceTxt.Name = "replaceTxt";
            this.replaceTxt.Size = new System.Drawing.Size(218, 22);
            this.replaceTxt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "pattern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "replace";
            // 
            // ReplaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceTxt);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.repAll);
            this.Controls.Add(this.repOne);
            this.Controls.Add(this.whiteSpaceCheck);
            this.Controls.Add(this.caseCheck);
            this.Controls.Add(this.patternTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceDialog";
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patternTxt;
        private System.Windows.Forms.CheckBox caseCheck;
        private System.Windows.Forms.CheckBox whiteSpaceCheck;
        private System.Windows.Forms.Button repOne;
        private System.Windows.Forms.Button repAll;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.TextBox replaceTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}