
using System.Net;
using Task9.Models.Requests;

namespace Task9
{
    public class DataContext
    {
        public int Id1;
        public int Id2;
        public string GetUserStatus;
        public HttpStatusCode SetStatusResponseCode;
        public HttpStatusCode DeleteUserStatusCode;
        public HttpStatusCode GetBalanceStatusCode;
        public HttpStatusCode GetChargeStatusCode;
        public HttpResponseMessage GetResponse;

    }
}
