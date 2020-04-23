using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Interface
{
    public interface IFindable
    {
        int Find(string word, RichTextBoxFinds option = default(RichTextBoxFinds), int start = -1);
    }
}
