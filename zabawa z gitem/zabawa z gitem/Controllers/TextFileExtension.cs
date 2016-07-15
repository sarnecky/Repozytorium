using System.Data.Entity;
using System.Linq;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.Controllers
{
    public static class TextFileExtension
    {
        public static TextFile FindTextFileWithId(this DbSet<TextFile> textFiles, int fileId)
        {
            return Enumerable.FirstOrDefault(textFiles, f => f.TextFileId == fileId);
        }
    }
}