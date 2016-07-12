using System;
using System.ComponentModel.DataAnnotations;

namespace zabawa_z_gitem.Models
{
    public class TextFile
    {
        public int TextFileId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDateTime { get; set; }
        public int Size { get; set; }
        public virtual Type Type { get; set; }
    }
}