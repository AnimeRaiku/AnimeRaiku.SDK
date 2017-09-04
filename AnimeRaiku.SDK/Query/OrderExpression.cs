namespace AnimeRaiku.SDK.Query
{
    public enum OrderType
    {
        Ascending,
        Descending
    }

    public class OrderExpression
    {
        public OrderExpression(string attributeName, OrderType orderType)
        {
            AttributeName = attributeName;
            OrderType = orderType;
        }
        public string AttributeName { get; set; }
        public OrderType OrderType { get; set; }

        public override string ToString()
        {
            var type = OrderType == OrderType.Ascending ? "asc" : "desc";
            return $"orders[]={AttributeName}:{type}";
        }
    }
}