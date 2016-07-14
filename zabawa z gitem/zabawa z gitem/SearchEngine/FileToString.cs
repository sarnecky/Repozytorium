using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.SearchEngine
{
    public abstract class FileToString
    {
        public abstract string GetFileText(TextFile file, string path); //przetwarza plik tekstowy na string
    }
}