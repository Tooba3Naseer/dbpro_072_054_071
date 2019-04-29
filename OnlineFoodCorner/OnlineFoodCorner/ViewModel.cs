using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodCorner
{
	public class ViewModel
	{
		public ChefOrder chef { get; set; }
		public Order or { get; set; }
		public OrderDetail orderdetails { get; set; }
		public MenuCard menu { get; set; }
	}
}