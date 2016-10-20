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


namespace COMP229_F2016_MidTerm_3008727721 { 
/* <summary>  
* This is the TodoList class for TodoList page.
* </summary>  
*   
* @class TodoDetails  
*/
    public partial class TodoList : System.Web.UI.Page
    {
        /**
       * <summary>
       * This is the protected method for for loading TodoListDetail page code
       * </summary>
       * 
       * @method Page_Load
       * @returns {void} 
       * @param {object} sender
       * @param {EventArgs} e
       */
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["SortColumn"] = "TodoID"; // default sort column
                Session["SortDirection"] = "ASC";

                // Get the todo data
                this.GridViewDataBind();
            }
           



        }

        /**
        * <summary>
        * This is the protected method GridViewDataBind to bind data with gridview
        * </summary>
        * 
        * @method GridViewDataBind
        * @returns {void} 
        */
        protected void GridViewDataBind()
        {


            // connect to EF DB
            using (TodoContext1 db = new TodoContext1())
            {
                string SortString = Session["SortColumn"].ToString() + " " +
                    Session["SortDirection"].ToString();
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
                TodoListGridView.DataSource = todoList.AsQueryable().OrderBy(SortString).ToList();
                TodoListGridView.DataBind();
                TodoListGridView.Columns[0].Visible = false;
               


            }



        }
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {


            TodoListGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);


        }

        /**
      * <summary>
      * This is the protected method TodoListGridView_RowDeleting to delete data
      * </summary>
      * 
      * @method TodoListGridView_RowDeleting
      * @returns {void} 
      * @param {object} sender
      * @param {GridViewDeleteEventArgs} e
      */
        protected void TodoListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected todoid using the Grid's DataKey collection
            int todoID = Convert.ToInt32(TodoListGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected student in the DB and remove it
            using (TodoContext1 db = new TodoContext1())
            {
                // create object ot the todo clas and store the query inside of it
                Todo tododelet = (from todorecord in db.Todos
                                  where todorecord.TodoID == todoID
                                  select todorecord).FirstOrDefault();

                // remove the selected todo from the db
                db.Todos.Remove(tododelet);

                // save my changes back to the db
                db.SaveChanges();

            }

            }

        }
}