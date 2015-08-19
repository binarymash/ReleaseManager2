using FluentValidation;
using Tracker = ReleaseManager.Api.Host.Representations.Tracker;

namespace ReleaseManager.Api.Host.Validators
{
    public class TrackerValidator : AbstractValidator<Tracker>
    {
        public TrackerValidator()
        {
            RuleSet("create", () =>
            {

            });
        }
    }
}
