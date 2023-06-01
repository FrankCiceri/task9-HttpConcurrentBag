using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9.Models.Responses
{
    public class TransactionsResponse
    {
        [JsonProperty("userId")]
        public int UserID { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("time")]
        public string Time  { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("baseTransactionId")]
        public string BaseTransactionId { get; set; }



    }
}
