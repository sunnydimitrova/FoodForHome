using FoodForHome.Data.Common.Models;

namespace FoodForHome.Data.Models
{
    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
