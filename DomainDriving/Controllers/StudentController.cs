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
using Microsoft.Extensions.Caching.Memory;
using Domain.Core.Notifications;
using MediatR;

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
        private IMemoryCache _cache;
        private readonly DomainNotificationHandler _notifications;
        public StudentController(IStudentAppService service,
            IMemoryCache cache, INotificationHandler<DomainNotification> notifications)
        {
            _service = service;
            _cache = cache;
            _notifications = notifications as DomainNotificationHandler;
        }

        /// <summary>
        /// 获取所有student信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllStudent")]
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
        [Route("Register")]
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
            _service.Register(studentViewModel);
            #region 
            /*RegisterStudentCommand registerStudentCommand =
                new RegisterStudentCommand(studentViewModel.Name,
                studentViewModel.Email, studentViewModel.BirthDate,
                studentViewModel.Phone);
            if (!registerStudentCommand.IsValid())
            {
                return ErrorString.CollectError(registerStudentCommand.ValidationResult.Errors);
            }*/
            if (_notifications.HasNotifications())
            {
                return ErrorString.CollectError(_notifications.GetNotifications());
            }
           
            #endregion

       
            return "success";
        }
    }
}