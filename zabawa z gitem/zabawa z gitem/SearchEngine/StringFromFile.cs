using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.SearchEngine
{
    public class StringFromFile
    {
        protected FileToString Handle;

        public StringFromFile(FileToString handle)
        {
            Handle = handle;
        }

        public string GetStringFormFile(TextFile file, string path)
        {
            return Handle.GetFileText(file, path);
        }
    }
}