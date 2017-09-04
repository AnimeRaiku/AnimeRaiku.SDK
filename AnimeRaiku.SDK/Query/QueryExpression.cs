using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Query
{
    public class QueryExpression
    {
        public QueryExpression()
        {
            Criteria = new FilterExpression();
            Orders = new List<OrderExpression>();
        }

        public FilterExpression Criteria { get; set; }

        public List<OrderExpression> Orders { get; set; }

        public void AddOrder(String attribute, OrderType orderType)
        {
            Orders.Add(new OrderExpression(attribute, orderType));
        }

        public override string ToString()
        {
            if(Criteria.Conditions.Count > 0 && Orders.Count == 0)
                return Criteria.ToString();
            if (Criteria.Conditions.Count == 0 && Orders.Count > 0)
                return String.Join("&", Orders);
            if (Criteria.Conditions.Count > 0 && Orders.Count > 0)
                return Criteria.ToString()+ "&" + String.Join("&", Orders);
            return "";
        }


    }
}
