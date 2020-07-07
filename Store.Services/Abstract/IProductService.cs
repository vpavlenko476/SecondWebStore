using Store.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Services.Abstract
{
	interface IProductService
	{
		IEnumerable<Section> GetSections();

		IEnumerable<Brand> GetBrands();
	}
}
