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
    public class TxtHandler : IFileOperator
    {
        public string Location { get; private set; }

        public TxtHandler(string location)
        {
            Location = location;
        }

        public RichTextBoxStreamType RTBType
        {
            get
            {
                return RichTextBoxStreamType.PlainText;
            }
        }

        public Task<Stream> GetInputStream()
        {
            Stream stream = new FileStream(Location, FileMode.Open, FileAccess.Read);

            return Task.FromResult(stream);
        }

        public Stream GetOutputStream()
        {
            FileStream fs = new FileStream(Location, FileMode.OpenOrCreate, FileAccess.Write);

            return fs;
        }

        public void Save(string content, string location = null)
        {
            throw new NotImplementedException();
        }
    }
}
