﻿using CamundaClient.Dto;
using System;
using System.Collections.Generic;

namespace CMA.ISMAI.Sagas.Domain.Interface
{
    public interface ITaskProcessing
    {
        bool FinishTasks(string processName, string Id, Dictionary<string, object> taskValues = null);
        object ReturnValueFromExternalTask(ExternalTask externalTask, string key);
        bool CheckIfItsSummerBreak(DateTime dateTime);
        Dictionary<string, object> returnDictionary(string newCardId, string courseName, string studentName, string courseInstitute);
    }
}
