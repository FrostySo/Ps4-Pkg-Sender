using System.Linq;
using System.Reflection;

namespace Ps4_Pkg_Sender.Utilities {
    public static class ReflectionUtil {
        public static void ChangeVaue(object obj, string propertyName, object newValue) {
            if (propertyName.IndexOf('.') != -1) {
                var dotSplit = propertyName.Split('.');
                object parentObject = obj;
                for (int i = 0; i < dotSplit.Length - 1; i++) {
                    PropertyInfo propertyInfo = parentObject.GetType().GetProperty(dotSplit[i]);
                    if (propertyInfo == null) {
                        return;
                    }
                    parentObject = propertyInfo.GetValue(parentObject);
                }

                PropertyInfo targetPropertyInfo = parentObject.GetType().GetProperty(dotSplit.Last());
                if (targetPropertyInfo != null) {
                    targetPropertyInfo.SetValue(parentObject, newValue);
                }
            } else {
                var property = obj.GetType().GetProperty(propertyName);
                property.SetValue(obj, newValue);
            }
        }
    }
}
