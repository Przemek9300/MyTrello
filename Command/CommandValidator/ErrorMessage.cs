namespace trelloApi.Command.CommandValidator
{
    public static class ErrorMessage
    {
///////////////////////////////////PASSWORD\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public static string PasswordEmpty = "Password cannot be empty";
        public static string PasswordLength = "Password lenght must be greater";
        public static string PasswordUppercaseLetter = "Password should contain uppercase letter";
        public static string PasswordLowercaseLetter = "Password should contain lowercase letter";
        public static string PasswordSpecialCharacter = "Password should contain special character";
        public static string PasswordDigit = "Password should contain digit";
        public static string PasswordMatch = "Password not match";

///////////////////////////////////EMAIL\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public static string EmailEmpty = "Email cannot be empty";
        public static string EmailInvalid = "Empty is not valid";
        public static string EmailExist = "Email already exist";
        public static string EmailNotExist = "Email not exist";






    }
}