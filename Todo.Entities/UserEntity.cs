using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Entities
{
	public class UserEntity : IEntityBase<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Login { get; set; }

		public string HashedPassword { get; set; }
	}
}
