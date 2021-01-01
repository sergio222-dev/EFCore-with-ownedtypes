using System;
using WebApplication.Core.ValueObject;

namespace WebApplication.Core.Entity
{
    public class StudioId : GuidValueObject
    {
        public Guid Value { get; set; }
        
        private StudioId(){}

        public StudioId(Guid value)
        {
            Value = value;
        }
    }
}