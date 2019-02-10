using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace PMA
{
    /// <summary>
    /// ExampleUI
    /// </summary>
    public partial class ExampleUI : Page
    {
        protected string CalDate;
        protected string DayStr;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExecuteApi1_Click(object sender, EventArgs e)
        {
            //create client and request
            var client = new RestClient("http://localhost:9172/");
            var request = new RestRequest("api/DateTimeValue", Method.GET);

            // return content type
            var response = client.Get<List<DateTimeValue>>(request);

            //bind dates
            DropDownListApi1.DataSource = response.Data;
            DropDownListApi1.DataValueField = "CalDate";
            DropDownListApi1.DataTextField = "DayStr";
            DropDownListApi1.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownListApi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item and display in modal dialog
            var ddl = (DropDownList) sender;
            var li = ddl.SelectedItem;
            DayStr = li.Text;
            CalDate = li.Value;
            divModal.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExecuteApi2_Click(object sender, EventArgs e)
        {
            // determine date offset to previous sunday from selected date
            DayOfWeek dow = DateTime.Parse(newDate.Value).DayOfWeek;
            var down = (int) Enum.Parse(typeof(DayNumberOfWeek),dow.ToString());
            int offset = (0 - down);

            //****
            // TODO: THERE IS A BUG IN THE request.AddJsonBody() FUNCTION
            // IT DOESN'T TAKE INTO ACCOUNT THE CURRENT CULTURE AND TIME ZONE
            // VALUE. ALL DATE MUST BE ADJUSTED MANUALLY BY -5:00 HOUR
            //****
            //generate new date values using offset
            List<NewDate> newDates = new List<NewDate> { new NewDate { CalDate = DateTime.Parse(newDate.Value.ToString(CultureInfo.CurrentCulture)).AddDays(offset).AddHours(-5) } };
            for (int i=(offset+1); i<=(6+offset); i++)
            {
                newDates = new List<NewDate> { new NewDate { CalDate = DateTime.Parse(newDate.Value.ToString(CultureInfo.CurrentCulture)).AddDays(offset).AddHours(-5) } };
            }

            //create client and request
            var client = new RestClient("http://localhost:9172/");
            var request = new RestRequest("api/DateTimeValue", Method.POST);
            request.AddJsonBody(newDates);

            // return content 
            var response = client.Post<List<DateTimeValue>>(request);

            //bind new dates
            DropDownListApi2.DataSource = response.Data;
            DropDownListApi2.DataValueField = "CalDate";
            DropDownListApi2.DataTextField = "DayStr";
            DropDownListApi2.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownListApi2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item and display in modal dialog
            var ddl = (DropDownList) sender;
            var li = ddl.SelectedItem;
            DayStr = li.Text;
            CalDate = li.Value;
            divModal.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseModal(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }
    }
}