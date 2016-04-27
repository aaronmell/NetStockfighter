using System.Collections.Generic;


namespace Stockfighter.Client.Data
{
    public class AllOrdersStatusResponse : BaseResponse
    {
        public string Venue { get; set; }

        public List<Order> Orders {get; set;}
    }
}
