using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application
{
    public class TBaseResponse<T>: BaseResponse
    {
        public T? Data { get; set; }

        public List<T>? Result { get; set; }

        public TBaseResponse(T data_) : base()
        {
            Data = data_;
        }

        public TBaseResponse(List<T> data_) : base()
        {
            Result = data_;
        }

        public TBaseResponse(string errorMessage) : base(errorMessage, false) {

        }
    }
}
