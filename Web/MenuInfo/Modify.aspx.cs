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
namespace FwjSoft.Web.MenuInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int MenuId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(MenuId);
				}
			}
		}
			
	private void ShowInfo(int MenuId)
	{
		FwjSoft.BLL.MenuInfo bll=new FwjSoft.BLL.MenuInfo();
		FwjSoft.Model.MenuInfo model=bll.GetModel(MenuId);
		this.lblMenuId.Text=model.MenuId.ToString();
		this.txtMenuName.Text=model.MenuName;
		this.txtMenuSpaceName.Text=model.MenuSpaceName;
		this.txtMenuFrmName.Text=model.MenuFrmName;
		this.txtMenuParentId.Text=model.MenuParentId.ToString();
		this.chkMenuUse.Checked=model.MenuUse;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtMenuName.Text.Trim().Length==0)
			{
				strErr+="菜单名称不能为空！\\n";	
			}
			if(this.txtMenuSpaceName.Text.Trim().Length==0)
			{
				strErr+="命名空间不能为空！\\n";	
			}
			if(this.txtMenuFrmName.Text.Trim().Length==0)
			{
				strErr+="窗体名称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtMenuParentId.Text))
			{
				strErr+="上级菜单ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int MenuId=int.Parse(this.lblMenuId.Text);
			string MenuName=this.txtMenuName.Text;
			string MenuSpaceName=this.txtMenuSpaceName.Text;
			string MenuFrmName=this.txtMenuFrmName.Text;
			int MenuParentId=int.Parse(this.txtMenuParentId.Text);
			bool MenuUse=this.chkMenuUse.Checked;


			FwjSoft.Model.MenuInfo model=new FwjSoft.Model.MenuInfo();
			model.MenuId=MenuId;
			model.MenuName=MenuName;
			model.MenuSpaceName=MenuSpaceName;
			model.MenuFrmName=MenuFrmName;
			model.MenuParentId=MenuParentId;
			model.MenuUse=MenuUse;

			FwjSoft.BLL.MenuInfo bll=new FwjSoft.BLL.MenuInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
