﻿namespace Authentication.Application.Common.Notifications.Servcies;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}
