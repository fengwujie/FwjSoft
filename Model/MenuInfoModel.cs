using System;
namespace FwjSoft.Model
{
	/// <summary>
	/// 菜单表
	/// </summary>
	[Serializable]
	public partial class MenuInfoModel
	{
		public MenuInfoModel()
		{}
		#region Model
		private int _menuid;
		private string _menuname;
		private string _menuspacename;
		private string _menufrmname;
		private int _menuparentid;
		private bool _menuuse= true;
        private bool _menubig = false;
        private int _menusort = 0;
        private byte[] _menubigimage;
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 命名空间
		/// </summary>
		public string MenuSpaceName
		{
			set{ _menuspacename=value;}
			get{return _menuspacename;}
		}
		/// <summary>
		/// 窗体名称
		/// </summary>
		public string MenuFrmName
		{
			set{ _menufrmname=value;}
			get{return _menufrmname;}
		}
		/// <summary>
		/// 上级菜单ID
		/// </summary>
		public int MenuParentId
		{
			set{ _menuparentid=value;}
			get{return _menuparentid;}
		}
		/// <summary>
		/// 菜单是否启用
		/// </summary>
		public bool MenuUse
		{
			set{ _menuuse=value;}
			get{return _menuuse;}
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuSort
        {
            set { _menusort = value; }
            get { return _menusort; }
        }
        /// <summary>
        /// 是否显示大菜单
        /// </summary>
        public bool MenuBig
        {
            set { _menubig = value; }
            get { return _menubig; }
        }
        /// <summary>
        /// 大菜单图片
        /// </summary>
        public byte[] MenuBigImage
        {
            set { _menubigimage = value; }
            get { return _menubigimage; }
        }
        #endregion Model

    }
}

