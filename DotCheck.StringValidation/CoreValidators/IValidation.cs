namespace DotCheck.StringValidation.CoreValidators;

public interface IValidation
{
    bool Validate(object? value);
}