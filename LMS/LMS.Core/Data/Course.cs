﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.Data
{
    public partial class Course
    {


        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public short PassMark { get; set; }
        public decimal CoursePrice { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }
        public string PreviewVideoUrl { get; set; }
        public int LevelId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Level Level { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<OffLineLecture> OffLineLectures { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Checkout> TraineeBuyCourses { get; set; }
        public virtual ICollection<WishListItem> WishListItems { get; set; }
    }
}
