using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommnad : IRequest
    {
        public string Name { get; set; }
    }
}
