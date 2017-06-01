using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace FwjSoft.DAL
{
	/// <summary>
	/// 数据访问类:MenuInfo
	/// </summary>
	public partial class MenuInfoDAL
	{
		public MenuInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MenuId", "MenuInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MenuId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MenuInfo");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FwjSoft.Model.MenuInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MenuInfo(");
			strSql.Append("MenuName,MenuSpaceName,MenuFrmName,MenuParentId,MenuUse,MenuSort)");
			strSql.Append(" values (");
			strSql.Append("@MenuName,@MenuSpaceName,@MenuFrmName,@MenuParentId,@MenuUse,@MenuSort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuSpaceName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuFrmName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuParentId", SqlDbType.Int,4),
					new SqlParameter("@MenuUse", SqlDbType.Bit,1),
                    new SqlParameter("@MenuSort",SqlDbType.Int)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.MenuSpaceName;
			parameters[2].Value = model.MenuFrmName;
			parameters[3].Value = model.MenuParentId;
			parameters[4].Value = model.MenuUse;
            parameters[5].Value = model.MenuSort;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FwjSoft.Model.MenuInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MenuInfo set ");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("MenuSpaceName=@MenuSpaceName,");
			strSql.Append("MenuFrmName=@MenuFrmName,");
			strSql.Append("MenuParentId=@MenuParentId,");
			strSql.Append("MenuUse=@MenuUse,");
            strSql.Append("MenuSort=@MenuSort");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuSpaceName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuFrmName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuParentId", SqlDbType.Int,4),
					new SqlParameter("@MenuUse", SqlDbType.Bit,1),
                    new SqlParameter("@MenuSort",SqlDbType.Int),
					new SqlParameter("@MenuId", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.MenuSpaceName;
			parameters[2].Value = model.MenuFrmName;
			parameters[3].Value = model.MenuParentId;
			parameters[4].Value = model.MenuUse;
            parameters[5].Value = model.MenuSort;
            parameters[6].Value = model.MenuId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MenuInfo ");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string MenuIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MenuInfo ");
			strSql.Append(" where MenuId in ("+MenuIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FwjSoft.Model.MenuInfoModel GetModel(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MenuId,MenuName,MenuSpaceName,MenuFrmName,MenuParentId,MenuUse,MenuSort from MenuInfo ");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuId;

			FwjSoft.Model.MenuInfoModel model=new FwjSoft.Model.MenuInfoModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FwjSoft.Model.MenuInfoModel DataRowToModel(DataRow row)
		{
            return Common.Mapper.ToEntity<Model.MenuInfoModel>(row);
            /*
			FwjSoft.Model.MenuInfoModel model=new FwjSoft.Model.MenuInfoModel();
			if (row != null)
			{
				if(row["MenuId"]!=null && row["MenuId"].ToString()!="")
				{
					model.MenuId=int.Parse(row["MenuId"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["MenuSpaceName"]!=null)
				{
					model.MenuSpaceName=row["MenuSpaceName"].ToString();
				}
				if(row["MenuFrmName"]!=null)
				{
					model.MenuFrmName=row["MenuFrmName"].ToString();
				}
				if(row["MenuParentId"]!=null && row["MenuParentId"].ToString()!="")
				{
					model.MenuParentId=int.Parse(row["MenuParentId"].ToString());
				}
				if(row["MenuUse"]!=null && row["MenuUse"].ToString()!="")
				{
					if((row["MenuUse"].ToString()=="1")||(row["MenuUse"].ToString().ToLower()=="true"))
					{
						model.MenuUse=true;
					}
					else
					{
						model.MenuUse=false;
					}
				}
                if (row["MenuSort"] != null && row["MenuSort"].ToString() != "")
                {
                    model.MenuSort = int.Parse(row["MenuSort"].ToString());
                }
            }
			return model;
            */
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MenuId,MenuName,MenuSpaceName,MenuFrmName,MenuParentId,MenuUse,MenuSort ");
			strSql.Append(" FROM MenuInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by MenuSort");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MenuId,MenuName,MenuSpaceName,MenuFrmName,MenuParentId,MenuUse,MenuSort ");
			strSql.Append(" FROM MenuInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM MenuInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.MenuId desc");
			}
			strSql.Append(")AS Row, T.*  from MenuInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "MenuInfo";
			parameters[1].Value = "MenuId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

