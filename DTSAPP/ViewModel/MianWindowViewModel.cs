using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSAPP.ViewModel
{
    public class MianWindowViewModel : Caliburn.Micro.Screen
    {
        private ObservableCollection<DTSModel> _dataList;

        public ObservableCollection<DTSModel> dataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                NotifyOfPropertyChange(nameof(dataList));
            }
        }

    }
}
