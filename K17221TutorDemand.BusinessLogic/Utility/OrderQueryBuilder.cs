using System.Reflection;
using System.Text;

namespace K17221TutorDemand.BusinessLogic.Utility;

public static class OrderQueryBuilder
{
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var direction = param.StartsWith("-") ? "desc" : "asc";

            var propertyFromQueryName = direction == "desc" ? param.Split("-")[1] : param;
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null) continue;

            orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        return orderQuery;
    }
}