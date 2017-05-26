using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using FwjSoft.Model;
namespace FwjSoft.BLL
{
	/// <summary>
	/// 权限表
	/// </summary>
	public partial class RoleRightBLL
	{
		private readonly FwjSoft.DAL.RoleRightDAL dal=new FwjSoft.DAL.RoleRightDAL();
		public RoleRightBLL()
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
		public bool Exists(int RoleRightId)
		{
			return dal.Exists(RoleRightId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(FwjSoft.Model.RoleRightModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FwjSoft.Model.RoleRightModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleRightId)
		{
			
			return dal.Delete(RoleRightId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RoleRightIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(RoleRightIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FwjSoft.Model.RoleRightModel GetModel(int RoleRightId)
		{
			
			return dal.GetModel(RoleRightId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public FwjSoft.Model.RoleRightModel GetModelByCache(int RoleRightId)
		{
			
			string CacheKey = "RoleRightModel-" + RoleRightId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleRightId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (FwjSoft.Model.RoleRightModel)objModel;
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
		public List<FwjSoft.Model.RoleRightModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FwjSoft.Model.RoleRightModel> DataTableToList(DataTable dt)
		{
			List<FwjSoft.Model.RoleRightModel> modelList = new List<FwjSoft.Model.RoleRightModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FwjSoft.Model.RoleRightModel model;
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

