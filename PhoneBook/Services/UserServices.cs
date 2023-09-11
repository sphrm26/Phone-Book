using DataAccessLayer;
using Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Services
{
    internal class Authentication
    {
        string name;
        string email;
        string password;
        public Authentication(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }



        private void capitalLetterCheck()
        {
            string pattern_AZ = @"[A-Z]+";
            if (!Regex.IsMatch(password, pattern_AZ))
            {
                throw new Exception("The pass word must contain capital letter ");
            }
        }

        private void smallLetterCheck()
        {
            string pattern_az = @"[a-z]+";
            if (!Regex.IsMatch(password, pattern_az))
            {
                throw new Exception("The pass word must contain small letter ");
            }
        }

        private void numExistanceCheck()
        {
            string pattern_09 = @"[0-9]+";
            if (!Regex.IsMatch(password, pattern_09))
            {
                throw new Exception("The pass word must contain at least one number");
            }
        }
        private void validationPassword()
        {
            if (password.Length < 8 || password.Length > 30)
            {
                throw new Exception("The Password length must be in range 8-30");
            }
            string pattern = @"^[A-Za-z0-9@#$%^&*+=_!]*$";
            if (!Regex.IsMatch(password, pattern))
            {
                throw new Exception("you can only use numbers and letters and this symboles {@ # $ % ^ & * + = _ !} for password");
            }
            smallLetterCheck();
            capitalLetterCheck();
            numExistanceCheck();
        }
        private void validationEmail()
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"^[a-zA-Z0-9]+(?:[a-zA-Z0-9._-]*[a-zA-Z0-9])?@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
        private void validationName()
        {
            if (name.Length == 0)
            {
                throw new Exception("please enter your name");
            }
            if (name.Length > 30)
            {
                throw new Exception("maximum length of name is 30 characters");
            }
        }
        public Response Authentication_SignUp()
        {
            Response response = new Response()
            {
                isSuccess = true,
                message = "successfuly sign up"
            };
            try
            {
                validationPassword();
                validationEmail();
                validationName();
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.Message;
            }
            return response;
        }

    }
    public class UserServices
    {
        private UnitOfWork db = new UnitOfWork();
        public Response SignUp(string name, string email, string password)
        {
            var response = new Response();

            //check for dos not have same email
            User user = db.UserRepository.FindUserByEmail(email);
            if (user != null)
            {
                response.isSuccess = false;
                response.message = "this email is already exist!";
                return response;
            }

            //Authentication for valid sign up
            Authentication authentication = new Authentication(name, email, password);
            response = authentication.Authentication_SignUp();
            if (!response.isSuccess)
            {
                return response;
            }

            //add User to Database
            if (db.UserRepository.AddUser(new User()
            {
                email = email,
                password = password,
                name = name
            }) == false)
            {
                response.isSuccess = false;
                response.message = "an error occurred in data base!";
            }
            return response;
        }
        public Response LogIn(string email, string password)
        {
            var user = db.UserRepository.FindUserByEmail(email);

            if (user == null)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "your email is incorrect!"
                };
            }

            if (user.password != password)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "your password is incorrect!"
                };
            }

            var obj = new List<object>()
                {
                    new
                    {
                        email = user.email,
                        password = user.password,
                        Id = user.Id
                    }
                };
            Console.WriteLine(((dynamic)obj[0]).Id);
            return new Response()
            {
                isSuccess = true,
                message = "successfuly login",
                objects = new List<object>()
                {
                    new
                    {
                        Id = user.Id
                    }
                }
            };
        }
        public void SendOTP(string email)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("mysmtp2sphrm26@gmail.com");
                email = Convert.ToString(email);
                mail.To.Add(email);
                mail.Subject = "Phone Book one time password";

                Random rnd = new Random();
                string code = Convert.ToString(rnd.Next(100000, 1000000));
                
                mail.Body = "<body>\r\n    <h1 style=\"text-align: center;\">Phone Book One Time Password</h1><br>\r\n    <U>\r\n        <h3 style=\"text-align: center;\">983939</h3><br>\r\n    </U>\r\n    <p style=\"text-align: center;\">this is your one time password\r\n        now you can signUp in Phone Book\r\n    </p>\r\n    <p style=\"text-align: center;\">\r\n        have a nice time\r\n    </p>\r\n</body>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("mysmtp2sphrm26@gmail.com", "ccrdhlvctcahcjjk");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
