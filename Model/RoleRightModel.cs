using System;
namespace FwjSoft.Model
{
	/// <summary>
	/// 权限表
	/// </summary>
	[Serializable]
	public partial class RoleRightModel
	{
		public RoleRightModel()
		{}
		#region Model
		private int _rolerightid;
		private int? _roleid;
		private int? _menuid;
		/// <summary>
		/// 权限表自增ID
		/// </summary>
		public int RoleRightId
		{
			set{ _rolerightid=value;}
			get{return _rolerightid;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 菜单ID
		/// </summary>
		public int? MenuId
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		#endregion Model

	}
}

