using System;
namespace FwjSoft.Model
{
	/// <summary>
	/// 用户关系角色表（一个用户可同时对应多个角色）
	/// </summary>
	[Serializable]
	public partial class UserRoleModel
	{
		public UserRoleModel()
		{}
		#region Model
		private int _userroleid;
		private string _userid;
		private int? _roleid;
		/// <summary>
		/// 自增量ID
		/// </summary>
		public int UserRoleId
		{
			set{ _userroleid=value;}
			get{return _userroleid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

