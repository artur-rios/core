﻿using Microsoft.AspNetCore.Mvc;
using TechCraftsmen.Core.Extensions;
using TechCraftsmen.Core.Output;

namespace TechCraftsmen.Core.WebApi;

public class WebApiOutput<T> : DataOutput<T>
{
    private readonly int _httpStatusCode;
    
    public WebApiOutput(T? data, string[] messages, bool success, int httpStatusCode) : base(data, messages, success)
    {
        ValidateStatusCode(httpStatusCode);
        
        _httpStatusCode = httpStatusCode;
    }

    public WebApiOutput(DataOutput<T> dataOutput, int httpStatusCode) : base(dataOutput.Data, dataOutput.Messages, dataOutput.Success)
    {
        ValidateStatusCode(httpStatusCode);
        
        _httpStatusCode = httpStatusCode;
    }

    public ObjectResult ToObjectResult()
    {
        return new ObjectResult(new DataOutput<T>(Data, Messages, Success)){ StatusCode = _httpStatusCode };
    }

    private static void ValidateStatusCode(int httpStatusCode)
    {
        if (httpStatusCode.NotIn(HttpStatusCodes.All))
        {
            throw new ArgumentException("Unsupported status code passed to constructor");
        }
    }
}