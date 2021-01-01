using System;
using WebApplication.Core.ValueObject;

namespace WebApplication.Core.Entity
{
    public class CustomerId : GuidValueObject
    {
        public Guid Value { get; set; }
        
        private CustomerId(){}

        public CustomerId(Guid value)
        {
            Value = value;
        }
    }
}