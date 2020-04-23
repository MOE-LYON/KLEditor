using KLEditor.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Dialogs
{
    public partial class FindDialog : Form
    {
        public FindDialog(IFindable findable)
        {
            this.findform = findable;
            InitializeComponent();
        }

        private IFindable findform;

        private void findNext_Click(object sender, EventArgs e)
        {
            String content = keyword.Text;

            RichTextBoxFinds finds = RichTextBoxFinds.None;
            if (this.caseCheck.Checked)
            {
                finds |= RichTextBoxFinds.MatchCase;
            }
            if (this.wholeWordCheck.Checked)
            {
                finds |= RichTextBoxFinds.WholeWord;
            }
            int res = findform.Find(content,finds);

            if (res == -1)
            {
                MessageBox.Show("no word can be found","warming",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
