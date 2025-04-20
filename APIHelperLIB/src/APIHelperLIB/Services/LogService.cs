using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHelperLIB.Services
{
    public static class LogService
    {
        public static string GetLogInfo()
        {
            return "LogID:{LogId} DeviceID:{DeviceID} CSN:{CSN} ServiceName:{ServiceName} Type:{Type} Parameter:{Parameter} Exception:{Exception}";
        }

        public static string[] GetLogDetail(string logId, string deviceId, string custId, string serviceName, string type, object data, string exception)
        {
            return
            [
                logId,
                deviceId.Trim(),
                custId.Trim(),
                serviceName.Trim(),
                type.Trim(),
                JsonSerializer.Serialize(data),
                exception.ToString()
            ];
        }
    }
}
