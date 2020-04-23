using KLEditor.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Dialogs
{
    public partial class ReplaceDialog : Form
    {
        private IReplaceable replaceable;
        public ReplaceDialog(IReplaceable replaceable)
        {
            this.replaceable = replaceable;
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private RegexOptions GetRegexOptions()
        {
            RegexOptions regexOptions = RegexOptions.Multiline;
            if (!caseCheck.Checked)
            {
                regexOptions |= RegexOptions.IgnoreCase;
            }
            if (!whiteSpaceCheck.Checked)
            {
                regexOptions |= RegexOptions.IgnorePatternWhitespace;
            }
            return regexOptions;
        }

        private void repOne_Click(object sender, EventArgs e)
        {
            var option = GetRegexOptions();
            string pa = patternTxt.Text;
            string replace = replaceTxt.Text;
            bool res = replaceable.ReplaceOne(pa,replace,option);
            if (!res)
            {
                MessageBox.Show("替换失败");
            }
        }

        private void repAll_Click(object sender, EventArgs e)
        {

            var option = GetRegexOptions();
            string pa = patternTxt.Text;
            string replace = replaceTxt.Text;
            var res = replaceable.ReplaceAll(pa, replace, option);

            MessageBox.Show($"已成功替换 {res} 个");
        }
    }
}
