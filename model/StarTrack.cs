using System;
using System.ComponentModel.DataAnnotations;

namespace feedBack
{
    class StarTrack
{
    [Key]
    public string StarTrackId { get; set; }
    public string UserId {get; set;}
    public int Star {get; set;}
    public string LearningPlanFeedBackId { get; set; }
    public string ResourceFeedBackId { get; set; }
     


}

}

