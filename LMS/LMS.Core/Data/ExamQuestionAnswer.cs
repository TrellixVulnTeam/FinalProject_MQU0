﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Data
{
    public partial class ExamQuestionAnswer
    {
        public int ExamQuestionAnswerId { get; set; }   

        public string Description { get; set; }
        public string correctAnswer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public int examId {  get; set; }

    }
}
