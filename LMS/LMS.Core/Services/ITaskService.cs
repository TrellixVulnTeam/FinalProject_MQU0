﻿using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.Core.Services
{
    public interface ITaskService
    {
        public Task AddTask(Task task);
        public List<Task> ReturnAllTask();
        public Task UpdateTask(Task task);




        public TraineeSectionTask AddTraineeSectionTaskId(TraineeSectionTask traineeSectionTask);
        public TraineeSectionTask UpdateTraineeSectionTaskId(TraineeSectionTask traineeSectionTask);
        public TraineeSectionTask SelectTraineeSectionTaskId();



    }
}
