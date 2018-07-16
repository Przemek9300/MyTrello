using FluentValidation;
using trelloApi.Command.CommandValidator.CommandValidatorExtensions;
using trelloApi.Services;

namespace trelloApi.Command.CommandValidator
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserService _userService;

        public RegisterCommandValidator(IUserService userService)
        {
            _userService = userService;
            RuleFor(x => x.Email).NotEmpty().WithMessage(ErrorMessage.EmailEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessage.EmailInvalid);
            RuleFor(x => x.Email).Must((x, Email) => !userService.UserExist(Email)).WithMessage(ErrorMessage.EmailExist);

            RuleFor(x => x.Password).Password();
            

            RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage(ErrorMessage.PasswordMatch);



        }
    }
}