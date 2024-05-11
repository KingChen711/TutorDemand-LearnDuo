namespace K17221TutorDemand.BusinessLogic.Extensions;

public static class EmployeeServiceExtensions
{
    //public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, EmployeeParameters parameters)
    //    => employees.Where(e => e.Age >= parameters.MinAge && e.Age <= parameters.MaxAge);

    //public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string? searchTerm)
    //{
    //    if (string.IsNullOrWhiteSpace(searchTerm)) return employees;

    //    var lowerCaseTerm = searchTerm.Trim().ToLower();
    //    return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
    //}

    //public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string? orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString)) return employees.OrderBy(e => e.Name);

    //    var orderQuery = OrderQueryBuilder.CreateOrderQuery<Employee>(orderByQueryString);

    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return employees.OrderBy(e => e.Name);

    //    return employees.OrderBy(orderQuery);
    //}
}