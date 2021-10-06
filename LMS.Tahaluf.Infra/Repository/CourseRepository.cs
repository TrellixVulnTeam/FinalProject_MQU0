﻿using Dapper;
using LMS.Tahaluf.Core.Common;
using LMS.Tahaluf.Core.Data;
using LMS.Tahaluf.Core.DTO;
using LMS.Tahaluf.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LMS.Tahaluf.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext dBContext;

        public CourseRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Course> GetAllCourse()
        {
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("GetAllCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("@CourseName", course.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Price", course.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@StartDate", course.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@EndDate", course.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("CreateCourse", p, commandType: CommandType.StoredProcedure);
            return true;
        }

 

        public List<Course> GetByCourseName(Course course)
        {
            var p = new DynamicParameters();
            p.Add("@CourseName", course.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("GetByCourseName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetByCourseName(String courseName)
        {
            var p = new DynamicParameters();
            p.Add("@CourseName", courseName, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("GetByCourseName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetByCoursePrice(double price)
        {
            var p = new DynamicParameters();
            p.Add("@Price", price, dbType: DbType.Double, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("GetByCoursePrice", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("@CourseId", course.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CourseName", course.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Price", course.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@StartDate", course.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@EndDate", course.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("UpdateCourse", p, commandType: CommandType.StoredProcedure);
        }
        public bool DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CourseId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteCourse", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Course> GetCourseBetweenDate(SearchBetweenates dates)
        {
            var p = new DynamicParameters();
            p.Add("@DateFrom", dates.dateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateTo", dates.dateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("GetCourseBetweenDate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}