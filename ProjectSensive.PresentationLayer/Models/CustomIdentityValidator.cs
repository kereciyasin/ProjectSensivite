using Microsoft.AspNetCore.Identity;

namespace ProjectSensive.PresentationLayer.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Das Passwort muss mindestens {length} Zeichen lang sein."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Das Passwort muss mindestens einen Kleinbuchstaben enthalten."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Das Passwort muss mindestens einen Großbuchstaben enthalten."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Das Passwort muss mindestens eine Zahl enthalten."
            };
        }
    }
}
