﻿using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Services
{
    public interface IExamService
    {
        public List<Exam> ReturnExam(int queryCode, int sectionId);
        public bool InsertExam(Exam exam);
        public bool UpdateExam(Exam exam);
        public bool DeleteExam(int examId);
       
        public bool AddTraineeSectionExam(TraineeSectionExam traineeSectionExam);


        //ExamQuestion
        public List<ExamQuestion> ReturnExamQuestion(int queryCode, int courseId);
        public bool InsertExamQuestion(ExamQuestion examQuestion);
        public bool UpdateExamQuestion(ExamQuestion examQuestion);
        public bool DeleteExamQuestion(int questionId);


        //ExamOption

        public List<ExamOption> ReturnExamOption(int queryCode, int questionId);
        public bool InsertExamOption(ExamOption examOption);
        public bool UpdateExamOption(ExamOption examOption);
        public bool DeleteExamOption(int optionId);

        //ReturnExamBySectionId
        public List<Exam> ReturnExamBySectionId(int sectionId);

        //Section Exam 
        public bool InsertSectionExam(SectionExam sectionExam);

        //SectionExamAnswer
        public bool InsertSectionExamAnswer(SectionExamAnswer sectionExamAnswer);
        public List<TraineeExamMarkDTO> GetExamMarkList(int examId);


        // <---------------------- DTO --------------------------------> 
        public List<GetTraineeMarksDTO> GetTraineeMarks(int sectionId);
        public List<TraineeAnswersDTO> GetTraineeAnswer(int sectionId);

        public List<ExamFormDTO> GetExamForm(int sectionId);

        public List<ExamAnswersDTO> GetExamAnswersDTOs(int sectionId);



        // ExamQuestionANswer
        public bool InsertExamQuestionAnswer(ExamQuestionAnswer examQuestionAnswer);

        public bool DeleteExamQuestionAnswer(int examId);

        public List<ExamQuestionAnswer> ReturnExamQuestionAnswer(int examId);

    }
}
