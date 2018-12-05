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

        private uint? page = null;
        public uint? Page {
            get {
                return page; 
            }
            set {
                if (page == 0)
                    throw new ArgumentOutOfRangeException();
                page = value;
            }
        }

        public FilterExpression Criteria { get; set; }

        public List<OrderExpression> Orders { get; set; }

        public void AddOrder(String attribute, OrderType orderType)
        {
            Orders.Add(new OrderExpression(attribute, orderType));
        }

        public override string ToString()
        {
            List<String> parameters = new List<string>();
            if(Criteria.Conditions.Count > 0)
                parameters.Add(Criteria.ToString());
            if (Orders.Count > 0)
                parameters.Add(String.Join("&", Orders));
            if (Page != null)
                parameters.Add("page=" + Page);

            return String.Join("&", parameters);
        }


    }
}
