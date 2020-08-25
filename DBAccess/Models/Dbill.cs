using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Dbill
    {
        public Dbill()
        {
            DbillDetails = new HashSet<DbillDetail>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public byte SystemType { get; set; }
        public byte HisBussinessTypeCode { get; set; }
        public DateTime? BillTime { get; set; }
        public string HisBussinessId { get; set; }
        public string HealthCardCode { get; set; }
        public string HealthCardId { get; set; }
        public byte ContentType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string OrderTitle { get; set; }
        public decimal OrderTotal { get; set; }
        public string OutTradeNo { get; set; }
        public DateTime? PayTime { get; set; }
        public int PaymentStatusId { get; set; }
        public int PayType { get; set; }
        public string PrepayId { get; set; }
        public bool IsDelete { get; set; }
        public string PaymentMethodSystemName { get; set; }
        public int OrderStatusId { get; set; }
        public string CredentialContent { get; set; }
        public string HisBussinessNo { get; set; }
        public string Describe { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string Reason { get; set; }
        public string GoTime { get; set; }

        public virtual HisBussinessType HisBussinessTypeCodeNavigation { get; set; }
        public virtual ICollection<DbillDetail> DbillDetails { get; set; }
    }
}
