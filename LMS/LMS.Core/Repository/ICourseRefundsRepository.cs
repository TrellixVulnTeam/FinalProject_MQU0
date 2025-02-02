﻿using LMS.Core.DTO;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ICourseRefundsRepository
    {
        public bool InsertCourseRefunds(CourseRefund courseRefund);
        public bool UpdateCourseRefunds(CourseRefund courseRefund);
        public bool DeleteCourseRefunds(int courseRefundId);

        public List<CourseRefundDTO> ReturnCourseRefund(int traineeId);
        public List<RefundReason> ReturnRefundReason(int queryCode);
        public bool InsertRefundReason(RefundReason refundReason);
        public bool UpdateRefundReason(RefundReason refundReason);
        public bool DeleteRefundReason(int reasonId);


        public bool ApproveRefundReason(int CourseRefundsId);

    }
}
