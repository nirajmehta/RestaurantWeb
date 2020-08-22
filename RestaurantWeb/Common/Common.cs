using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWeb.Common
{
	public class Common
	{
	}

	public enum Status
	{
		Error = -1,
		Cancelled = 0,
		Processing = 1,
		OutForDelivery = 2,
		Complete = 3
	}
}