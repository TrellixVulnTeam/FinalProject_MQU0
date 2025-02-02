﻿using LMS.Core.DTO;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IContactUsRepository
    {
        //Contact us
        public List<ContactUs> ReturnMessage(int queryCode);
        public bool InsertMessage(ContactUs contactUs);
        public bool UpdateMessage(ContactUs contactUs);
        public bool DeleteMessage(int messageId);

        // Testimonails 
        public bool InsertTestimonials(Testimonial testimonial);
        public bool UpdateTestimonial(Testimonial testimonial);
        public bool DeleteTestimonial(int testimonialId);

        public List<UserTestimonailsDTO>GetUserTestimonails(int queryID);
    }
}
