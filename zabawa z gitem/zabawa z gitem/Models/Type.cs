using System.Collections;
using System.Collections.Generic;

namespace zabawa_z_gitem.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string IconFileName { get; set; }
        public virtual ICollection<TextFile> Files { get; set; }
    }
}