using Domain.Core.Bus;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Domain.Core.Commands;
using Domain.Core.Notifications;

namespace Domain.CommandHandlers
{
    public class CommandHandler
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler _bus;
        protected IMemoryCache _cache;
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, IMemoryCache cache)
        {
            _uow = uow;
            _bus = bus;
            _cache = cache;
        }

        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);

                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent<DomainNotification>(new DomainNotification("", error.ErrorMessage));
            }

            //将错误信息收集一：缓存方法（错误示范）
           // _cache.Set("ErrorData", errorInfo);
        }

        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
     
}
