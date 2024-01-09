namespace DotCheck.StringValidation;

public sealed class DotCheckStringValidation : IDotCheckStringValidation
{
    public string TextDataForValidation { get; }

    internal DotCheckStringValidation(string textDataForValidation) =>
        TextDataForValidation = textDataForValidation;
}