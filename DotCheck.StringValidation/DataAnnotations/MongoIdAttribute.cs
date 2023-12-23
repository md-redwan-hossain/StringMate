using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class MongoIdAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new MongoIdValidation().Validate(value);
}