using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FwjSoft.BLL;
using FwjSoft.Model;
using DevExpress.XtraTreeList.Nodes;

namespace Forms
{
    public partial class FormMenuInfo : Form
    {
        public FormMenuInfo()
        {
            InitializeComponent();
        }
        List<MenuInfoModel> listMenuInfo = null;
        private void FormMenuInfo_Load(object sender, EventArgs e)
        {
            listMenuInfo = new MenuInfoBLL().GetModelList("");
            this.treeList1.DataSource = listMenuInfo;
            //this.treeList1.DataSource = new MenuInfoBLL().GetList("").Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            try
            {
                MenuInfoBLL bll = new MenuInfoBLL();
                MenuInfoModel model = new MenuInfoModel();
                //model.MenuId = bll.GetMaxId();
                model.MenuId = -1;
                if (this.treeList1.FocusedNode == null)
                {
                    model.MenuSort = 10;
                    model.MenuParentId = 0;
                    listMenuInfo.Add(model);
                }
                else
                {
                    model.MenuParentId = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode)).MenuId;
                    if (this.treeList1.FocusedNode.Nodes.Count > 0)
                    {
                        model.MenuSort = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.Nodes.LastNode)).MenuSort + 10;
                    }
                    else
                    {
                        model.MenuSort = 10;
                    }
                    listMenuInfo.Add(model);
                }
                this.treeList1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            try
            {
                MenuInfoBLL bll = new MenuInfoBLL();
                MenuInfoModel model = new MenuInfoModel();
                //model.MenuId = bll.GetMaxId();
                model.MenuId = -1;
                if (this.treeList1.FocusedNode == null)
                {
                    model.MenuSort = 10;
                    model.MenuParentId = 0;
                    listMenuInfo.Add(model);
                }
                else
                {
                    if (this.treeList1.FocusedNode.ParentNode == null)
                    {
                        model.MenuParentId = 0;
                    }
                    else
                    {
                        model.MenuParentId = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.ParentNode)).MenuId;
                    }

                    if (this.treeList1.FocusedNode.PrevNode != null)
                    {
                        int prevSort = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.PrevNode)).MenuSort;
                        int curSort = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode)).MenuSort;
                        model.MenuSort = (prevSort + curSort) / 2;
                    }
                    else
                    {
                        int curSort = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode)).MenuSort;
                        model.MenuSort = curSort / 2;
                    }
                    listMenuInfo.Add(model);
                }
                this.treeList1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList1.FocusedNode == null) return;
                if(this.treeList1.FocusedNode.Nodes.Count>0)
                {
                    MessageBox.Show("当前节点包含下级节点，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MenuInfoModel model = (MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode);
                new MenuInfoBLL().Delete(model.MenuId);
                listMenuInfo.Remove(model);
                this.treeList1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(true);
        }
        private bool Save(bool bShowSuccess)
        {
            bool bSave = true;
            try
            {
                if (this.treeList1.FocusedNode != null)
                {
                    MenuInfoModel model = (MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode);
                    if (string.IsNullOrEmpty(model.MenuName))
                    {
                        MessageBox.Show("菜单名称不允许为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (model.MenuId <= 0)
                    {
                        int menuID = new MenuInfoBLL().Add(model);
                        model.MenuId = menuID;
                    }
                    else
                    {
                        new MenuInfoBLL().Update(model);
                    }
                    bSave = true;
                    if(bShowSuccess)
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bSave = false;
            }
            return bSave;
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            if (this.treeList1.FocusedNode != null)
            {
                if(this.treeList1.FocusedNode.PrevNode!=null)
                {
                    try
                    {
                        MenuInfoModel prevModel = (MenuInfoModel)this.treeList1.GetDataRecordByNode( this.treeList1.FocusedNode.PrevNode);
                        MenuInfoModel curModel = (MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode);
                        int prevSort = prevModel.MenuSort;
                        prevModel.MenuSort = curModel.MenuSort;
                        curModel.MenuSort = prevSort;
                        MenuInfoBLL bll = new MenuInfoBLL();
                        bll.Update(prevModel);
                        bll.Update(curModel);
                        this.treeList1.RefreshDataSource();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("已是首个节点，无法上移！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            if (this.treeList1.FocusedNode != null)
            {
                if (this.treeList1.FocusedNode.NextNode != null)
                {
                    try
                    {
                        MenuInfoModel nextModel = (MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode.NextNode);
                        MenuInfoModel curModel = (MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode);
                        int nextSort = nextModel.MenuSort;
                        nextModel.MenuSort = curModel.MenuSort;
                        curModel.MenuSort = nextSort;
                        MenuInfoBLL bll = new MenuInfoBLL();
                        bll.Update(nextModel);
                        bll.Update(curModel);
                        this.treeList1.RefreshDataSource();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("已是最后节点，无法下移！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnRefreshSort_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            if(this.treeList1.Nodes.Count>0)
            {
                int iSort = 10;
                MenuInfoBLL bll = new MenuInfoBLL();
                for(int i=0;i<treeList1.Nodes.Count;i++)
                {
                    MenuInfoModel model = (MenuInfoModel)treeList1.GetDataRecordByNode(this.treeList1.Nodes[i]);
                    model.MenuSort = iSort;
                    bll.Update(model);
                    iSort += 10;
                    updateChildNodeSort(this.treeList1.Nodes[i]);
                }
                this.treeList1.RefreshDataSource();
            }
        }

        private void updateChildNodeSort(TreeListNode node)
        {
            if(node.Nodes.Count > 0)
            {
                int iSort = 10;
                MenuInfoBLL bll = new MenuInfoBLL();
                for (int i=0;i<node.Nodes.Count;i++)
                {
                    MenuInfoModel model = (MenuInfoModel)treeList1.GetDataRecordByNode(node.Nodes[i]);
                    model.MenuSort = iSort;
                    bll.Update(model);
                    iSort += 10;
                    updateChildNodeSort(node.Nodes[i]);
                }
            }
        }

        private void treeList1_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            e.CanFocus = Save(false);
        }

        private void btnAddTopLevel_Click(object sender, EventArgs e)
        {
            if (!Save(false)) return;
            try
            {
                MenuInfoBLL bll = new MenuInfoBLL();
                MenuInfoModel model = new MenuInfoModel();
                model.MenuId = -1;
                if(this.treeList1.Nodes.LastNode ==null)
                {
                    model.MenuSort = 10;
                }
                else
                {
                    model.MenuSort = ((MenuInfoModel)this.treeList1.GetDataRecordByNode(this.treeList1.Nodes.LastNode)).MenuSort + 10;
                }
                model.MenuParentId = 0;
                listMenuInfo.Add(model);
                this.treeList1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
