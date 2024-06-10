namespace AutoSchoolApp.API.Models
{
    public class Helper
    {
        public static bool IsExists<T>(ref T value, List<T> list_values)
        {
            foreach (var item in list_values)
            {
                if (item.Equals(value))
                {
                    value = item;
                    return true;
                }
            }
            return false;
        }
    }
}
