﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CarBook.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResults
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}