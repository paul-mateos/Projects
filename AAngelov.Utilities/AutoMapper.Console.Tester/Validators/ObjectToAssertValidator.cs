using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAngelov.Utilities.Test.Validators;
using AutoMapper.Console.Tester.OriginalObjects;

namespace AutoMapper.Console.Tester.Validators
{
    public class ObjectToAssertValidator : PropertiesValidator<ObjectToAssertValidator, ObjectToAssert>
    {
        public void Validate(ObjectToAssert expected, ObjectToAssert actual)
        {
            this.Validate(expected, actual, "FirstName");
        }
    }
}
