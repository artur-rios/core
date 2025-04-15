﻿namespace TechCraftsmen.Core.Output;

public abstract class CustomException(string[] messages, string message = "Internal error") : Exception(message)
{
    public string[] Messages { get; } = messages;
}
