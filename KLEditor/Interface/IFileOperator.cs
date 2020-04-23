using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Interface
{
    public interface IFileOperator
    {
        RichTextBoxStreamType RTBType { get; }
        Task<Stream> GetInputStream();

        void Save(String content,string location =null);

        String Location { get; }

        Stream GetOutputStream();
    }
}
