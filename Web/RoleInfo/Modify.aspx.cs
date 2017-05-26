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
namespace FwjSoft.Web.RoleInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int RoleId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(RoleId);
				}
			}
		}
			
	private void ShowInfo(int RoleId)
	{
		FwjSoft.BLL.RoleInfo bll=new FwjSoft.BLL.RoleInfo();
		FwjSoft.Model.RoleInfo model=bll.GetModel(RoleId);
		this.lblRoleId.Text=model.RoleId.ToString();
		this.txtRoleName.Text=model.RoleName;
		this.txtRoleDesc.Text=model.RoleDesc;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtRoleName.Text.Trim().Length==0)
			{
				strErr+="角色名称不能为空！\\n";	
			}
			if(this.txtRoleDesc.Text.Trim().Length==0)
			{
				strErr+="角色描述不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RoleId=int.Parse(this.lblRoleId.Text);
			string RoleName=this.txtRoleName.Text;
			string RoleDesc=this.txtRoleDesc.Text;


			FwjSoft.Model.RoleInfo model=new FwjSoft.Model.RoleInfo();
			model.RoleId=RoleId;
			model.RoleName=RoleName;
			model.RoleDesc=RoleDesc;

			FwjSoft.BLL.RoleInfo bll=new FwjSoft.BLL.RoleInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
