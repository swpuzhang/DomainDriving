using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Commands;
using DomainDriving.Helper;

namespace DomainDriving.Controllers
{
    /// <summary>
    /// Student 相关操作
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentAppService _service;
        public StudentController(IStudentAppService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取所有student信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<StudentViewModel> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// 注册一个student
        /// </summary>
        /// <param name="studentViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                string errorMsg = string.Empty;
                foreach (var onePire in ModelState)
                {
                    var state = onePire.Value;
                    errorMsg += ErrorString.CollectError(state.Errors.Select(r => r.ErrorMessage));
                }
         
                return errorMsg;
            }
            #region 
            /*RegisterStudentCommand registerStudentCommand =
                new RegisterStudentCommand(studentViewModel.Name,
                studentViewModel.Email, studentViewModel.BirthDate,
                studentViewModel.Phone);
            if (!registerStudentCommand.IsValid())
            {
                return ErrorString.CollectError(registerStudentCommand.ValidationResult.Errors);
            }*/
            #endregion

            _service.Register(studentViewModel);
            return "success";
        }
    }
}