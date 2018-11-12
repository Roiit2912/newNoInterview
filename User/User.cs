    
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
    namespace sample
    {

         public class User
      {
          [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
          public string Email{get;set;}
          public string Password { get; set; }
           public string FullName{get;set;}
         
      }

    }
    
   