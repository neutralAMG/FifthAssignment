﻿

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public class UserGetResponceDto
	{
		public string Id { get; set; }
		public string FirstName {  get; set; }
		public string  LastName { get; set; }
		public string  Cedula {  get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public bool IsActive { get; set; }
	}
}
