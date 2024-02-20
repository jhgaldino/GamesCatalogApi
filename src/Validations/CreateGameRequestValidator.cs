using FluentValidation;
using GamesCatalogApi.Dtos;

namespace GamesCatalogApi.Validations
{
    // Você pode usar essa classe para definir as validações por exemplo.
    public class CreateGameRequestValidator : AbstractValidator<CreateGameRequest>
    {
        public CreateGameRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage("Titulo é obrigatório"); // A mensagem acaba sendo opcional se você usar a versão pt-br
        }
    }
}
