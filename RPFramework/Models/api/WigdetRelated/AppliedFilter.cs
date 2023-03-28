using System.Collections.Generic;

namespace RPFramework.Models.api.WigdetRelated
{
    public class AppliedFilter
    {
        public string owner { get; set; }
        public bool share { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<Condition> conditions { get; set; }
        public List<Order> orders { get; set; }
        public string type { get; set; }
    }
}