using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace feedBack
{

    class QuestionFeedBack
    {

        [Key]
        public string QuestionFeedBackId { get; set; }
        public List<UserId> UserIdTracker{get;set;}
        public int QuestionId{get;set;}

        public int Ambiguity {get; set;} 
    }

}