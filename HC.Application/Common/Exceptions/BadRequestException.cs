using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Exceptions
{
    public class BadRequestException : BaseHttpException
    {
        private readonly static int statusCode = StatusCodes.Status400BadRequest;

        public BadRequestException(object customError) : base(customError, statusCode)
        {
        }

        public BadRequestException(IEnumerable<ValidationError> errors) : base(errors, statusCode)
        {
        }

        public BadRequestException(Exception ex) : base(ex, statusCode)
        {
        }

        public BadRequestException(string message, string errorCode = null, string refLink = null) : base(message, statusCode, errorCode, refLink)
        {
        }
    }
}
