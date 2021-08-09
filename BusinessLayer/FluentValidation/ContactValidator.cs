using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçerli bir e-mail giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(3).WithMessage("Konu boş geçilemez ve 3 karakterden az konu oluşturulamaz.");
            RuleFor(x => x.Message).NotEmpty().MinimumLength(3).WithMessage("Konu boş geçilemez ve 3 karakterden az konu oluşturulamaz.");

}
    }
}
