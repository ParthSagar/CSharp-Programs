using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class ItemMasterList
    {
        public void Add(List<ItemMaster> list)
        {
            MyList = list;
        }

        public List<ItemMaster> MyList { get; set; }
    }
}
