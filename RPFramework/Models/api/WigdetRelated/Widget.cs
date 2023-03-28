using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RPFramework.Models.api.WigdetRelated
{
    public class Widget
    {
        public string description { get; set; }
        public string owner { get; set; }
        public bool share { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string widgetType { get; set; }
        public ContentParameters contentParameters { get; set; }
        public List<AppliedFilter> appliedFilters { get; set; }
        public Content content { get; set; }

        protected bool Equals(Widget other)
        {
            return description == other.description && id == other.id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Widget)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(description, id);
        }
    }
}