using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sample;

namespace temp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {

        IUserRepository IUserobj;
        public loginController(IUserRepository UserRepository)
        {
            this.IUserobj = UserRepository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromHeader]string token)
        {

            var value = TokenManager.ValidateMyToken(token);

            if (value == null)
            {
                return Unauthorized();
            }

            else
            {
                return Ok("access granted");
            }

        }

        

        [HttpPost()]

        [Route("/sme/signIn")]

        public string smeSignIn([FromBody] signIn signIn)
        {
            if (ModelState.IsValid)
            {
                User u = IUserobj.GetUser(signIn.email);
                if (u == null)
                {
                    string x="user does not exist";
                    return JsonConvert.SerializeObject(x);
                }

                if(!(IUserobj.Hash(signIn.password).Equals(u.Password)))
                {
                    string x = "Password entered is not correct";
                    return JsonConvert.SerializeObject(x) ;
                }

                if(!(u.Designation.Equals("SME")))
                {
                    string x = "You are a learner, Please sign in through learner page";
                    return JsonConvert.SerializeObject(x) ;

                }    

                bool credentials = (IUserobj.Hash(signIn.password).Equals(u.Password) && (u.Designation.Equals("SME")));
                if (credentials)
                { 
                    //var token = TokenManager.GenerateSmeToken(signIn.email);
                    string token = TokenManager.GenerateSmeToken(signIn.email);
                    //var pass = IUserobj.Hash(signIn.password);
                    Console.WriteLine("dady!!!!!!!!!!!!!!!!!" + u.Password+token);

                    return token;

                }

        
            }
            return "Invalid state";
        }


        [HttpPost()]

        [Route("/sme/signUp")]

        public string smeSignUp([FromBody]signUp signUp)
        {
            if(ModelState.IsValid)
            {
                User u = IUserobj.GetUser(signUp.email);
            
            string s = IUserobj.GenerateSecurityKey(signUp.fullName);
            string secureKey = s.Substring(0, 5);
            Console.WriteLine("Security Key = "+secureKey);
            //string secureKey="mybro";
            if(u != null)
            {
                string x = "User already exist";
                return JsonConvert.SerializeObject(x) ;
            }
            else if(signUp.securityKey != secureKey)
            {
                string x = "Wrong Security Key entered";
                return JsonConvert.SerializeObject(x) ;

            }
            //bool confirm = ((u == null) && (signUp.securityKey == secureKey));
            else
            {
               User newUser=new User();
                newUser.Email = signUp.email;
                newUser.Password = IUserobj.Hash(signUp.password);
               // newUser.Password= signUp.password;
                newUser.FullName = signUp.fullName;
                newUser.Designation = "SME";
                IUserobj.Register(newUser);
                string x = "Success";
                return JsonConvert.SerializeObject(x) ;

            }
                
            }

            
            else
            {
                string x = "Invalid state";
                return JsonConvert.SerializeObject(x) ;
            }



        }




        [HttpPost]

        [Route("/learner/signIn")]

        public string learnerSignIn(signIn signIn)
        {
            if (ModelState.IsValid)
            {
                 
                User u = IUserobj.GetUser(signIn.email);
                if (u == null)
                {
                    string x="user does not exist";
                    return JsonConvert.SerializeObject(x);
                }

                if(!(IUserobj.Hash(signIn.password).Equals(u.Password)))
                {
                    string x = "Password entered is not correct";
                    return JsonConvert.SerializeObject(x) ;
                }

                if(!(u.Designation.Equals("LEARNER")))
                {
                    string x = "You are a sme, Please sign in through sme page";
                    return JsonConvert.SerializeObject(x) ;

                }    

                bool credentials = (IUserobj.Hash(signIn.password).Equals(u.Password) && (u.Designation.Equals("LEARNER")));
             
                if (credentials)
                { 
                     
                    //var token = TokenManager.GenerateLearnerToken(signIn.email);
                     var token = TokenManager.GenerateLearnerToken(signIn.email); 
                     Console.WriteLine("brooooooooooooooooooooooooo"+token);
                    return token;

                }
                
        
            }
            
            return "Invalid state";
           
        }


        [HttpPost]

        [Route("/learner/signUp")]

        public string learnerSignUp(signUp signUp)
        {
            if(ModelState.IsValid)
            {
                User u = IUserobj.GetUser(signUp.email);
            
            
                if(u != null)
                {
                    string x = "User already exist";
                    return JsonConvert.SerializeObject(x) ;
                }
            
                else
                {
                    User newUser=new User();
                    newUser.Email = signUp.email;
                    newUser.Password = IUserobj.Hash(signUp.password);
                    // newUser.Password= signUp.password;
                    newUser.FullName = signUp.fullName;
                    newUser.Designation = "LEARNER";
                    IUserobj.Register(newUser);
                    string x = "Success";
                    return JsonConvert.SerializeObject(x) ;
                }

            }
            else
            {
                return "Invalid state";
            }

            
           

        }


        
    }
}
