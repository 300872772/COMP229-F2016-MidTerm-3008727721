using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP229_F2016_MidTerm_3008727721.Models;
using System.Web.ModelBinding;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Data.Entity.SqlServer;
using System.Globalization;

/**
* This is a TodoList web application  
* 
* @FileName: TodoList.aspc.cs.aspx.cs
* @Author Md Mamunur Rahman
* @student ID: 300872772
* @Last Update 19-October-2016
* @website: http://comp229-todolist.azurewebsites.net/
* @description: this file is cs file of TodoList.aspx file
*/


namespace COMP229_F2016_MidTerm_3008727721
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewDataBind();



        }


        protected void GridViewDataBind()
        {


            // connect to EF DB
            using (TodoContext1 db = new TodoContext1())
            {

                // query the Todos Table using EF and LINQ
                var todoList = (from todolist in db.Todos
                                select new
                                {
                                    TodoID = todolist.TodoID,
                                    TodoDescription = todolist.TodoDescription,
                                    TodoNotes = todolist.TodoNotes,
                                    Completed = todolist.Completed

                                }).ToList();



                // bind the result to the TodoListGridView 
                TodoListGridView.DataSource = todoList.AsQueryable().OrderBy("TodoID").ToList();
                TodoListGridView.DataBind();
                TodoListGridView.Columns[0].Visible = false;
               


            }



        }
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {


            TodoListGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);


        }



    }
}