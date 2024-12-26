using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Results.SocialMediaResults;

namespace Udemy.CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResults>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
