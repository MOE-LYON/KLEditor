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
    public class RtfHandler:IFileOperator
    {
        public RtfHandler(string location)
        {
            Location = location;
        }

        public RichTextBoxStreamType RTBType
        {
            get
            {
                return RichTextBoxStreamType.RichText;
            }
        }

        public string Location { get; private set; }

        public static RtfHandler GenNewRtf()
        {
            String fileName = Guid.NewGuid().ToString() + ".rtf";

            return new RtfHandler(fileName);
        }

        public Task<Stream> GetInputStream()
        {
            if (!File.Exists(Location))
            {
                return Task.FromResult(Stream.Null);
            }
            else
            {
                return Task.FromResult<Stream>(File.OpenRead(Location));
            }
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
