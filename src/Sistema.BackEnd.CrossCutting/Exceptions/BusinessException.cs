using System;

namespace Sistema.BackEnd.CrossCutting.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message): base(message)
        {
                
        }
    }
}
