﻿using BirdsShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } 
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; } //результат запроса

        
    }

    public interface IBaseResponse<T>
    {
        StatusCode StatusCode { get; }
        T Data { get; }        
    }
}