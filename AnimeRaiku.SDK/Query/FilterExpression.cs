using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Query
{
    public class FilterExpression
    {
        public FilterExpression()
        {
            Conditions = new List<ConditionExpression>();
        }
        public List<ConditionExpression> Conditions { get; set; }

        public void AddCondition(String attribute, ConditionOperator conditionOperator, params Object[] values)
        {
            Conditions.Add(new ConditionExpression(attribute, conditionOperator, values));
        }

        public override string ToString()
        {
            return String.Join("&", Conditions);
        }
    }
}
