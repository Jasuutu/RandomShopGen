using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RandomShopGen.Lib.Models;

namespace RandomShopGen.Lib
{
    public class ItemTypeRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return value is ItemType itemTypeValue && itemTypeValue != ItemType.None;
        }
    }

    public class ListCountMinAttribute : ValidationAttribute
    {
        private readonly int minCount;

        public ListCountMinAttribute(int minCount)
        {
            this.minCount = minCount;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult($"{validationContext.MemberName} is null", new []{validationContext.MemberName});
            if (!(value is IList enumerableObject) || (enumerableObject.Count < minCount))
            {
                return new ValidationResult($"{validationContext.MemberName}'s count is less than {minCount}", new []{validationContext.MemberName});
            }

            return ValidationResult.Success;
        }
    }
}