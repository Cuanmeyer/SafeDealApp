using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Model
{
    public class DealGroup
    {
        public int DealGroupId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public List<Deal> Deals
        {
            get;
            set;
        }
    }
}
