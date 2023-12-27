namespace DotCheck.StringValidation.CoreValidators.Interfaces;

public interface IParameterizedValidation<in TParameter> 
    where TParameter : notnull
{
    bool Validate(object? value, TParameter parameter);
}