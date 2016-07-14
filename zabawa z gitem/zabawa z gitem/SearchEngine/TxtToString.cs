using System;
using System.IO;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.SearchEngine
{
    public class TxtToString : FileToString
    {
        public override string GetFileText(TextFile file, string path)
        {
            string text="";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd().ToString();
                }
            }
            catch (Exception e)
            {
                //Nie mozna otowrzyc pliku do zrobienia
               
            }
            return text;
        }

    }
}