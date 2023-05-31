using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatingLibrary
{
    public class HeatingOutput
    {
        public float l { get; set; } // длина пластины
        public float beg_temp { get; set; }//начальная темп пластины
        public float temp_bake { get; set; } //температура в печи  
        public float temp { get; set; } //конец нагрева
        public double time { get; set; }
        
        public float alpha { get; set; }//коэффициент температуропроводности
        public float lambda { get; set; } //коэфф. теплоотдачи
        public int p { get; set; } //плотность метала
        public float c { get; set; } //теплоемкость
        public float a { get; set; } //коэффициент теплоотдачи
        public float Bi { get; set; }
        public float n { get; set; }
        public float m { get; set; }
        public float p_c { get; set; }
        public float thickness { get; set; }
        public float F { get; set; }
        public float massa { get; set; }//
        public double bi { get; set; }
        public double O_cr { get; set; }
        public double O_pow { get; set; }
        public double O_mas { get; set; }
        public double temp_cr { get; set; }
        public double temp_v_pow { get; set; }
        public double temp_n_pow { get; set; }
    }
}
