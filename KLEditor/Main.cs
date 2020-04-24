using KLEditor.Dialogs;
using KLEditor.enums;
using KLEditor.Interface;
using KLEditor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor
{
    public partial class Main : Form, IFindable, IReplaceable
    {
        public Main()
        {
            InitializeComponent();

            InitFont();
        }
        private IFileOperator file;
        private int currentIdx = 0;
        private bool isUpdate = false;
        public int Find(string word, RichTextBoxFinds option = default(RichTextBoxFinds), int start = -1)
        {
            if (start != -1)
            {
                currentIdx = start;
            }
            int idx = richTextBox.Find(word, currentIdx, option);
            
            currentIdx = idx + 1;
            return idx;
        }

        private void InitFont()
        {
            var fontnames =  FontFamily.Families.Select((f) =>
            {
                return f.Name;
            });

            fontNameComboBox.Items.Clear();
            fontNameComboBox.Items.AddRange(fontnames.ToArray());
            fontNameComboBox.SelectedItem = "Microsoft YaHei";
            for(int i=8; i<72; ++i)
            {
                fontSizeComboBox.Items.Add(i);
            }
            fontSizeComboBox.SelectedItem = 12;
            richTextBox.Font = new Font("Microsoft YaHei",12);
        }

        #region File
        private String TitleCase(String word)
        {
            if (String.IsNullOrEmpty(word))
            {
                return String.Empty;
            }

            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        private async void loadFileAsync(String location, SupportFormat format)
        {
           
            string handler = "KLEditor.Utils." + TitleCase(format.ToString()) + "Handler";

            Type type = Type.GetType(handler);

            var con = type.GetConstructor(new Type[] { typeof(String) });
            file = con.Invoke(new Object[] { location }) as IFileOperator;
            var stream = await file.GetInputStream();

            richTextBox.Invoke(new Action( () =>
            {
                using (stream)
                {
                    richTextBox.LoadFile(stream, file.RTBType);
                }
                
            }));

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "*.rtf";
            openFile.Filter = "txt files (*.txt)|*.txt|RTF Files|*.rtf|word document|*.doc;*.docx";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFile.FileName;
                Debug.WriteLine(openFile.FilterIndex);
                loadFileAsync(openFile.FileName,  (SupportFormat) openFile.FilterIndex);
            }
        }
        

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            if(file == null)
            {
                saveAsToolStripMenuItem1_Click(sender, e);
            }
            else
            {

                if(file is WordHandler)
                {
                    file.Save(richTextBox.Rtf);
                }
                else
                {
                    using(Stream stream = file.GetOutputStream()){

                        richTextBox.SaveFile(stream, file.RTBType);
                        stream.Flush();
                    }
                    
                }
                
            }
        }
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "txt files|*.txt|rtf files|*.rtf|doc files|*.docx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveName = saveFileDialog.FileName;
                if (saveFileDialog.FilterIndex == 1)
                {
                    richTextBox.SaveFile(saveName, RichTextBoxStreamType.PlainText);
                    //file = new TxtHandler(saveName);
                }
                else if (saveFileDialog.FilterIndex == 2)
                {
                    richTextBox.SaveFile(saveName, RichTextBoxStreamType.RichText);
                   // file = new RtfHandler(saveName);
                }
                else if(saveFileDialog.FilterIndex == 3)
                {
                    richTextBox.SaveAsWord(saveName);
                    //file = new WordHandler(saveName);
                }
            }
        }
       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (isUpdate)
            //{
            //    if(MessageBox.Show("是否保存文件") == DialogResult.OK)
            //    {
            //        richTextBox.SaveFile(file.Location, file.RTBType);
            //    }
            //}
            isUpdate = false;
            richTextBox.Clear();
            richTextBox.ClearUndo();
            file = null;
            this.Text = "New File";
        }
        #endregion


        #region edit
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox.CanUndo;
            redoToolStripMenuItem.Enabled = richTextBox.CanRedo;

            copyToolStripMenuItem.Enabled = richTextBox.SelectedText.Length > 0;
            cutToolStripMenuItem.Enabled = richTextBox.SelectedText.Length > 0;
            pasteToolStripMenuItem.Enabled = Clipboard.GetText(TextDataFormat.Rtf).Length > 0;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            this.isUpdate = true;
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FindDialog findDialog = new FindDialog(this);

            findDialog.Show();
        }
        #endregion
        private void toolbarToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Text;
            FieldInfo fieldInfo = this.GetType().GetField(name.ToLower() + "Strip", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                return;
            }
            ToolStrip toolStrip = fieldInfo.GetValue(this) as ToolStrip;
            ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            if (item.Checked)
            {
                toolStrip.Hide();
            }
            else
            {
                toolStrip.Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUpdate)
            {
                var result = MessageBox.Show("当前文档未保存 是否要保存", "warming", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        if(file != null)
                        {
                            using (Stream stream = file.GetOutputStream())
                            {

                                richTextBox.SaveFile(stream, file.RTBType);
                                stream.Flush();
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

       

        #region formatter
        private void UpdateJustfiyStatus(HorizontalAlignment alignment)
        {
            justfiLeftToolStrip.Checked = HorizontalAlignment.Left == alignment;
            justfiMiddleToolStrip.Checked = HorizontalAlignment.Center == alignment;
            justfiRightToolStrip.Checked = HorizontalAlignment.Right == alignment;
        }

        private void justfiLeftToolStrip_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
            UpdateJustfiyStatus(richTextBox.SelectionAlignment);
        }

        private void justfiMiddleToolStrip_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            UpdateJustfiyStatus(richTextBox.SelectionAlignment);
        }

        private void justfiRightToolStrip_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
            UpdateJustfiyStatus(richTextBox.SelectionAlignment);
        }
        
        private void colorChooseStrip_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = colorDialog.Color;
            }
        }

        #endregion

        #region font
        private Font GetRTBFont()
        {
            Font font = richTextBox.SelectionFont ?? richTextBox.Font;
            Debug.WriteLine(font);
            return font;
        }

        private void SetValue(object instance,string key,object value)
        {
            var info =  instance.GetType().GetProperty(key);

            if (info != null)
            {
                info.SetValue(instance, value);
            }
        }

        private void fontBolidtoolStrip_Click(object sender, EventArgs e)
        {
            Font current = GetRTBFont();
            if (fontBolidtoolStrip.Checked)
            {
                richTextBox.SelectionFont = new Font(current, current.Style | FontStyle.Bold);
            }
            else
            {
                richTextBox.SelectionFont = new Font(current, current.Style ^ FontStyle.Bold);
            }
        }

        private void fontItalictoolStrip_Click(object sender, EventArgs e)
        {
            Font current = GetRTBFont();
            if (fontItalictoolStrip.Checked)
            {
                richTextBox.SelectionFont = new Font(current, current.Style | FontStyle.Italic);
            }
            else
            {
                richTextBox.SelectionFont = new Font(current, current.Style ^ FontStyle.Italic);
            }
        }

        private void fontUdToolStrip_Click(object sender, EventArgs e)
        {
            Font current = GetRTBFont();
            if (fontUdToolStrip.Checked)
            {
                richTextBox.SelectionFont = new Font(current, current.Style | FontStyle.Underline);
            }
            else
            {
                richTextBox.SelectionFont = new Font(current, current.Style ^ FontStyle.Underline);
            }
        }
        private void fontNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font current = GetRTBFont();
            richTextBox.SelectionFont = new Font(fontNameComboBox.SelectedItem.ToString(), current.Size,current.Style);
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font current = GetRTBFont();
            richTextBox.SelectionFont = new Font(current.FontFamily, float.Parse(fontSizeComboBox.SelectedItem.ToString()), current.Style);
        }

        private void formatToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            boldToolStripMenuItem.Checked = (richTextBox.SelectionFont.Style & FontStyle.Bold) > 0;
            italicToolStripMenuItem.Checked = (richTextBox.SelectionFont.Style & FontStyle.Italic) > 0;
            underLineToolStripMenuItem.Checked = (richTextBox.SelectionFont.Style & FontStyle.Underline) > 0;
        }

        #endregion

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            lock (richTextBox)
            {
                // 跟新字体样式

                fontBolidtoolStrip.Checked = (richTextBox?.SelectionFont?.Style & FontStyle.Bold) > 0;
                fontItalictoolStrip.Checked = (richTextBox?.SelectionFont?.Style & FontStyle.Italic) > 0;
                fontUdToolStrip.Checked = (richTextBox?.SelectionFont?.Style & FontStyle.Underline) > 0;

                //更新字体信息
                
                //var cfont = richTextBox.SelectionFont;
                var cfont = GetRTBFont();
                if (cfont != null)
                {
                    fontSizeComboBox.SelectedIndexChanged -= fontSizeComboBox_SelectedIndexChanged;
                    fontNameComboBox.SelectedIndexChanged -= fontNameComboBox_SelectedIndexChanged ;
                    fontNameComboBox.SelectedItem = cfont.FontFamily.Name;
                    fontSizeComboBox.SelectedItem = cfont.Size;

                    fontSizeComboBox.SelectedIndexChanged += fontSizeComboBox_SelectedIndexChanged;
                    fontNameComboBox.SelectedIndexChanged += fontNameComboBox_SelectedIndexChanged;
                }
                

                // 跟新文档对其格式

                var align = richTextBox.SelectionAlignment;
                UpdateJustfiyStatus(align);
            }
           
        }

        public bool ReplaceOne(string pattern, string replacemet, RegexOptions optons)
        {
            Regex regex = new Regex(pattern, optons);


            if (regex.Match(this.richTextBox.Text).Success)
            {
                this.richTextBox.Rtf = regex.Replace(this.richTextBox.Rtf, replacemet, 1);
            }
            else
            {
                return false;
            }

            return true;
        }

        public int ReplaceAll(string pattern, string replacemet, RegexOptions optons)
        {
            Regex regex = new Regex(pattern, optons);
            int cnt = 0;
            var match = regex.Match(richTextBox.Rtf);
            //regex.Matches(richTextBox.Rtf).Count
            while (match != null && match.Success)
            {
                cnt++;
                match = match.NextMatch();
            }
            this.richTextBox.Rtf = regex.Replace(this.richTextBox.Rtf, replacemet);

            return cnt;
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceDialog replaceDialog = new ReplaceDialog(this);

            replaceDialog.Show();
        }
    }
}
