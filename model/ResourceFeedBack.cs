using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace feedBack
{

    class ResourceFeedBack
    {
        public string ResourceFeedBackId { get; set; }
        public string ResourceId{get;set;}
        public float AverageStar { get; set;}
        public List<StarTrack> StarTracker {get;set;}
        
    }


}

