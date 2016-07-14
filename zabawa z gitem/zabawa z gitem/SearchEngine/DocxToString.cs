using System.IO;
using System.IO.Compression;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.SearchEngine
{
    public class DocxToString : FileToString
    {
        public override string GetFileText(TextFile file, string path)
        {
            var ms = new MemoryStream();
            using()
        }
    }
}