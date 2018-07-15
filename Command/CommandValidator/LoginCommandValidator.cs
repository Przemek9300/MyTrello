using FluentValidation;
using trelloApi.Command.CommandValidator.CommandValidatorExtensions;
using trelloApi.Services;

namespace trelloApi.Command.CommandValidator
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUserService _userSerivce;
        public LoginCommandValidator(IUserService userService)
        {
            _userSerivce = userService;
            RuleFor(x => x.Email).NotEmpty().WithMessage(ErrorMessage.EmailEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessage.EmailInvalid);
            RuleFor(x => x.Email).Must((x, Email)=>_userSerivce.UserExist(Email)).WithMessage(ErrorMessage.EmailExist);

            RuleFor(x => x.Password).Password();
        }



    }
}