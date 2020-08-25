using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ServicesReview
    {
        public ServicesReview()
        {
            ReviewItems = new HashSet<ReviewItem>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }
        public string Suggestions { get; set; }
        public string BillNo { get; set; }
        public string CardId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual DuserLogin User { get; set; }
        public virtual ICollection<ReviewItem> ReviewItems { get; set; }
    }
}
