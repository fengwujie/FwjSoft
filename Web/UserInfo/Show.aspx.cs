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
namespace FwjSoft.Web.UserInfo
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
					string UserID= strid;
					ShowInfo(UserID);
				}
			}
		}
		
	private void ShowInfo(string UserID)
	{
		FwjSoft.BLL.UserInfo bll=new FwjSoft.BLL.UserInfo();
		FwjSoft.Model.UserInfo model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID;
		this.lblUserName.Text=model.UserName;
		this.lblPassWord.Text=model.PassWord;

	}


    }
}
