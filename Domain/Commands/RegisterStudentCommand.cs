using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Domain.Commands
{
    public class RegisterStudentCommand : StudentCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
        }

        // 重写基类中的 是否有效 方法
        // 主要是为了引入命令验证 RegisterStudentCommandValidation。
        public override bool IsValid()
        {
            ValidationResult  = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
