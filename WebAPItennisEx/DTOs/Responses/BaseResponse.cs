using System.Net;

namespace WebAPItennisEx.DTOs.Responses
{
    public class BaseResponse
    {
        public int Status_code {  get; set; }
        public object Data { get; set; }
        public int? Current_page { get; set; }
        public int? Result_count { get; set; }

        /// <summary></summary>    
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public void CreateResponse(HttpStatusCode statusCode, object data, int? current_page, int? result_count)
        {
            Status_code = (int)statusCode;
            Current_page = current_page;
            Result_count = result_count;
            this.Data = data;
        }
    }
}
