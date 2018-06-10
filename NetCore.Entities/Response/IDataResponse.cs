using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Entities.Response
{
    public interface IDataResponse<T> where T : class
    {
        List<T> Data { get; set; }
    }

}
