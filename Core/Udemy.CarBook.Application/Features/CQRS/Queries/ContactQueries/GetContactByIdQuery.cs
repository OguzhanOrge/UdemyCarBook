﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
