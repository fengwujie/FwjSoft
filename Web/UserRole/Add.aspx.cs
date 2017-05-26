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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string UserId=this.txtUserId.Text;
			int RoleId=int.Parse(this.txtRoleId.Text);

			FwjSoft.Model.UserRole model=new FwjSoft.Model.UserRole();
			model.UserId=UserId;
			model.RoleId=RoleId;

			FwjSoft.BLL.UserRole bll=new FwjSoft.BLL.UserRole();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
