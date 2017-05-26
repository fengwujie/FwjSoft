using System;
namespace FwjSoft.Model
{
	/// <summary>
	/// 角色表
	/// </summary>
	[Serializable]
	public partial class RoleInfoModel
	{
		public RoleInfoModel()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _roledesc;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 角色描述
		/// </summary>
		public string RoleDesc
		{
			set{ _roledesc=value;}
			get{return _roledesc;}
		}
		#endregion Model

	}
}

