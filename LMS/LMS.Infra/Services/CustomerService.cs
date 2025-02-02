﻿using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Core.Repository;
using LMS.Core.Services;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public bool InsertCart(Cart cart)
        {
            return customerRepository.InsertCart(cart);
        }

        public bool InsertCartItem(CartItem cartItem)
        {
            return customerRepository.InsertCartItem(cartItem);
        }

        public bool DeleteCart(int cartId)
        {
            return customerRepository.DeleteCart(cartId);
        }

        public bool DeleteCartItem(int cartId)
        {
            return customerRepository.DeleteCartItem(cartId);
        }

        public SectionCountDTO ReturnSectionCount(int traineeId, int courseId)
        {
            return customerRepository.ReturnSectionCount(traineeId, courseId);
        }

        public bool InsertCheckout(Checkout checkout)
        {
            return customerRepository.InsertCheckout(checkout);
        }

        public List<Cart> ReturnCart(int queryCode, int trineeId)
        {
            return customerRepository.ReturnCart(queryCode, trineeId);
        }


        public List<Checkout> ReturnCheckout()
        {
            return customerRepository.ReturnCheckout();
        }

        public List<EnrollmentDTO> ReturnEnrollmentCourses(int traineeId)
        {
            return customerRepository.ReturnEnrollmentCourses(traineeId);
        }

        public List<LiveCourseDTO> ReturnLiveCourses(int traineeId)
        {
            return customerRepository.ReturnLiveCourses(traineeId);
        }

        public List<MySectionsDTO> ReturnSection(int traineeId)
        {
            return customerRepository.ReturnSection(traineeId);
        }

        //WishList

        public List<WishList> ReturnWishList(int traineeId)
        {
            return customerRepository.ReturnWishList(traineeId);
        }
        public bool InsertWishList(WishList wishList)
        {
            return customerRepository.InsertWishList(wishList);
        }
        public bool DeleteWishList(int wishListId)
        {
            return customerRepository.DeleteWishList(wishListId);
        }

        //WithListItem

        public bool InsertWishListItem(WishListItem wishListItem)
        {
            return customerRepository.InsertWishListItem(wishListItem);
        }
        public bool DeleteWishListItem(int wishListId, int courseId)
        {
            return customerRepository.DeleteWishListItem(wishListId,courseId);
        }

        public List<SoldCourseDTO> ReturnSoldCourses()
        {
            return customerRepository.ReturnSoldCourses();
        }

        public List<CartItemDTO> ReturnAllCartItem(int traineeId)
        {
            return customerRepository.ReturnAllCartItem(traineeId);
        }

        public List<WishListItemDTO> ReturnWishListItem(int traineeId)
        {
            return customerRepository.ReturnWishListItem(traineeId);
        }


        public List<TraineeAttendanceDTO> ReturnTraineeAttendance(int sectionId, int lectureId)
        {
            return customerRepository.ReturnTraineeAttendance(sectionId, lectureId);
        }

        public TraineeInfoDTO ReturnTraineeInfo(int traineeId)
        {
            return customerRepository.ReturnTraineeInfo(traineeId);
        }


        public Task<bool> InsertTrainee(TraineeInfoDTO trainee)
        {
            return customerRepository.InsertTrainee(trainee);
        }

        //Update Trainee 
        public bool UpdateTrainee(Trainee trainee)
        {
            return customerRepository.UpdateTrainee(trainee);
        }

        //Delete Trainee
        public bool DeleteTrainee(int traineeId)
        {
            return customerRepository.DeleteTrainee(traineeId);
        }


        public bool InsertCertificate(Certificate certificate)
        {
            return customerRepository.InsertCertificate(certificate);
        }

        public bool DeleteCertificate(int certificateId)
        {
            return customerRepository.DeleteCertificate(certificateId);
        }

        public List<Trainee> ReturnTrainee(int queryCode)
        {
            return customerRepository.ReturnTrainee(queryCode);
        }

        public bool StatusStudent(int stdId)
        {
            return customerRepository.StatusStudent(stdId);
        }
    }

}
