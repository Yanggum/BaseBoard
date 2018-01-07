using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;
//using Mik.SmartPortal.Common.Management;

namespace Pc.PcBoard.Resources.MultilangApi
{
    /*!
     * \brief   다국어 리소스를 지원하는 싱글턴 클래스입니다.
     */
    public class MultilangManager
    {
        private Dictionary<string, Dictionary<LangCultureParameter, string>> MultilangDictionary
        { get; set; }


        // 클라이언트 기반 코드베이스와 달리 웹상에서는 공용 변수로는 처리가 불가능함
        //private LangCultureParameter _currentLang = LangCultureParameter.Ko;

        /*!
		 * \brief   현재 설정된 문화권의 언어 코드를 반환하거나 설정합니다.
		 */
        public LangCultureParameter CurrentLang
        {
            //get { return _currentLang; }
            //private set
            //{
            //    if (_currentLang == value)
            //        return;

            //    _currentLang = value;

            //    //if (CurrentLangChanged != null)
            //    //CurrentLangChanged.CrossInvoke(this, EventArgs.Empty);
            //}
            get
            {

                //switch (UserInfoManager.CurrentUserInfo.UseLangCode.ToUpper())
                String langcode = null;
                try
                {
					//var cookie = HttpContext.Current.Request.Cookies["MIK_LANGUAGE_CODE"];
					//langcode = cookie == null ? "KO" : cookie.Value;
					langcode = "KO";//UserInfoManager.CurrentUserInfo.UseLangCode;
                }
                catch (Exception) { langcode = "KO"; }
                switch (langcode.ToUpper())
                {
                    case "EN":
                        return LangCultureParameter.En;
                    case "ZH":
                        return LangCultureParameter.Zh;
                    default:
                    case "KO":
                        return LangCultureParameter.Ko;
                }

            }
        }

        /*!
		 * \brief   key에 해당하는 리소스를 반환합니다.
		 */
        public string Get(string key)
        {
            return MultilangDictionary[key][CurrentLang];
        }

        public String GetSafety(String key, String defaultValue = "")
        {
            if (MultilangDictionary.ContainsKey(key))
            {
                if (MultilangDictionary[key].ContainsKey(CurrentLang))
                {
                    return MultilangDictionary[key][CurrentLang];
                }
            }
            return defaultValue;
        }

        /*!
		 * \brief   인스턴스를 반환합니다.
		 */
        public static MultilangManager Instance
        { get { return _instantce.Value; } }

        private static readonly Lazy<MultilangManager> _instantce
            = new Lazy<MultilangManager>(() => new MultilangManager());

        /*!
		 * \brief   Constructor
		 */
        private MultilangManager()
        {
            MultilangDictionary = new Dictionary<string, Dictionary<LangCultureParameter, string>>();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Resources.MultiLanguage);
            LoadXml(xml);
        }

        /*!
		 * \brief   XML 리소스를 로드합니다.
		 */
        private void LoadXml(XmlDocument xml)
        {
            //<resource xmlns:xsi="http:www.w3.org/2001/XMLSchema-instance">
            //  <multilang>
            //    <set>
            //      <key>sampleResource</key>
            //      <val>
            //        <ko>샘플입니다.</ko>
            //        <en>샘플입니다.</en>
            //        <zh>샘플입니다.</zh>
            //        <ja>샘플입니다.</ja>
            //      </val>
            //    </set>
            //  </multilang>
            //</resource>

            MultilangDictionary = new Dictionary<string, Dictionary<LangCultureParameter, string>>();

            //XmlNodeList setNodeList = xml.SelectNodes("/resource/multiLang/set");
            XmlNodeList setNodeList = xml.SelectNodes("/PortalMultiLanguage/Section/set");

            foreach (XmlNode setNode in setNodeList)
            {
                string key = setNode["key"].InnerText;

                Dictionary<LangCultureParameter, string> valueStore = new Dictionary<LangCultureParameter, string>();

                foreach (XmlNode valNode in setNode["val"].ChildNodes)
                {
                    string langName = valNode.Name;
                    string langValue = valNode.InnerText;

                    switch (langName.ToUpper())
                    {
                        case "KO":
                            {
                                valueStore.Add(LangCultureParameter.Ko, langValue);
                                break;
                            }
                        case "EN":
                            {
                                valueStore.Add(LangCultureParameter.En, langValue);
                                break;
                            }
                        case "ZH":
                            {
                                valueStore.Add(LangCultureParameter.Zh, langValue);
                                break;
                            }
                    }
                }

                MultilangDictionary.Add(key, valueStore);
            }
        }

        ///*!
        // * \brief   현재 문화권을 설정합니다.
        // */
        //public void SetCurrentCulture(string culture)
        //{ SetCurrentCultureInternal(culture); }

        ///*!
        // * \brief   현재 문화권을 설정합니다.
        // */
        //public void SetCurrentCulture(CultureInfo culture)
        //{ SetCurrentCultureInternal(culture.Name); }

        ///*!
        // * \brief   현재 문화권을 설정합니다.
        // */
        //private void SetCurrentCultureInternal(string culture)
        //{

        //    if (culture.Equals("ko", StringComparison.OrdinalIgnoreCase))
        //    {
        //        CurrentLang = LangCultureParameter.Ko;
        //    }
        //    else if (culture.Equals("en", StringComparison.OrdinalIgnoreCase))
        //    {
        //        CurrentLang = LangCultureParameter.En;
        //    }
        //    else if (culture.Equals("zh", StringComparison.OrdinalIgnoreCase))
        //    {
        //        CurrentLang = LangCultureParameter.Zh;
        //    }
        //    else
        //    {
        //        CurrentLang = LangCultureParameter.Ko;
        //    }
        //}
    }
}