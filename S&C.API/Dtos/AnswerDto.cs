using S_C.API.Models;

namespace S_C.API.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }

        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }

        public int QuestionId { get; set; }
    }
}
