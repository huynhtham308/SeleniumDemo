using System.Configuration;

namespace TestFrameWorkCore.Helper
{
    public class ConfigurationHelper
    {
        // T: co nhieu data type
        // static ma ko khoi tao vi no la 
        public static T? GetConfig<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value is null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
