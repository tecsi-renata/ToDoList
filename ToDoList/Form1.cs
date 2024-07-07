﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }
        /*
        Must have feautures:
        TO DO:
        - Checkbox or Button to mark a task as completed
        - Pinning task priority vise
        - Set task board color priority vise
        - Provide login options so users can access data from different machines
        DONE:
        - Allow users to add tasks with tiles and checkboxes along with an optional description
        - Option to delete task added by users
        - View tasks in list format for ease of reading
         */

        //create data table
        DataTable todoList = new DataTable();

        //boolean that tracks when things are edited
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            //create colums
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            //point datagridView to our datasource
            toDoListView.DataSource = todoList;
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;

            //fill textfields with data from table
            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
            }
            else
            {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            //clears fields when added
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }   
}
