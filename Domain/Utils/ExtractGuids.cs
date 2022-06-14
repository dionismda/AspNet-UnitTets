using Domain.Commands;

namespace Domain.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
        {
            List<Guid> guids = new List<Guid>();
            foreach (var item in items)
            {
                guids.Add(item.Product);
            }

            return guids;
        }
    }
}
