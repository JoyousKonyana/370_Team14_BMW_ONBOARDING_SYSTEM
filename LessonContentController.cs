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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonContentController : ControllerBase
    {
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly IMapper _mapper;

        public LessonContentController(ILessonContentRepository lessonContentRepository, IMapper mapper)
        {
            _lessonContentRepository = lessonContentRepository;
            _mapper = mapper;
        }

        //[HttpGet("name")]
        //public async Task<ActionResult<Less>> GetCourseByName([FromBody] string name)
        //{
        //    try
        //    {
        //        var result = await _courseRepository.GetCourseByNameAsync(name);

        //        if (result == null) return NotFound();

        //        return _mapper.Map<CourseViewModel>(result);
        //    }
        //    catch (Exception)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
        //    }
        //}


        //[HttpPost]
        // public IActionResult Index(IFormFile files)
        // {
        //     if (files != null)
        //     {
        //         if (files.Length > 0)
        //         {
        //             //Getting FileName
        //             var fileName = Path.GetFileName(files.FileName);
        //             //Getting file Extension
        //             var fileExtension = Path.GetExtension(fileName);
        //             // concatenating  FileName + FileExtension
        //             var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

        //             var objfiles = new Files()
        //             {
        //                 DocumentId = 0,
        //                 Name= newFileName,
        //                 FileType = fileExtension,
        //                 CreatedOn = DateTime.Now
        //             };

        //             using (var target = new MemoryStream())
        //             {
        //                 files.CopyTo(target);
        //                 objfiles.DataFiles = target.ToArray();
        //             }

        //             _context.Files.Add(objfiles);
        //             _context.SaveChanges();

        //         }
        //     }
        //     return View();
        // }


        //[HttpPost]
        //public async Task<ActionResult> Uploadfile([FromForm] LessonContentViewModelDTO model)
        //{


        //    IFormFile file = model.LessonContentBytes;

        //    if (file != null)
        //    {
        //        if (file.Length > 0)
        //        {
        //            var filename = file.FileName;
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fileExtension = Path.GetExtension(filename);
        //            var newf = filename = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

        //            var obj = new LessonContent()
        //            {
        //                LessonConentId = 3,
        //                LessonContenetTypeId = 1,
        //                LessonContentDescription = model.LessonContentDescription,
        //                //LessonContentName = fileName,
        //                //LessonContentType =fileExtension,
        //                //LessonId = model.LessonId,
        //                ArchiveStatusId = 1
        //            };
        //            using(var target = new MemoryStream())
        //            {
        //                file.CopyTo(target);
        //                obj.LessonContentBytes = target.ToArray();
        //            }

        //            _lessonContentRepository.Add(obj);

        //            if( await _lessonContentRepository.SaveChangesAsync())
        //            {
        //                return Ok();
        //            }

        //         }
        //    }



        //var filen = file.FileName;

        //long length = file.Length;

        //if (length < 0)
        //    return BadRequest();

        //using var fileStream = file.OpenReadStream();
        //byte[] bytes = new byte[length];
        //var x = fileStream.Read(bytes, 0, (int)file.Length);

        //using(Stream fs = file.InputStream)
        //  long length = file.Length;

        //  if (length < 0) 
        //      return BadRequest();



        //  using var fileStream = file.OpenReadStream();
        //  byte[] bytes = new byte[length];

        //  var mx =file.ContentType;
        //var m=  fileStream.Read(bytes, 0, (int)file.Length);

        //if (file.Length > 0)
        //  {
        //      using (var ms = new MemoryStream())
        //      {
        //          var hex = file.CopyToAsync(ms);

        //          var fileBytes = ms.ToArray();

        //          var s = Convert.ToBase64String(fileBytes);

        //          LessonContentViewModel mb = new LessonContentViewModel();

        //          mb.ArchiveStatusId = model.ArchiveStatusId;
        //          mb.LessonContenetTypeId = model.LessonContenetTypeId;
        //          mb.LessonContentBytes = bytes;
        //      }
        //  }
        //if(file.Length == 0)
        //      return BadRequest();
        //  else
        //  {
        //      using (StreamReader reader = new StreamReader(file.OpenReadStream()))
        //      {
        //          string content = reader.ReadToEnd();
        //      }
        //  }




        //    return Ok();
        //}

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LessonContentViewModel>> UploadContentLink([FromBody] LessonContentViewModel model)
        {
            try
            {
                var lessonContent = _mapper.Map<LessonContent>(model);
                _lessonContentRepository.Add(lessonContent);

                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return Ok(lessonContent);
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]")]
        public async Task<ActionResult<LessonContentViewModel>> AchiveLessonContent(int id, LessonContentViewModelDTO model)
        {
            try
            {
                var results = await _lessonContentRepository.GetLessonContentByIdAsync(id);

                if (results == null)
                {
                    return NotFound($"Could Not find Lesson content");
                }
                else
                {
                    results.ArchiveStatusId = 1;
                    _mapper.Map(model, results);

                }



                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return Ok("Lesson content successfully archived");
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }


        //get lesson content associated with a specific lesson outcome
        [Authorize(Roles = Role.Onboarder + "," + Role.Admin + "," + Role.Manager)]
        [HttpGet("{id}")]
        [Route("[action]")]
        public async Task<ActionResult<LessonContentViewModel[]>> GetLessonContentByLessonOutcome(int id)
        {
            try
            {
                var result = await _lessonContentRepository.GetLessonContentByLessonIDsAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<LessonContentViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }

}
