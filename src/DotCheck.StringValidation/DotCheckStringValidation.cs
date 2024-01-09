namespace DotCheck.StringValidation;

internal sealed class DotCheckStringValidation : IDotCheckStringValidation
{
    public string TextDataForValidation { get; }

    internal DotCheckStringValidation(string textDataForValidation) =>
        TextDataForValidation = textDataForValidation;
}