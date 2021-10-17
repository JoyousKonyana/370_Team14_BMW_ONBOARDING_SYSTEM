using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboarderController : ControllerBase
    {
        private readonly IOnboarderRepository _onboarderRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public OnboarderController(IOnboarderRepository onboarderRepository, IMapper mapper)
        {
            _onboarderRepository = onboarderRepository;
            _mapper = mapper;
        }

        //[Authorize(Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        //getAll courses Assigeng to this a onboarder
        // used to show courses to onboarder
        public async Task<ActionResult<Onboarder[]>> GetAllOnboarders()
        {
            try
            {
                var result = await _onboarderRepository.GetOnboarders();

                if (result == null) return NotFound();



                return result;
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [Authorize(Role.Admin)]
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        //getAll courses Assigeng to this a onboarder
        // used to show courses to onboarder
        public async Task<ActionResult<OnboarderCourseEnrollment[]>> GetAllCoursesAssignedToOnboarder(int empID)
        {
            try
            {

                empID = 2;
                var result = await _onboarderRepository.GetOnboarderbyEmpID(empID);

                if (result == null) return NotFound();
                OnboarderCourseEnrollment[] assignedCourses = await _onboarderRepository.GetAssignedCourses(2);
                if (assignedCourses == null) return NotFound();


                return assignedCourses;
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        // cant send email for ask a question
        //public void  AskQuestion(PushNotificationViewModel model)
        //{
        //    SmtpClient Client = new SmtpClient()
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential()
        //        {
        //            UserName = "team14onboarding@gmail.com",
        //            Password = "Team123456"
        //        }

        //    };
        //    MailAddress FromMail = new MailAddress(model.SendersMail, "Onboarder");
        //    MailAddress ToEmail = new MailAddress(model.ReceiversMail, "Manager");
        //    MailMessage Message = new MailMessage()
        //    {
        //        From = FromMail,
        //        Subject = "Log in details",
        //        Body = $"Good day \n \n  {model.Body} \n \n Kind regards \n Onboarder"
        //    };

        //    Message.To.Add(ToEmail);

        //    try
        //    {
        //        //    Client.UseDefaultCredentials = true;

        //        Client.Send(Message);


        //    }
        //    catch (Exception ex)
        //    {

        //        var n = ex.Message;
        //    }
        //}
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
                    UserName = "skhosanajames48@gmail.com",
                    Password = "Nja@9901"
                }

            };
            MailAddress FromMail = new MailAddress("skhosanajames48@gmail.com", "Admin");
            MailAddress ToEmail = new MailAddress("konyanajoyous2@gmail.com", "Joyous");
            MailMessage Message = new MailMessage()
            {
                From = FromMail,
                Subject = "Log in details",
                Body = $"Good day \n Theis email aim to give you your login credentials \n Username: {user.Username} \n password: {password}"
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

        //[Authorize(Role.Onboarder)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<OnboarderCourseEnrollment>> GenerateCourseProgressReport([FromBody] OnboarderProgressViewModel model)
        {
            try
            {
                var result = await _onboarderRepository.GenerateOnboarderCourseProgress(model);

                if (result == null) return NotFound();

                return _mapper.Map<OnboarderCourseEnrollment>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<OnboarderCourseEnrollment[]>> GenerateAllCourseProgressReport([FromBody] OnboarderProgressViewModel model)
        {
            try
            {
                var result = await _onboarderRepository.GenerateAllOnboarderCourseProgress(model);

                if (result == null) return NotFound();

                return _mapper.Map<OnboarderCourseEnrollment[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

    }
}
