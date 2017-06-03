using FwjSoft.BLL;
using FwjSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FwjSoft.Froms.CommonClass
{
    public static class CacheInfo
    {
        public static List<MenuInfoModel> _listMenuInfoModel = new List<MenuInfoModel>();
        public static List<MenuInfoModel> listMenuInfoModel()
        {
            if(_listMenuInfoModel.Count == 0)
            {
                _listMenuInfoModel = new MenuInfoBLL().GetModelList("");
            }
            return _listMenuInfoModel;
        }
    }
}
