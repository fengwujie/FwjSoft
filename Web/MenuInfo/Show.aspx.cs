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
namespace FwjSoft.Web.MenuInfo
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
					int MenuId=(Convert.ToInt32(strid));
					ShowInfo(MenuId);
				}
			}
		}
		
	private void ShowInfo(int MenuId)
	{
		FwjSoft.BLL.MenuInfo bll=new FwjSoft.BLL.MenuInfo();
		FwjSoft.Model.MenuInfo model=bll.GetModel(MenuId);
		this.lblMenuId.Text=model.MenuId.ToString();
		this.lblMenuName.Text=model.MenuName;
		this.lblMenuSpaceName.Text=model.MenuSpaceName;
		this.lblMenuFrmName.Text=model.MenuFrmName;
		this.lblMenuParentId.Text=model.MenuParentId.ToString();
		this.lblMenuUse.Text=model.MenuUse?"是":"否";

	}


    }
}
