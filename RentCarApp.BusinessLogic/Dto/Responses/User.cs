using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.BusinessLogic.Dto.Responses
{

	public class TokenResponse
	{
		public string Token { get; set; }
	}

	public class UserResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Thumbnail { get; set; }
		public bool HasActiveCart { get; set; }
	}
}
