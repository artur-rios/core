﻿// ReSharper disable InconsistentNaming
// Reason: these are not test methods

using System.Text.RegularExpressions;
using ArturRios.Common.Util.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;

namespace ArturRios.Common.Validation;

public class FluentValidator<T> : AbstractValidator<T>, IFluentValidator<T>
{
    // ReSharper disable once StaticMemberInGenericType
    // Reason: This is a default value for the unwanted characters in error messages
    private static readonly char[] DefaultErrorMessageUnwantedChars = ['\'', '.'];
    private readonly Regex _unwantedCharsRegex = RegexBuilder
        .New()
        .WithChars(DefaultErrorMessageUnwantedChars)
        .Build();
    
    public string[] ValidateAndReturnErrors(T model)
    {
        var validationResult = Validate(model);
        return validationResult.IsValid ? [] : GetErrorMessages(validationResult);
    }
    
    private string[] GetErrorMessages(ValidationResult validationResult)
    {
        return validationResult.Errors.Select(e => _unwantedCharsRegex.Remove(e.ErrorMessage)).ToArray();
    }
}
