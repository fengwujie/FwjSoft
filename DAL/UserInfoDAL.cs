﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace FwjSoft.DAL
{
	/// <summary>
	/// 数据访问类:UserInfo
	/// </summary>
	public partial class UserInfoDAL
	{
		public UserInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,20)			};
			parameters[0].Value = UserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FwjSoft.Model.UserInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("UserID,UserName,PassWord)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@UserName,@PassWord)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,20),
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@PassWord", SqlDbType.VarChar,20)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.PassWord;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(FwjSoft.Model.UserInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PassWord=@PassWord");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,30),
					new SqlParameter("@PassWord", SqlDbType.VarChar,20),
					new SqlParameter("@UserID", SqlDbType.VarChar,20)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.UserID;

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
		public bool Delete(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,20)			};
			parameters[0].Value = UserID;

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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public FwjSoft.Model.UserInfoModel GetModel(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,UserName,PassWord from UserInfo ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,20)			};
			parameters[0].Value = UserID;

			FwjSoft.Model.UserInfoModel model=new FwjSoft.Model.UserInfoModel();
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
		public FwjSoft.Model.UserInfoModel DataRowToModel(DataRow row)
		{
			FwjSoft.Model.UserInfoModel model=new FwjSoft.Model.UserInfoModel();
			if (row != null)
			{
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
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
			strSql.Append("select UserID,UserName,PassWord ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append(" UserID,UserName,PassWord ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "UserID";
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

