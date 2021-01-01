namespace WebApplication.Core.Entity
{
    public class Customer
    {
      public CustomerName Name { get; private set; }  
      public CustomerId Id { get; private set; }
      public StudioId StudioId { get; private set; }
      
      
      private Customer(){}

      public Customer(CustomerId id, CustomerName name, StudioId studioId)
      {
          Id = id;
          Name = name;
          StudioId = studioId;
      }

      static public Customer Create(CustomerId id, CustomerName name, StudioId studioId)
      {
          return new Customer(id, name, studioId);
      }
    }
}