using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveAble.Model
{
    public class UserValidator : AbstractValidator<People>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull().Length(10, 20);
            RuleFor(x => x.Password).NotNull().Length(5, 15);
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }
}
