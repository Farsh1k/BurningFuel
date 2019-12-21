using System;
using System.Collections.Generic;
using System.Text;

namespace Gorenie
{
    # region <<<< Классы для формирования данных в отчете
    // Базовый класс для заглавия
    public class cReportList
    {
        public cReportList() { }

        public cReportList(string parDesc, string parVar)
        { _parDesc = parDesc; _parVar = parVar; }

        private string _parDesc;
        public string parDesc
        {
            get { return _parDesc; }
            set { _parDesc = value; }
        }

        private string _parVar;
        public string parVar
        {
            get { return _parVar; }
            set { _parVar = value; }
        }

        public string this[int ind]
        {
            get
            {
                switch (ind)
                {
                    case 1:
                        return _parDesc;
                    case 2:
                        return _parVar;
                    default:
                        return "null";
                }
            }
            set
            {
                switch (ind)
                {
                    case 1:
                        _parDesc = value;
                        break;
                    case 2:
                        _parVar = value;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class cReportInput : cReportList
    {
    }
    class cReportOutput : cReportList
    {
    }
    #endregion
    }

