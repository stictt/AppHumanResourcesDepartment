using AppHumanResourcesDepartment.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppHumanResourcesDepartment.Model;
using System.Threading;

namespace AppHumanResourcesDepartment.View
{
    public partial class DivisionStructureForm : Form
    {
        private TreeNode _departmentSelected;
        private TreeNode _workSelected;
        public DivisionStructureForm()
        {
            InitializeComponent();
            LoadDepartment();
        }

        private async Task LoadWork()
        {
            if(_departmentSelected == null) { return; }

            List<Work> works = null;
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    works = await context.Works
                        .Include(x => x.Department)
                        .Include(x => x.Perent)
                        .Where(x => x.DepartmentID == (int)_departmentSelected.Tag)
                        .ToListAsync();
                }
            }
            catch { MessageBox.Show("Ошибка загрузки данных"); }


            WorkTreeView2.Nodes.Clear();
            Work tempNodeWork = works?.FirstOrDefault(x => x.Perent == null);
            while(tempNodeWork != null)
            {
                WorkTreeView2.Nodes.Add(new TreeNode() 
                { 
                    Text = tempNodeWork.Name, 
                    Tag = tempNodeWork.Id 
                });
                tempNodeWork = tempNodeWork.Next;
            }
        } 

        private async Task LoadDepartment()
        {
            DepartmentTreeView1.Nodes.Clear();
            List<Department> departments = null;
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    departments = await context.Departments
                        .ToListAsync();
                }
            }
            catch { MessageBox.Show("Ошибка загрузки данных"); }

            departments?.ForEach(x =>
            {
                DepartmentTreeView1.Nodes.Add(new TreeNode() { Text = x.Name, Tag = x.Id });
            });
        }

        private async Task RemoveDepartment()
        {
            Department department = null;
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    department = await context.Departments
                        .Include(x => x.Works)
                        .ThenInclude(x => x.People)
                        .Include(x => x.Works)
                        .ThenInclude(x => x.Perent)
                        .Include(x => x.Works)
                        .ThenInclude(x => x.RefineFields)
                        .FirstOrDefaultAsync(x => x.Id == (int)_departmentSelected.Tag);

                    context.Departments.Remove(department);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            { 
                MessageBox.Show("Ошибка загрузки данных"); 
            }

            WorkTreeView2.Nodes.Clear();
            await LoadDepartment();
        }

        private async void RemoveDepartmentButton2_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null)
            {
                return;
            }
            
            await RemoveDepartment();
            _departmentSelected = null;
        }

        private async void DepartmentTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _departmentSelected = e.Node;
            await LoadWork();
        }

        private void AddDepartmentButton1_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.FormClosed += async (object? sender, FormClosedEventArgs e) =>
            {
                if (departmentForm.IsChanges)
                {
                    WorkTreeView2.Nodes.Clear();
                    await LoadDepartment();
                }
            };

            departmentForm.ShowDialog();
        }

        private void EditDepartmentButton3_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null)
            {
                return;
            }

            DepartmentForm departmentForm = new DepartmentForm((int)_departmentSelected.Tag);
            departmentForm.FormClosed += async (object? sender, FormClosedEventArgs e) =>
            {
                if (departmentForm.IsChanges)
                {
                    WorkTreeView2.Nodes.Clear();
                    await LoadDepartment();
                }
            };

            departmentForm.ShowDialog();
        }

        private void EditWorkButton8_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null || _departmentSelected == null)
            {
                return;
            }

            WorkForm workForm = new WorkForm((int)_departmentSelected.Tag, (int)_workSelected.Tag);
            workForm.FormClosed += async (object? sender, FormClosedEventArgs e) =>
            {
                if (workForm.IsChanges)
                {
                    await LoadWork();
                }
            };

            workForm.ShowDialog();
        }

        private void AddWorkButton6_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null || _departmentSelected == null)
            {
                return;
            }

            WorkForm workForm = new WorkForm((int)_departmentSelected.Tag);
            workForm.FormClosed += async (object? sender, FormClosedEventArgs e) =>
            {
                if (workForm.IsChanges)
                {
                    await LoadWork();
                }
            };

            workForm.ShowDialog();
        }

        private async Task RemoveWork()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    var work = await context.Works
                        .Include(x => x.Perent)
                        .Include(x => x.Next)
                        .Include(x => x.Department)
                        .Include(x => x.People)
                        .Include(x => x.RefineFields)
                        .FirstOrDefaultAsync(x => x.Id == (int)_workSelected.Tag && (int)_departmentSelected.Tag == x.DepartmentID);

                    if (work.Perent != null && work.Next != null)
                    {
                        work.Next.Perent = work.Perent;
                        context.SaveChanges();
                    }
                    context.Works.Remove(work);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            { 
                MessageBox.Show("Ошибка загрузки данных"); 
            }
        }

        private async void RemoveWorkButton7_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null || _departmentSelected == null)
            {
                return;
            }
            await RemoveWork();
            await LoadWork();
        }

        private void WorkTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _workSelected = e.Node;
        }

        private async Task UPWork()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    var works = await context.Works
                        .Include(x => x.Perent)
                        .Include(x => x.Next)
                        .Include(x => x.Department)
                        .Include(x => x.People)
                        .Include(x => x.RefineFields)
                        .Where(x =>(int)_departmentSelected.Tag == x.DepartmentID)
                        .ToListAsync();

                    var shakenWork = works
                        .Where(x => x.Id == (int)_workSelected.Tag)
                        .First();
                    var shakenWorkNext = shakenWork.Next;
                    if (shakenWork.Perent == null)
                    { 
                        return; 
                    }
                    var perentWork = shakenWork.Perent;

                    int? perentPerentWorkId = perentWork.Perent?.Id;
                    int? shakenWorkId =  shakenWork.Id;
                    int? perentWorkId = perentWork.Id;

                    shakenWork.PerentID = null;
                    perentWork.PerentID = null;
                    if (shakenWorkNext != null)
                    {
                        shakenWorkNext.PerentID = null;
                    }

                    context.SaveChanges();
                    shakenWork.PerentID = perentPerentWorkId;
                    perentWork.PerentID = shakenWorkId;
                    if (shakenWorkNext != null)
                    {
                        shakenWorkNext.PerentID = perentWorkId;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка загрузки данных");
            }
        }

        private async Task DownWork()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    var works = await context.Works
                        .Include(x => x.Perent)
                        .Include(x => x.Next)
                        .Include(x => x.Department)
                        .Include(x => x.People)
                        .Include(x => x.RefineFields)
                        .Where(x => (int)_departmentSelected.Tag == x.DepartmentID)
                        .ToListAsync();

                    var shakenWork = works
                        .Where(x => x.Id == (int)_workSelected.Tag)
                        .First();

                    if (shakenWork.Next == null)
                    {
                        return;
                    }
                    var shakenWorkNext = shakenWork.Next;
                    var shakenWorkNextNext = shakenWorkNext.Next;
                    var perentWork = shakenWork.Perent;

                    int? nextWorkId = shakenWorkNext?.Id;
                    int? nextNextWorkId = shakenWorkNextNext?.Id;
                    int? shakenWorkId = shakenWork.Id;
                    int? perentWorkId = perentWork?.Id;

                    shakenWork.PerentID = null;
                    if (shakenWorkNextNext != null)
                    {
                        shakenWorkNextNext.PerentID = null;
                    }

                    shakenWorkNext.PerentID = null;
                    context.SaveChanges();

                    shakenWork.PerentID = nextWorkId;
                    if (shakenWorkNextNext != null)
                    {
                        shakenWorkNextNext.PerentID = shakenWorkId;
                    }
                    shakenWorkNext.PerentID = perentWorkId;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка загрузки данных");
            }
        }

        private async void UPWorkButton4_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null || _departmentSelected == null)
            {
                return;
            }
            await UPWork();
            await LoadWork();
        }

        private async void DownWorkButton5_Click(object sender, EventArgs e)
        {
            if (_departmentSelected == null || _departmentSelected == null)
            {
                return;
            }
            await DownWork();
            await LoadWork();
        }
    }
}
