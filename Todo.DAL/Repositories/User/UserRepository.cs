using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.Data;
using Todo.Entities;

namespace Todo.DAL.Repositories.User
{
	public class UserRepository: BaseRepository<UserEntity>, IUserRepository
	{
		public UserRepository(TodoDbContext context): base(context) { }
	}
}
