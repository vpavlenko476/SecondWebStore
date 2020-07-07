using AutoMapper;
using Store.DAL;
using Store.Domain;
using Store.Entities;
using Store.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
	public class ProductService : IProductService
	{
		private readonly StoreUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ProductService(StoreUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public IEnumerable<Product> GetProducts(int? sectionId = null, int? brandId = null)
		{
			var products = _unitOfWork.ProductRepository.GetAll().ToList();
			if(sectionId != null)
			{
				return _mapper.Map<List<Product>>(products.Where(p => p.SectionId == sectionId));				
			}
			if (brandId != null)
			{
				return _mapper.Map<List<Product>>(products.Where(p => p.BrandId == brandId));				
			}			
			return _mapper.Map<List<Product>>(products);
		}
	}
}
