using System.ComponentModel.DataAnnotations;

namespace HeatingPlate_WEB.Data
{
    public class metals
    {
        [Key]
        public int metal_id { get; set; }
	    public string metal_name { get; set; }
        public int temperature { get; set; }
        public int density { get; set; }
	    public float lambda { get; set; }
	    public float heat_capacity {get; set; }
	    public float forward_movement { get; set; }
    }
}
