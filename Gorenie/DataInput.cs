using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorenieDLL;

namespace Gorenie
{
    [Serializable]
    class DataInputGaz
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private GorenieLibrary _gor = new GorenieLibrary();
        public DataInputGaz(GorenieLibrary gor)
        {
            _gor = gor;
        }

        [Description("Содержание CO2 в топливе, %")]
        [DisplayName("CO2")]
        [Category("Исходные данные")]
        public double CO2
        {
            get { return _gor.CO2; }
            set { _gor.CO2 = value; }
        }

        [Description("Содержание CO в топливе, %")]
        [DisplayName("CO")]
        [Category("Исходные данные")]
        public double CO
        {
            get { return _gor.CO; }
            set { _gor.CO = value; }
        }

        [Description("Содержание H2 в топливе, %")]
        [DisplayName("H2")]
        [Category("Исходные данные")]
        public double H2
        {
            get { return _gor.H2; }
            set { _gor.H2 = value; }
        }

        [Description("Содержание CH4 в топливе, %")]
        [DisplayName("CH4")]
        [Category("Исходные данные")]
        public double CH4
        {
            get { return _gor.CH4; }
            set { _gor.CH4 = value; }
        }

        [Description("Содержание C2H6 в топливе, %")]
        [DisplayName("C2H6")]
        [Category("Исходные данные")]
        public double C2H6
        {
            get { return _gor.C2H6; }
            set { _gor.C2H6 = value; }
        }

        [Description("Содержание C3H8 в топливе, %")]
        [DisplayName("C3H8")]
        [Category("Исходные данные")]
        public double C3H8
        {
            get { return _gor.C3H8; }
            set { _gor.C3H8 = value; }
        }

        [Description("Содержание C4H10 в топливе, %")]
        [DisplayName("C4H10")]
        [Category("Исходные данные")]
        public double C4H10
        {
            get { return _gor.C4H10; }
            set { _gor.C4H10 = value; }
        }

        [Description("Содержание C5H12 в топливе, %")]
        [DisplayName("C5H12")]
        [Category("Исходные данные")]
        public double C5H12
        {
            get { return _gor.C5H12; }
            set { _gor.C5H12 = value; }
        }

        [Description("Содержание H2S в топливе, %")]
        [DisplayName("H2S")]
        [Category("Исходные данные")]
        public double H2S
        {
            get { return _gor.H2S; }
            set { _gor.H2S = value; }
        }

        [Description("Содержание N2 в топливе, %")]
        [DisplayName("N2")]
        [Category("Исходные данные")]
        public double N2
        {
            get { return _gor.N2; }
            set { _gor.N2 = value; }
        }

        [Description("Содержание H2O в топливе, %")]
        [DisplayName("H2O")]
        [Category("Исходные данные")]
        public double H2O
        {
            get { return _gor.H2O; }
            set { _gor.H2O = value; }
        }

        [Description("Проверка процентной суммы всех компонентов\nстрого = 100")]
        [DisplayName("Сумма")]
        [Category("Исходные данные")]
        public double summaG
        {
            get { return _gor.summaG; }
            set { _gor.summaG = value; }
        }

        [Description("Влагосодержание воздуха, г/м3 сухого воздуха")]
        [DisplayName("g")]
        [Category("Исходные данные")]
        public double gG
        {
            get { return _gor.gG; }
            set { _gor.gG = value; }
        }

        [Description("Температура подогрева газообразного топлива перед горением, °С")]
        [DisplayName("t_г, °С ")]
        [Category("Исходные данные")]
        public double t_gG
        {
            get { return _gor.t_gG; }
            set { _gor.t_gG = value; }
        }

        [Description("Температура подогрева воздуха перед горением, °С")]
        [DisplayName("t_в, °С")]
        [Category("Исходные данные")]
        public double t_vG
        {
            get { return _gor.t_vG; }
            set { _gor.t_vG = value; }
        }

        [Description("Коэффициент расхода воздуха на горение")]
        [DisplayName("alfa")]
        [Category("Исходные данные")]
        public double alfaG
        {
            get { return _gor.alfaG; }
            set { _gor.alfaG = value; }
        }

    }

    class DataInputTverd
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private GorenieLibrary _gor = new GorenieLibrary();
        public DataInputTverd(GorenieLibrary gor)
        {
            _gor = gor;
        }

        [Description("Содержание углерода в топливе, %")]
        [DisplayName("C")]
        [Category("Исходные данные")]
        public double C
        {
            get { return _gor.C; }
            set { _gor.C = value; }
        }

        [Description("Содержание водорода в топливе, %")]
        [DisplayName("H")]
        [Category("Исходные данные")]
        public double H
        {
            get { return _gor.H; }
            set { _gor.H = value; }
        }

        [Description("Содержание серы в топливе, %")]
        [DisplayName("S")]
        [Category("Исходные данные")]
        public double S
        {
            get { return _gor.S; }
            set { _gor.S = value; }
        }

        [Description("Содержание азота в топливе, %")]
        [DisplayName("N")]
        [Category("Исходные данные")]
        public double N
        {
            get { return _gor.N; }
            set { _gor.N = value; }
        }

        [Description("Содержание кислорода в топливе, %")]
        [DisplayName("H")]
        [Category("Исходные данные")]
        public double O
        {
            get { return _gor.O; }
            set { _gor.O = value; }
        }

        [Description("Содержание влаги в топливе, масс. %")]
        [DisplayName("Wр")]
        [Category("Исходные данные")]
        public double Wр
        {
            get { return _gor.Wр; }
            set { _gor.Wр = value; }
        }

        [Description("Содержание золы в топливе, масс. %")]
        [DisplayName("H")]
        [Category("Исходные данные")]
        public double Aр
        {
            get { return _gor.Aр; }
            set { _gor.Aр = value; }
        }

        [Description("Проверка процентной суммы всех компонентов\nстрого = 100")]
        [DisplayName("Сумма")]
        [Category("Исходные данные")]
        public double summaT
        {
            get { return _gor.summaT; }
            set { _gor.summaT = value; }
        }

        [Description("Температура подогрева воздуха перед горением, °С")]
        [DisplayName("t_в")]
        [Category("Исходные данные")]
        public double t_vT
        {
            get { return _gor.t_vT; }
            set { _gor.t_vT = value; }
        }

        [Description("Температура подогрева топлива перед горением (вводить только для мазута !), °С")]
        [DisplayName("t_т")]
        [Category("Исходные данные")]
        public double t_tT
        {
            get { return _gor.t_tT; }
            set { _gor.t_tT = value; }
        }

        [Description("Коэффициент расхода воздуха на горение")]
        [DisplayName("alfa")]
        [Category("Исходные данные")]
        public double alfaT
        {
            get { return _gor.alfaT; }
            set { _gor.alfaT = value; }
        }

        [Description("Механический недожог топлива, % к теплоте сгорания топлива")]
        [DisplayName("М Недожог")]
        [Category("Исходные данные")]
        public double M_nedojog
        {
            get { return _gor.M_nedojog; }
            set { _gor.M_nedojog = value; }
        }

        [Description("Влагосодержание воздуха, г/м3 сухого воздуха")]
        [DisplayName("g")]
        [Category("Исходные данные")]
        public double gT
        {
            get { return _gor.gT; }
            set { _gor.gT = value; }
        }

    }
}
