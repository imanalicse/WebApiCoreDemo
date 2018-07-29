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
            RuleFor(x => x.Artist).NotEmpty().WithMessage("Artist is required");
            RuleFor(x => x.postCode)
                .Must((x, y) => IsValidPostCode(x))
                .WithMessage("'Post Code' must be 4 digits.");
        }

        private bool IsValidPostCode(TicketItem command)
        {
            if (command.postCode.ToString().Length != 4)
            {
                return false;
            }

            return true;
        }
    }
}
