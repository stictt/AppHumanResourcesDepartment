using AppHumanResourcesDepartment.Model;
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

namespace AppHumanResourcesDepartment.View
{

    public partial class WorkForm : Form
    {
        public Work ItemWork;
        public bool IsChanges = false;
        private List<(Label, TextBox, Button, RefineField)> _refineField;
        public WorkForm(int depatmentId,int workId = -1)
        {
            _refineField = new List<(Label, TextBox, Button, RefineField)>();
            InitializeComponent();
            FillFields(depatmentId, workId);

        }
        private async void FillFields(int depatmentId, int workId)
        {
            if (workId == -1)
            {
                await CreateDepartment(depatmentId);
                return;
            }
            await LoadWork(workId);

            if (ItemWork == null)
            {
                this.Close();
                MessageBox.Show("Ошибка загрузки данных.");
                return;
            }

            WorkTextBox1.Text = ItemWork?.Name;
            await LoadField();
        }

        private async Task CreateDepartment(int departmentId)
        {
            ItemWork = new Work();
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    ItemWork.Department = await context.Departments
                        .Where(x => x.Id == departmentId)
                        .FirstAsync();
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки данных");
                ItemWork = null;
            }
        }

        private async Task LoadWork(int id)
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    ItemWork = await context.Works
                        .Include(x=>x.Department)
                        .Include(x => x.RefineFields)
                        .Where(x=>x.Id == id)
                        .FirstAsync();
                }
            }
            catch { MessageBox.Show("Ошибка загрузки данных"); }
        }
        private async Task<bool> Save()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    if (ItemWork.Id == default)
                    {
                        var department = await context.Departments
                            .Include(x => x.Works)
                            .Where(x =>x.Id == ItemWork.Department.Id)
                            .FirstOrDefaultAsync();

                        var lastWork = await context.Works
                            .Include(x=>x.Department)
                            .Include(x => x.Perent)
                            .Where(x=>x.Next == null && x.Department.Id == ItemWork.Department.Id)
                            .FirstOrDefaultAsync();

                        ItemWork.Department = department;
                        if (lastWork != null)
                        {
                            lastWork.Next = ItemWork;
                        }
                        context.Works.Add(ItemWork);
                    }
                    else
                    {
                        var temp = await context.Works
                            .FirstOrDefaultAsync(x => x.Id == ItemWork.Id);
                        temp.Name = ItemWork.Name;
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка проведения данных.");
                return false;
            }
            return true;
        }

        private void TransactionDeleteField(HumanResourcesContext context,List<RefineField> refines)
        {
            if (refines.Count() > 0)
            {
                context.RefineFields.RemoveRange(refines);
                context.SaveChanges();
            }
        }

        private void PreparationForConservationFields(List<RefineField> refines,Work work)
        {
            var tempItem = refines.FirstOrDefault();
            refines.ForEach(x => x.Perent = null);
            int count = 0;
            refines.ForEach(x =>
            {
                x.Work = work;
                x.WorkID = work.Id;
                if (count != 0)
                {
                    x.Perent = tempItem;
                }
                count++;
                tempItem = x;
            });
        }

        private List<RefineField> UpdateTrackedAndReturnAll(List<RefineField> refines, List<RefineField> refinesTracked)
        {
            var editFields = refines
                .Where(x => x.Id != default)
                .Select(x =>
                {
                    var tempItem = refinesTracked.FirstOrDefault(y => y.Id == x.Id);
                    if (tempItem == null) { return x; }
                    tempItem.Value = x.Value;
                    return tempItem;
                })
                .ToList();
            editFields.AddRange(refines.Where(x => x.Id == default));
            return editFields;
        }

        private async Task<bool> SaveField()
        {
            try
            {
                
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    using var transaction = context.Database.BeginTransaction();

                    var tempWork = await context.Works
                        .Include(x => x.Next)
                        .Include(x => x.Perent)
                        .Include(x => x.RefineFields)
                        .Where(x => x.Id == ItemWork.Id)
                        .FirstOrDefaultAsync(); 

                    var tempOldList = await context.RefineFields
                        .Include(x => x.Next)
                        .Include(x => x.Perent)
                        .Include(x => x.Work)
                        .Where(x => x.WorkID == ItemWork.Id)
                        .ToListAsync();

                    var formFields = _refineField
                        .Select(x => x.Item4)
                        .ToList();

                    var billetDifference = formFields.Where(x => x.Id != default).ToList();
                    var deleteList = tempOldList.Where(x=> !billetDifference.Any(y=>y.Id == x.Id)).ToList();
                    formFields = formFields.Where(x => !deleteList.Any(y => y.Id == x.Id)).ToList();

                    formFields = UpdateTrackedAndReturnAll(formFields, tempOldList);
                    context.SaveChanges();

                    TransactionDeleteField(context, deleteList);

                    PreparationForConservationFields(formFields, tempWork);
                    
                    

                    var newFields = formFields.Where(x => x.Id == default).ToList();
                    if (newFields.Count()>0)
                    {
                        context.RefineFields.AddRange(newFields);
                        context.SaveChanges();
                    }


                    context.SaveChanges();
                    transaction.Commit();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка проведения данных.");
                return false;
            }
            return true;
        }

        private async void OkButton1_Click(object sender, EventArgs e)
        {
            IsChanges = true;
            ItemWork.Name = WorkTextBox1.Text;

            if (await Save() && await SaveField())
            {
                this.Close();
            }
        }

        private void UpdatePointField()
        {
            int count = 0;
            _refineField.ForEach(x => 
            {
                x.Item1.Location = new Point(30, (count * 30) + 130);
                x.Item2.Location = new Point(110, (count * 30) + 130);
                x.Item3.Location = new Point(275, (count * 30) + 130);

                count++;
            });
        }

        private void GenerateField(RefineField refineField )
        {
            RefineField field = refineField;

            Label label = new Label();
            label.Location = new Point(30, _refineField.Count * 30 + 130);
            label.Size = new Size(50, 30);
            label.Name = "FieldLabel" + _refineField.Count.ToString();
            label.Text = field.Name;
            Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Location = new Point(110, _refineField.Count * 30 + 130);
            textBox.Size = new Size(125, 30);
            textBox.Name = "FieldTextBox" + _refineField.Count.ToString();
            textBox.Text = field.Value;
            textBox.TextChanged += (object? sender, EventArgs e) => 
            {
                field.Value = textBox.Text;
            };
            Controls.Add(textBox);

            Button button = new Button();
            button.Location = new Point(275, _refineField.Count * 30 + 130);
            button.Size = new Size(75, 23);
            button.Name = "FieldButton" + _refineField.Count.ToString();
            button.Text = "Удалить";

            (Label, TextBox, Button, RefineField) tuple = (label, textBox, button, field);
            Controls.Add(button);
            button.Click += (object? sender, EventArgs e) =>
            {
                label.Visible = false;
                textBox.Visible = false;
                button.Visible = false;

                _refineField.Remove(tuple);
                UpdatePointField();
            };

            _refineField.Add(tuple);
        }

        private async Task LoadField()
        {
            List<RefineField> fields = new List<RefineField>();
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    fields = await context.RefineFields
                        .Where(x => x.WorkID == ItemWork.Id)
                        .ToListAsync();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки данных");
                ItemWork = null;
            }
            fields = SortField(fields);
            fields.ForEach(x => 
            {
                GenerateField(x);
            });
        }

        private List<RefineField> SortField(List<RefineField> fields)
        {
            RefineField tempField = fields.FirstOrDefault(x => x.Perent == null);
            List<RefineField> result = new List<RefineField>();
            while (tempField!= null)
            {
                result.Add(tempField);
                tempField = tempField.Next;
            }
            return result;
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFieldbutton1_Click(object sender, EventArgs e)
        {
            if (ItemWork == null)
            {
                return;
            }

            AddFieldForm addFieldForm = new AddFieldForm(ItemWork.Id);
            addFieldForm.FormClosed += (object? sender, FormClosedEventArgs e) =>
            {
                if (addFieldForm.IsChanges)
                {
                    GenerateField(addFieldForm.ItemRefineField);
                    UpdatePointField();
                }
            };

            addFieldForm.ShowDialog();
        }
    }
}
