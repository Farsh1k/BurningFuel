using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorenieDLL
{
    [Serializable]
    public class GorenieLibrary
    {
        #region -- исходные данные

        #region -- газообразное
        /// <summary>
        /// Содержание CO2 в топливе, %
        /// </summary> 
        private double _CO2;    // закрытая переменная класса 
        public double CO2
        {
            get { return _CO2; }
            set { _CO2 = value; }
        }
        
        /// <summary>
        /// Содержание CO в топливе, %
        /// </summary> 
        private double _CO;    // закрытая переменная класса 
        public double CO
        {
            get { return _CO; }
            set { _CO = value; }
        }

         /// <summary>
        /// Содержание H2 в топливе, %
        /// </summary> 
        private double _H2;    // закрытая переменная класса 
        public double H2
        {
            get { return _H2; }
            set { _H2 = value; }
        }

        /// <summary>
        /// Содержание CH4 в топливе, %
        /// </summary> 
        private double _CH4;    // закрытая переменная класса 
        public double CH4
        {
            get { return _CH4; }
            set { _CH4 = value; }
        }

        /// <summary>
        /// Содержание C2H6 в топливе, %
        /// </summary> 
        private double _C2H6;    // закрытая переменная класса 
        public double C2H6
        {
            get { return _C2H6; }
            set { _C2H6 = value; }
        }

        /// <summary>
        /// Содержание C3H8 в топливе, %
        /// </summary> 
        private double _C3H8;    // закрытая переменная класса 
        public double C3H8
        {
            get { return _C3H8; }
            set { _C3H8 = value; }
        }

        /// <summary>
        /// Содержание C4H10 в топливе, %
        /// </summary> 
        private double _C4H10;    // закрытая переменная класса 
        public double C4H10
        {
            get { return _C4H10; }
            set { _C4H10 = value; }
        }

        /// <summary>
        /// Содержание C5H12 в топливе, %
        /// </summary> 
        private double _C5H12;    // закрытая переменная класса 
        public double C5H12
        {
            get { return _C5H12; }
            set { _C5H12 = value; }
        }

        /// <summary>
        /// Содержание H2S в топливе, %
        /// </summary> 
        private double _H2S;    // закрытая переменная класса 
        public double H2S
        {
            get { return _H2S; }
            set { _H2S = value; }
        }

        /// <summary>
        /// Содержание N2 в топливе, %
        /// </summary> 
        private double _N2;    // закрытая переменная класса 
        public double N2
        {
            get { return _N2; }
            set { _N2 = value; }
        }

        /// <summary>
        /// Содержание H2O в топливе, %
        /// </summary> 
        private double _H2O;    // закрытая переменная класса 
        public double H2O
        {
            get { return _H2O; }
            set { _H2O = value; }
        }

        /// <summary>
        /// Проверка процентной суммы всех компонентов
        /// </summary> 
        private double _summaG;    // закрытая переменная класса
        public double summaG
        {
            get { return _summaG; }
            set { _summaG = value; }
        }

        /// <summary>
        /// Влагосодержание воздуха, г/м3 сухого воздуха
        /// </summary> 
        private double _gG;    // закрытая переменная класса 
        public double gG
        {
            get { return _gG; }
            set { _gG = value; }
        }

        /// <summary>
        /// Температура подогрева газообразного топлива перед горением, °С
        /// </summary> 
        private double _t_gG;    // закрытая переменная класса 
        public double t_gG
        {
            get { return _t_gG; }
            set { _t_gG = value; }
        }

        /// <summary>
        /// Температура подогрева воздуха перед горением, °С
        /// </summary> 
        private double _t_vG;    // закрытая переменная класса 
        public double t_vG
        {
            get { return _t_vG; }
            set { _t_vG = value; }
        }

        /// <summary>
        /// Коэффициент расхода воздуха на горение
        /// </summary> 
        private double _alfaG;    // закрытая переменная класса 
        public double alfaG
        {
            get { return _alfaG; }
            set { _alfaG = value; }
        }
        #endregion -- газообразное

        #region -- твердое

        /// <summary>
        /// Содержание углерода в топливе, %
        /// </summary> 
        private double _C;    // закрытая переменная класса 
        public double C
        {
            get { return _C; }
            set { _C = value; }
        }

        /// <summary>
        /// Содержание водорода в топливе, %
        /// </summary> 
        private double _H;    // закрытая переменная класса 
        public double H
        {
            get { return _H; }
            set { _H = value; }
        }

        /// <summary>
        /// Содержание серы в топливе, %
        /// </summary> 
        private double _S;    // закрытая переменная класса 
        public double S
        {
            get { return _S; }
            set { _S = value; }
        }

        /// <summary>
        /// Содержание азота в топливе, %
        /// </summary> 
        private double _N;    // закрытая переменная класса 
        public double N
        {
            get { return _N; }
            set { _N = value; }
        }

        /// <summary>
        /// Содержание кислорода в топливе, %
        /// </summary> 
        private double _O;    // закрытая переменная класса 
        public double O
        {
            get { return _O; }
            set { _O = value; }
        }

        /// <summary>
        /// Содержание влаги в топливе, масс. %
        /// </summary> 
        private double _Wр;    // закрытая переменная класса 
        public double Wр
        {
            get { return _Wр; }
            set { _Wр = value; }
        }

        /// <summary>
        /// Содержание золы в топливе, масс. %
        /// </summary> 
        private double _Aр;    // закрытая переменная класса 
        public double Aр
        {
            get { return _Aр; }
            set { _Aр = value; }
        }

        /// <summary>
        /// Проверка процентной суммы всех компонентов
        /// </summary> 
        private double _summaT;    // закрытая переменная класса 
        public double summaT
        {
            get { return _summaT; }
            set { _summaT = value; }
        }

        /// <summary>
        /// Температура подогрева воздуха перед горением, °С
        /// </summary> 
        private double _t_vT;    // закрытая переменная класса 
        public double t_vT
        {
            get { return _t_vT; }
            set { _t_vT = value; }
        }

        /// <summary>
        /// Температура подогрева топлива перед горением (вводить только для мазута !), °С
        /// </summary> 
        private double _t_tT;    // закрытая переменная класса 
        public double t_tT
        {
            get { return _t_tT; }
            set { _t_tT = value; }
        }

        /// <summary>
        /// Коэффициент расхода воздуха на горение
        /// </summary> 
        private double _alfaT;    // закрытая переменная класса 
        public double alfaT
        {
            get { return _alfaT; }
            set { _alfaT = value; }
        }

        /// <summary>
        /// Механический недожог топлива, % к теплоте сгорания топлива
        /// </summary> 
        private double _M_nedojog;    // закрытая переменная класса 
        public double M_nedojog
        {
            get { return _M_nedojog; }
            set { _M_nedojog = value; }
        }

        /// <summary>
        /// Влагосодержание воздуха, г/м3 сухого воздуха
        /// </summary> 
        private double _gT;    // закрытая переменная класса 
        public double gT
        {
            get { return _gT; }
            set { _gT = value; }
        }

        #endregion -- твердое

        #endregion -- исходные данные


        #region -- расчетные параметры

        #region -- газ

        #region -- Расчет количества окислителя на горение, м3/м3

        /// <summary>
        /// Теоретический расход окислителя на горение, м3/м3
        /// </summary> 
        private double _Lo;    // закрытая переменная класса 
        public double get_Lo()
        {
            return _Lo = (0.01/0.21)*(0.5*_CO+0.5*_H2+1.5*_H2S+2*_CH4+3.5*_C2H6+5*_C3H8+6.5*_C4H10+8*_C5H12);
        }

        /// <summary>
        /// Действительный расход окислителя на горение, м3/м3
        /// </summary> 
        private double _L_alfa;    // закрытая переменная класса 
        public double get_L_alfa()
        {
            return _L_alfa = get_Lo() * _alfaG;
        }

        #endregion -- Расчет количества окислителя на горение, м3/м3

        #region -- Расчет количества продуктов горения, м3/м3 (газообразное)

        /// <summary>
        /// Количество CO2 в продуктах горения, м3/м3 топлива
        /// </summary> 
        private double _Vo_CO2_G;    // закрытая переменная класса 
        public double get_Vo_CO2_G()
        {
            return _Vo_CO2_G = 0.01*(_CO2+_CO+_CH4+2.0*_C2H6+3.0*_C3H8+4.0*_C4H10+5.0*_C5H12)- get_Vo_CO_G();
        }

        /// <summary>
        /// Количество SO2 в продуктах горения, м3/м3 топлива
        /// </summary> 
        private double _Vo_SO2_G;    // закрытая переменная класса 
        public double get_Vo_SO2_G()
        {
            return _Vo_SO2_G = 0.01*_H2S;
        }

        /// <summary>
        /// Количество H2O в продуктах горения, м3/м3 топлива
        /// </summary> 
        private double _Vo_H2O_G;    // закрытая переменная класса 
        public double get_Vo_H2O_G()
        {
            return _Vo_H2O_G = 0.01*(_H2O+_H2+_H2S+2 * _CH4+3 * _C2H6+4 * _C3H8+5 * _C4H10+6 * _C5H12)-get_Vo_H2_G();
        }

        /// <summary>
        /// Количество N2 в продуктах горения, м3/м3 топлива
        /// </summary> 
        private double _Vo_N2_G;    // закрытая переменная класса 
        public double get_Vo_N2_G()
        {
            return _Vo_N2_G = 0.01 * _N2 + 0.79 * get_Lo();
        }

        /// <summary>
        /// Количество CO в продуктах горения (диссоциация CO2), м3/м3 топлива
        /// </summary> 
        private double _Vo_CO_G;    // закрытая переменная класса 
        public double get_Vo_CO_G()
        {
            return _Vo_CO_G = Math.Pow(Math.Pow(2,0.5)*(Math.Exp((-58090.0+17.628*get_temp_ter_G())/(1.987*get_temp_ter_G()))),2.0/3.0);
        }

        /// <summary>
        /// Количество H2 в продуктах горения (диссоциация H2O), м3/м3 топлива
        /// </summary> 
        private double _Vo_H2_G;    // закрытая переменная класса 
        public double get_Vo_H2_G()
        {
            return _Vo_H2_G = Math.Pow(Math.Pow(2,0.5)*Math.Exp((-52300+12.081*get_temp_ter_G())/(1.987*get_temp_ter_G())), 2.0 / 3.0);
        }

        /// <summary>
        /// Количество O2 в продуктах горения (диссоциация CO2 и H2O), м3/м3 топлива
        /// </summary> 
        private double _Vo_O2_G;    // закрытая переменная класса 
        public double get_Vo_O2_G()
        {
            return _Vo_O2_G = 0.5*get_Vo_CO_G()+0.5*get_Vo_H2_G();
        }

        /// <summary>
        /// Теоретический объем продуктов горения, м3/м3 топлива
        /// </summary> 
        private double _Vo_G;    // закрытая переменная класса 
        public double get_Vo_G()
        {
            return _Vo_G = get_Vo_CO2_G()+get_Vo_SO2_G()+get_Vo_H2O_G()+get_Vo_N2_G()+get_Vo_CO_G()+get_Vo_H2_G()+get_Vo_O2_G();
        }

        /// <summary>
        /// Практический выход N2 при избытке окислителя, м3/м3
        /// </summary> 
        private double _V_alfa_N2_G;    // закрытая переменная класса 
        public double get_V_alfa_N2_G()
        {
            return _V_alfa_N2_G = 0.01*_N2+0.79*get_L_alfa();
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения, м3/м3 топлива
        /// </summary> 
        private double _V_O2_izb_G;    // закрытая переменная класса 
        public double get_V_O2_izb_G()
        {
            return _V_O2_izb_G = 0.21*(_alfaG-1)*get_Lo()+get_Vo_O2_G();
        }

        /// <summary>
        /// Действительное количество продуктов горения, м3/м3 топлива
        /// </summary> 
        private double _V_alfa_G;    // закрытая переменная класса 
        public double get_V_alfa_G()
        {
            return _V_alfa_G = get_Vo_CO2_G()+get_Vo_SO2_G()+get_Vo_H2O_G()+get_Vo_CO_G()+get_Vo_H2_G()+get_V_alfa_N2_G()+get_V_O2_izb_G();
        }

        #endregion -- Расчет количества продуктов горения, м3/м3 (газообразное)

        #region -- Химический состав продуктов горения, %
        
        /// <summary>
        /// Содержание CO2 в продуктах горения, %
        /// </summary> 
        private double _CO2_R_G;    // закрытая переменная класса 
        public double get_CO2_R_G()
        {
            return _CO2_R_G = (get_Vo_CO2_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения, %
        /// </summary> 
        private double _SO2_R_G;    // закрытая переменная класса 
        public double get_SO2_R_G()
        {
            return _SO2_R_G = (get_Vo_SO2_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание H2O в продуктах горения, %
        /// </summary> 
        private double _H2O_R_G;    // закрытая переменная класса 
        public double get_H2O_R_G()
        {
            return _H2O_R_G = (get_Vo_H2O_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание N2 в продуктах горения, %
        /// </summary> 
        private double _N2_R_G;    // закрытая переменная класса 
        public double get_N2_R_G()
        {
            return _N2_R_G = (get_Vo_N2_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание CO в продуктах горения(диссоциация), %
        /// </summary> 
        private double _CO_R_G;    // закрытая переменная класса 
        public double get_CO_R_G()
        {
            return _CO_R_G = (get_Vo_CO_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание H2 в продуктах горения(диссоциация), %
        /// </summary> 
        private double _H2_R_G;    // закрытая переменная класса 
        public double get_H2_R_G()
        {
            return _H2_R_G = (get_Vo_H2_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Содержание O2 в продуктах горения, %
        /// </summary> 
        private double _O2_R_G;    // закрытая переменная класса 
        public double get_O2_R_G()
        {
            return _O2_R_G = (get_Vo_O2_G()/get_Vo_G())*100;
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов(должна быть =100%)
        /// </summary> 
        private double _summa_R_G;    // закрытая переменная класса 
        public double get_summa_R_G()
        {
            return _summa_R_G =  get_CO2_R_G()+get_SO2_R_G()+get_H2O_R_G()+get_N2_R_G()+get_CO_R_G()+get_H2_R_G()+get_O2_R_G();
        }

        ///------------------------------------------------------------------------------------

        /// <summary>
        /// Содержание CO2 в продуктах горения, %
        /// </summary> 
        private double _CO2_R_G_alfa;    // закрытая переменная класса 
        public double get_CO2_R_G_alfa()
        {
            return _CO2_R_G_alfa = (get_Vo_CO2_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения, %
        /// </summary> 
        private double _SO2_R_G_alfa;    // закрытая переменная класса 
        public double get_SO2_R_G_alfa()
        {
            return _SO2_R_G_alfa = (get_Vo_SO2_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание H2O в продуктах горения, %
        /// </summary> 
        private double _H2O_R_G_alfa;    // закрытая переменная класса 
        public double get_H2O_R_G_alfa()
        {
            return _H2O_R_G_alfa = (get_Vo_H2O_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание N2 в продуктах горения, %
        /// </summary> 
        private double _N2_R_G_alfa;    // закрытая переменная класса 
        public double get_N2_R_G_alfa()
        {
            return _N2_R_G_alfa = (get_V_alfa_N2_G() / get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание CO в продуктах горения(диссоциация), %
        /// </summary> 
        private double _CO_R_G_alfa;    // закрытая переменная класса 
        public double get_CO_R_G_alfa()
        {
            return _CO_R_G_alfa = (get_Vo_CO_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание H2 в продуктах горения(диссоциация), %
        /// </summary> 
        private double _H2_R_G_alfa;    // закрытая переменная класса 
        public double get_H2_R_G_alfa()
        {
            return _H2_R_G_alfa = (get_Vo_H2_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Содержание O2 в продуктах горения, %
        /// </summary> 
        private double _O2_R_G_alfa;    // закрытая переменная класса 
        public double get_O2_R_G_alfa()
        {
            return _O2_R_G_alfa = (get_V_O2_izb_G()/get_V_alfa_G())*100;
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов(должна быть =100%)
        /// </summary> 
        private double _summa_R_G_alfa;    // закрытая переменная класса 
        public double get_summa_R_G_alfa()
        {
            return _summa_R_G_alfa = get_CO2_R_G_alfa()+get_SO2_R_G_alfa()+get_H2O_R_G_alfa()+get_N2_R_G_alfa()+get_CO_R_G_alfa()+get_H2_R_G_alfa()+get_O2_R_G_alfa();
        }


        #endregion -- Химический состав продуктов горения, %
        
        #region -- Расчет теплоемкости топлива и воздуха, кДж/(кг*°С)

        /// <summary>
        /// Удельная теплоемкость газообразного топлива, кДж/(м3*°С)
        /// </summary> 
        private double _c_topl_G;    // закрытая переменная класса 
        public double get_c_topl_G()
        {
            return _c_topl_G = 0.01 * (_CO2 * (0.0005 * _t_gG + 1.6876) +_CO * (0.0001 * _gG + 1.2851)+_H2 * (0.00005 * _t_gG + 1.2814)+_CH4 * (0.0011 * _t_gG + 1.5699)+_C2H6 * (0.0022 * _t_gG + 2.36)+_C3H8 * (0.0032 * _t_gG + 3.3462)+_C4H10 * (0.004 * _t_gG + 4.4928) +_C5H12 * (0.0048 * _t_gG + 5.5781) +_H2S * (0.0004 * _t_gG + 1.502) +_N2 * (0.0001 * _t_gG + 1.2796) +_H2O * (0.0002 * _t_gG + 1.4756));
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(м3*°С)
        /// </summary> 
        private double _c_vozd_G;    // закрытая переменная класса 
        public double get_c_vozd_G()
        {
            return _c_vozd_G = 0.0001 * _t_vG + 1.2857;
        }

        /// <summary>
        /// Воздух в ПГ, %
        /// </summary> 
        private double _vozd_vPG_G;    // закрытая переменная класса 
        public double get_vozd_vPG_G()
        {
            return _vozd_vPG_G = (_L_alfa-_Lo)*100/_V_alfa_G;
        }   

        #endregion -- Расчет теплоемкости топлива и воздуха, кДж/(кг*°С)

        #region -- Расчет энтальпий продуктов горения, кДж/м3

        /// <summary>
        /// Теплота сгорания топлива, кДж/м3
        /// </summary> 
        private double _Q_G;    // закрытая переменная класса 
        public double get_Q_G()
        {
            return _Q_G = 127.7*_CO+108*_H2+358*_CH4+636*_C2H6+913*_C3H8+1185*_C4H10+1465*_C5H12+234*_H2S;
        } 

        /// <summary>
        /// Химическая энтальпия топлива, кДж/м3 
        /// </summary> 
        private double _i_him_G;    // закрытая переменная класса 
        public double get_i_him_G()
        {
            return _i_him_G = get_Q_G() / get_Vo_G();
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива, кДж/м3 
        /// </summary> 
        private double _i_topl_G;    // закрытая переменная класса 
        public double get_i_topl_G()
        {
            return _i_topl_G = get_c_topl_G()*_t_gG/ get_Vo_G();
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха, кДж/м3
        /// </summary> 
        private double _i_vozd_G;    // закрытая переменная класса 
        public double get_i_vozd_G()
        {
            return _i_vozd_G = get_c_vozd_G()*_t_vG*get_Lo()/ get_Vo_G();
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения, кДж/м3 
        /// </summary> 
        private double _i_count_t_G;    // закрытая переменная класса 
        public double get_i_count_t_G()
        {
            return _i_count_t_G = get_i_him_G()+get_i_topl_G()+get_i_vozd_G();
        }

        /// <summary>
        /// Энтальпия химического недожога, кДж/м3 
        /// </summary> 
        private double _i_3_G;    // закрытая переменная класса 
        public double get_i_3_G()
        {
            return _i_3_G = (get_Vo_CO_G()*12600+get_Vo_H2_G()*10800)/get_Vo_G();
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_b_G;    // закрытая переменная класса 
        public double get_i_count_b_G()
        {
            return _i_count_b_G = get_i_count_t_G() - get_i_3_G();
        }

        ///-----------------------------------------------------------------------------------------

        /// <summary>
        /// Химическая энтальпия топлива, кДж/м3 
        /// </summary> 
        private double _i_him_G_alfa;    // закрытая переменная класса 
        public double get_i_him_G_alfa()
        {
            return _i_him_G_alfa = _Q_G/_V_alfa_G;
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива, кДж/м3 
        /// </summary> 
        private double _i_topl_G_alfa;    // закрытая переменная класса 
        public double get_i_topl_G_alfa()
        {
            return _i_topl_G_alfa = _c_topl_G*_t_gG/_V_alfa_G;
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха, кДж/м3
        /// </summary> 
        private double _i_vozd_G_alfa;    // закрытая переменная класса 
        public double get_i_vozd_G_alfa()
        {
            return _i_vozd_G_alfa = _c_vozd_G*_t_vG*_L_alfa/_V_alfa_G;
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения, кДж/м3 
        /// </summary> 
        private double _i_count_t_G_alfa;    // закрытая переменная класса 
        public double get_i_count_t_G_alfa()
        {
            return _i_count_t_G_alfa = _i_him_G_alfa+_i_topl_G_alfa+_i_vozd_G_alfa;
        }

        /// <summary>
        /// Энтальпия химического недожога, кДж/м3 
        /// </summary> 
        private double _i_3_G_alfa;    // закрытая переменная класса 
        public double get_i_3_G_alfa()
        {
            return _i_3_G_alfa = (_Vo_CO_G*12600+_Vo_H2_G*10800)/_V_alfa_G;
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_b_G_alfa;    // закрытая переменная класса 
        public double get_i_count_b_G_alfa()
        {
            return _i_count_b_G_alfa = _i_count_t_G_alfa - _i_3_G_alfa;
        }

        #endregion -- Расчет энтальпий продуктов горения, кДж/м3

        #region -- Расчет температуры горения

        //public static double Func(double x)
        public double Func(double x)
        {
            //уравнение
            return 0.0;
            //return x - get_i_count_t_G() / ((get_CO2_R_G() * ((0.0005 * x) + 1.6876) + get_SO2_R_G() * ((0.0004 * x) + 1.8119) + 18.44 * ((0.0002 * x) + 1.4756) + 71.48 * ((0.0001 * x) + 1.2796) + 0.56 * ((0.0001 * x) + 1.2851) + 0.21 * ((0.00005 * x) + 1.2814) + 0.38 * ((0.0002 * x) + 1.3094)) / 100);
        }
        /// <summary>
        /// Теоретическая, °С
        /// </summary> 
        private double _temp_ter_G;    // закрытая переменная класса 
        public double get_temp_ter_G()
        {
            // Точность.
            double accuracy = 1e-8;
            // Интервал поиска.
            double min = 1500;
            double max = 3000;
            // Длина интервала.
            var length = max - min;
            // Начальная ошибка.
            var err = length;
            // Корень.
            double x = 0;
            while (err > accuracy && Func(x) != 0)
            {
                // Вычисляем середину интервала.
                x = (min + max) / 2;
                // Найдём новый интервал, в котором функция меняет знак.
                if (Func(min) * Func(x) < 0)
                {
                    max = x;
                }
                else if (Func(x) * Func(max) < 0)
                {
                    min = x;
                }
                // Вычисляем новую ошибку.
                err = (max - min) / length;
            }

            return x;
        }

        /// <summary>
        /// Целевая функция (=0)
        /// </summary> 
        private double _temp_ter_celFunc_G;    // закрытая переменная класса 
        public double get_temp_ter_celFunc_G()
        {
            return _temp_ter_celFunc_G = get_temp_ter_G() - get_i_count_t_G() / ((get_CO2_R_G() * ((0.0005 * get_temp_ter_G()) + 1.6876) + get_SO2_R_G() *((0.0004 * get_temp_ter_G()) + 1.8119) +get_H2O_R_G() * ((0.0002 * get_temp_ter_G()) + 1.4756) +get_N2_R_G() * ((0.0001 * get_temp_ter_G()) + 1.2796) +get_CO_R_G() * ((0.0001 * get_temp_ter_G()) + 1.2851) +get_H2_R_G() * ((0.00005 * get_temp_ter_G()) + 1.2814) +get_O2_R_G() * ((0.0002 * get_temp_ter_G()) + 1.3094))/ 100);
        }

        /// <summary>
        /// Балансовая, °С
        /// </summary> 
        private double _temp_balans_G;    // закрытая переменная класса 
        public double get_temp_balans_G()
        {
            return _temp_balans_G = 2107.09681064275;
        }

        /// <summary>
        /// Целевая функция (=0)
        /// </summary> 
        private double _temp_balans_celFunc_G;    // закрытая переменная класса 
        public double get_temp_balans_celFunc_G()
        {
            return _temp_balans_celFunc_G = get_temp_balans_G() - get_i_count_b_G() / ((get_CO2_R_G() * (0.0005 * get_temp_balans_G() + 1.6876) + get_SO2_R_G() * (0.0004 * get_temp_balans_G() + 1.8119) + get_H2O_R_G() * (0.0002 * get_temp_balans_G() + 1.4756) + get_N2_R_G() * (0.0001 * get_temp_balans_G() + 1.2796) + get_CO_R_G() * (0.0001 * get_temp_balans_G() + 1.2851) + get_H2_R_G() * (0.00005 * get_temp_balans_G() + 1.2814) + get_O2_R_G() * (0.0002 * get_temp_balans_G() + 1.3094))/ 100);
        }
        ///------------------------------------
        /// <summary>
        /// _pass
        /// </summary> 
        private double _temp_ter_G_alfa;    // закрытая переменная класса 
        public double get_temp_ter_G_alfa()
        {
            return _temp_ter_G_alfa = 2026.52020196304;
        }

        /// <summary>
        /// _pass
        /// </summary> 
        private double _temp_ter_celFunc_G_alfa;    // закрытая переменная класса 
        public double get_temp_ter_celFunc_G_alfa()
        {
            return _temp_ter_celFunc_G_alfa = get_temp_ter_G_alfa() - get_i_count_t_G_alfa() / ((get_CO2_R_G_alfa() * ((0.0005 * get_temp_ter_G_alfa()) + 1.6876) + get_SO2_R_G_alfa() * ((0.0004 * get_temp_ter_G_alfa()) + 1.8119) + get_H2O_R_G_alfa() * ((0.0002 * get_temp_ter_G_alfa()) + 1.4756) + get_N2_R_G_alfa() * ((0.0001 * get_temp_ter_G_alfa()) + 1.2796) + get_CO_R_G_alfa() * ((0.0001 * get_temp_ter_G_alfa()) + 1.2851) + get_H2_R_G_alfa() * ((0.00005 * get_temp_ter_G_alfa()) + 1.2814) + get_O2_R_G_alfa() * ((0.0002 * get_temp_ter_G_alfa()) + 1.3094)) / 100);
        }

        /// <summary>
        /// _pass
        /// </summary> 
        private double _temp_balans_G_alfa;    // закрытая переменная класса 
        public double get_temp_balans_G_alfa()
        {
            return _temp_balans_G_alfa = 1982.5543207679;
        }

        /// <summary>
        /// _pass
        /// </summary> 
        private double _temp_balans_celFunc_G_alfa;    // закрытая переменная класса 
        public double get_temp_balans_celFunc_G_alfa()
        {
            return _temp_balans_celFunc_G_alfa = get_temp_balans_G_alfa() - get_i_count_b_G_alfa() / ((get_CO2_R_G_alfa() * (0.0005 * get_temp_balans_G_alfa() + 1.6876) + get_SO2_R_G_alfa() * (0.0004 * get_temp_balans_G_alfa() + 1.8119) + get_H2O_R_G_alfa() * (0.0002 * get_temp_balans_G_alfa() + 1.4756) + get_N2_R_G_alfa() * (0.0001 * get_temp_balans_G_alfa() + 1.2796) + get_CO_R_G_alfa() * (0.0001 * get_temp_balans_G_alfa() + 1.2851) + get_H2_R_G_alfa() * (0.00005 * get_temp_balans_G_alfa() + 1.2814) + get_O2_R_G_alfa() * (0.0002 * get_temp_balans_G_alfa() + 1.3094)) / 100);
        }


        #endregion -- Расчет температуры горения

        #endregion -- газ


        #region -- твердое

        #region -- Расчет количества окислителя, м3/кг
        /// <summary>
        /// Количество необходимого кислорода для окисления всех горючих компонентов топлива, м3/кг
        /// </summary> 
        private double _V_O2_T;    // закрытая переменная класса 
        public double get_V_O2_T()
        {
            return _V_O2_T = 0.01*(1.867*_C+5.6*_H+0.7*_S-0.7*_O);
        }

        /// <summary>
        /// Теоретический расход сухого воздуха, м3/кг
        /// </summary> 
        private double _Lo_s_v_T;    // закрытая переменная класса 
        public double get_Lo_s_v_T()
        {
            return _Lo_s_v_T = (1+3.76)*get_V_O2_T();
        }

        /// <summary>
        /// Теоретический расход влажного воздуха, м3/кг
        /// </summary> 
        private double _Lo_v_v_T;    // закрытая переменная класса 
        public double get_Lo_v_v_T()
        {
            return _Lo_v_v_T = (1+0.00124*_gT)* get_Lo_s_v_T();
        }

        /// <summary>
        /// Действительный расход влажного воздуха, м3/кг
        /// </summary> 
        private double _L_alfa_v_v_T;    // закрытая переменная класса 
        public double get_L_alfa_v_v_T()
        {
            return _L_alfa_v_v_T = _alfaT* get_Lo_v_v_T();
        }
        #endregion -- Расчет количества окислителя, м3/кг

        #region -- Расчет количества продуктов горения, м3/кг

        /// <summary>
        /// Количество CO2 в продуктах горения при alfa=1, м3/кг топлива
        /// </summary> 
        private double _Vo_CO2_T;    // закрытая переменная класса 
        public double get_Vo_CO2_T()
        {
            return _Vo_CO2_T = 0.01*1.867*_C-get_Vo_CO_T();
        }

        /// <summary>
        /// Количество SO2 в продуктах горения при alfa=1, м3/кг топлива
        /// </summary> 
        private double _Vo_SO2_T;    // закрытая переменная класса 
        public double get_Vo_SO2_T()
        {
            return _Vo_SO2_T = 0.01*0.7*_S;
        }

        /// <summary>
        /// Количество H2O в продуктах горения при alfa=1, м3/кг топлива
        /// </summary> 
        private double _Vo_H2O_T;    // закрытая переменная класса 
        public double get_Vo_H2O_T()
        {
            return _Vo_H2O_T = 0.01*1.244*_Wр+0.01*11.2*_H+0.00124*_gT*get_Lo_s_v_T()-get_Vo_H2_T();
        }

        /// <summary>
        /// Количество N2 в продуктах горения при alfa=1, м3/кг топлива
        /// </summary> 
        private double _Vo_N2_T;    // закрытая переменная класса 
        public double get_Vo_N2_T()
        {
            return _Vo_N2_T = 0.01*0.8*_N+3.76*get_V_O2_T();
        }
        /// <summary>
        /// Количество CO в продуктах горения при alfa=1 (диссоциация CO2), м3/кг топлива
        /// </summary> 
        private double _Vo_CO_T;    // закрытая переменная класса 
        public double get_Vo_CO_T()
        {
            return _Vo_CO_T = Math.Pow(Math.Pow(2,0.5)*Math.Exp((-58090+17.628* get_temp_ter_T()) /(1.987* get_temp_ter_T())),2.0/3.0);
        }

        /// <summary>
        /// Количество H2 в продуктах горения при alfa=1 (диссоциация H2O), м3/кг топлива
        /// </summary> 
        private double _Vo_H2_T;    // закрытая переменная класса 
        public double get_Vo_H2_T()
        {
            return _Vo_H2_T = Math.Pow(Math.Pow(2,0.5)*Math.Exp((-52300+12.081* get_temp_ter_T()) /(1.987* get_temp_ter_T())), 2.0/3.0);
        }

        /// <summary>
        /// Количество O2 в продуктах горения при alfa=1 (диссоциация CO2 и H2O), м3/кг топлива
        /// </summary> 
        private double _Vo_O2_T;    // закрытая переменная класса 
        public double get_Vo_O2_T()
        {
            return _Vo_O2_T = 0.5*get_Vo_CO_T()+0.5*get_Vo_H2_T();
        }

        /// <summary>
        /// Действительный расход влажного воздуха, м3/кг
        /// </summary> 
        private double _Vo_T;    // закрытая переменная класса 
        public double get_Vo_T()
        {
            return _Vo_T = get_Vo_CO2_T()+get_Vo_SO2_T()+get_Vo_H2O_T()+get_Vo_N2_T()+get_Vo_CO_T()+get_Vo_H2_T()+get_Vo_O2_T();
        }
        /// alfa ------------------------------------------------------------------------------
        /// <summary>
        /// Количество CO2 в продуктах горения при alfa>1, м3/кг топлива
        /// </summary> 
        private double _Vo_CO2_T_alfa;    // закрытая переменная класса 
        public double get_Vo_CO2_T_alfa()
        {
            return _Vo_CO2_T_alfa = get_Vo_CO2_T();
        }

        /// <summary>
        /// Количество SO2 в продуктах горения при alfa>1, м3/кг топлива
        /// </summary> 
        private double _Vo_SO2_T_alfa;    // закрытая переменная класса 
        public double get_Vo_SO2_T_alfa()
        {
            return _Vo_SO2_T_alfa = get_Vo_SO2_T();
        }

        /// <summary>
        /// Количество H2O в продуктах горения при alfa>1, м3/кг топлива
        /// </summary> 
        private double _Vo_H2O_T_alfa;    // закрытая переменная класса 
        public double get_Vo_H2O_T_alfa()
        {
            return _Vo_H2O_T_alfa = get_Vo_H2O_T()+0.00124*_gT*(_alfaT-1)*get_Lo_s_v_T();
        }

        /// <summary>
        /// Количество N2 в продуктах горения при alfa>1, м3/кг топлива
        /// </summary> 
        private double _Vo_N2_T_alfa;    // закрытая переменная класса 
        public double get_Vo_N2_T_alfa()
        {
            return _Vo_N2_T_alfa = get_Vo_N2_T()+3.76*(_alfaT-1)*get_V_O2_T();
        }

        /// <summary>
        /// Количество CO в продуктах горения при alfa>1 (диссоциация CO2), м3/кг топлива
        /// </summary> 
        private double _Vo_CO_T_alfa;    // закрытая переменная класса 
        public double get_Vo_CO_T_alfa()
        {
            return _Vo_CO_T_alfa = Math.Pow(Math.Pow(2,0.5)*Math.Exp((-58090+17.628* get_temp_ter_T_alfa()) /(1.987* get_temp_ter_T_alfa())), 2.0/3.0);
        }

        /// <summary>
        /// Количество H2 в продуктах горения при alfa>1 (диссоциация H2O), м3/кг топлива
        /// </summary> 
        private double _Vo_H2_T_alfa;    // закрытая переменная класса 
        public double get_Vo_H2_T_alfa()
        {
            return _Vo_H2_T_alfa = Math.Pow(Math.Pow(2,0.5)*Math.Exp((-52300+12.081* get_temp_ter_T_alfa()) /(1.987* get_temp_ter_T_alfa())), 2.0/3.0);
        }

        /// <summary>
        /// Количество O2 в продуктах горения при alfa>1 (диссоциация CO2 и H2O), м3/кг топлива
        /// </summary> 
        private double _Vo_O2_T_alfa;    // закрытая переменная класса 
        public double get_Vo_O2_T_alfa()
        {
            return _Vo_O2_T_alfa = 0.5*get_Vo_CO_T_alfa()+0.5*get_Vo_H2_T_alfa();
        }

        /// <summary>
        /// Количество избыточного кислорода в продуктах горения, м3/кг топлива
        /// </summary> 
        private double _V_O2_izb_T_alfa;    // закрытая переменная класса 
        public double get_V_O2_izb_T_alfa()
        {
            return _V_O2_izb_T_alfa = (_alfaT-1)*get_V_O2_T();
        }

        /// <summary>
        /// Действительный расход влажного воздуха, м3/кг
        /// </summary> 
        private double _V_alfa_T;    // закрытая переменная класса 
        public double get_V_alfa_T()
        {
            return _V_alfa_T = get_Vo_CO2_T_alfa()+get_Vo_SO2_T_alfa()+get_Vo_H2O_T_alfa()+get_Vo_N2_T_alfa()+get_Vo_CO_T_alfa()+get_Vo_H2_T_alfa()+get_Vo_O2_T_alfa()+get_V_O2_izb_T_alfa();
        }

        #endregion -- Расчет количества продуктов горения, м3/кг

        #region -- Химический состав  и теплоемкость продуктов горения, %

        /// <summary>
        /// Содержание CO2 в продуктах горения, %
        /// </summary> 
        private double _CO2_T;    // закрытая переменная класса 
        public double get_CO2_T()
        {
            return _CO2_T = (get_Vo_CO2_T() /get_Vo_T())*100;
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения, %
        /// </summary> 
        private double _SO2_T;    // закрытая переменная класса 
        public double get_SO2_T()
        {
            return _SO2_T = (get_Vo_SO2_T() / get_Vo_T()) *100;
        }

        /// <summary>
        /// Содержание H2O в продуктах горения, %
        /// </summary> 
        private double _H2O_T;    // закрытая переменная класса 
        public double get_H2O_T()
        {
            return _H2O_T = (get_Vo_H2O_T() / get_Vo_T()) * 100;
        }

        /// <summary>
        /// Содержание N2 в продуктах горения, %
        /// </summary> 
        private double _N2_T;    // закрытая переменная класса 
        public double get_N2_T()
        {
            return _N2_T = (get_Vo_N2_T() / get_Vo_T()) * 100;
        }

        /// <summary>
        /// Содержание CO в продуктах горения, %
        /// </summary> 
        private double _CO_T;    // закрытая переменная класса 
        public double get_CO_T()
        {
            return _CO_T = (get_Vo_CO_T() / get_Vo_T()) * 100;
        }

        /// <summary>
        /// Содержание H2 в продуктах горения, %
        /// </summary> 
        private double _H2_T;    // закрытая переменная класса 
        public double get_H2_T()
        {
            return _H2_T = (get_Vo_H2_T() / get_Vo_T()) * 100;
        }

        /// <summary>
        /// Содержание O2 в продуктах горения, %
        /// </summary> 
        private double _O2_T;    // закрытая переменная класса 
        public double get_O2_T()
        {
            return _O2_T = (get_Vo_O2_T() / get_Vo_T()) * 100;
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов (должна быть 100%)
        /// </summary> 
        private double _summa_R_T;    // закрытая переменная класса 
        public double get_summa_R_T()
        {
            return _summa_R_T = get_CO2_T() + get_SO2_T() + get_H2O_T() + get_N2_T() + get_CO_T() + get_H2_T() + get_O2_T();
        }

        //----------------------------

        /// <summary>
        /// Содержание CO2 в продуктах горения, %
        /// </summary> 
        private double _CO2_T_alfa;    // закрытая переменная класса 
        public double get_CO2_T_alfa()
        {
            return _CO2_T_alfa = (get_Vo_CO2_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание SO2 в продуктах горения, %
        /// </summary> 
        private double _SO2_T_alfa;    // закрытая переменная класса 
        public double get_SO2_T_alfa()
        {
            return _SO2_T_alfa = (get_Vo_SO2_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание H2O в продуктах горения, %
        /// </summary> 
        private double _H2O_T_alfa;    // закрытая переменная класса 
        public double get_H2O_T_alfa()
        {
            return _H2O_T_alfa = (get_Vo_H2O_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание N2 в продуктах горения, %
        /// </summary> 
        private double _N2_T_alfa;    // закрытая переменная класса 
        public double get_N2_T_alfa()
        {
            return _N2_T_alfa = (get_Vo_N2_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание CO в продуктах горения, %
        /// </summary> 
        private double _CO_T_alfa;    // закрытая переменная класса 
        public double get_CO_T_alfa()
        {
            return _CO_T_alfa = (get_Vo_CO_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание H2 в продуктах горения, %
        /// </summary> 
        private double _H2_T_alfa;    // закрытая переменная класса 
        public double get_H2_T_alfa()
        {
            return _H2_T_alfa = (get_Vo_H2_T_alfa() / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Содержание O2 в продуктах горения, %
        /// </summary> 
        private double _O2_T_alfa;    // закрытая переменная класса 
        public double get_O2_T_alfa()
        {
            return _O2_T_alfa = ((get_V_O2_izb_T_alfa()+get_Vo_O2_T_alfa()) / get_V_alfa_T()) * 100;
        }

        /// <summary>
        /// Общая процентная сумма всех компонентов (должна быть 100%)
        /// </summary> 
        private double _summa_R_T_alfa;    // закрытая переменная класса 
        public double get_summa_R_T_alfa()
        {
            return _summa_R_T_alfa = get_CO2_T_alfa() + get_SO2_T_alfa() + get_H2O_T_alfa() + get_N2_T_alfa() + get_CO_T_alfa() + get_H2_T_alfa() + get_O2_T_alfa();
        }

        #endregion -- Химический состав  и теплоемкость продуктов горения, %

        #region -- Расчет теплоемкости топлива и воздуха, кДж/(кг*°С)

        /// <summary>
        /// Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)
        /// </summary> 
        private double _c_topl_T;    // закрытая переменная класса 
        public double get_c_topl_T()
        {
            return _c_topl_T = 0.005 * _t_tT+ 1.78;
        }

        /// <summary>
        /// Удельная теплоемкость воздуха, кДж/(м3*°С)
        /// </summary> 
        private double _c_vozd_T;    // закрытая переменная класса 
        public double get_c_vozd_T()
        {
            return _c_vozd_T = 0.0001 * _t_vT + 1.2857;
        }

        /// <summary>
        /// Содержание воздуха в продуктах горения, %
        /// </summary> 
        private double _vozd_pg_T;    // закрытая переменная класса 
        public double get_vozd_pg_T()
        {
            return _vozd_pg_T = (get_L_alfa_v_v_T() - get_Lo_v_v_T()) * 100 / get_V_alfa_T();
        }

        #endregion -- Расчет теплоемкости топлива и воздуха, кДж/(кг*°С)

        #region -- Расчет энтальпий продуктов горения, кДж/м3

        /// <summary>
        /// Теплота сгорания топлива, кДж/кг
        /// </summary> 
        private double _Q_T;    // закрытая переменная класса 
        public double get_Q_T()
        {
            return _Q_T = 339 * _C + 1030 * _H - 109 * (_O - _S) - 25 * (9 * _H + _Wр);
        }

        /// <summary>
        /// Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)
        /// </summary> 
        private double _i_him_T;    // закрытая переменная класса 
        public double get_i_him_T()
        {
            return _i_him_T = get_Q_T()/get_Vo_T() ;
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива, кДж/м3
        /// </summary> 
        private double _i_top_T;    // закрытая переменная класса 
        public double get_i_top_T()
        {
            return _i_top_T = get_c_topl_T() * _t_tT / get_Vo_T();
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха, кДж/м3
        /// </summary> 
        private double _i_vozd_T;    // закрытая переменная класса 
        public double get_i_vozd_T()
        {
            return _i_vozd_T = get_c_vozd_T() * _t_vT * get_Lo_v_v_T() / get_Vo_T();
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_T;    // закрытая переменная класса 
        public double get_i_count_T()
        {
            return _i_count_T = get_i_him_T()+ get_i_top_T() + get_i_vozd_T();
        }

        /// <summary>
        /// Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)
        /// </summary> 
        private double _i_3_i_4_T;    // закрытая переменная класса 
        public double get_i_3_i_4_T()
        {
            return _i_3_i_4_T = (_M_nedojog / 100) * get_i_him_T() + (get_Vo_CO_T() * 12600 + get_Vo_H2_T() * 10800) / get_Vo_T();
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_b_T;    // закрытая переменная класса 
        public double get_i_count_b_T()
        {
            return _i_count_b_T = get_i_count_T() - get_i_3_i_4_T();
        }

        //----------------------------------------

        /// <summary>
        /// Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)
        /// </summary> 
        private double _i_him_T_alfa;    // закрытая переменная класса 
        public double get_i_him_T_alfa()
        {
            return _i_him_T_alfa = get_Q_T()/get_V_alfa_T();
        }

        /// <summary>
        /// Физическая энтальпия подогретого топлива, кДж/м3
        /// </summary> 
        private double _i_top_T_alfa;    // закрытая переменная класса 
        public double get_i_top_T_alfa()
        {
            return _i_top_T_alfa = get_c_topl_T() * _t_tT / get_V_alfa_T();
        }

        /// <summary>
        /// Физическая энтальпия подогретого воздуха, кДж/м3
        /// </summary> 
        private double _i_vozd_T_alfa;    // закрытая переменная класса 
        public double get_i_vozd_T_alfa()
        {
            return _i_vozd_T_alfa = get_c_vozd_T() * _t_vT * get_L_alfa_v_v_T() / get_V_alfa_T();
        }

        /// <summary>
        /// Общая (теоретическая) энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_T_alfa;    // закрытая переменная класса 
        public double get_i_count_T_alfa()
        {
            return _i_count_T_alfa = get_i_him_T_alfa() + get_i_top_T_alfa() + get_i_vozd_T_alfa();
        }

        /// <summary>
        /// Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)
        /// </summary> 
        private double _i_3_i_4_T_alfa;    // закрытая переменная класса 
        public double get_i_3_i_4_T_alfa()
        {
            return _i_3_i_4_T_alfa = (_M_nedojog / 100) * get_i_him_T_alfa() + (get_Vo_CO_T_alfa() * 12600 + get_Vo_H2_T_alfa() * 10800) / get_V_alfa_T();
        }

        /// <summary>
        /// Общая балансовая энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _i_count_b_T_alfa;    // закрытая переменная класса 
        public double get_i_count_b_T_alfa()
        {
            return _i_count_b_T_alfa = get_i_count_T_alfa() - get_i_3_i_4_T_alfa();
        }

        #endregion -- Расчет энтальпий продуктов горения, кДж/м3

        #region -- Расчет температуры горения

        /// <summary>
        /// Теоретическая, °С
        /// </summary> 
        private double _temp_ter_T;    // закрытая переменная класса 
        public double get_temp_ter_T()
        {
            return _temp_ter_T = 2150.7659273209;
        }

        /// <summary>
        /// Целевая функция (=0)
        /// </summary> 
        private double _temp_ter_celFunc_T;    // закрытая переменная класса 
        public double get_temp_ter_celFunc_T()
        {
            return _temp_ter_celFunc_T = get_temp_ter_T() - get_i_count_T() / ((get_CO2_T() * (0.0005 * get_temp_ter_T() + 1.6876) +get_SO2_T() * (0.0004 * get_temp_ter_T() + 1.8119) +get_H2O_T() * (0.0002 * get_temp_ter_T() + 1.4756) +get_N2_T() * (0.0001 * get_temp_ter_T() + 1.2796) +get_CO_T() * (0.0001 * get_temp_ter_T() + 1.2851) +get_H2_T() * (0.00005 * get_temp_ter_T() + 1.2814) +get_O2_T() * (0.0002 * get_temp_ter_T() + 1.3094))/ 100);
        }

        /// <summary>
        /// Балансовая, °С
        /// </summary> 
        private double _temp_balans_T;    // закрытая переменная класса 
        public double get_temp_balans_T()
        {
            return _temp_balans_T = 2046.29254664502;
        }

        /// <summary>
        /// Теплота сгорания топлива, кДж/кг
        /// </summary> 
        private double _temp_balans_celFunc_T;    // закрытая переменная класса 
        public double get_temp_balans_celFunc_T()
        {
            return _temp_balans_celFunc_T = get_temp_balans_T() - get_i_count_b_T() / ((get_CO2_T() * (0.0005 * get_temp_balans_T() + 1.6876) + get_SO2_T() * (0.0004 * get_temp_balans_T() + 1.8119) + get_H2O_T() * (0.0002 * get_temp_balans_T() + 1.4756) + get_N2_T() * (0.0001 * get_temp_balans_T() + 1.2796) + get_CO_T() * (0.0001 * get_temp_balans_T() + 1.2851) + get_H2_T() * (0.00005 * get_temp_balans_T() + 1.2814) + get_O2_T() * (0.0002 * get_temp_balans_T() + 1.3094))/ 100);
        }

        //-------------------------

        /// <summary>
        /// Теоретическая, °С
        /// </summary> 
        private double _temp_ter_T_alfa;    // закрытая переменная класса 
        public double get_temp_ter_T_alfa()
        {
            return _temp_ter_T_alfa = 1874.6625511434;
        }

        /// <summary>
        /// Целевая функция (=0)
        /// </summary> 
        private double _temp_ter_celFunc_T_alfa;    // закрытая переменная класса 
        public double get_temp_ter_celFunc_T_alfa()
        {
            return _temp_ter_celFunc_T_alfa = get_temp_ter_T_alfa() - get_i_count_T_alfa() / ((get_CO2_T_alfa() * (0.0005 * get_temp_ter_T_alfa() + 1.6876) + get_SO2_T_alfa() * (0.0004 * get_temp_ter_T_alfa() + 1.8119) + get_H2O_T_alfa() * (0.0002 * get_temp_ter_T_alfa() + 1.4756) + get_N2_T_alfa() * (0.0001 * get_temp_ter_T_alfa() + 1.2796) + get_CO_T_alfa() * (0.0001 * get_temp_ter_T_alfa() + 1.2851) + get_H2_T_alfa() * (0.00005 * get_temp_ter_T_alfa() + 1.2814) + get_O2_T_alfa() * (0.0002 * get_temp_ter_T_alfa() + 1.3094)) / 100);
        }

        /// <summary>
        /// Балансовая, °С
        /// </summary> 
        private double _temp_balans_T_alfa;    // закрытая переменная класса 
        public double get_temp_balans_T_alfa()
        {
            return _temp_balans_T_alfa = 1809.04492469862;
        }

        /// <summary>
        /// Теплота сгорания топлива, кДж/кг
        /// </summary> 
        private double _temp_balans_celFunc_T_alfa;    // закрытая переменная класса 
        public double get_temp_balans_celFunc_T_alfa()
        {
            return _temp_balans_celFunc_T_alfa = get_temp_balans_T_alfa() - get_i_count_b_T_alfa() / ((get_CO2_T_alfa() * (0.0005 * get_temp_balans_T_alfa() + 1.6876) + get_SO2_T_alfa() * (0.0004 * get_temp_balans_T_alfa() + 1.8119) + get_H2O_T_alfa() * (0.0002 * get_temp_balans_T_alfa() + 1.4756) + get_N2_T_alfa() * (0.0001 * get_temp_balans_T_alfa() + 1.2796) + get_CO_T_alfa() * (0.0001 * get_temp_balans_T_alfa() + 1.2851) + get_H2_T_alfa() * (0.00005 * get_temp_balans_T_alfa() + 1.2814) + get_O2_T_alfa() * (0.0002 * get_temp_balans_T_alfa() + 1.3094)) / 100);
        }
        #endregion -- Расчет температуры горения

        #endregion -- твердое

        #endregion -- расчетные параметры


        #region -- методы сериализации
        /// <summary>
        /// Загрузить исходные данные в экземпляр объекта расчета 
        /// </summary>  
        /// <param name="NameFile">Имя файла для извлечения данных</param>
        public GorenieLibrary LoadData(string FileName)
        {
            // Восстановить данные путем десериализации из XML-файла
            SoapFormatter myXMLFormat = new SoapFormatter();
            FileStream myStreamB = File.OpenRead(FileName);
            GorenieLibrary _s = (GorenieLibrary)myXMLFormat.Deserialize(myStreamB);
            myStreamB.Close();
            return _s;
        }

        /// <summary>
        /// Сохранение исходных данных объекта на диск
        /// </summary>  
        /// <param name="hc">Объект  для сохранения на диск</param>
        /// <param name="NameFile">Имя файла для сохранения</param>
        public void SaveData(GorenieLibrary s, string NameFile)
        {
            FileStream myStream = File.Create(NameFile);
            SoapFormatter myXMLFormat = new SoapFormatter();
            myXMLFormat.Serialize(myStream, s);
            myStream.Close();
        }

        /// <summary>
        /// Свойство для хранения имени файла данных
        /// </summary>    
        private string _sFileName;    // закрытая переменная класса для хранения имени файла исходных данных
        public string FileName
        {
            get { return _sFileName; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Не определен объект FileName");
                else
                    _sFileName = value;
            }
        }
        #endregion
    }
}
