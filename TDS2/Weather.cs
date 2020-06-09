using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;

namespace TDS2
{
    public static class Weather
    {
        public static string Get()
        {
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData("https://free-api.heweather.net/s6/weather/now?location=auto_ip&key=db86a5196f304e52a4369818c5182e60"); //从指定网站下载数据
                //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句
                string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                JObject HeWeather6 = (JObject)JsonConvert.DeserializeObject(pageHtml);// 入库
                string city = HeWeather6["HeWeather6"][0]["basic"]["parent_city"].ToString();
                string cond_txt = HeWeather6["HeWeather6"][0]["now"]["cond_txt"].ToString();
                string tmp = HeWeather6["HeWeather6"][0]["now"]["tmp"].ToString();
                int tmp1 = Convert.ToInt32(tmp);
                string hum = HeWeather6["HeWeather6"][0]["now"]["hum"].ToString();
                return city + "：" + cond_txt + "  |  室外温度：" + tmp1 + "℃" + "  |  相对湿度：" + hum + "%";
            }
            catch (Exception)
            {
                return "天气信息获取失败";
            }
        }

    }
}
