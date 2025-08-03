using Xunit;
using SpesenApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SpesenApp.Tests
{
    public class SpesenEintragTests
    {
        private List<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Model_IsValid_WithMinimalValidData()
        {
            var eintrag = new SpesenEintrag
            {
                Datum = DateTime.Today,
                Kst1 = 100,
                PersonenId = 1
            };

            var errors = ValidateModel(eintrag);
            Assert.Empty(errors);
        }

       [Fact]
        public void Model_IsInvalid_WhenKst1IsZero()
        {
            var eintrag = new SpesenEintrag
            {
                Datum = DateTime.Today,
                Kst1 = 0 // Ungültig wegen Range
            };

            var errors = ValidateModel(eintrag);

            Assert.Contains(errors, e => e.MemberNames.Contains("Kst1"));
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Model_IsInvalid_WithNegativeKosten(decimal invalidValue)
        {
            var eintrag = new SpesenEintrag
            {
                Datum = DateTime.Today,
                Kst1 = 1,
                Verpflegung = invalidValue
            };

            var errors = ValidateModel(eintrag);

            Assert.Contains(errors, e => e.MemberNames.Contains("Verpflegung"));
        }

        [Fact]
        public void Total_IsCalculatedCorrectly()
        {
            var eintrag = new SpesenEintrag
            {
                Verpflegung = 10,
                Reisekosten = 20,
                ReisespesenAuto = 5,
                Kursmaterial = 15,
                AndereKosten = 7
            };

            var expected = 10 + 20 + 5 + 15 + 7;
            Assert.Equal(expected, eintrag.Total);
        }
    }
}