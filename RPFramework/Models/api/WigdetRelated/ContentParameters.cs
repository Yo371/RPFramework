using System.Collections.Generic;

namespace RPFramework.Models.api.WigdetRelated
{
    public class ContentParameters
    {
        public List<string> contentFields { get; set; }
        public int itemsCount { get; set; }
        public WidgetOptions widgetOptions { get; set; }
    }
}