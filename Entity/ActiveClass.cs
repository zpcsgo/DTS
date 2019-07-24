using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ActiveClass
    {
        public Guid id { get; set; }
        public string name { get; set; }
        private List<ActiveSmallClass> _smList;

        public List<ActiveSmallClass> smList
        {
            get
            {
                if (_smList == null)
                {
                    _smList = new List<ActiveSmallClass>();
                }
                return _smList;
            }
            set { _smList = value; }
        }
    }
}
