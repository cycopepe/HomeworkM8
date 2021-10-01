using System.Collections.Generic;

namespace Common.Dtos
{
    public class PlayersResponse
    {
        public List<InnerPlayerResponse> Values { get; set; }
    }

    public class InnerPlayerResponse
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public float h_meters { get; set; }
        public int h_in { get; set; }
    }

    /*
     "first_name":"Alex",
"h_in":"77",
"h_meters":"1.96",
"last_name":"Acker"
     */
}