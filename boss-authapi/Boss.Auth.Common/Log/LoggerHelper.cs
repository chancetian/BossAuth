using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Log
{
    public static class LoggerHelper
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();


        public static void Debug(string info)
        {
            _logger.Debug(info);
        }

        public static void Info(string info)
        {
            _logger.Info(info);
        }

        public static void Error(string info)
        {
            _logger.Error(info);
        }

        public static void Error(Exception ex, string message)
        {
            _logger.Error(ex, message);
        }
    }
}
