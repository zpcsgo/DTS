using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ActiveSmallClass
    {
        public Guid id { get; set; }
        public string name { get; set; }
        private List<string> _triggers;

        public List<string> triggers
        {
            get
            {
                if (_triggers == null)
                {
                    _triggers = new List<string>();
                }
                return _triggers;
            }
            set { _triggers = value; }
        }

    }
}
