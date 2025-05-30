﻿namespace eCommerceApp.Application.Services.interfaces.Logging
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogWaning(string message);
        void LogError(Exception ex, string message);
    }
}
