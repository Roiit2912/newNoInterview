    
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
    namespace sample
    {

         public class User
      {
          //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

         // public int UserId{get;set;}

          public string Email{get;set;}

          public string FullName{get;set;}

          

           // [Required]
          // public string Username { get; set; }

         // [Required]
          public string Password { get; set; }

          public string Designation {get;set;}

        //   public enum Designation { Learner, SME} ;      //enum declared

        //   public  Designation value  {get; set;}

         

      }

    }
    
   