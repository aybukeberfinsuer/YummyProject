using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
	public class SocialMedia
	{
		public int SocialMediaId { get; set; }		
		public string SocialMediaUrl { get; set; }
		public string SocialMediaTitle { get; set; }
		public string Icon { get; set; }
	}
}