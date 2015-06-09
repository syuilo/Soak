using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himawari.Common
{
	/// <summary>
	/// Soakで利用されるアカウントです。
	/// </summary>
	public class Account
	{
		/// <summary>
		/// このアカウントからTwitterAPIにアクセスする際に利用されるConsumerKey
		/// </summary>
		public string ConsumerKey
		{
			get;
			set;
		}

		/// <summary>
		/// このアカウントからTwitterAPIにアクセスする際に利用されるConsumerSecret
		/// </summary>
		public string ConsumerSecret
		{
			get;
			set;
		}

		/// <summary>
		/// このアカウントからTwitterAPIにアクセスする際に利用されるAccessToken
		/// </summary>
		public string AccessToken
		{
			get;
			set;
		}

		/// <summary>
		/// このアカウントからTwitterAPIにアクセスする際に利用されるAccessTokenSecret
		/// </summary>
		public string AccessTokenSecret
		{
			get;
			set;
		}
	}
}
