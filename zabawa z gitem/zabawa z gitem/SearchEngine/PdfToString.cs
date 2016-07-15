using System.IO;
using System.Text;
using zabawa_z_gitem.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace zabawa_z_gitem.SearchEngine
{
    public class PdfToString : FileToString
    {
        public override string GetFileText(TextFile file, string path)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            return text.ToString();
        }
    }
}