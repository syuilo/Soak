using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himawari.Storages
{
	public static class AccountStorage
	{
		public static ObservableCollection<Common.Account> Accounts
		{
			get;
			set;
		}
	}
}
