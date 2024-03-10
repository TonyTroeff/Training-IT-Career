using Microsoft.AspNetCore.Mvc.Rendering;

namespace SampleApp1.Web.MVC.Extensions
{
    public static class ViewExtensions
    {
        public static IEnumerable<SelectListItem> ConstructListItems<T>(this IEnumerable<T> items, Func<T, string> valueSelector, Func<T, string> nameSelector)
        {
            yield return new SelectListItem(string.Empty, string.Empty);

            foreach (var item in items)
            {
                var value = valueSelector(item);
                yield return new SelectListItem(nameSelector(item), value);
            }
        }
    }
}
