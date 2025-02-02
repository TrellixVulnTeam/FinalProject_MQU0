﻿using Dapper;
using First.Core.Common;
using LMS.Core.DTO;
using LMS.Core.Repository;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;
        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool InsertCategory(Category category)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@employeeId", category.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add("@image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertCategory", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool InsertComment(Comment comment)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Description", comment.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@SectionId", comment.SectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@CourseId", comment.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@traineeId", comment.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertComment", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool InsertTag(Tag tag)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_TagName",tag.TagName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@P_CreatedBy",tag.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertTag", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool InsertCourse(Course course)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CourseName", course.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@CourseDescription", course.CourseDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@passMark", course.PassMark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@CoursePrice", course.CoursePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
            queryParameters.Add("@TypeId", course.TypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Image", course.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@PreviewVideoUrl", course.PreviewVideoUrl, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@LevelId", course.LevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@CategoryId", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@TagId", course.TagId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@employeeId", course.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertCourse", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool InsertTopic(Topic topic)
        {

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_TopicName", topic.TopicName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@P_CourseId", topic.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@P_Description", topic.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@P_CreatedBy", topic.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertTopic", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool InsertCoupon(Coupon coupon)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Code",coupon.Code, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@StartDate",coupon.StartDate , dbType: DbType.DateTime, direction: ParameterDirection.Input);
            queryParameters.Add("@EndDate", coupon.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            queryParameters.Add("@Redemption",coupon.Redemption , dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Discount",coupon.Discount , dbType: DbType.Double, direction: ParameterDirection.Input);
            queryParameters.Add("@courseId",coupon.CourseId , dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@employeeId",coupon.CreatedBy , dbType: DbType.Int64, direction: ParameterDirection.Input);

            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertCoupon", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool InsertCourseRate(CourseRating courseRating)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@star", courseRating.NoOfStar, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@notes", courseRating.RateNote, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@sectionId", courseRating.SectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@TraineeId", courseRating.TraineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertCourseRating", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@recordId", categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteCategory", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteComment(int commentId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@recordId", commentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteComment", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCoupon(int couponId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@recordId", couponId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteCoupon", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCourse(int courseId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@recordId", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteCourse", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteTag(int tagId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_TagId", tagId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteTag", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteTopic(int topicId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_Id", topicId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteTopic", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Category> GetAllCategories(int queryCode)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Query_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("ReturnCategory", queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Comment> GetAllCommentForCourse(int queryCode)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Query_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            IEnumerable<Comment> result = _dbContext.Connection.Query<Comment>("ReturnComment", queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<CommentDTO> ReturnAllComments(int courseId, int queryCode)
        {
            var parm = new DynamicParameters();
            
            parm.Add("@QueryCode", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parm.Add("@RecordId", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CommentDTO> result = _dbContext.Connection.Query<CommentDTO>("ReturnAllComments", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetAllCourse(int queryCode)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Query_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>("ReturnCourse", queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //need edit
        public List<Tag> GetAllTags()
        {
            IEnumerable<Tag> result = _dbContext.Connection.Query<Tag>("ReturnAllTag", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //need edit
        public List<Topic> GetCourseTopic(int courseId)
            
        {
           var queryParameters = new DynamicParameters();
            queryParameters.Add("@CourseId", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Topic> result = _dbContext.Connection.Query<Topic>("ReturnAllTopicForCourse",queryParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CouponDTO> ReturnAllCoupon(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<CouponDTO> result = _dbContext.Connection.Query<CouponDTO>("ReturnAllCoupon", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Coupon> GetAllCoupons(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@Query_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Coupon> result = _dbContext.Connection.Query<Coupon>("ReturnCoupon", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCategory(Category category)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CategoryId", category.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@Image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            // queryParameters.Add("@IsActive", category.IsActive, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateCategory", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateComment(Comment comment)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CommentId", comment.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Description", comment.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@IsActive", comment.IsActive, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateComment", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCoupon(Coupon coupon)
        {
            var queryParameters = new DynamicParameters();
            
            queryParameters.Add("@couponId", coupon.CouponId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Code", coupon.Code, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@StartDate", coupon.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            queryParameters.Add("@EndDate", coupon.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            queryParameters.Add("@Redemption", coupon.Redemption, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@Discount", coupon.Discount, dbType: DbType.Double, direction: ParameterDirection.Input);
            queryParameters.Add("@courseId", coupon.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@IsActive", coupon.IsActive, dbType: DbType.Boolean, direction: ParameterDirection.Input);


            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateCoupon", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCourse(Course course)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CourseId", course.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@name", course.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@description", course.CourseDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@pass", course.PassMark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@price", course.CoursePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
            queryParameters.Add("@typeId", course.TypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@tagId", course.TagId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@levelId", course.LevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@categoryId", course.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@image", course.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@video", course.PreviewVideoUrl, dbType: DbType.String, direction: ParameterDirection.Input);

            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateCourse", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCourseRating(CourseRating courseRating)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@NoOfStar", courseRating.NoOfStar, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@RateNote", courseRating.RateNote, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@CourseRatingId", courseRating.CourseRatingId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateCourseRating", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateTopic(Topic topic)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_Id", topic.TopicId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add("@P_TopicName", topic.TopicName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@P_Description", topic.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@P_CourseId", topic.CourseId, dbType: DbType.Int16, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("UpdateTopic", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool InsertType(Data.Type type)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@p_TypeName", type.TypeName, dbType: DbType.String, direction: ParameterDirection.Input);
            queryParameters.Add("@p_CreatedBy",type.CreatedBy , dbType: DbType.Int64, direction: ParameterDirection.Input);
           

            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("InsertType", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteType(int typeId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@P_TypeId", typeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //execute proc
            var result = _dbContext.Connection.ExecuteAsync("DeleteType", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Data.Type> GetAllType()
        {

            IEnumerable<Data.Type> result = _dbContext.Connection.Query<Data.Type>("ReturnAllType", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CourseRatingDTO> ReturnAllCourseRating(int sectionId)
        {
            var Parameter = new DynamicParameters();
            Parameter.Add("@SectionId", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseRatingDTO> result = _dbContext.Connection.Query<CourseRatingDTO>("ReturnAllCourseRating", Parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<CourseRating> GetCourseRatings(int courseId)
        {
            var Parameter = new DynamicParameters();
            Parameter.Add("@courseId", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseRating> result = _dbContext.Connection.Query<CourseRating>("ReturnCourseRating", Parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CourseDTO> ReturnAllCourses(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseDTO> result = _dbContext.Connection.Query<CourseDTO>("ReturnAllCourses", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool DeleteLevel(int levelId)
        {
            var parm = new DynamicParameters();
            parm.Add("@LevelId", levelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("DeleteLevel", parm, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool InsertLevel(Level level)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", level.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@CreatedBy", level.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("InsertLevel", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Level> ReturnLevel(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Level> result = _dbContext.Connection.Query<Level>("ReturnLevel", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateLevel(Level level)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LevelId", level.LevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@Name", level.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@IsActive", level.IsActive, dbType: DbType.Boolean, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("UpdateLevel", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool ChangeCouponStatus(int couponId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CouponId", couponId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("ChangeCouponStatus", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
