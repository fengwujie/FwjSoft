using System;
namespace FwjSoft.Model
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	public partial class UserInfoModel
	{
		public UserInfoModel()
		{}
		#region Model
		private string _userid;
		private string _username;
		private string _password;
		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		#endregion Model

	}
}

