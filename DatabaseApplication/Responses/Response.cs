﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Responses
{
    public class Response<T>
    {



        public readonly static int FoundCode = 200;
        public readonly static int NotFoundCode = 404;

        public int Code { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }
    }
}
