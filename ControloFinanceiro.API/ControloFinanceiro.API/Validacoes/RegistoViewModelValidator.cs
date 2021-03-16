using ControloFinanceiro.API.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControloFinanceiro.API.Validacoes
{
    public class RegistoViewModelValidator : AbstractValidator<RegistoViewModel>
    {
        public RegistoViewModelValidator()
        {
            RuleFor(r => r.NomeUtilizador)
                .NotNull().WithMessage("Insira o nome de utilizador")
                .NotEmpty().WithMessage("Insira o nome de utilizador")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caracteres");

            RuleFor(r => r.CodigoPostal)
                .NotNull().WithMessage("Insira o codigo postal")
                .NotEmpty().WithMessage("Insira o codigo postal")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(20).WithMessage("Use menos caracteres");

            RuleFor(r => r.Pofissao)
                .NotNull().WithMessage("Insira a profissão")
                .NotEmpty().WithMessage("Insira a profissão")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(30).WithMessage("Use menos caracteres");

            RuleFor(r => r.Foto)
               .NotNull().WithMessage("Escolha a sua foto")
               .NotEmpty().WithMessage("Escolha a sua foto");

            RuleFor(r => r.Email)
                .NotNull().WithMessage("Insira o email")
                .NotEmpty().WithMessage("Insira o email")
                .MinimumLength(10).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caracteres")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(r => r.PasswordUtl)
                .NotNull().WithMessage("Insira a password")
                .NotEmpty().WithMessage("Insira a password")
                .MinimumLength(6).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caracteres");
        }
    }
}
