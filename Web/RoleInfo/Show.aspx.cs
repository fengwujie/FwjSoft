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
namespace FwjSoft.Web.RoleInfo
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
					int RoleId=(Convert.ToInt32(strid));
					ShowInfo(RoleId);
				}
			}
		}
		
	private void ShowInfo(int RoleId)
	{
		FwjSoft.BLL.RoleInfo bll=new FwjSoft.BLL.RoleInfo();
		FwjSoft.Model.RoleInfo model=bll.GetModel(RoleId);
		this.lblRoleId.Text=model.RoleId.ToString();
		this.lblRoleName.Text=model.RoleName;
		this.lblRoleDesc.Text=model.RoleDesc;

	}


    }
}
