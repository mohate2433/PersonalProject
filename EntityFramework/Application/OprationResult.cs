using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Application
{
    public class OprationResult
    {

        public string Message { get; set; }
        public bool IsSuccedd { get; set; }

        public OprationResult()
        {
            IsSuccedd = false;
        }

        public OprationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedd = true;
            Message = message;
            return this;
        }
        public OprationResult Failed(string message)
        {
            IsSuccedd = false;
            Message = message;
            return this;
        }
    }
}
