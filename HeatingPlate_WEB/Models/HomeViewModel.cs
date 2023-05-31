using HeatingPlate_WEB.Data;

namespace HeatingPlate_WEB.Models
{
    public class HomeViewModel
    {
        public metals? Metal { get; set; }
        public List<metals> MetalsList { get; set; }
        
        public coefficients? coefficient { get; set; }
        public List<coefficients> coefficientsList { get; set;}

    }
}
