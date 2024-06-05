namespace S_C.API.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }

        // Foreign key for Question
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        // Foreign key for User (Microsoft Identity kullanılacak)
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AnswerId { get; internal set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
