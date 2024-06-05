using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_C.API.Dtos;
using S_C.API.Models;

namespace S_C.API.Controllers
{
   
    [ApiController]
    [Route("api/Questions")]
    
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public QuestionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<QuestionDto> GetList()
        {
            var questions = _context.Questions.ToList();
            var questionsDtos = _mapper.Map<List<QuestionDto>>(questions);
            return questionsDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public QuestionDto Get(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).SingleOrDefault();
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        [HttpGet]
        [Route("{id}/Answers")]
        public List<AnswerDto> GetAnswer(int id)
        {
            var answers = _context.Answers.Where(q => q.AnswerId == id).ToList();
            var answerDtos = _mapper.Map<List<AnswerDto>>(answers);
            return answerDtos;
        }

        [HttpPost]
        public ResultDto Post(QuestionDto dto)
        {
            if (_context.Questions.Count(c => c.Title == dto.Title) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Başlık Kayıtlıdır!";
                return result;
            }
            var question = _mapper.Map<Question>(dto);
            question.Updated = DateTime.Now;
            question.Created = DateTime.Now;
            _context.Questions.Add(question);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Başlık Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(QuestionDto dto)
        {
            var question = _context.Questions.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (question == null)
            {
                result.Status = false;
                result.Message = "Soru Bulunamadı!";
                return result;
            }
            question.Title = dto.Title;
            question.IsActive = dto.IsActive;
            question.Body = dto.Body;
            question.Updated = DateTime.Now;
            question.CategoryId = dto.CategoryId;
            _context.Questions.Update(question);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Soru Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).SingleOrDefault();
            if (question == null)
            {
                result.Status = false;
                result.Message = "Soru Bulunamadı!";
                return result;
            }

            // Sorunun bağlı cevaplarını bul ve sil
            var answers = _context.Answers.Where(a => a.QuestionId == id).ToList();
            _context.Answers.RemoveRange(answers);

            _context.Questions.Remove(question);
            try
            {
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Soru Silindi";
            }
            catch (DbUpdateException ex)
            {
                result.Status = false;
                result.Message = "Silme işlemi sırasında bir hata oluştu: " + ex.InnerException?.Message;
            }

            return result;
        }



    }

}
