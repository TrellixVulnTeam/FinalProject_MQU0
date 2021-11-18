﻿using LMS.Core.DTO;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Services
{
    public interface ISectionService
    {
        public StudentCountDTO ReturnStudentCount(int sectionId);
        //Section

        public Task<bool> AddSection(Section section, int trainerId);

        public Task<bool> UpdateSection(Section section, int trainerId);
        public bool DeleteSection(int SectionId);
        public List<Section> GetAllSection();


        //Trainee Section
        public bool AddTraineeSection(TraineeSection traineeSection);
        public bool DeleteTraineeSection(int traineeSectionId);

        public bool UpdateTraineeSection(TraineeSection traineeSection);
    


        //Trainee Section Task
        public bool InsertTraineeTask(TraineeSectionTask traineeSectionTask);
        public bool UpdateTraineeTask(TraineeSectionTask traineeSectionTask);
        public bool DeleteTraineeSectionTask(int traineeSectionTaskId);


        //Unit
        public bool InsertUnit(Unit unit);
        public bool DeleteUnit(int unitId);

        public List<Unit> ReturnSectionUnits(int sectionId);

        //Status

        public List<Status> GetAllStatus();

        //ReturnAllTrainerSections
        public List<TrainerSectionDTO> ReturnAllTrainerSections(int trainerId);

        //ReturnSectionByCourseId
        public List<SectionByCourseDTO> ReturnSectionByCourseId(int courseId);

        //ReturnSectionOfTrainee
        public List<SectionOfTraineeDTO> ReturnSectionOfTrainee(int traineeId, int sectionId);
       

        //ReturnAllComments
        public List<CommentDTO> ReturnAllComments(int sectionId, int queryCode);

        //ReturnUnitBySectionId
        public List<Unit> ReturnUnitBySectionId(int sectionId);

        public bool InsertTask(Tasks task);

        public bool UpdateTask(Tasks task);



        public List<Tasks> SelectTraineeSectionTaskId();

        //ReturnTasksOfSection
        public List<Tasks> ReturnTasksOfSection(int sectionTrainerId);


        public List<TaskSolutionDTO> ReturnTraineeSolutionOfTask(int taskId, int sectionId);


    }
}
