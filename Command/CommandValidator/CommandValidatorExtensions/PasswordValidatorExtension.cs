using FluentValidation;

namespace trelloApi.Command.CommandValidator.CommandValidatorExtensions
{
public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
    {
        var options = ruleBuilder
            .NotEmpty().WithMessage(ErrorMessage.PasswordEmpty)
            .MinimumLength(minimumLength).WithMessage(ErrorMessage.PasswordLength)
            .Matches("[A-Z]").WithMessage(ErrorMessage.PasswordUppercaseLetter)
            .Matches("[a-b]").WithMessage(ErrorMessage.PasswordLowercaseLetter)
            .Matches("[0-9]").WithMessage(ErrorMessage.PasswordDigit)
            .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessage.PasswordSpecialCharacter);
        return options;
    }
}
}