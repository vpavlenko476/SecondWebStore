using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Services.Abstract
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts(Section section = null, Brand brand = null);		
	}
}
