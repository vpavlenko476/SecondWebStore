using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entities.Abstract
{
	public interface IEntity
	{
		int Id { get; set; }
	}

	public interface INamedEntity: IEntity
	{
		string Name { get; set; }
	}

	public interface IOrderedEntity: IEntity
	{
		int Order { get; set; }
	}
}
