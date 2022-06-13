using Flunt.Validations;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email)
        {

            AddNotifications(
                new Contract()
                        .Requires()
                        .IsNotNull(name, "Name", "Name not is nullable")
                        .IsEmail(email, "Email", "Invalid e-mail")
            );

            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}