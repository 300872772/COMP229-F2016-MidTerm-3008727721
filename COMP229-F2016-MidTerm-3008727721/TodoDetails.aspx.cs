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
* @FileName: TodoDetail.aspc.cs.aspx.cs
* @Author Md Mamunur Rahman
* @student ID: 300872772
* @Last Update 19-October-2016
* @website: http://comp229-todolist.azurewebsites.net/
* @description: this file is cs file of TodoDetails.aspx file
*/


namespace COMP229_F2016_MidTerm_3008727721
{
    /**  
* <summary>  
* This is the TodoDetails class for TodoDetails page.  
* </summary>  
*   
* @class TodoDetails  
*/
    public partial class TodoDetails : System.Web.UI.Page
    {

        //PROTECTED METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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



          


        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
        }

        /**
        * <summary>
        * This is the protected method SaveButton_Click as an event
        * </summary>
        * 
        * @method SaveButton_Click
        * @returns {void} 
        * @param {object} sender
        * @param {EventArgs} e
        */
        protected void SaveButton_Click(object sender, EventArgs e)
        {


            // Use EF to conect to the server
            using (TodoContext1 db = new TodoContext1())
            {
                // use the todo model to create a new todo object and 
                // save a new record

                Todo newtodo = new Todo();

               

                newtodo.TodoDescription = todoname.ToString();
                newtodo.TodoNotes = todoname.ToString();
                newtodo.Completed = false;
               
                    db.Todos.Add(newtodo);
             

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated todolist page
                Response.Redirect("~/TodoList.aspx");


            }




        }

    }
}