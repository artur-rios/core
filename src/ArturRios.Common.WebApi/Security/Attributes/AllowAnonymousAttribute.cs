﻿// ReSharper disable ClassNeverInstantiated.Global
// Reason: This class is used as an attribute and is not instantiated directly

namespace ArturRios.Common.WebApi.Security.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute;
