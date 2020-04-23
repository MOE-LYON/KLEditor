namespace KLEditor.Dialogs
{
    partial class FindDialog
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
            this.keyword = new System.Windows.Forms.TextBox();
            this.caseCheck = new System.Windows.Forms.CheckBox();
            this.wholeWordCheck = new System.Windows.Forms.CheckBox();
            this.findNext = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyword
            // 
            this.keyword.Location = new System.Drawing.Point(50, 26);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(251, 22);
            this.keyword.TabIndex = 0;
            // 
            // caseCheck
            // 
            this.caseCheck.AutoSize = true;
            this.caseCheck.Location = new System.Drawing.Point(50, 72);
            this.caseCheck.Name = "caseCheck";
            this.caseCheck.Size = new System.Drawing.Size(104, 21);
            this.caseCheck.TabIndex = 1;
            this.caseCheck.Text = "Match Case";
            this.caseCheck.UseVisualStyleBackColor = true;
            // 
            // wholeWordCheck
            // 
            this.wholeWordCheck.AutoSize = true;
            this.wholeWordCheck.Location = new System.Drawing.Point(160, 72);
            this.wholeWordCheck.Name = "wholeWordCheck";
            this.wholeWordCheck.Size = new System.Drawing.Size(150, 21);
            this.wholeWordCheck.TabIndex = 2;
            this.wholeWordCheck.Text = "Match Whole Word";
            this.wholeWordCheck.UseVisualStyleBackColor = true;
            // 
            // findNext
            // 
            this.findNext.Location = new System.Drawing.Point(330, 19);
            this.findNext.Name = "findNext";
            this.findNext.Size = new System.Drawing.Size(94, 36);
            this.findNext.TabIndex = 3;
            this.findNext.Text = "Find Next";
            this.findNext.UseVisualStyleBackColor = true;
            this.findNext.Click += new System.EventHandler(this.findNext_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(330, 64);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(94, 35);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // FindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 134);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.findNext);
            this.Controls.Add(this.wholeWordCheck);
            this.Controls.Add(this.caseCheck);
            this.Controls.Add(this.keyword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialog";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyword;
        private System.Windows.Forms.CheckBox caseCheck;
        private System.Windows.Forms.CheckBox wholeWordCheck;
        private System.Windows.Forms.Button findNext;
        private System.Windows.Forms.Button cancel;
    }
}