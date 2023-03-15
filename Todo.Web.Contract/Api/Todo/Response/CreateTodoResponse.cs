﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Web.Models;

namespace Todo.Web.Contract.Api.Todo.Response
{
	public class CreateTodoResponse: BaseResponse
	{
		public TodoItem Todo { get; set; }
	}
}
