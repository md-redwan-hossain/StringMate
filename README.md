`DotCheck.StringValidation` offers a collection of valuable extension methods designed for validating the C# `string`
type, complemented by their corresponding data annotations. These extensions provide enhanced functionality for string
validation in C# applications.

**Example:**

```csharp
IDotCheckStringValidation stringValidator = new DotCheckStringValidation();
var result = stringValidator.IsTimeOf12Hour("06:10 PM", includeSecond: false);
if (result) Console.WriteLine("Yee! Validated");
```

- The instance of `DotCheckStringValidation` should be used as singleton because it only contains static extension
  methods.
- For example, dependency injection configuration of `DotCheckStringValidation` in AspDotnet should be done by the
  following way:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDotCheckStringValidation, DotCheckStringValidation>();
var app = builder.Build();
```

- Then it can be injected into a class by the following way:

```csharp
public class DemoServiceClass
{
  private readonly IDotCheckStringValidation _dotCheckStringValidation;
  
    public DemoServiceClass(IDotCheckStringValidation dotCheckStringValidation)
  {
    _dotCheckStringValidation = dotCheckStringValidation;
  }

}
```