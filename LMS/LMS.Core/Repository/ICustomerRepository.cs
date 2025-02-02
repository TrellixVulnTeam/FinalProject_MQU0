﻿using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ICustomerRepository
    {
        //Cart

        public List<Cart> ReturnCart(int queryCode, int trineeId);
        public bool InsertCart(Cart cart);
        public bool DeleteCart(int cartId);

        //CartItem

        public bool InsertCartItem(CartItem cartItem);

        public bool DeleteCartItem(int cartId);

        //Checkout
        public List<Checkout> ReturnCheckout();
        public bool InsertCheckout(Checkout checkout);
        //public bool DeleteCheckout(int checkoutId);

        //ReturnSoldCourses
        public List<SoldCourseDTO> ReturnSoldCourses();

        //Return Enrollment
        public List<EnrollmentDTO> ReturnEnrollmentCourses(int traineeId);
        // Return Live Course 
        public List<LiveCourseDTO> ReturnLiveCourses(int traineeId);

        public List<MySectionsDTO> ReturnSection(int traineeId);

        //GetSectionCount
        public SectionCountDTO ReturnSectionCount(int traineeId,int courseId);


        //WishList

        public List<WishList> ReturnWishList(int traineeId);
        public bool InsertWishList(WishList wishList);
        public bool DeleteWishList(int wishListId);

        //WithListItem

        public bool InsertWishListItem(WishListItem wishListItem);
        public bool DeleteWishListItem(int wishListId,int courseId);


        //ReturnAllCartItem
        public List<CartItemDTO> ReturnAllCartItem(int traineeId);


        //ReturnWishListItem
        public List<WishListItemDTO> ReturnWishListItem(int traineeId);



        //ReturnTraineeAttendance
        public List<TraineeAttendanceDTO> ReturnTraineeAttendance(int sectionId, int lectureId);

        //ReturnTraineeInfo
        public TraineeInfoDTO ReturnTraineeInfo(int traineeId);


        public List<Trainee> ReturnTrainee(int queryCode);

        // Add New Trainee 
        //public bool InsertTrainee(TraineeInfoDTO trainee);
        public Task<bool> InsertTrainee(TraineeInfoDTO trainee);

        //Update Trainee 
        public bool UpdateTrainee(Trainee trainee);

        //Delete Trainee
        public bool DeleteTrainee(int traineeId);

        //Insert Certificate

        public bool InsertCertificate(Certificate certificate);

        public bool DeleteCertificate(int certificateId);
        public bool StatusStudent(int stdId);
    }

}
