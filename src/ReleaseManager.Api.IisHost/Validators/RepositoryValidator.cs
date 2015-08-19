using FluentValidation;
using Repository = ReleaseManager.Api.Host.Representations.Repository;

namespace ReleaseManager.Api.Host.Validators
{
    public class RepositoryValidator : AbstractValidator<Repository>
    {
        public RepositoryValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(r => r.Path).NotNull().Length(1, 1024).WithMessage("Path length must be between 1 and 1024 characters");
            });
        }
    }
}
