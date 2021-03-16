using ControloFinanceiro.API.ViewModels;
using ControloFinanceiro.BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControloFinanceiro.API.Validacoes
{
    public class FuncoesViewModelValidator : AbstractValidator<FuncoesViewModel>
    {
        public FuncoesViewModelValidator()
        {
            RuleFor(f => f.Name)
                .NotNull().WithMessage("Insira a funcão")
                .NotEmpty().WithMessage("Insira a funcão")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(30).WithMessage("Use menos caracteres");

            RuleFor(f => f.Descricao)
                .NotNull().WithMessage("Insira a descriçao")
                .NotEmpty().WithMessage("Insira a descriçao")
                .MinimumLength(1).WithMessage("Use mais caracteres")
                .MaximumLength(50).WithMessage("Use menos caracteres");


        }
    }
}
