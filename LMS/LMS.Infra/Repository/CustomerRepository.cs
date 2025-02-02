﻿using Dapper;
using First.Core.Common;
using LMS.Core.Data;
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
    public class CustomerRepository : ICustomerRepository
    {
        private IDbContext dBContext;
        public CustomerRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool InsertCart(Cart cart)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_TraineeId", cart.TraineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("InsertCart", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<Cart> ReturnCart(int queryCode, int trineeId)
        {
            var parm = new DynamicParameters();

            parm.Add("@Query_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parm.Add("@P_TraineeId", trineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Cart> result = dBContext.Connection.Query<Cart>("ReturnCart", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool InsertCartItem(CartItem cartItem)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_CartId", cartItem.CartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_CourseID", cartItem.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("InsertCartItem", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCart(int cartId)
        {
            var parm = new DynamicParameters();
            parm.Add("@recordId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteCart", parm, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCartItem(int cartId)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CartItemId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dBContext.Connection.ExecuteAsync("DeleteCartItem", parm, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool InsertCheckout(Checkout checkout)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CartId", checkout.CartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("InsertCheckout", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public SectionCountDTO ReturnSectionCount(int traineeId, int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TraineeId",traineeId , dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@CourseId",courseId , dbType: DbType.Int32, direction: ParameterDirection.Input);
            SectionCountDTO result = dBContext.Connection.QuerySingle<SectionCountDTO>("ReturnMyNewestCourse",parameters, commandType: CommandType.StoredProcedure);
            return result;

        }

        public List<Checkout> ReturnCheckout()
        {

            IEnumerable<Checkout> result = dBContext.Connection.Query<Checkout>("ReturnCheckout", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<EnrollmentDTO> ReturnEnrollmentCourses(int traineeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<EnrollmentDTO> result = dBContext.Connection.Query<EnrollmentDTO>("ReturnMyOwnCourses", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public List<LiveCourseDTO> ReturnLiveCourses(int traineeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LiveCourseDTO> result = dBContext.Connection.Query<LiveCourseDTO>("ReturnMyLiveSection", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MySectionsDTO> ReturnSection(int traineeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MySectionsDTO> result = dBContext.Connection.Query<MySectionsDTO>("ReturnMyOwnSection", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //WishList

        public List<WishList> ReturnWishList(int traineeId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@P_TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<WishList> result = dBContext.Connection.Query<WishList>("ReturnWishlist", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool InsertWishList(WishList wishList)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_TraineeId", wishList.TraineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("InsertWishlist", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteWishList(int wishListId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_WishListId", wishListId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteWishlist", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        //WithListItem

        public bool InsertWishListItem(WishListItem wishListItem)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_WishListId", wishListItem.WishListId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_CourseId", wishListItem.CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_CreatedBy", wishListItem.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("InsertWishlistItem", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteWishListItem(int wishListId, int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@P_CourseId", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_WishListId", wishListId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteWishlistItem", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<SoldCourseDTO> ReturnSoldCourses()
        {
            IEnumerable<SoldCourseDTO> result = dBContext.Connection.Query<SoldCourseDTO>("ReturnSoldCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CartItemDTO> ReturnAllCartItem(int traineeId)
        {
            var parm = new DynamicParameters();
            parm.Add("@TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<CartItemDTO> result = dBContext.Connection.Query<CartItemDTO>("ReturnAllCartItem", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<WishListItemDTO> ReturnWishListItem(int traineeId)
        {
            var parm = new DynamicParameters();
            parm.Add("@TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<WishListItemDTO> result = dBContext.Connection.Query<WishListItemDTO>("ReturnWishListItem", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }




        public List<CouponDTO> ReturnAllCoupon(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<CouponDTO> result = dBContext.Connection.Query<CouponDTO>("ReturnAllCoupon", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<TraineeAttendanceDTO> ReturnTraineeAttendance(int sectionId, int lectureId)
        {
            var parm = new DynamicParameters();
            parm.Add("@SectionId", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parm.Add("@LectureId", lectureId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TraineeAttendanceDTO> result = dBContext.Connection.Query<TraineeAttendanceDTO>("ReturnTraineeAttendance", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TraineeInfoDTO ReturnTraineeInfo(int traineeId)
        {
            var parm = new DynamicParameters();
            parm.Add("@TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            TraineeInfoDTO result = dBContext.Connection.QuerySingle<TraineeInfoDTO>("ReturnTraineeInfo", parm, commandType: CommandType.StoredProcedure);
            return result;
        }


        public List<Trainee> ReturnTrainee(int queryCode)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_CODE", queryCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Trainee> result = dBContext.Connection.Query<Trainee>("ReturnTrainee", parm, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        // Add New Trainee 
        public async Task<bool> InsertTrainee(TraineeInfoDTO trainee)
        {

            var parm = new DynamicParameters();
            parm.Add("@P_FirstName", trainee.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_LastName", trainee.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_PhoneNumber", trainee.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_Nationality", trainee.Nationality, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_Email", trainee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_ImageName", trainee.ImageName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await dBContext.Connection.ExecuteAsync("InsertTrainee", parm, commandType: CommandType.StoredProcedure);



            var traineeId = ReturnTrainee(1).OrderByDescending(x => x.TraineeId).FirstOrDefault().TraineeId;

            var parameters = new DynamicParameters();
            parameters.Add("@username", trainee.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@pass", trainee.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@P_EmployeeId", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@P_RoleId", trainee.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result1 = await dBContext.Connection.ExecuteAsync("InsertLogin", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        //Update Trainee 
        public bool UpdateTrainee(Trainee trainee)
        {
            var parm = new DynamicParameters();
            parm.Add("@P_TraineeId", trainee.TraineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parm.Add("@P_FirstName", trainee.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_LastName", trainee.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_PhoneNumber", trainee.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_Nationality", trainee.Nationality, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_Email", trainee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_ImageName", trainee.ImageName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("UpdateTrainee", commandType: CommandType.StoredProcedure);
            return true;
        }

        //Delete Trainee
        public bool DeleteTrainee(int traineeId)
        {
            var parm = new DynamicParameters();

            parm.Add("@P_TraineeId", traineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteTrainee", commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool AddThing()
        {
            return false;
        }
        public bool InsertCertificate(Certificate certificate)
        {
            var parm = new DynamicParameters();

            parm.Add("@P_CertificatePath", certificate.CertificatePath, dbType: DbType.String, direction: ParameterDirection.Input);
            parm.Add("@P_TraineeId", certificate.TraineeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.Connection.ExecuteAsync("InsertCertificate", commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCertificate(int certificateId)
        {
            var parm = new DynamicParameters();

            parm.Add("@P_CertificateId", certificateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("DeleteCertificate", commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool StatusStudent(int stdId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@traineeId", stdId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("ChangeTraineeStatus", queryParameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }

}
