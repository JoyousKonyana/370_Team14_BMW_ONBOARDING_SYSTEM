using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOTPRepository _otpRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserRepository userRepository,
             IOTPRepository otpRepository,
             IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _otpRepository = otpRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<User>> registerUser(CreateUserViewModel model)
        {


            try
            {

                var user = _mapper.Map<User>(model);
                var randomPassword = CreateRandomPassword();
                user.Password = hashPassword(randomPassword);
                //user.UserRoleID = 1;


                _userRepository.Add(user);

                if (await _userRepository.SaveChangesAsync())
                {
                    sendEmail(user, randomPassword);
                    return Ok();
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("name")]
        public async Task<ActionResult<User>> GetUserByEmail([FromBody] string email)
        {
            try
            {
                User user = await _userRepository.GetUserByemail(email);
                if (user == null)
                    return NotFound();

                return _mapper.Map<User>(user);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(Authenticate model)
        {
            try
            {

                User user = await _userRepository.GetUserByemail(model.UserName);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                //var user = _mapper.Map<User>(model);

                string hashedpasswod = hashPassword(model.Password);
                string b = user.Password;
                var m = user.UserRole.UserRoleName.Trim();
                var n = string.Equals(hashedpasswod, b);
                if (user.Password == hashedpasswod)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.UserRoleName.Trim())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    // return basic user info and authentication token
                    return Ok(new
                    {
                        Id = user.UserId,
                        Username = user.Username,
                        employeeID = user.EmployeeId,
                        Token = tokenString,
                        Userrole = user.UserRole.UserRoleName
                    });
                    //return _mapper.Map<User>(user);
                    //return Created($"/api/User{model.UserName}", _mapper.Map<User>(user));
                }
                return BadRequest("Either passsword or username is incorrect");

            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> twofatorAuth([FromBody] TwoFactorAuth model)
        {
            try
            {

                Otp userOtp = await _otpRepository.AuthoriseUserAsync(model.UserId);
                User user = await _userRepository.GetUserByIdAsync(model.UserId);
                if (userOtp == null)
                    return BadRequest(new { message = "Could not find Otp contact system administrator" });

                //var user = _mapper.Map<User>(model);

                //string hashedpasswod = hashPassword(model.Password);
                //string b = user.Password;
                //var m = user.UserRole.UserRoleName.Trim();
                //var n = string.Equals(hashedpasswod, b);
                if (userOtp.OtpValue == model.OtpValue)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.UserRoleName.Trim())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    // return basic user info and authentication token
                    return Ok(new
                    {
                        Id = user.UserId,
                        Username = user.Username,
                        employeeID = user.EmployeeId,
                        Token = tokenString,
                        Userrole = user.UserRole.UserRoleName
                    });
                    //return _mapper.Map<User>(user);
                    //return Created($"/api/User{model.UserName}", _mapper.Map<User>(user));
                }
                return BadRequest("OTP incorrect");

            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> compareOTP([FromBody] TwoFactorAuth model)
        {
            try
            {

                Otp userOtp = await _otpRepository.AuthoriseUserAsync(model.UserId);
                User user = await _userRepository.GetUserByIdAsync(model.UserId);
                if (userOtp == null)
                    return BadRequest(new { message = "Could not find Otp contact system administrator" });

              

               
                if (userOtp.OtpValue == model.OtpValue)
                {
                 
                    return Ok(user.UserId);
                  
                }
                return BadRequest("OTP incorrect");

            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> forgotPaaword([FromBody] string model)
        {
            try
            {

                //Otp userOtp = await _otpRepository.AuthoriseUserAsync(model.UserId);
                //User user = await _userRepository.GetUserByIdAsync(model.UserId);
                User user = await _userRepository.GetUserByemail(model);
                if (user == null)
                    return BadRequest(new { message = "Could not find User contact system administrator" });

               
                if (user != null)
                {
                    var otpGenerator = "";
                    Random otp = new Random();
                    otpGenerator = (otp.Next(100000, 999999)).ToString();
                    DateTime date = new DateTime();
                    OTPViewModel newotp = new OTPViewModel();
                    newotp.Timestamp = DateTime.Now;
                    newotp.UserId = 2;
                    newotp.OtpValue = otpGenerator;

                    var OTP1 = _mapper.Map<Otp>(newotp);

                    _userRepository.Add(OTP1);
                    if (await _userRepository.SaveChangesAsync())
                    {
                        sendOTpEmail(newotp.OtpValue, user.Username);
                        return Ok(user.UserId);

                        //return _mapper.Map<User>(user);
                        //return Created($"/api/User{model.UserName}", _mapper.Map<User>(user));

                    }
                }
                return BadRequest("Could not send otp");

            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> setPaaword([FromBody] ResetPasswordViewModel model)
        {
            try
            {

             
                var user = await _userRepository.GetUserByIdAsync(model.UserId);
                if (user == null)
                    return BadRequest(new { message = "Could not find User contact system administrator" });

                if (user != null)
                {

                    string hashedpasswod = hashPassword(model.Password);
                    user.Password = hashedpasswod;
                 
                    if (await _userRepository.SaveChangesAsync())
                    {
                        
                        return Ok("Your new password was successfully set");

                       

                    }
                }
                return BadRequest("Could not reset password");

            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login2(Authenticate model)
        {
            try
            {
                User user = await _userRepository.GetUserByemail(model.UserName);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                //var user = _mapper.Map<User>(model);

                string hashedpasswod = hashPassword(model.Password);
                string b = user.Password;
                var m = user.UserRole.UserRoleName.Trim();
                var n = string.Equals(hashedpasswod, b);
                if (user != null)
                {
                    var otpGenerator = "";
                    Random otp = new Random();
                    otpGenerator = (otp.Next(100000, 999999)).ToString();
                    DateTime date = new DateTime();
                    OTPViewModel newotp = new OTPViewModel();
                    newotp.Timestamp = DateTime.Now;
                    newotp.UserId = 2;
                    newotp.OtpValue = otpGenerator;

                    var OTP1 = _mapper.Map<Otp>(newotp);

                    _userRepository.Add(OTP1);
                    if (await _userRepository.SaveChangesAsync())
                    {
                        sendOTpEmail(newotp.OtpValue, user.Username);
                        return Ok("Please enter otp sent to your email");

                        //return _mapper.Map<User>(user);
                        //return Created($"/api/User{model.UserName}", _mapper.Map<User>(user));

                    }
                }
            }
            catch (Exception e)
            {

                BadRequest(e.Message);
            }
            return BadRequest();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<CreateUserViewModel>> AssignUserRole(AssignedUserRoleViewModel updatedModel)
        {
            try
            {
                var existinguser = await _userRepository.GetUserByIdAsync(updatedModel.UserRoleID);

                if (existinguser == null) return NotFound($"Could Not find this User ");

                existinguser.UserRoleId = updatedModel.UserRoleID;

                //_mapper.Map(updatedModel, existinguserRole);

                if (await _userRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CreateUserViewModel>(existinguser);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        //[Authorize(Roles = Role.Onboarder + "," + Role.Admin + "," + Role.Manager)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CreateUserViewModel>> ForgotPassword([FromBody] string userEmail)
        {
            try
            {
                var existinguser = await _userRepository.GetUserByemail(userEmail);

                if (existinguser == null) return NotFound($"Sorry couldnot find the user with email:{userEmail}");
                var randomPassword = CreateRandomPassword();
                existinguser.Password = hashPassword(randomPassword);


                //_mapper.Map(updatedModel, existinguserRole);

                if (await _userRepository.SaveChangesAsync())
                {
                    sendEmail(existinguser, randomPassword);
                    return Ok("Check your email for a new password");
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        public void sendEmail(User user, string password)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "team14onboarding@gmail.com",
                    Password = "Team123456"
                }

            };
            MailAddress FromMail = new MailAddress("team14onboarding@gmail.com", "Admin");
            MailAddress ToEmail = new MailAddress(user.Username, "User");
            MailMessage Message = new MailMessage()
            {
                
            
                From = FromMail,
                Subject = "Log in details",
                Body = $"Good day \n \n  Warm welcome to the IT ZA-HUB family. \n \n This email aim to give you your login credentials \n \n Username: {user.Username} \n \n Password: {password} \n \n Kind regards \n Admin"
            };

            Message.To.Add(ToEmail);

            try
            {
                //    Client.UseDefaultCredentials = true;

                Client.Send(Message);

            }
            catch (Exception ex)
            {

                var n = ex.Message;
            }
        }

        public void sendOTpEmail(string otp, string userEmail)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "team14onboarding@gmail.com",
                    Password = "Team123456"
                }

            };
            MailAddress FromMail = new MailAddress("team14onboarding@gmail.com", "Admin");
            MailAddress ToEmail = new MailAddress(userEmail, "User");
            MailMessage Message = new MailMessage()
            {


                From = FromMail,
                Subject = "log in OTP details",
                Body = $"Good day \n \n  We have realised that you trying to log-into the system. \n \n Please provide the following OTP to confirm it was you \n \n OTP: {otp} \n \n  Kind regards \n Admin"
            };

            Message.To.Add(ToEmail);

            try
            {
                //    Client.UseDefaultCredentials = true;

                Client.Send(Message);

            }
            catch (Exception ex)
            {

                var n = ex.Message;
            }
        }
        public static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }


        // create random password for user
        private static string CreateRandomPassword(int length = 6)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
