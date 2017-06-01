using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FwjSoft.Froms.CommonClass
{
    public static class SysMethod
    {
        public static void ShowPopupMessage(string Msg, string Tips, bool IsError, int interval = 3000)
        {
            /*
            frmPopupMessage frmMsg = new frmPopupMessage();
            if (IsError)
                frmMsg.SetMessage(Msg, "操作失败!", false, Tips, interval);
            else
                frmMsg.SetMessage(Msg, "操作成功!", true, Tips, interval);
            frmMsg.ShowToScreen();
            */
        }
    }
}
