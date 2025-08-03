using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using SpesenApp.Models;

public class PersonTests
{
    private List<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void Person_IsInvalid_IfVornameIsMissing()
    {
        var person = new Person
        {
            Nachname = "Muster",
            Email = "test@example.com"
        };

        var errors = ValidateModel(person);

        Assert.Contains(errors, e => e.MemberNames.Contains("Vorname"));
    }

    [Fact]
    public void Person_IsInvalid_IfNachnameIsMissing()
    {
        var person = new Person
        {
            Vorname = "Max",
            Email = "test@example.com"
        };

        var errors = ValidateModel(person);

        Assert.Contains(errors, e => e.MemberNames.Contains("Nachname"));
    }

    [Fact]
    public void Person_IsInvalid_IfEmailIsInvalid()
    {
        var person = new Person
        {
            Vorname = "Max",
            Nachname = "Muster",
            Email = "not-an-email"
        };

        var errors = ValidateModel(person);

        Assert.Contains(errors, e => e.MemberNames.Contains("Email"));
    }

    [Fact]
    public void Person_IsValid_WithCorrectData()
    {
        var person = new Person
        {
            Vorname = "Max",
            Nachname = "Muster",
            Email = "max.muster@example.com"
        };

        var errors = ValidateModel(person);

        Assert.Empty(errors);
    }
}
