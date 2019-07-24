using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTSAPP.ViewModel
{
    public class DTSModel : Caliburn.Micro.Screen
    {
        private DtsClass _dts;

        public DtsClass Dts
        {
            get { return _dts; }
            set { _dts = value; }
        }
        private string _dtsId;

        public string DTSId
        {
            get { return _dts.DTSId; }
            set
            {
                _dtsId = value;
                NotifyOfPropertyChange(nameof(DTSId));
            }
        }
        public DTSModel(DtsClass dts)
        {
            if (dts != null)
            {
                Type type = dts.GetType();
                PropertyInfo[] piArry = type.GetProperties();
                foreach (var item in piArry)
                {
                    object filedValue = type.GetProperty(item.Name).GetValue(item, null);
                    if (filedValue == null)
                    {
                        type.GetProperty(item.Name).SetValue(Dts, "");
                    }
                    else
                    {
                        type.GetProperty(item.Name).SetValue(Dts, filedValue.ToString());
                    }
                }
            }
        }
    }
}
