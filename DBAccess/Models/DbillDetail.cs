using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DbillDetail
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid BillId { get; set; }
        public DateTime? BillTime { get; set; }
        public string ItemTitle { get; set; }
        public double? ItemMoney { get; set; }
        public string BillReceipt { get; set; }
        public DateTime? PayTime { get; set; }
        public byte PayType { get; set; }
        public byte BillState { get; set; }
        public bool IsDelete { get; set; }

        public virtual Dbill Bill { get; set; }
    }
}
