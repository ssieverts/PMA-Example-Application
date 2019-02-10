using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMA;

namespace PMADesktop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExecute1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:9172/");
            var request = new RestRequest("api/DateTimeValue", Method.GET);

            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            var response = client.Get<List<DateTimeValue>>(request);
            ddlApi1.Enabled = false;
            ddlApi1.DataSource = response.Data;
            ddlApi1.ValueMember = "CalDate";
            ddlApi1.DisplayMember = "DayStr";
            ddlApi1.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExecute2_Click(object sender, EventArgs e)
        {
            // determine date offset to previous sunday from selected date
            DayOfWeek dow = DateTime.Parse(newDate.Value.ToString(CultureInfo.CurrentCulture)).DayOfWeek;
            var down = (int)Enum.Parse(typeof(DayNumberOfWeek), dow.ToString());
            int offset = (0 - down);

            //****
            // TODO: THERE IS A BUG IN THE request.AddJsonBody() FUNTION
            // IT DOSEN'T TAKE INTO ACCOUNT THE CURRENT CULTURE AND TIME ZONE
            // VALUE. ALL DATE MUST BE AGJUSTED MANUALLY BY -5:00 HOUR
            //****
            //generate new date values using offset
            List<NewDate> newDates = new List<NewDate> { new NewDate { CalDate = DateTime.Parse(newDate.Value.ToString(CultureInfo.CurrentCulture)).AddDays(offset).AddHours(-5) } };
            for (int i = (offset + 1); i <= (6 + offset); i++)
            {
                newDates.Add(new NewDate { CalDate = DateTime.Parse(newDate.Value.ToString(CultureInfo.CurrentCulture)).AddDays(i).AddHours(-5) });
            }

            //create client and request
            var client = new RestClient("http://localhost:9172/");
            var request = new RestRequest("api/DateTimeValue", Method.POST);
            request.AddJsonBody(newDates);

            // return content 
            var response = client.Post<List<DateTimeValue>>(request);

            //bind new dates
            ddlApi2.Enabled = false;
            ddlApi2.DataSource = response.Data;
            ddlApi2.ValueMember = "CalDate";
            ddlApi2.DisplayMember = "DayStr";
            ddlApi2.Enabled = true;
        }

        /// <summary>
        /// Application Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DdlApi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (ComboBox)sender;
            if (ddl.Enabled)
            {
                var li = (DateTimeValue) ddl.SelectedItem;
                MessageBox.Show(@"Day of Week: " + li.DayStr + @" -- " + @"Date: " + li.CalDate, "Details",
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DdlApi2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (ComboBox)sender;
            if (ddl.Enabled)
            {
                var li = (DateTimeValue)ddl.SelectedItem;
                MessageBox.Show(@"Day of Week: " + li.DayStr + @" -- " + @"Date: " + li.CalDate, "Details",
                    MessageBoxButtons.OK);
            }

        }
    }
}
