using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApiCoreDemo.Model
{
    public class TicketItemModelValidator : AbstractValidator<TicketItem>
    {
        public TicketItemModelValidator()
        {
            RuleFor(x => x.Concert).NotEmpty();
        }
    }
}
