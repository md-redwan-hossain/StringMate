namespace DotCheck.StringValidation.CoreValidators.Interfaces;

public interface IParameterizedValidation<in TParameter> 
    where TParameter : notnull
{
    bool Validate(string value, TParameter parameter);
}