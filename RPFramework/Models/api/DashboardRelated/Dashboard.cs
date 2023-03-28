using System;
using System.Collections.Generic;

namespace RPFramework.Models.api.DashboardRelated
{
    public class Dashboard
    {
        public string Description { get; set; }
        public string Owner { get; set; }
        public bool Share { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WidgetInDashboard> Widgets { get; set; }

        protected bool Equals(Dashboard other)
        {
            return Description == other.Description && Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Dashboard)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Description, Id, Name);
        }
    }
}