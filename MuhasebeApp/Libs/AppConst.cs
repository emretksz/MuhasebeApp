using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeApp.Libs
{
    public static class AppConst
    {

        public static List<Check> CheckList
        {
            get
            {
                var json = Preferences.Get("CheckList", null);
                return string.IsNullOrEmpty(json) ? new List<Check>()
                    : JsonConvert.DeserializeObject<List<Check>>(json);
            }
        }

        public static Check GetCheck(long id)
        {
            var json = Preferences.Get("CheckList", null);
            if (string.IsNullOrEmpty(json))
                return null;
            var result = JsonConvert.DeserializeObject<List<Check>>(json);
            return result.Where(a => a.id == id).FirstOrDefault();
        }

        public static bool AddCheck(Check check)
        {
            var json = Preferences.Get("CheckList", null);
            if (string.IsNullOrEmpty(json) == false)
            {
                var result = JsonConvert.DeserializeObject<List<Check>>(json);
                result.Add(check);
                Preferences.Set("CheckList", JsonConvert.SerializeObject(result));
            }
            else
                Preferences.Set("CheckList", JsonConvert.SerializeObject(check));

            return true;

        }
        public static bool UpdateCheck(Check check)
        {
            var json = Preferences.Get("CheckList", null);
            var result = JsonConvert.DeserializeObject<List<Check>>(json);
            var query = result.FirstOrDefault(a => a.id == check.id);
            query = check;
            Preferences.Set("CheckList", JsonConvert.SerializeObject(result));
            return true;

        }

    }
}
