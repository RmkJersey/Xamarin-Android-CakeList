using System.Collections.Generic;
using System.Linq;

namespace CakeList.Models
{
    public class WaracleCakeList
    {
        public List<WaracleCake> Cakes { get; private set; } = new List<WaracleCake>();
        public string ErrorMessage { get; set; } = string.Empty;

        public void AddRangeWithSort(List<WaracleCake> cakeList)
        {
            Cakes.AddRange(cakeList);

            RemoveDuplicateEntries();

            Cakes.ForEach(a => a.CleanTitleAndDesc());
            Sort();
        }

        public void Sort(bool ascending = true)
        {
            Cakes = ascending ? Cakes.OrderBy(x => x.Title).ToList() : Cakes.OrderByDescending(x => x.Title).ToList();
        }

        public void RemoveDuplicateEntries()
        {
            Cakes = Cakes.Distinct().ToList();
        }
    }
}