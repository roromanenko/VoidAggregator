using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VoidAggregator.Api.Models;
using VoidAggregator.Dal.Exceptions;

namespace VoidAggregator.Api.Controllers
{
	public class AppBaseController : ControllerBase
	{
		protected string GetCurrentUserId()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
				?? throw new AppException("Can not find name indentifier in claims");

			return userId;
		}
	}
}
