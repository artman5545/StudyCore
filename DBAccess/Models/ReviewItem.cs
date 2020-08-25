using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ReviewItem
    {
        public Guid Id { get; set; }
        public int ReviewTypeId { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public Guid ServicesReviewId { get; set; }
        public string ReviewText { get; set; }
        public float Rating { get; set; }

        public virtual ServicesReview ServicesReview { get; set; }
    }
}
