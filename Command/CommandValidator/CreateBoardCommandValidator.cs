using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trelloApi.Services;

namespace trelloApi.Command.CommandValidator
{
    public class CreateBoardCommandValidator : AbstractValidator<CreateBoardCommand>
    {
        private readonly IUserService _userSerivce;
        public CreateBoardCommandValidator(IUserService userService)
        {
            _userSerivce = userService;
            RuleFor(x => x.Title).NotEmpty().WithMessage(ErrorMessage.BoardTitleEmpty);
            //RuleFor(x => x.Title).Must((x,Title) => !userService.BoardIsUnique(x)).WithMessage(ErrorMessage.BoardTitleExist);



        }
    }
}
