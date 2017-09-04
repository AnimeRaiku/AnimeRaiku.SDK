using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Query
{
    public enum ConditionOperator
    {
        Contains,
        StartWith,
        EndWith,
        Equals,
        GreaterThan,
        LessThan,
        In,
        NotNull,
        Null,
        Year

    }

    public class ConditionExpression
    {
        public ConditionExpression(String attributeName, ConditionOperator conditionOperator, params Object[] values)
        {
            AttributeName = attributeName;
            ConditionOperator = conditionOperator;
            Values = values;
        }

        private static Dictionary<ConditionOperator, string> operators = new Dictionary<ConditionOperator, string>()
        {
            { Query.ConditionOperator.Contains, "ct" },
            { Query.ConditionOperator.StartWith, "sw" },
            { Query.ConditionOperator.EndWith, "ew" },
            { Query.ConditionOperator.Equals, "eq" },
            { Query.ConditionOperator.GreaterThan, "gt" },
            { Query.ConditionOperator.LessThan, "lt" },
            { Query.ConditionOperator.In, "in" },
            { Query.ConditionOperator.NotNull, "nn" },
            { Query.ConditionOperator.Null, "nu" },
            { Query.ConditionOperator.Year, "y" },

        };



        public String AttributeName { get; set; }

        public ConditionOperator ConditionOperator { get; set; }

        public Object[] Values { get; set; }


        public override string ToString() {
            if(ConditionOperator == ConditionOperator.In)
                return $"{AttributeName}:{operators[ConditionOperator]}:['{String.Join("','", Values)}']";

            return $"filters[]={AttributeName}:{operators[ConditionOperator]}:{Values[0]}";
        }
    }
}
