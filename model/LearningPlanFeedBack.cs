using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace feedBack
{

    class LearningPlanFeedBack
    {
        [Key]
        public string LearningPlanFeedBackId { get; set; }
        // chane camel case into pascal case
        public List<UserId> UserIdTracker{get;set;}
        public string LearningPlanId{get;set;}
        public double AverageStar { get; set;}
        public List<StarTrack> StarTracker {get;set;}

        // public bool subscribe {get; set;}

        // public SubscribeTrack SubscribeTracker {get;set;}

    }


}

