using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Helpers
{
    public static class Constants
    {
      
        public static string Wave_live_PublicKey = "FLWPUBK-95d03c8a604b14a5d7e56259099c44f0-X";
        public static string Wave_live_SecretKey = "FLWSECK-b5f8e98109ed10d11d39559c4be76d3c-X";
        public static string Wave_live_EncryptionKey = "b5f8e98109ed175260fe3c29";
        
        public static string Wave_test_PublicKey = "FLWPUBK_TEST-be05b6283bf02cabb4d08a701d84aff4-X";
        public static string Wave_test_SecretKey = "FLWSECK_TEST-d51098d13a93cb8f54139ff2794fd221-X";
        public static string Wave_test_EncryptionKey = "FLWSECK_TESTacaf5d42c462";

        public static string Wave_Base_Script_API_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/flwpbf-inline.js";
        //Live URL
        //public static string RaveApiUrl = "https://api.ravepay.co/flwv3-pug/getpaidx/api/v2/";
        //Test URL
        public static string RaveApiUrl = "https://ravesandboxapi.flutterwave.com/flwv3-pug/getpaidx/api/v2";
    }

    public static class PageUrls
    {
        public static string Faq  = "/Home/Page/1";
        public static string About = "/Home/Page/2";

        public static string PolicyPage = "/Home/Page/3";
        
        public static string Terms = "/Home/Page/4"; 

    }

    public static class AppConstant
    {
        public static double UsdPerCowries = 0.05;
        public static double UsdPerEpisode = 0.15; 
    }
}
