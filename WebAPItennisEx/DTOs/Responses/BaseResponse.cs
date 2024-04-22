using System.Net;

namespace WebAPItennisEx.DTOs.Responses
{
    public class BaseResponse
    {
        public int status_code {  get; set; }
        public object data { get; set; }

        /// <summary></summary>    
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public void CreateResponse(HttpStatusCode statusCode, object data)
        {
            status_code = (int)statusCode;
            this.data = data;
        }
    }
}
