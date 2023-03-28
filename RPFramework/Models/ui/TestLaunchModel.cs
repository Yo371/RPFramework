namespace RPFramework.Models.ui
{
    public class TestLaunchModel
    {
        public string Title { get; set; }
        
        public string Total { get; set; }
        
        public string Passed { get; set; }
        
        public string Failed { get; set; }
        
        public string Skipped { get; set; }
        
        public string ProductBug { get; set; }
        
        public string AutoBug { get; set; }
        
        public string SystemIssue { get; set; }
        
        public string ToInvestigate { get; set; }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            var other = (TestLaunchModel)obj;
            return Title == other.Title && Total == other.Total && Passed == other.Passed && Failed == other.Failed && Skipped 
                == other.Skipped && ProductBug == other.ProductBug && AutoBug == other.AutoBug && SystemIssue 
                == other.SystemIssue && ToInvestigate == other.ToInvestigate;
        }
    }
}