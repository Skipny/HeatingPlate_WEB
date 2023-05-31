using HeatingPlate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using HeatingLibrary;
using System.Diagnostics;
using HeatingPlate_WEB.Data;
using Microsoft.EntityFrameworkCore;


namespace HeatingPlate_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }
        [HttpPost]
        public IActionResult Result( HeatingInput input )
        {
            var temp = new TemporaryVariables();
            var viewModel = new HomeViewModel();
            viewModel.coefficientsList = _context.coefficients.ToList();
            input.a =(input.lambda*3600)/(input.c*input.p*1000);
            if(input.Select1==2) 
            { 
                input.l=input.l/2;
            }
            float Bi = (input.alpha * input.l) / (input.lambda);
            foreach (var y in viewModel.coefficientsList)
            {
                if (y.bi < Bi)
                {
                    temp.bi_min = y.bi;
                    temp.thickness_min = y.thickness;
                    temp.n_min = y.number_n;
                    temp.m_min = y.number_m;
                    temp.p_min = y.number_p;
                }
                else if (y.bi>Bi) {
                    temp.bi_max = y.bi;
                    temp.thickness_max = y.thickness;
                    temp.n_max = y.number_n;
                    temp.m_max = y.number_m;
                    temp.p_max = y.number_p;
                    break;
                }
            }
            input.thickness= temp.thickness_min - (temp.thickness_min - temp.thickness_max) * ((Bi - temp.bi_min) / (temp.bi_max - temp.bi_min));
            input.n = temp.n_min - (temp.n_min - temp.n_max) * ((Bi - temp.bi_min) / (temp.bi_max - temp.bi_min));
            input.m = temp.m_min - (temp.m_min - temp.m_max) * ((Bi - temp.bi_min) / (temp.bi_max - temp.bi_min));
            input.p_c = temp.p_min - (temp.p_min - temp.p_max) * ((Bi - temp.bi_min) / (temp.bi_max - temp.bi_min));
            input.Bi = Bi;

            var lib = new Plate(input);
            var result = lib.Calc();
            return View(result);
        }
        

        [HttpGet]
        public IActionResult Index(int? Id)
        {
            var viewModel = new HomeViewModel();
            if(Id != null)
            {
                viewModel.Metal = _context.metals.FirstOrDefault(x => x.metal_id == Id);
            }
            viewModel.MetalsList = _context.metals.ToList();
            viewModel.coefficientsList = _context.coefficients.ToList();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}