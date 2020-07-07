using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Services.Abstract
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts(int? sectionId, int? brandId);		
	}
}
