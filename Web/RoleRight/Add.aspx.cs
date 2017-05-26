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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			int RoleId=int.Parse(this.txtRoleId.Text);
			int MenuId=int.Parse(this.txtMenuId.Text);

			FwjSoft.Model.RoleRight model=new FwjSoft.Model.RoleRight();
			model.RoleId=RoleId;
			model.MenuId=MenuId;

			FwjSoft.BLL.RoleRight bll=new FwjSoft.BLL.RoleRight();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
