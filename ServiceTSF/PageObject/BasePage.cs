using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTSF.WrapperFactory;

namespace ServiceTSF.PageObject
{
    class BasePage
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            return page;
        }

        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static NonLoginHomePage NonLoginHome
        {
            get { return GetPage<NonLoginHomePage>(); }
        }

    }
}
