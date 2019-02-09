using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

namespace PMA
{
    public partial class ExampleUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExecute1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:9172/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api/DateTimeValue", Method.GET);
            request.AddParameter("name", "value",ParameterType.RequestBody); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            //request.AddHeader("header", "value");

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //var response2 = client.Get<DateTimeValue[]>(request);

        }

        protected void btnExecute2_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}