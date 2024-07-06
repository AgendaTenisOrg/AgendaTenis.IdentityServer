﻿using FluentValidation;

namespace AgendaTenis.IdentityServer.Core.Validators;

public class EmailValidator : AbstractValidator<string?>
{
    public EmailValidator()
    {
        RuleFor(email => email)
                .NotNull()
                .WithMessage("E-mail deve ser preenchido.")
                .EmailAddress()
                .WithMessage("O e-mail não é válido.");
    }

    protected override void EnsureInstanceNotNull(object instanceToValidate)
    {
    }
}
