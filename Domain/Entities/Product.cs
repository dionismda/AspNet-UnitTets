using Flunt.Validations;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, bool active)
        {

            AddNotifications(
                new Contract()
                        .Requires()
                        .IsNotNull(title, "Title", "Invalid Title")
                        .IsGreaterThan(price, 0, "Price", "Price must be greater than 0")
            );

            Title = title;
            Price = (price > 0) ? price : 0;
            Active = active;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}
