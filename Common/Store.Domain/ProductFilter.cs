using System.Collections.Generic;

namespace Store.Domain
{
    /// <summary>
    /// Класс для фильтрации товаров
    /// </summary>
    public class ProductFilter
    {
        public int? SectionId { get; set; }
        public int? BrandId { get; set; }
        public int[] Ids { get; set; }
    }
}
