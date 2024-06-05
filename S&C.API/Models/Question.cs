namespace S_C.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign key for Category
        public DateTime Updated { get; internal set; }
        public DateTime Created { get; internal set; }

        // Foreign key for User (Microsoft Identity kullanılacak)
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        // Navigation property for Answers

        public int AnswerId { get; set; }
        public List<Answer> Answers { get; set; }
        public int CategoryId { get; internal set; }

        public bool IsActive { get; set; }
    }
}
