using OEleitor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEleitor.Domain.Message
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; } 

        public string Message { get; set; }

        public object Data { get; set; }

        public CommandResult() { }

        public CommandResult(object data)
        {
            Data = data;
        }

        public CommandResult(bool success)
        {
            Success = success;
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, object data)
        {
            Success = success;
            Data = data;
        }
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
