namespace S_C.API.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public bool IsActive { get; set; }

        public int AnswerId { get; set; }
    }
}
