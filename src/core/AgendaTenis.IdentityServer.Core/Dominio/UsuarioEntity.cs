﻿using AgendaTenis.IdentityServer.Core.Utils;
using AgendaTenis.IdentityServer.Core.Validators;
using FluentValidation;

namespace AgendaTenis.IdentityServer.Core.Dominio;

public class UsuarioEntity
{
    private readonly UsuarioEntityValidator _usuarioEntityValidator = new UsuarioEntityValidator();
    private readonly ISenhaHasher<UsuarioEntity> _hasher;

    private UsuarioEntity() { }

    public UsuarioEntity(string email, string senha, ISenhaHasher<UsuarioEntity> hasher)
    {
        _usuarioEntityValidator.ValidateAndThrow(this);
        _hasher = hasher;

        Email = email;
        Senha = _hasher.HashSenha(this, senha);
    }

    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
}

public class UsuarioEntityValidator : AbstractValidator<UsuarioEntity>
{
    public UsuarioEntityValidator()
    {
        RuleFor(x => x.Email)
            .SetValidator(new EmailValidator());

        RuleFor(x => x.Senha)
            .SetValidator(new SenhaValidator());
    }
}
