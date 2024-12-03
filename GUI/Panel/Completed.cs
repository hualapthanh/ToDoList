﻿using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Panel
{
    public partial class Completed : Form
    {
        private UserDTO user;
        private bool isImportant;
        public TaskBUS taskBUS;
        public List<TaskDTO> listTasks;
        public Completed(UserDTO user)
        {
            this.user = user;
            InitializeComponent();

            taskBUS = new TaskBUS();
            //listTasks = taskBUS.getAllTaskCompleted(user.UserID);
            isImportant = false;
        }

        private void Completed_Load(object sender, EventArgs e)
        {
            if (tableCompleted.Columns.Count == 0)
            {
                tableCompleted.Columns.Add("clTitle_cmp", "Title");
                tableCompleted.Columns.Add("clDuedate_cmp", "Due Date");
                tableCompleted.Columns.Add("clImportance_cmp", "Important");
                tableCompleted.Columns.Add("clDone_cmp", "Done");
            }

            loadDataTable(listTasks);
        }

        private void loadDataTable(List<TaskDTO> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                return;
            }

            tableCompleted.Rows.Clear();

            foreach (var task in tasks)
            {
                int rowIndex = tableCompleted.Rows.Add();

                tableCompleted.Rows[rowIndex].Cells["clTitle_cmp"].Value = task.Title;
                tableCompleted.Rows[rowIndex].Cells["clDuedate_cmp"].Value = task.DueDate.ToString("dd/MM/yyyy");
                if (!task.IsImportant)
                {
                    tableCompleted.Rows[rowIndex].Cells["clImportance_cmp"].Value = Properties.Resources.Important_24px;
                }
                else
                {
                    tableCompleted.Rows[rowIndex].Cells["clImportance_cmp"].Value = Properties.Resources.ImportantSelected_24px;
                }
                if (task.CompletedDate == null)
                {
                    tableCompleted.Rows[rowIndex].Cells["clDone_cmp"].Value = Properties.Resources.notDone_24;
                }
                else
                {
                    //tableCompleted.Rows[rowIndex].Cells["clDone_cmp"].Value = Properties.Resources.done_24;
                }
            }
        }

        private void tableCompleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tableCompleted.Columns["clDone_cmp"].Index)
            {
                try
                {
                    var selectedTask = listTasks[e.RowIndex];
                    var index = listTasks.FindIndex(t => t.TaskID == selectedTask.TaskID);

                    DateTime? previousDate = selectedTask.CompletedDate;

                    selectedTask.CompletedDate = previousDate == null ? DateTime.Now : (DateTime?)null;

                    bool check = taskBUS.update(selectedTask);
                    if (check)
                    {
                        if (selectedTask.CompletedDate == null)
                        {
                            tableCompleted.Rows.RemoveAt(e.RowIndex);
                            listTasks.RemoveAt(index);
                        }
                        //listTasks[index].CompletedDate = selectedTask.CompletedDate;
                        //loadDataTable(listTasks);
                    }
                    else
                    {
                        selectedTask.CompletedDate = previousDate;
                        MessageBox.Show("Failed to update task completion.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
