using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mysurveyaspnet4.Models
{
    public class SurveyAnswer
    {
        [Key]
        public string SurveyId { get; set; }
        public string SurveyName { get; set; }
        public DateTime SurveyDate { get; set; }
        public DateTime EventDate { get; set; }

        public List<Answers> Answers { get; set; }
    }

    public class Answers
    {
        [Key]
        public int QuestionId { get; set; }
        public List<string> PossibleAnswers { get; set; }

        public string SelectedAnswer { get; set; }

    }
}