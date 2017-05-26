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
namespace FwjSoft.Web.RoleRight
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int RoleRightId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(RoleRightId);
				}
			}
		}
			
	private void ShowInfo(int RoleRightId)
	{
		FwjSoft.BLL.RoleRight bll=new FwjSoft.BLL.RoleRight();
		FwjSoft.Model.RoleRight model=bll.GetModel(RoleRightId);
		this.lblRoleRightId.Text=model.RoleRightId.ToString();
		this.txtRoleId.Text=model.RoleId.ToString();
		this.txtMenuId.Text=model.MenuId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtRoleId.Text))
			{
				strErr+="角色ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMenuId.Text))
			{
				strErr+="菜单ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int RoleRightId=int.Parse(this.lblRoleRightId.Text);
			int RoleId=int.Parse(this.txtRoleId.Text);
			int MenuId=int.Parse(this.txtMenuId.Text);


			FwjSoft.Model.RoleRight model=new FwjSoft.Model.RoleRight();
			model.RoleRightId=RoleRightId;
			model.RoleId=RoleId;
			model.MenuId=MenuId;

			FwjSoft.BLL.RoleRight bll=new FwjSoft.BLL.RoleRight();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
