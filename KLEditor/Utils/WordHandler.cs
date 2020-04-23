using Aspose.Words;
using KLEditor.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLEditor.Utils
{
    public class WordHandler : IFileOperator
    {
        public WordHandler(string location)
        {
            Location = location;
        }

        public string Location { get; private set; }

        public RichTextBoxStreamType RTBType
        {
            get
            {
                return RichTextBoxStreamType.RichText;
            }
        }


        public Task<Stream> GetInputStream()
        {
            return Task.Run<Stream>(() =>
            {
                Document document = new Document(Location);
                MemoryStream memory = new MemoryStream();
                document.Save(memory, SaveFormat.Rtf);
                memory.Position = 0;
                return memory;
            });
        }

        public Stream GetOutputStream()
        {
            FileStream fs = new FileStream(Location, FileMode.OpenOrCreate, FileAccess.Write);

            return fs;
        }

        public void Save(string content, string location = null)
        {
            
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] dataBytes = encoding.GetBytes(content);
               
            using(MemoryStream stream = new MemoryStream(dataBytes))
            {
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.LoadFormat = LoadFormat.Rtf;
                Document doc = new Document(stream, loadOptions);
                using (Stream outstream = GetOutputStream())
                {
                    doc.Save(outstream, SaveFormat.Docx);
                }
            }
            
        }
    }
}
