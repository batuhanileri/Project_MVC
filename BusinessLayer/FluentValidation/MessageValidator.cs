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
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {


            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Maili  boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu  boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı  boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Başlığı en az 3 karakter olmalı");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir e-mail giriniz");

        }
        
    }
    }

