﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Domain.DomainModels
{
    public class EmailMessage : BaseEntity
    {
        public string MailTo { get; set; }
        public string Subject{ get; set; }
        public string Content { get; set; }
        public Boolean Status { get; set; }
    }
}
