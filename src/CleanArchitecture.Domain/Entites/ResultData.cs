using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entites
{
    public class ResultData
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string error_detail { get; set; }
    }
}
