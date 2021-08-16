using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir e-mail giriniz");
            //RuleFor(x => x.PasswordSalt).NotEmpty().WithMessage("Parola alanı boş geçilemez!").Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");

        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
