namespace RPFramework.Models.api.DashboardRelated
{
    public class WidgetInDashboard
    {
        public string WidgetName { get; set; }
        public int WidgetId { get; set; }
        public string WidgetType { get; set; }
        public WidgetSize WidgetSize { get; set; }
        public WidgetPosition WidgetPosition { get; set; }
        public bool Share { get; set; }
        public WidgetOptions WidgetOptions { get; set; }
    }
}