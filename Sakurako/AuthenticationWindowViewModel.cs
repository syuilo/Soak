using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using Twitch;

namespace Sakurako
{
	public class AuthenticationWindowViewModel : ViewModel
	{
		public void Initialize()
		{
			this.Twitter = new Twitter(
				Himawari.Config.ConsumerKey, Himawari.Config.ConsumerSecret);
		}

		public Twitter Twitter
		{
			get;
			set;
		}

		#region PINCode変更通知プロパティ
		private string _PINCode;

		public string PINCode
		{
			get
			{ return _PINCode; }
			set
			{
				if (_PINCode == value)
					return;
				_PINCode = value;
				RaisePropertyChanged("PINCode");
			}
		}
		#endregion

		#region IsAuthorizeFormOpend変更通知プロパティ
		private bool _IsAuthorizeFormOpend;

		public bool IsAuthorizeFormOpend
		{
			get
			{ return _IsAuthorizeFormOpend; }
			set
			{
				if (_IsAuthorizeFormOpend == value)
					return;
				_IsAuthorizeFormOpend = value;
				RaisePropertyChanged("IsAuthorizeFormOpend");
			}
		}
		#endregion

		#region OpenAuthorizeFormCommand
		private ViewModelCommand _OpenAuthorizeFormCommand;

		public ViewModelCommand OpenAuthorizeFormCommand
		{
			get
			{
				if (_OpenAuthorizeFormCommand == null)
				{
					_OpenAuthorizeFormCommand = new ViewModelCommand(OpenAuthorizeForm);
				}
				return _OpenAuthorizeFormCommand;
			}
		}

		public async void OpenAuthorizeForm()
		{
			try
			{
				await this.Twitter.Authorize();
			}
			catch (Exception ex)
			{
				Messenger.Raise(
					new InformationMessage("エラーが発生しました。再度お試しください。", "", "Error"));
			}
			this.IsAuthorizeFormOpend = true;
		}
		#endregion

		#region AcceptCommand
		private ViewModelCommand _AcceptCommand;

		public ViewModelCommand AcceptCommand
		{
			get
			{
				if (_AcceptCommand == null)
				{
					_AcceptCommand = new ViewModelCommand(Accept);
				}
				return _AcceptCommand;
			}
		}

		public async void Accept()
		{
			var tw = await this.Twitter.AuthorizePin(this.PINCode);

			Messenger.Raise(
				new InformationMessage("@" + tw.ScreenName + " を連携しました！", "成功", "Success"));
		}
		#endregion
	}
}
