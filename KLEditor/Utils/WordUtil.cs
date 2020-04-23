using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Utils
{
    public static class WordUtil
    {
        public static void SaveAsWord(this RichTextBox rich ,string fileName)
        {
            string content = rich.Rtf;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] dataBytes = encoding.GetBytes(content);
            MemoryStream stream = new MemoryStream(dataBytes);

            LoadOptions loadOptions = new LoadOptions();
            loadOptions.LoadFormat = LoadFormat.Rtf;
            Document doc = new Document(stream, loadOptions);

            Stream outstream = File.OpenWrite(fileName);
            doc.Save(outstream, SaveFormat.Docx);
            stream.Close();
            outstream.Close();
        }
    }
}
