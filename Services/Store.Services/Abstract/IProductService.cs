using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
	public interface IProductService
	{
		/// <summary>
		/// Получение списка товаров соответсвующего бренда или секции
		/// </summary>
		/// <param name="sectionId">Секция</param>
		/// <param name="brandId">Бренд</param>		
		IEnumerable<Product> GetProducts(ProductFilter filter = null);

		/// <summary>
		/// Получение товара по его идентификатору
		/// </summary>
		/// <param name="id">Иентификатор товара</param>		
		Task<Product> GetProductByIdAsync(int id);
	}
}
