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
namespace FwjSoft.Web.UserRole
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int UserRoleId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(UserRoleId);
				}
			}
		}
			
	private void ShowInfo(int UserRoleId)
	{
		FwjSoft.BLL.UserRole bll=new FwjSoft.BLL.UserRole();
		FwjSoft.Model.UserRole model=bll.GetModel(UserRoleId);
		this.lblUserRoleId.Text=model.UserRoleId.ToString();
		this.txtUserId.Text=model.UserId;
		this.txtRoleId.Text=model.RoleId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserId.Text.Trim().Length==0)
			{
				strErr+="用户ID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRoleId.Text))
			{
				strErr+="角色ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserRoleId=int.Parse(this.lblUserRoleId.Text);
			string UserId=this.txtUserId.Text;
			int RoleId=int.Parse(this.txtRoleId.Text);


			FwjSoft.Model.UserRole model=new FwjSoft.Model.UserRole();
			model.UserRoleId=UserRoleId;
			model.UserId=UserId;
			model.RoleId=RoleId;

			FwjSoft.BLL.UserRole bll=new FwjSoft.BLL.UserRole();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
