using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using GorenieDLL;

namespace Gorenie
{
    public partial class Form1 : Form
    {
        // Создать главный объект, который включает в себя все нужные объекты
        public GorenieDLL.GorenieLibrary gor = new GorenieDLL.GorenieLibrary();

        private DataInputGaz _dataInput;
        private List<Gorenie.Param> _allParamsInput = new List<Gorenie.Param>(), _paramsToReportInput = new List<Gorenie.Param>();
        private List<Gorenie.Param> _allParamsOutput = new List<Gorenie.Param>(), _paramsToReportOutput = new List<Gorenie.Param>();

        public FrmReportGaz frmRpt;
        public frmReportTverd frmRptTverd;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ProgramExit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Где будем искать .xml-файл с исходными данными 
            FileInfo fileDefaultUserAppDataPath = new FileInfo(Application.UserAppDataPath.ToString() + @"\\default.xml");

            if (fileDefaultUserAppDataPath.Exists)  // если файл найден, то десериализовать его
            {
                GorenieDLL.GorenieLibrary GL = new GorenieDLL.GorenieLibrary();
                this.gor = GL.LoadData(fileDefaultUserAppDataPath.ToString());
            }
            else  // если файла нет, то сформировать его и сериализовать в указанный каталог для последующего вызова
            {
                #region -- Загрузка первоначальных значений
                gor.CO2 = 0.30;
                gor.CO = 0.0;
                gor.H2 = 0.0;
                gor.CH4 = 87.46;
                gor.C2H6 = 1.89;
                gor.C3H8 = 0.20;
                gor.C4H10 = 0.3;
                gor.C5H12 = 0.0;
                gor.H2S = 0.0;
                gor.N2 = 9.24;
                gor.H2O = 0.62;
                gor.summaG = Math.Round(gor.CO2+gor.CO+ gor.H2+gor.CH4+gor.C2H6+gor.C3H8+gor.C4H10+gor.C5H12+gor.H2S+gor.N2+gor.H2O, 1);
                gor.gG = 5.0;
                gor.t_gG = 200.0;
                gor.t_vG = 200.0;
                gor.alfaG = 1.1;
                //------------
                gor.C = 85.1;
                gor.H = 9.9;
                gor.S = 0.3;
                gor.N = 0.5;
                gor.O = 0.2;
                gor.Wр = 3.9;
                gor.Aр = 0.1;
                gor.summaT = Math.Round(gor.C+gor.H+gor.S+gor.N+gor.O+gor.Wр+gor.Aр, 1);
                gor.t_vT = 280.0;
                gor.t_tT = 98.0;
                gor.alfaT = 1.25;
                gor.M_nedojog = 4.0;
                gor.gT = 13.0;
                #endregion -- Загрузка первоначальных значений

                // Сохранить параметры доступа к базе данных на диск для последующего вызова
                gor.SaveData(gor, fileDefaultUserAppDataPath.ToString());
            }

            // Настроить элементы формы
            FormOptionDefault();
        }

        private void btnResultGaz_Click(object sender, EventArgs e)
        {
            tbControlGaz.SelectedIndex = 1;
            dataGridViewGaz.Rows.Clear();
            #region Заполнение DataGridView
            dataGridViewGaz.Rows.Add("Расчет количества окислителя на горение","","");

            dataGridViewGaz.Rows.Add("", "Теоретический расход окислителя на горение, м3/м3", Math.Round(gor.get_Lo(), 2));
            dataGridViewGaz.Rows.Add("", "Действительный расход окислителя на горение, м3/м3", Math.Round(gor.get_L_alfa(), 2));

            dataGridViewGaz.Rows.Add("Расчет количества продуктов горения", "", "");

            dataGridViewGaz.Rows.Add("", "Количество CO2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_CO2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество SO2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_SO2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество H2O в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_H2O_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество N2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_N2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество CO в продуктах горения (диссоциация CO2), м3/м3 топлива", Math.Round(gor.get_Vo_CO_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество H2 в продуктах горения (диссоциация H2O), м3/м3 топлива", Math.Round(gor.get_Vo_H2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество O2 в продуктах горения (диссоциация CO2 и H2O), м3/м3 топлива", Math.Round(gor.get_Vo_O2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Теоретический объем продуктов горения, м3/м3 топлива", Math.Round(gor.get_Vo_G(), 2));
            dataGridViewGaz.Rows.Add("", "Практический выход N2 при избытке окислителя, м3/м3", Math.Round(gor.get_V_alfa_N2_G(), 2));
            dataGridViewGaz.Rows.Add("", "Количество избыточного кислорода в продуктах горения, м3/м3 топлива", Math.Round(gor.get_V_O2_izb_G(), 2));
            dataGridViewGaz.Rows.Add("", "Действительное количество продуктов горения, м3/м3 топлива", Math.Round(gor.get_V_alfa_G(), 2));

            dataGridViewGaz.Rows.Add("Химический состав продуктов горения\nпри alfa = 1", "", "");

            dataGridViewGaz.Rows.Add("", "Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание CO в продуктах горения(диссоциация), %", Math.Round(gor.get_CO_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание H2 в продуктах горения(диссоциация), %", Math.Round(gor.get_H2_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_R_G(), 2));
            dataGridViewGaz.Rows.Add("", "Общая процентная сумма всех компонентов(должна быть =100%)", Math.Round(gor.get_summa_R_G(), 2));

            dataGridViewGaz.Rows.Add("Химический состав продуктов горения\nпри alfa > 1", "", "");

            dataGridViewGaz.Rows.Add("", "Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание CO в продуктах горения(диссоциация), %", Math.Round(gor.get_CO_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание H2 в продуктах горения(диссоциация), %", Math.Round(gor.get_H2_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_R_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Общая процентная сумма всех компонентов(должна быть =100%)", Math.Round(gor.get_summa_R_G_alfa(), 2));

            dataGridViewGaz.Rows.Add("Расчет теплоемкости топлива и воздуха", "", "");

            dataGridViewGaz.Rows.Add("", "Удельная теплоемкость газообразного топлива, кДж/(м3*°С)", Math.Round(gor.get_c_topl_G(), 2));
            dataGridViewGaz.Rows.Add("", "Удельная теплоемкость воздуха, кДж/(м3*°С)", Math.Round(gor.get_c_vozd_G(), 2));
            dataGridViewGaz.Rows.Add("", "Воздух в ПГ, %", Math.Round(gor.get_vozd_vPG_G(), 2));

            dataGridViewGaz.Rows.Add("Расчет энтальпий продуктов горения\nпри alfa = 1", "", "");

            dataGridViewGaz.Rows.Add("", "Химическая энтальпия топлива, кДж/м3", Math.Round(gor.get_i_him_G(), 2));
            dataGridViewGaz.Rows.Add("", "Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_topl_G(), 2));
            dataGridViewGaz.Rows.Add("", "Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_G(), 2));
            dataGridViewGaz.Rows.Add("", "Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_t_G(), 2));
            dataGridViewGaz.Rows.Add("", "Энтальпия химического недожога, кДж/м3", Math.Round(gor.get_i_3_G(), 2));
            dataGridViewGaz.Rows.Add("", "Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_G(), 2));

            dataGridViewGaz.Rows.Add("Расчет энтальпий продуктов горения\nпри alfa > 1", "", "");

            dataGridViewGaz.Rows.Add("", "Химическая энтальпия топлива, кДж/м3", Math.Round(gor.get_i_him_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_topl_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_t_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Энтальпия химического недожога, кДж/м3", Math.Round(gor.get_i_3_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_G_alfa(), 2));

            dataGridViewGaz.Rows.Add("Расчет температуры горения\nпри alfa = 1", "", "");

            dataGridViewGaz.Rows.Add("", "Теоретическая, °С", Math.Round(gor.get_temp_ter_G(), 2));
            dataGridViewGaz.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_G(), 2));
            dataGridViewGaz.Rows.Add("", "Балансовая, °С", Math.Round(gor.get_temp_balans_G(), 2));
            dataGridViewGaz.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_G(), 2));

            dataGridViewGaz.Rows.Add("Расчет температуры горения\nпри alfa > 1", "", "");

            dataGridViewGaz.Rows.Add("", "Теоретическая, °С", Math.Round(gor.get_temp_ter_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Балансовая, °С", Math.Round(gor.get_temp_balans_G_alfa(), 2));
            dataGridViewGaz.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_G_alfa(), 2));
            #endregion Заполнение DataGridView

            btnReport.Enabled = true;
            btnGraphGaz.Enabled = true;
        }

        private void ptGridGaz_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            gor.summaG = Math.Round(gor.CO2 + gor.CO + gor.H2 + gor.CH4 + gor.C2H6 + gor.C3H8 + gor.C4H10 + gor.C5H12 + gor.H2S + gor.N2 + gor.H2O, 1);
            ptGridGaz.Refresh();
            if (gor.summaG != 100.0)
            {
                btnResultGaz.Enabled = false;
            }
            else
            {
                btnResultGaz.Enabled = true;
            }

        }

        private void btnResultTverd_Click(object sender, EventArgs e)
        {
            tbControlTverd.SelectedIndex = 1;
            dataGridViewTverd.Rows.Clear();
            #region Заполнение DataGridView
            dataGridViewTverd.Rows.Add("Расчет количества окислителя", "", "");

            dataGridViewTverd.Rows.Add("", "Количество необходимого кислорода для окисления всех горючих компонентов топлива, м3 / кг", Math.Round(gor.get_V_O2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Теоретический расход сухого воздуха, м3/кг", Math.Round(gor.get_Lo_s_v_T(), 2));
            dataGridViewTverd.Rows.Add("", "Теоретический расход влажного воздуха, м3/кг", Math.Round(gor.get_Lo_v_v_T(), 2));
            dataGridViewTverd.Rows.Add("", "Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_L_alfa_v_v_T(), 2));

            dataGridViewTverd.Rows.Add("Расчет количества продуктов горения\nпри alfa = 1", "", "");

            dataGridViewTverd.Rows.Add("", "Количество CO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество SO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_SO2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество H2O в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2O_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество N2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_N2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество CO в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество H2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Количество O2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_O2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_Vo_T(), 2));

            dataGridViewTverd.Rows.Add("Расчет количества продуктов горения\nпри alfa > 1", "", "");

            dataGridViewTverd.Rows.Add("", "Количество CO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество SO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_SO2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество H2O в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2O_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество N2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_N2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество CO в продуктах горения(диссоциация CO2), м3/кг топлива", Math.Round(gor.get_Vo_CO_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество H2 в продуктах горения(диссоциация H2O), м3/кг топлива", Math.Round(gor.get_Vo_H2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество O2 в продуктах горения(диссоциация CO2 и H2O), м3/кг топлива", Math.Round(gor.get_Vo_O2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Количество избыточного кислорода в продуктах горения, м3/кг топлива", Math.Round(gor.get_V_O2_izb_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_V_alfa_T(), 2));

            dataGridViewTverd.Rows.Add("Химический состав  и теплоемкость продуктов горения\nпри alfa = 1", "", "");

            dataGridViewTverd.Rows.Add("", "Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание CO в продуктах горения, %", Math.Round(gor.get_CO_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание H2 в продуктах горения, %", Math.Round(gor.get_H2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_T(), 2));
            dataGridViewTverd.Rows.Add("", "Общая процентная сумма всех компонентов (должна быть 100%)", Math.Round(gor.get_summa_R_T(), 2));

            dataGridViewTverd.Rows.Add("Химический состав  и теплоемкость продуктов горения\nпри alfa > 1", "", "");

            dataGridViewTverd.Rows.Add("", "Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание CO в продуктах горения, %", Math.Round(gor.get_CO_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание H2 в продуктах горения, %", Math.Round(gor.get_H2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Общая процентная сумма всех компонентов (должна быть 100%)", Math.Round(gor.get_summa_R_T_alfa(), 2));

            dataGridViewTverd.Rows.Add("Расчет теплоемкости топлива и воздуха", "", "");

            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_c_topl_T(), 2));
            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость воздуха, кДж/(м3*°С)", Math.Round(gor.get_c_vozd_T(), 2));
            dataGridViewTverd.Rows.Add("", "Содержание воздуха в продуктах горения, %", Math.Round(gor.get_vozd_pg_T(), 2));

            dataGridViewTverd.Rows.Add("Расчет энтальпий продуктов горения\nпри alfa = 1", "", "");

            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_him_T(), 2));
            dataGridViewTverd.Rows.Add("", "Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_top_T(), 2));
            dataGridViewTverd.Rows.Add("", "Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_T(), 2));
            dataGridViewTverd.Rows.Add("", "Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_T(), 2));
            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_3_i_4_T(), 2));
            dataGridViewTverd.Rows.Add("", "Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_T(), 2));

            dataGridViewTverd.Rows.Add("Расчет энтальпий продуктов горения\nпри alfa > 1", "", "");

            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_him_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_top_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_3_i_4_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_T_alfa(), 2));

            dataGridViewTverd.Rows.Add("Расчет температуры горения\nпри alfa = 1", "", "");

            dataGridViewTverd.Rows.Add("", "Теоретическая, °С", Math.Round(gor.get_temp_ter_T(), 2));
            dataGridViewTverd.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_T(), 2));
            dataGridViewTverd.Rows.Add("", "Балансовая, °С", Math.Round(gor.get_temp_balans_T(), 2));
            dataGridViewTverd.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_T(), 2));

            dataGridViewTverd.Rows.Add("Расчет температуры горения\nпри alfa > 1", "", "");

            dataGridViewTverd.Rows.Add("", "Теоретическая, °С", Math.Round(gor.get_temp_ter_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Балансовая, °С", Math.Round(gor.get_temp_balans_T_alfa(), 2));
            dataGridViewTverd.Rows.Add("", "Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_T_alfa(), 2));

            #endregion Заполнение DataGridView

            btnReportTverd.Enabled = true;
        }

        private void ptGridTverd_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            gor.summaT = Math.Round(gor.C + gor.H + gor.S + gor.N + gor.O + gor.Wр + gor.Aр, 1);
            ptGridTverd.Refresh();
            if (gor.summaT != 100.0)
            {
                btnResultTverd.Enabled = false;
            }
            else
            {
                btnResultTverd.Enabled = true;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            frmRpt = new FrmReportGaz();

            List<cReportList> RepListInput = new List<cReportList>();
            #region --Input

            RepListInput.Add(new Gorenie.cReportList("Содержание CO2 в топливе, %", Math.Round(gor.CO2, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание CO в топливе, %", Math.Round(gor.CO, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание H2 в топливе, %", Math.Round(gor.H2, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание CH4 в топливе, %", Math.Round(gor.CH4, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание C2H6 в топливе, %", Math.Round(gor.C2H6, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание C3H8 в топливе, %", Math.Round(gor.C3H8, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание C4H10 в топливе, %", Math.Round(gor.C4H10, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание C5H12 в топливе, %", Math.Round(gor.C5H12, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание H2S в топливе, %", Math.Round(gor.H2S, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание N2 в топливе, %", Math.Round(gor.N2, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание H2O в топливе, %", Math.Round(gor.H2O, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Проверка процентной суммы всех компонентов", Math.Round(gor.summaG, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Влагосодержание воздуха, г/м3 сухого воздуха", Math.Round(gor.gG, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Температура подогрева газообразного топлива перед горением, °С", Math.Round(gor.t_gG, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Температура подогрева воздуха перед горением, °С", Math.Round(gor.t_vG, 2).ToString()));
            RepListInput.Add(new Gorenie.cReportList("Коэффициент расхода воздуха на горение", Math.Round(gor.alfaG, 2).ToString()));

            #endregion --Input


            List<cReportList> RepListOutput = new List<cReportList>();
            #region -- Output

            RepListOutput.Add(new Gorenie.cReportList("Расчет количества окислителя на горение", ""));

            RepListOutput.Add(new Gorenie.cReportList("Теоретический расход окислителя на горение, м3/м3", Math.Round(gor.get_Lo(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Действительный расход окислителя на горение, м3/м3", Math.Round(gor.get_L_alfa(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет количества продуктов горения", ""));

            RepListOutput.Add(new Gorenie.cReportList("Количество CO2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_CO2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество SO2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_SO2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2O в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_H2O_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество N2 в продуктах горения, м3/м3 топлива", Math.Round(gor.get_Vo_N2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество CO в продуктах горения (диссоциация CO2), м3/м3 топлива", Math.Round(gor.get_Vo_CO_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2 в продуктах горения (диссоциация H2O), м3/м3 топлива", Math.Round(gor.get_Vo_H2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество O2 в продуктах горения (диссоциация CO2 и H2O), м3/м3 топлива", Math.Round(gor.get_Vo_O2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Теоретический объем продуктов горения, м3/м3 топлива", Math.Round(gor.get_Vo_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Практический выход N2 при избытке окислителя, м3/м3", Math.Round(gor.get_V_alfa_N2_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество избыточного кислорода в продуктах горения, м3/м3 топлива", Math.Round(gor.get_V_O2_izb_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Действительное количество продуктов горения, м3/м3 топлива", Math.Round(gor.get_V_alfa_G(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Химический состав продуктов горения\nпри alfa = 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO в продуктах горения(диссоциация), %", Math.Round(gor.get_CO_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2 в продуктах горения(диссоциация), %", Math.Round(gor.get_H2_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_R_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая процентная сумма всех компонентов(должна быть =100%)", Math.Round(gor.get_summa_R_G(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Химический состав продуктов горения\nпри alfa > 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO в продуктах горения(диссоциация), %", Math.Round(gor.get_CO_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2 в продуктах горения(диссоциация), %", Math.Round(gor.get_H2_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_R_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая процентная сумма всех компонентов(должна быть =100%)", Math.Round(gor.get_summa_R_G_alfa(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет теплоемкости топлива и воздуха", ""));

            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость газообразного топлива, кДж/(м3*°С)", Math.Round(gor.get_c_topl_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость воздуха, кДж/(м3*°С)", Math.Round(gor.get_c_vozd_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Воздух в ПГ, %", Math.Round(gor.get_vozd_vPG_G(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет энтальпий продуктов горения\nпри alfa = 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Химическая энтальпия топлива, кДж/м3", Math.Round(gor.get_i_him_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_topl_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_t_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Энтальпия химического недожога, кДж/м3", Math.Round(gor.get_i_3_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_G(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет энтальпий продуктов горения\nпри alfa > 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Химическая энтальпия топлива, кДж/м3", Math.Round(gor.get_i_him_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_topl_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_t_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Энтальпия химического недожога, кДж/м3", Math.Round(gor.get_i_3_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_G_alfa(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет температуры горения\nпри alfa = 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Теоретическая, °С", Math.Round(gor.get_temp_ter_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Балансовая, °С", Math.Round(gor.get_temp_balans_G(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_G(), 2).ToString()));

            RepListOutput.Add(new Gorenie.cReportList("Расчет температуры горения\nпри alfa > 1", ""));

            RepListOutput.Add(new Gorenie.cReportList("Теоретическая, °С", Math.Round(gor.get_temp_ter_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Балансовая, °С", Math.Round(gor.get_temp_balans_G_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_G_alfa(), 2).ToString()));
            #endregion -- Output

            // Указать отчету источники данных                
            frmRpt.cReportInputBindingSource.DataSource = RepListInput;
            frmRpt.cReportOutputBindingSource.DataSource = RepListOutput;

            // Показать окно отчета на весь экран
            frmRpt.WindowState = FormWindowState.Maximized;
            frmRpt.ShowDialog(this);
        }

        private void btnReportTverd_Click(object sender, EventArgs e)
        {
            frmRptTverd = new frmReportTverd();
            List<cReportList> RepListInput = new List<cReportList>();
            #region >> Input
            RepListInput.Add(new Gorenie.cReportList("Содержание углерода в топливе, %", gor.C.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание водорода в топливе, %", gor.H.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание серы в топливе, %", gor.S.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание азота в топливе, %", gor.N.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание кислорода в топливе, %", gor.O.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание влаги в топливе, масс. %", gor.Wр.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Содержание золы в топливе, масс. %", gor.Aр.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Проверка процентной суммы всех компонентов", gor.summaT.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Температура подогрева воздуха перед горением, °С", gor.t_vT.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Температура подогрева топлива перед горением (вводить только для мазута !), °С", gor.t_tT.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Коэффициент расхода воздуха на горение", gor.alfaT.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Механический недожог топлива, % к теплоте сгорания топлива", gor.M_nedojog.ToString()));
            RepListInput.Add(new Gorenie.cReportList("Влагосодержание воздуха, г/м3 сухого воздуха", gor.gT.ToString()));
            #endregion

            List<cReportList> RepListOutput = new List<cReportList>();
            #region >> Output

            RepListOutput.Add(new Gorenie.cReportList("Расчет количества окислителя", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Количество необходимого кислорода для окисления всех горючих компонентов топлива, м3 / кг", Math.Round(gor.get_V_O2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Теоретический расход сухого воздуха, м3/кг", Math.Round(gor.get_Lo_s_v_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Теоретический расход влажного воздуха, м3/кг", Math.Round(gor.get_Lo_v_v_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_L_alfa_v_v_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет количества продуктов горения\nпри alfa = 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Количество CO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество SO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_SO2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2O в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2O_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество N2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_N2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество CO в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество O2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_O2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_Vo_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет количества продуктов горения\nпри alfa > 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Количество CO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_CO2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество SO2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_SO2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2O в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_H2O_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество N2 в продуктах горения, м3/кг топлива", Math.Round(gor.get_Vo_N2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество CO в продуктах горения(диссоциация CO2), м3/кг топлива", Math.Round(gor.get_Vo_CO_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество H2 в продуктах горения(диссоциация H2O), м3/кг топлива", Math.Round(gor.get_Vo_H2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество O2 в продуктах горения(диссоциация CO2 и H2O), м3/кг топлива", Math.Round(gor.get_Vo_O2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Количество избыточного кислорода в продуктах горения, м3/кг топлива", Math.Round(gor.get_V_O2_izb_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Действительный расход влажного воздуха, м3/кг", Math.Round(gor.get_V_alfa_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Химический состав  и теплоемкость продуктов горения\nпри alfa = 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO в продуктах горения, %", Math.Round(gor.get_CO_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2 в продуктах горения, %", Math.Round(gor.get_H2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая процентная сумма всех компонентов (должна быть 100%)", Math.Round(gor.get_summa_R_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Химический состав  и теплоемкость продуктов горения\nпри alfa > 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO2 в продуктах горения, %", Math.Round(gor.get_CO2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание SO2 в продуктах горения, %", Math.Round(gor.get_SO2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2O в продуктах горения, %", Math.Round(gor.get_H2O_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание N2 в продуктах горения, %", Math.Round(gor.get_N2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание CO в продуктах горения, %", Math.Round(gor.get_CO_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание H2 в продуктах горения, %", Math.Round(gor.get_H2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание O2 в продуктах горения, %", Math.Round(gor.get_O2_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая процентная сумма всех компонентов (должна быть 100%)", Math.Round(gor.get_summa_R_T_alfa(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет теплоемкости топлива и воздуха", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_c_topl_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость воздуха, кДж/(м3*°С)", Math.Round(gor.get_c_vozd_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Содержание воздуха в продуктах горения, %", Math.Round(gor.get_vozd_pg_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет энтальпий продуктов горения\nпри alfa = 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_him_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_top_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_3_i_4_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет энтальпий продуктов горения\nпри alfa > 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_him_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого топлива, кДж/м3", Math.Round(gor.get_i_top_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Физическая энтальпия подогретого воздуха, кДж/м3", Math.Round(gor.get_i_vozd_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая (теоретическая) энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Удельная теплоемкость топлива (только для мазута !), кДж/(кг*°С)", Math.Round(gor.get_i_3_i_4_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Общая балансовая энтальпия продуктов горения, кДж/м3", Math.Round(gor.get_i_count_b_T_alfa(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет температуры горения\nпри alfa = 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Теоретическая, °С", Math.Round(gor.get_temp_ter_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Балансовая, °С", Math.Round(gor.get_temp_balans_T(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_T(), 2).ToString()));
            
            RepListOutput.Add(new Gorenie.cReportList("Расчет температуры горения\nпри alfa > 1", ""));
            
            RepListOutput.Add(new Gorenie.cReportList("Теоретическая, °С", Math.Round(gor.get_temp_ter_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_ter_celFunc_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Балансовая, °С", Math.Round(gor.get_temp_balans_T_alfa(), 2).ToString()));
            RepListOutput.Add(new Gorenie.cReportList("Целевая функция (=0)", Math.Round(gor.get_temp_balans_celFunc_T_alfa(), 2).ToString()));

            #endregion

            frmRptTverd.cReportInputBindingSource.DataSource = RepListInput;
            frmRptTverd.cReportOutputBindingSource.DataSource = RepListOutput;

            frmRptTverd.WindowState = FormWindowState.Maximized;
            frmRptTverd.ShowDialog(this);

        }
        private System.Windows.Forms.Form displayForm_ = null;
        private void btnGraphGaz_Click(object sender, EventArgs e)
        {
            displayForm_ = new PlotSurface2DDemo(gor);
            displayForm_.ShowDialog();
        }

        private void FormOptionDefault()
        {
            // Установить редактируемый объект в PropertyGrid
            ptGridGaz.SelectedObject = new DataInputGaz(gor);
            ptGridTverd.SelectedObject = new DataInputTverd(gor);
        }
        private void ProgramExit()
        {
            string path = Application.UserAppDataPath.ToString();

            // Сохранить данные объекта на диск для последующего вызова
            gor.SaveData(gor, path + @"\\default.xml");

            #region -- сохранить параметры отчета в файле: исходные данные в отчет
            XmlSerializer xmls = new XmlSerializer(typeof(List<Gorenie.Param>));
            FileStream fs = null;
            try
            {
                fs = new FileStream("cfgInputToRep.xml", FileMode.Create);
                xmls.Serialize(fs, _allParamsInput);
            }
            catch
            {
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            #endregion


            #region -- сохранить параметры отчета в файле: результаты в отчет
            XmlSerializer xmlsOut = new XmlSerializer(typeof(List<Gorenie.Param>));
            FileStream fsOut = null;
            try
            {
                fsOut = new FileStream("cfgOutputToRep.xml", FileMode.Create);
                xmlsOut.Serialize(fsOut, _allParamsOutput);
            }
            catch
            {
            }
            finally
            {
                if (fsOut != null) fsOut.Close();
            }
            #endregion -- сохранить параметры отчета в файле: исходные данные в отчет

            Application.Exit();
        }
    }
}