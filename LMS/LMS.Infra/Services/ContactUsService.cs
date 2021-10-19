﻿using LMS.Core.Repository;
using LMS.Core.Services;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Services
{
    public class ContactUsService: IContactUsService
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        public bool DeleteMessage(int messageId)
        {
            return contactUsRepository.DeleteMessage(messageId);
        }

        public bool InsertMessage(ContactUs contactUs)
        {
            return contactUsRepository.InsertMessage(contactUs);
        }

        public List<ContactUs> ReturnMessage(int queryCode)
        {
            return contactUsRepository.ReturnMessage(queryCode);
        }

        public bool UpdateMessage(ContactUs contactUs)
        {
            return contactUsRepository.UpdateMessage(contactUs);
        }
    }
}
