namespace Domain.Repositories
{
    public interface IDeliveryFreeRepository
    {
        decimal Get(string zipcode);
    }
}
