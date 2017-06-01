using FwjSoft.BLL;
using FwjSoft.Froms.CommonClass;
using FwjSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Froms
{
    public partial class FormMain : Form
    {
        //bool isChangedCombobox = false;
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //InitMainMenu();
            InitMenuStrip();

            /*
            DataTable tableSkin = GetSkinFileName();
            InitCombobox(tableSkin);
            this.toolStripComboBox1.SelectedIndex = -1;
            this.toolStripComboBox1.SelectedIndex = 0;
            */
        }

        #region 菜单
        List<MenuInfoModel> listMenuInfo = new List<MenuInfoModel>();

        #region MainMenu
        private void InitMainMenu()
        {
            MainMenu theMenu = new MainMenu();
            listMenuInfo = new MenuInfoBLL().GetModelList("");
            if (listMenuInfo == null || listMenuInfo.Count == 0) return;
            var query = from menu in listMenuInfo
                        where (menu.MenuParentId == 0 && menu.MenuUse == true)
                        select menu;
            if (query == null || query.Count() == 0) return;
            foreach (var ci in query)
            {
                MenuItem item = new MenuItem(ci.MenuName);
                item.Tag = ci;
                GetMenuItem(item,ci);
                theMenu.MenuItems.Add(item);
            }
            this.Menu = theMenu;
        }
        private void GetMenuItem(MenuItem item, MenuInfoModel model)
        {
            var query = from menu in listMenuInfo
                        where (menu.MenuParentId == model.MenuId && menu.MenuUse == true)
                        select menu;
            if (query == null || query.Count() == 0) return;
            
            int intNo = 0;
            foreach (var ci in query)
            {
                string strtext = ci.MenuName;
                MenuItem mMenuItem;
                if (strtext == "-")
                {   //如果是分隔符-，那么不显示顺序
                    mMenuItem = new MenuItem(strtext);
                }
                else
                {
                    intNo++;
                    mMenuItem = new MenuItem(ChangeNo(intNo) + "." + strtext);
                }
                mMenuItem.Tag =ci;
                mMenuItem.Click += new System.EventHandler(this.ItemClick);
                GetMenuItem(mMenuItem, ci);
                item.MenuItems.Add(mMenuItem);
            }
        }
        //编辑编号，如果大于9，则用字母表示
        private string ChangeNo(int intNo)
        {
            if (intNo > 9)
            {
                return ((char)(intNo - 9 + 65 - 1)).ToString();
            }
            return intNo.ToString();
        }
        private void ItemClick(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MenuInfoModel model = (MenuInfoModel)menuItem.Tag;
            if (model == null) return;
            ShowForm(model, false);
        }
        #endregion

        #region MenuStrip
        private void InitMenuStrip()
        {
            try
            {
                listMenuInfo = new MenuInfoBLL().GetModelList("");
                if (listMenuInfo == null || listMenuInfo.Count == 0) return;
                var query = from menu in listMenuInfo
                            where (menu.MenuParentId == 0 && menu.MenuUse == true)
                            select menu;
                if (query == null || query.Count() == 0) return;
                foreach (var ci in query)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(ci.MenuName);
                    item.Tag = ci;
                    GetMenuStripItem(item, ci);
                    this.menuStrip.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("初始化菜单出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetMenuStripItem(ToolStripMenuItem item, MenuInfoModel model)
        {
            var query = from menu in listMenuInfo
                        where (menu.MenuParentId == model.MenuId && menu.MenuUse == true)
                        select menu;
            if (query == null || query.Count() == 0) return;
            int intNo = 0;
            foreach (var ci in query)
            {
                string strtext = ci.MenuName;
                ToolStripMenuItem itemDetail = new ToolStripMenuItem();
                if (strtext == "-")
                {   //如果是分隔符-，那么不显示顺序
                    itemDetail = new ToolStripMenuItem(strtext);
                    ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                    item.DropDownItems.Add(toolStripSeparator);
                }
                else
                {
                    intNo++;
                    itemDetail = new ToolStripMenuItem(ChangeNo(intNo) + "." + strtext);
                    itemDetail.Tag = ci;
                    itemDetail.Click += new System.EventHandler(this.ItemDetailClick);
                    GetMenuStripItem(itemDetail, ci);
                    item.DropDownItems.Add(itemDetail);
                }
            }
        }
        private void ItemDetailClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
                MenuInfoModel model = (MenuInfoModel)toolStripMenuItem.Tag;
                if (model == null) return;
                ShowForm(model, false);
            }
            catch(Exception ex)
            {
                //SysMethod.ShowPopupMessage(ex.Message, "", true);
                MessageBox.Show(ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 打开菜单指定窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="strFormTitle">窗体标题</param>
        /// <param name="strFormClass">窗体所在的命名空间及类型</param>
        /// <param name="strNamespace">表单的所属命名空间</param>
        /// <param name="bShowModal">是否以模式窗口显示</param>
        private static void ShowForm(MenuInfoModel model, bool bShowModal)
        {
            //Example.Form1,Example
            string typeName = string.Format("{0}.{1}",model.MenuSpaceName,model.MenuFrmName);
            Type t = Type.GetType(typeName, true, true);
            Form myForm = GetForm(t);

            if (myForm == null)
            {
                Assembly assembly = Assembly.GetAssembly(t);
                object formClass = assembly.CreateInstance(typeName);
                myForm = (Form)formClass;
                myForm.Name = model.MenuFrmName;
                myForm.Text = model.MenuName;

                #region 给指定窗体传参数
                //Labletext参数属性名,dfsafsfsdfsdf参数属性对应的值
                /*
                System.Reflection.PropertyInfo pi = t.GetProperty("Labletext", System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
                pi.SetValue(myForm, "dfsafsfsdfsdf", null);
                */
                #endregion

                if (bShowModal)
                {
                    myForm.ShowDialog();
                }
                else
                {
                    //设置窗口的Mdi父窗体
                    Form mForm = GetMdiMForm();
                    if (mForm != null)
                    {
                        myForm.MdiParent = mForm;
                    }
                    myForm.Show();
                }
            }
            else
            {
                myForm.Activate();
            }
        }

        /// <summary>
        /// 返回指定表单类型已经打开的表单窗体
        /// </summary>
        /// <param name="tFormType"></param>
        /// <returns></returns>
        public static Form GetForm(Type tFormType)
        {
            Form fReturn = null;
            foreach (Form currForm in Application.OpenForms)
            {
                if (currForm.GetType() == tFormType)
                {
                    fReturn = currForm;
                }
            }
            return fReturn;
        }

        /// <summary>
        /// 判断当前系统是否有MDI子窗体
        /// </summary>
        /// <returns></returns>
        public static bool ExistMDIChildrenForm()
        {
            bool bReturn = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.IsMdiChild)
                {
                    bReturn = true;
                    break;
                }
            }
            return bReturn;
        }

        /// <summary>
        /// 获取Mdi主窗体
        /// </summary>
        /// <returns></returns>
        public static Form GetMdiMForm()
        {
            Form fReturn = null;
            foreach (Form currForm in Application.OpenForms)
            {
                if (currForm.IsMdiContainer)
                {
                    fReturn = currForm;
                    break;
                }
            }
            return fReturn;
        }

        #endregion

        #endregion

        /*
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!isChangedCombobox || this.toolStripComboBox1.SelectedIndex < 0) return;
            string skin = this.toolStripComboBox1.ComboBox.SelectedValue.ToString();
            if (skin == "Default")
            {
                //this.skinEngine1.SkinFile = "";
                this.skinUI1.SkinFile = "";
            }
            else
            {
                skin = skin.Substring(1);
                if (skin.Substring(skin.Length - 3) == "ssk")
                {
                    //this.skinEngine1.SkinFile = skin;
                }
                else
                    this.skinUI1.SkinFile = skin;
            }
            
        }
        /// <summary>
        /// 取得皮肤文件名
        /// </summary>
        /// <returns>返回DATATBLE数据，PATH,FILENAME</returns>
        private DataTable GetSkinFileName()
        {
            DataTable tableSkin = new DataTable();
            DataColumn colPath = new DataColumn("path", typeof(string));
            DataColumn colFileName = new DataColumn("filename", typeof(string));
            tableSkin.Columns.AddRange(new DataColumn[] { colPath, colFileName });
            string folderPath = Application.StartupPath + "\\dotnet 皮肤dll";   //皮肤文件存放的路径
            DataRow newRow = tableSkin.NewRow();
            newRow["path"] = "Default";
            newRow["filename"] = "Default";
            tableSkin.Rows.Add(newRow);
            ListFiles(tableSkin, new DirectoryInfo(folderPath));
            return tableSkin;
        }

        /// <summary>
        /// 遍历指定目录下的文件及文件夹，取得皮肤文件的名称及路径
        /// </summary>
        /// <param name="tableSkin">存放取得的皮肤文件名称和路径的TABLE</param>
        /// <param name="info">文件实例</param>
        private void ListFiles(DataTable tableSkin, FileSystemInfo info)
        {
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录 
            if (dir == null) return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件 
                if (file != null)
                {
                    //如果文件最后四个字节为.ssk或.skn的文件才是皮肤文件
                    if (file.Name.LastIndexOf(".ssk") == file.Name.Length - 4 || file.Name.LastIndexOf(".skn") == file.Name.Length - 4)
                    {
                        DataRow newRow = tableSkin.NewRow();
                        newRow["path"] = (file.DirectoryName + "\\" + file.Name).Replace(Application.StartupPath, "");
                        newRow["filename"] = file.Name;
                        tableSkin.Rows.Add(newRow);
                    }
                }
                //对于子目录，进行递归调用 
                else
                    ListFiles(tableSkin, files[i]);
            }
        }

        /// <summary>
        /// 初始化填充皮肤下拉控件值
        /// </summary>
        /// <param name="tableSkin"></param>
        private void InitCombobox(DataTable tableSkin)
        {
            isChangedCombobox = false;     //控件填充数据时不触发控件的SelectedIndexChanged事件
            this.toolStripComboBox1.ComboBox.DataSource = tableSkin;
            this.toolStripComboBox1.ComboBox.DisplayMember = "filename";
            this.toolStripComboBox1.ComboBox.ValueMember = "path";
            isChangedCombobox = true;    //控件填充数据后，把标识设为TRUE
        }
        */
    }
}
