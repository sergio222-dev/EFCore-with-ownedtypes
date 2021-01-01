using WebApplication.Core.ValueObject;

namespace WebApplication.Core.Entity
{
    public class CustomerName : StringValueObject

    {
        public string Value { get; set; }
        
        private CustomerName() {}

        public CustomerName(string value)
        {
            Value = value;
        }
    }
}