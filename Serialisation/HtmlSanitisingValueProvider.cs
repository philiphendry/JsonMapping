using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace JsonMapping.Serialisation
{
    public class HtmlSanitisingValueProvider : IValueProvider
    {
        private readonly PropertyInfo _targetPropertyInfo;

        public HtmlSanitisingValueProvider(PropertyInfo targetPropertyInfo)
        {
            _targetPropertyInfo = targetPropertyInfo;
        }

        public void SetValue(object target, object value)
        {
            var sanitisedHtml = new Ganss.XSS.HtmlSanitizer().Sanitize(value as string);
            _targetPropertyInfo.SetValue(target, sanitisedHtml);
        }

        public object GetValue(object target)
        {
            return _targetPropertyInfo.GetValue(target);
        }
    }
}