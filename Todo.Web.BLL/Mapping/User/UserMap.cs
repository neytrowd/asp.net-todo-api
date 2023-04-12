using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Todo.Entities;
using Todo.Web.Contract.Models;

namespace Todo.Web.BLL.Mapping.User
{
	public class UserMap: Profile
	{
		public UserMap()
		{
			CreateMap<UserEntity, UserModel>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(dest => dest.Id))
				.ForMember(
					dest => dest.Name,
					opt => opt.MapFrom(dest => dest.Name))
				.ForMember(
					dest => dest.Login,
					opt => opt.MapFrom(dest => dest.Login))
				.ReverseMap();
		}
	}
}
