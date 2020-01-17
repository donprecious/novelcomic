

namespace Webnovel.Enum
{
    public enum ContentStatus{
        Completed, UnderReview, Developing, Hide, 
    }

    public enum EntityVisibilityStatus
    {
        Hidden, Visible
    }
    public enum ChapterStatus
    {
        Published, Draft
    }

    public class StatusModel
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int StatusEnumValue { get; set; }
    }
}
