using DomainModel;

namespace Interfaces.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int feedback_mark { get; set; }
        public string feedback_text { get; set; }

        public FeedbackDTO () { }
        public FeedbackDTO (Feedback feedback)
        {
            Id = feedback.Id;
            feedback_mark = feedback.feedback_mark; 
            feedback_text = feedback.feedback_text;
        }

    }
}
