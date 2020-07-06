﻿using Store.Entities.Abstract;
using Store.Entities.Base;

namespace Store.Entities
{
	class SectionEntity : BaseNamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int? ParentId { get; set; }
	}
}