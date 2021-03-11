using ControloFinanceiro.BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControloFinanceiro.API.Validacoes
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Prencha o nome")
                .NotEmpty().WithMessage("Prencha o nome")
                .MaximumLength(50).WithMessage("Utilize no máximo 50 caracteres")
                .MinimumLength(6).WithMessage("Utilize mais caracteres");

            RuleFor(c => c.Icone)
                .NotNull().WithMessage("Prencha o icone")
                .NotEmpty().WithMessage("Prencha o icone")
                .MaximumLength(15).WithMessage("Utilize no máximo 15 caracteres")
                .MinimumLength(1).WithMessage("Utilize mais caracteres");

            RuleFor(c => c.TipoId)
                .NotNull().WithMessage("Escolha o tipo da categoria")
                .NotEmpty().WithMessage("Escolha o tipo da categoria");


        }
    }
}
