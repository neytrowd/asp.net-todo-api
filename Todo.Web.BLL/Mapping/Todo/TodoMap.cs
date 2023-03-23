using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Todo.Web.Contract.Models;
using Todo.Web.Models;

namespace Todo.Web.BLL.Mapping.Todo
{
	public class TodoMap: Profile
	{
		public TodoMap()
		{
			CreateMap<TodoEntity, TodoModel>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(src => src.Id))
				.ForMember(
					dest => dest.Title,
					opt => opt.MapFrom(src => src.Title))
				.ForMember(
					dest => dest.IsCompleted,
					opt => opt.MapFrom(src => src.IsCompleted))
				.ReverseMap();
		}
	}
}
