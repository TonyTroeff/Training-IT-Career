using Microsoft.AspNetCore.Mvc.Rendering;

namespace SampleApp1.Web.MVC.Extensions
{
    public static class ViewExtensions
    {
        public static IEnumerable<SelectListItem> ConstructListItems<T>(this IEnumerable<T> items, Func<T, string> valueSelector, Func<T, string> nameSelector, string? selectedValue = null)
        {
            if (string.IsNullOrWhiteSpace(selectedValue))
            {
                yield return new SelectListItem(string.Empty, string.Empty, selected: true);
            }

            foreach (var item in items)
            {
                var value = valueSelector(item);
                yield return new SelectListItem(nameSelector(item), value, selected: value == selectedValue);
            }
        }
    }
}
