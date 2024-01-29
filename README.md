`DotCheck.StringValidation` offers a collection of valuable extension methods designed for validating the C# `string`
type, complemented by their corresponding data annotations. These extensions provide enhanced functionality for string
validation in C# applications.

- `DotCheckStringValidation` is a static class which contains all the validation methods.
- Since it is a Static class, garbage collection won't be an issue.
- To install, run `dotnet add package DotCheck.StringValidation` or from
  **[Nuget](https://www.nuget.org/packages/DotCheck.StringValidation/)**

**Example Usage:**

```csharp
using DotCheck.StringValidation;
using DotCheck.StringValidation.Helpers;

var resultOfTimeValidation = DotCheckStringValidation.Is12HourTime("06:10 PM", includeSecond: false);
if (resultOfTimeValidation) Console.WriteLine("Yee! Validated time");



var constructedDateFormat = new DateFormatBuilder()
    .AddDayWithLeadingZero()
    .AddMonthWithLeadingZero()
    .AddYearWithFourDigit()
    .AddHyphenDelimiter()
    .Build();

var resultOfDateValidation = DotCheckStringValidation.IsDate("10-11-2014", dateFormat: constructedDateFormat);
if (resultOfDateValidation) Console.WriteLine("Yee! Validated date");
```

# Available Methods in `DotCheckStringValidation` Class

| Method             | Signature                                                                                                                                                      | Description                                                                                                                                                                                                                                                                          |
|--------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `IsDate`           | `bool IsDate(string text, string dateFormat)`                                                                                                                  | Validates whether the input string represents a valid date. Supports `-` or `/` as delimiter. Use the `DateFormatBuilder` helper class to construct the `dateFormat` parameter. `IDateFormatBuilder` interface is also included for loose coupling and dependency injection purpose. |
| `Is12HourTime`     | `bool Is12HourTime(string text, bool includeSecond)`                                                                                                           | Validates whether the input string represents a valid 12-hour time format.                                                                                                                                                                                                           |
| `Is24HourTime`     | `bool Is24HourTime(string text, bool includeSecond)`                                                                                                           | Validates whether the input string represents a valid 24-hour time format.                                                                                                                                                                                                           |
| `IsStrongPassword` | `IsStrongPassword(string text, int minLength = 8, int minLowercase = 1, int minUppercase = 1, int minNumbers = 1, int minSymbols = 1, int minUniqueChars = 0)` | Validates whether the input string represents a strong password. Default parameters are added for convenience.                                                                                                                                                                       |
| `IsHash`           | `bool IsHash(string text, HashingAlgorithm algorithm)`                                                                                                         | Validates whether the input string represents a valid hash based on the specified hashing algorithm.`HashingAlgorithm` is an enum type.                                                                                                                                              |
| `IsSlug`           | `bool IsSlug(string text)`                                                                                                                                     | Validates whether the input string represents a valid slug.                                                                                                                                                                                                                          |
| `IsMongoId`        | `bool IsMongoId(string text)`                                                                                                                                  | Validates whether the input string represents a valid MongoDB ObjectId.                                                                                                                                                                                                              |
| `IsUuid`           | `bool IsUuid(string text, UuidVersion version)`                                                                                                                | Validates whether the input string represents a valid UUID based on the specified version. `UuidVersion` is an enum type.                                                                                                                                                            |
| `IsJwt`            | `bool IsJwt(string text)`                                                                                                                                      | Validates whether the input string represents a valid JSON Web Token (JWT).                                                                                                                                                                                                          |
| `IsBase64`         | `bool IsBase64(string text, bool checkUrlSafety)`                                                                                                              | Validates whether the input string represents a valid Base64-encoded string, with URL safety check.                                                                                                                                                                                  |
| `IsHexadecimal`    | `bool IsHexadecimal(string text)`                                                                                                                              | Validates whether the input string represents a valid hexadecimal number.                                                                                                                                                                                                            |

# Available Data Annotations based on `DotCheckStringValidation` class

| Attribute                 | Data Annotation                                                                                                                                                        | Description                                                                                                                                                                                                                                                                        |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `HexadecimalAttribute`    | `[Hexadecimal]`                                                                                                                                                        | Specifies that the property value should be a valid hexadecimal number.                                                                                                                                                                                                            |
| `JsonWebTokenAttribute`   | `[JsonWebToken]`                                                                                                                                                       | Specifies that the property value should be a valid JSON Web Token (JWT).                                                                                                                                                                                                          |
| `MongoIdAttribute`        | `[MongoId]`                                                                                                                                                            | Specifies that the property value should be a valid MongoDB ObjectId.                                                                                                                                                                                                              |
| `SlugAttribute`           | `[Slug]`                                                                                                                                                               | Specifies that the property value should be a valid slug.                                                                                                                                                                                                                          |
| `HashAttribute`           | `[Hash(HashingAlgorithm algorithm)]`                                                                                                                                   | Specifies that the property value should be a valid hash based on the specified hashing algorithm.                                                                                                                                                                                 |
| `StrongPasswordAttribute` | `[StrongPassword]` or `[StrongPassword(int minLength = 8, int minLowercase = 1, int minUppercase = 1, int minNumbers = 1, int minSymbols = 1, int minUniqueChars = 0)` | Specifies that the property value should be a valid strong password. Default parameters are added for convenience.                                                                                                                                                                 |
| `DateAttribute`           | `[Date]` or `[Date(string dateFormat)]`                                                                                                                                | Specifies that the property value should be a valid date. Supports `-` or `/` as delimiter. Use the `DateFormatBuilder` helper class to construct the `dateFormat` parameter. `IDateFormatBuilder` interface is also included for loose coupling and dependency injection purpose. |
| `TimeOf12HourAttribute`   | `[TimeOf12Hour(bool includeSecond)]`                                                                                                                                   | Specifies that the property value should be a valid 12-hour time format.                                                                                                                                                                                                           |
| `TimeOf24HourAttribute`   | `[TimeOf24Hour(bool includeSecond)]`                                                                                                                                   | Specifies that the property value should be a valid 24-hour time format.                                                                                                                                                                                                           |
| `UuidAttribute`           | `[Uuid(UuidVersion version)]` or `[Uuid]`                                                                                                                              | Specifies that the property value should be a valid UUID. Optionally specifies the UUID version for validation.                                                                                                                                                                    |
