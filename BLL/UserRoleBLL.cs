using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using FwjSoft.Model;
namespace FwjSoft.BLL
{
	/// <summary>
	/// 用户关系角色表（一个
	/// </summary>
	public partial class UserRoleBLL
	{
		private readonly FwjSoft.DAL.UserRoleDAL dal=new FwjSoft.DAL.UserRoleDAL();
		public UserRoleBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserRoleId)
		{
			return dal.Exists(UserRoleId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(FwjSoft.Model.UserRoleModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FwjSoft.Model.UserRoleModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserRoleId)
		{
			
			return dal.Delete(UserRoleId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserRoleIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(UserRoleIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FwjSoft.Model.UserRoleModel GetModel(int UserRoleId)
		{
			
			return dal.GetModel(UserRoleId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public FwjSoft.Model.UserRoleModel GetModelByCache(int UserRoleId)
		{
			
			string CacheKey = "UserRoleModel-" + UserRoleId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserRoleId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (FwjSoft.Model.UserRoleModel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FwjSoft.Model.UserRoleModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FwjSoft.Model.UserRoleModel> DataTableToList(DataTable dt)
		{
			List<FwjSoft.Model.UserRoleModel> modelList = new List<FwjSoft.Model.UserRoleModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FwjSoft.Model.UserRoleModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

