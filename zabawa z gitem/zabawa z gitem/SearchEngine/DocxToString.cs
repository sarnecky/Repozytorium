using System.IO;
using System.IO.Compression;
using Ionic.Zip;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.SearchEngine
{
    public class DocxToString : FileToString
    {
        public override string GetFileText(TextFile file, string path)
        {
            MemoryStream stream = new MemoryStream();
            using (ZipFile zip = ZipFile.Read(path))
            {
                ZipEntry a = zip[@"word\document.xml"];
                a.Extract(stream);
            }

            stream.Position = 0;
            var sr = new StreamReader(stream);
            var myStr = sr.ReadToEnd();

            return myStr;
        }
    }
}