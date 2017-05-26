using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace FwjSoft.Web.UserInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string UserID= Request.Params["id"];
					ShowInfo(UserID);
				}
			}
		}
			
	private void ShowInfo(string UserID)
	{
		FwjSoft.BLL.UserInfo bll=new FwjSoft.BLL.UserInfo();
		FwjSoft.Model.UserInfo model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID;
		this.txtUserName.Text=model.UserName;
		this.txtPassWord.Text=model.PassWord;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="用户名称不能为空！\\n";	
			}
			if(this.txtPassWord.Text.Trim().Length==0)
			{
				strErr+="用户密码不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UserID=this.lblUserID.Text;
			string UserName=this.txtUserName.Text;
			string PassWord=this.txtPassWord.Text;


			FwjSoft.Model.UserInfo model=new FwjSoft.Model.UserInfo();
			model.UserID=UserID;
			model.UserName=UserName;
			model.PassWord=PassWord;

			FwjSoft.BLL.UserInfo bll=new FwjSoft.BLL.UserInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
