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
namespace FwjSoft.Web.UserRole
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int UserRoleId=(Convert.ToInt32(strid));
					ShowInfo(UserRoleId);
				}
			}
		}
		
	private void ShowInfo(int UserRoleId)
	{
		FwjSoft.BLL.UserRole bll=new FwjSoft.BLL.UserRole();
		FwjSoft.Model.UserRole model=bll.GetModel(UserRoleId);
		this.lblUserRoleId.Text=model.UserRoleId.ToString();
		this.lblUserId.Text=model.UserId;
		this.lblRoleId.Text=model.RoleId.ToString();

	}


    }
}
