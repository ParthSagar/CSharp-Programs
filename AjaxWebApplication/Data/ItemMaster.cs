using System;

namespace Data
{
    public class ItemMaster
    {
        public int Id { get; set; }

        public String item { get; set; }
        public int qty { get; set; }
        public DateTime date { get; set; }
        public String phone { get; set; }
        public override string ToString()
        {
            return string.Format("ID={0} item={1} qty={2} date={3} phone={4}", Id, item, qty, date, phone);

        }

    }
}