using AutoMapper;
using Store.DAL;
using Store.Domain;
using Store.Entities;
using Store.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
	class BlogService: IBlogService
	{
		private readonly StoreUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public BlogService(StoreUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<int> Add(Blog blog)
		{
			return await _unitOfWork.BlogRepository.Add(_mapper.Map<BlogEntity>(blog));
		}

		public async Task Delete(int blogId)
		{
			var blgToDelete = _unitOfWork.BlogRepository.GetAll().Where(e => e.Id == blogId).Single();
			await _unitOfWork.BlogRepository.Delete(blgToDelete);			
		}

		public async Task Edit(Blog blog)
		{
			await _unitOfWork.BlogRepository.Update(_mapper.Map<BlogEntity>(blog));
		}

		public IQueryable<Blog> GetAll()
		{
			return _unitOfWork.BlogRepository.GetAll().Select(_mapper.Map<Blog>).AsQueryable();
		}
	}
}
