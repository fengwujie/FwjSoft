using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace FwjSoft.DAL
{
	/// <summary>
	/// 数据访问类:UserRole
	/// </summary>
	public partial class UserRoleDAL
	{
		public UserRoleDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserRoleId", "UserRole"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserRoleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserRole");
			strSql.Append(" where UserRoleId=@UserRoleId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserRoleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FwjSoft.Model.UserRoleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserRole(");
			strSql.Append("UserId,RoleId)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@RoleId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,20),
					new SqlParameter("@RoleId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RoleId;

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
		public bool Update(FwjSoft.Model.UserRoleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserRole set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("RoleId=@RoleId");
			strSql.Append(" where UserRoleId=@UserRoleId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,20),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RoleId;
			parameters[2].Value = model.UserRoleId;

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
		public bool Delete(int UserRoleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserRole ");
			strSql.Append(" where UserRoleId=@UserRoleId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserRoleId;

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
		public bool DeleteList(string UserRoleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserRole ");
			strSql.Append(" where UserRoleId in ("+UserRoleIdlist + ")  ");
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
		public FwjSoft.Model.UserRoleModel GetModel(int UserRoleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserRoleId,UserId,RoleId from UserRole ");
			strSql.Append(" where UserRoleId=@UserRoleId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserRoleId;

			FwjSoft.Model.UserRoleModel model=new FwjSoft.Model.UserRoleModel();
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
		public FwjSoft.Model.UserRoleModel DataRowToModel(DataRow row)
		{
			FwjSoft.Model.UserRoleModel model=new FwjSoft.Model.UserRoleModel();
			if (row != null)
			{
				if(row["UserRoleId"]!=null && row["UserRoleId"].ToString()!="")
				{
					model.UserRoleId=int.Parse(row["UserRoleId"].ToString());
				}
				if(row["UserId"]!=null)
				{
					model.UserId=row["UserId"].ToString();
				}
				if(row["RoleId"]!=null && row["RoleId"].ToString()!="")
				{
					model.RoleId=int.Parse(row["RoleId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserRoleId,UserId,RoleId ");
			strSql.Append(" FROM UserRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" UserRoleId,UserId,RoleId ");
			strSql.Append(" FROM UserRole ");
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
			strSql.Append("select count(1) FROM UserRole ");
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
				strSql.Append("order by T.UserRoleId desc");
			}
			strSql.Append(")AS Row, T.*  from UserRole T ");
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
			parameters[0].Value = "UserRole";
			parameters[1].Value = "UserRoleId";
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

