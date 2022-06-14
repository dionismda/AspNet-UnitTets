namespace Domain.Repositories
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipcode);
    }
}
