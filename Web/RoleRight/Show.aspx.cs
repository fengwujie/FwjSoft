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
namespace FwjSoft.Web.RoleRight
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
					int RoleRightId=(Convert.ToInt32(strid));
					ShowInfo(RoleRightId);
				}
			}
		}
		
	private void ShowInfo(int RoleRightId)
	{
		FwjSoft.BLL.RoleRight bll=new FwjSoft.BLL.RoleRight();
		FwjSoft.Model.RoleRight model=bll.GetModel(RoleRightId);
		this.lblRoleRightId.Text=model.RoleRightId.ToString();
		this.lblRoleId.Text=model.RoleId.ToString();
		this.lblMenuId.Text=model.MenuId.ToString();

	}


    }
}
