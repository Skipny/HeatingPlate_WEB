namespace HeatingLibrary
{
    public class Plate
    {
        public float l { get; set; } // длина пластины
        public float beg_temp { get; set; }//начальная темп пластины
        public float temp_bake { get; set; } //температура в печи  
        public float temp { get; set; } //конец нагрева
        public float time_tonk { get; set; } //время нагрева (сек)
        public float time_mass { get; set; }
        public float alpha { get; set; }//коэффициент температуропроводности
        public float lambda { get; set; } //коэфф. теплоотдачи
        public int p { get; set; } //плотность метала
        public float c { get; set; } //теплоемкость
        public float a { get; set; } //коэффициент температуропроводности
        public float Bi { get; set; }
        public float n { get; set; }
        public float m { get; set; }
        public float p_c { get; set; }
        public float thickness { get; set; }
        public float F { get; set; }
        public float massa{ get; set; }

        public Plate(HeatingInput input)
        {
            l = input.l;
            beg_temp = input.beg_temp;
            temp_bake = input.temp_bake;
            temp = input.temp;
            time_tonk = input.time_tonk;
            time_mass = input.time_mass;
            alpha = input.alpha;
            lambda = input.lambda;
            p = input.p;
            c = input.c;
            a = input.a;
            Bi = input.Bi;
            n = input.n;
            m = input.m;
            p_c = input.p_c;
            thickness = input.thickness;
            massa= input.massa;
            F = input.F;

        }

        public HeatingOutput Calc()
        {
            if (massa > 0)
            {
                double temp_cr = beg_temp - (beg_temp - temp_bake) * Math.Exp(-(F * alpha * time_tonk) / (massa * c*1000));
                return new HeatingOutput
                {
                    l = l,
                    beg_temp = beg_temp,
                    temp_bake = temp_bake,
                    bi = Bi,
                    time = time_tonk,
                    temp_cr = temp_cr,
                    F = F,
                    c = c,
                    p = p,
                    massa = massa,
                    alpha = alpha,
                    lambda = lambda,
                    temp = temp

                };
            }
            else
            {
                double Fo = 0;
                double[] arr = new double[20];
                if (time_mass == 0)
                {
                    Fo = Math.Log(Math.Round((temp - temp_bake) / (beg_temp - temp_bake), 3)) / (-Math.Round(thickness, 3));
                    
                }
                else
                {
                    Fo = (a * 0.000001 * time_mass) / (l * l);
                }
                double time = (Fo * l * l * 3600) / (a);
                double O_cr = n * Math.Exp(-thickness * Fo);
                double O_Pow = p_c * Math.Exp(-thickness * Fo);
                double O_mas = m * Math.Exp(-thickness * Fo);
                double temp_cr = (1 - O_cr) * temp_bake;
                double temp_v_pov = (1 - O_Pow) * temp_bake;
                double temp_n_pov = 2 * temp_cr - temp_v_pov;
                return new HeatingOutput
                {
                    
                    l = l,
                    beg_temp = beg_temp,
                    temp_bake = temp_bake,
                    temp = temp,
                    time = time,
                    alpha = alpha,
                    lambda = lambda,
                    massa = massa,
                    F = F,
                    c= c,
                    p = p,
                    bi = Bi,
                    O_cr = O_cr,
                    O_pow = O_Pow,
                    O_mas = O_mas,
                    temp_cr = temp_cr,
                    temp_v_pow = temp_v_pov,
                    temp_n_pow = temp_n_pov,
                };
            }
            
        }
    }
}