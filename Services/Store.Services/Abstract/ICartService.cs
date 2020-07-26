using Store.ViewModels;

namespace Store.Services.Abstract
{
	public interface ICartService
	{
		void AddToCart(int id);
		void DecrementFromCart(int id);
		void RemoveFromCart(int id);
		void Clear();
		CartViewModel GetCartModel();
	}
}
