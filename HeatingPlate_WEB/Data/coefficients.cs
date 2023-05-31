using System.ComponentModel.DataAnnotations;

namespace HeatingPlate_WEB.Data
{
    public class coefficients
    {
        [Key]
        public int coefficient_id { get; set; }
	    public float bi { get; set; }
        public float thickness { get; set; }
        public float number_p {get; set; }
        public float number_m { get; set; }
        public float number_n {get; set; }

    }
}
