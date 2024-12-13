using FluentValidation;

namespace AdventureGameRepo
{
    // Class representing player input
    public class PlayerInput
    {
        public string PlayerName { get; set; }
        public string Action { get; set; }
    }

    // Validator for PlayerInput
    public class PlayerInputValidator : AbstractValidator<PlayerInput>
    {
        public PlayerInputValidator()
        {
            RuleFor(input => input.PlayerName)
                .NotEmpty().WithMessage("Player name must not be empty.")
                .Length(3, 50).WithMessage("Player name must be between 3 and 50 characters.");

            RuleFor(input => input.Action)
                .NotEmpty().WithMessage("Action must not be empty.")
                .Must(action => action == "Attack" || action == "Defend" || action == "UseAbility")
                .WithMessage("Action must be one of the following: Attack, Defend, UseAbility.");
        }
    }

    // Class representing game settings
    public class GameSettings
    {
        public int DifficultyLevel { get; set; }
        public bool EnableSound { get; set; }
    }

    // Validator for GameSettings
    public class GameSettingsValidator : AbstractValidator<GameSettings>
    {
        public GameSettingsValidator()
        {
            RuleFor(settings => settings.DifficultyLevel)
                .InclusiveBetween(1, 5).WithMessage("Difficulty level must be between 1 and 5.");

            RuleFor(settings => settings.EnableSound)
                .NotNull().WithMessage("EnableSound must be specified.");
        }
    }
}
