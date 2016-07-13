using System.Collections.Generic;

namespace zabawa_z_gitem.Models
{
    public class SearchModel : GenericModel<List<SearchReslutModel>>
    {
        public int UserId { get; set; } 
        public string SerachString { get; set; }
    }
}