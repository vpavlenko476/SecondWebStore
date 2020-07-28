using Store.Entities;
using System.Collections.Generic;
using Store.Entities.Identity;
using System;

namespace Store.DAL.DataInit
{
	public static class TestData
	{
		public static List<SectionEntity> Sections = new List<SectionEntity>
			{
			  new SectionEntity { Id = 1, Name = "Спорт", Order = 0 },
			  new SectionEntity { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
			  new SectionEntity { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
			  new SectionEntity { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
			  new SectionEntity { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
			  new SectionEntity { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
			  new SectionEntity { Id = 7, Name = "Для мужчин", Order = 1 },
			  new SectionEntity { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
			  new SectionEntity { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
			  new SectionEntity { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
			  new SectionEntity { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
			  new SectionEntity { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
			  new SectionEntity { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
			  new SectionEntity { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
			  new SectionEntity { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
			  new SectionEntity { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
			  new SectionEntity { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
			  new SectionEntity { Id = 18, Name = "Для женщин", Order = 2 },
			  new SectionEntity { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
			  new SectionEntity { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
			  new SectionEntity { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
			  new SectionEntity { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
			  new SectionEntity { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
			  new SectionEntity { Id = 24, Name = "Для детей", Order = 3 },
			  new SectionEntity { Id = 25, Name = "Мода", Order = 4 },
			  new SectionEntity { Id = 26, Name = "Для дома", Order = 5 },
			  new SectionEntity { Id = 27, Name = "Интерьер", Order = 6 },
			  new SectionEntity { Id = 28, Name = "Одежда", Order = 7 },
			  new SectionEntity { Id = 29, Name = "Сумки", Order = 8 },
			  new SectionEntity { Id = 30, Name = "Обувь", Order = 9 },
			};

		public static List<EmployeeEntity> Employees = new List<EmployeeEntity>()
		{
			new EmployeeEntity(){Name="Name0", SecondName="SecondName0", Patronymic="Patronymic0", Age=22, Email="test0@email.ru", MobilePhone="+7(999)000-00-00"},
			new EmployeeEntity(){Name="Name1", SecondName="SecondName1", Patronymic="Patronymic1", Age=22, Email="test1@email.ru", MobilePhone="+7(999)000-00-01"},
			new EmployeeEntity(){Name="Name2", SecondName="SecondName2", Patronymic="Patronymic2", Age=22, Email="test2@email.ru", MobilePhone="+7(999)000-00-02"}
		};

		public static List<BrandEntity> Brands = new List<BrandEntity>()
			{
			new BrandEntity { Id = 1, Name = "Acne", Order = 0 },
			new BrandEntity { Id = 2, Name = "Grune Erde", Order = 1 },
			new BrandEntity { Id = 3, Name = "Albiro", Order = 2 },
			new BrandEntity { Id = 4, Name = "Ronhill", Order = 3 },
			new BrandEntity { Id = 5, Name = "Oddmolly", Order = 4 },
			new BrandEntity { Id = 6, Name = "Boudestijn", Order = 5 },
			new BrandEntity { Id = 7, Name = "Rosch creative culture", Order = 6 },
		};

		public static List<ProdctEntity> Products = new List<ProdctEntity>()
		{
			new ProdctEntity { Id = 1, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 2, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 3, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 4, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
			new ProdctEntity { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 7, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
			new ProdctEntity { Id = 8, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
			new ProdctEntity { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
			new ProdctEntity { Id = 10, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
			new ProdctEntity { Id = 11, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
			new ProdctEntity { Id = 12, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
		};

		public static List<BlogEntity> Blogs = new List<BlogEntity>()
		{
			new BlogEntity(){Author = new User() {UserName="TestUser"}, AddTime = DateTime.Now, Body="Полное описание новости", Topic="Тестовый заголовок" },
		};
	}
}
