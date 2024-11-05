using Nancy.Json;
using ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using System.Net;


namespace ShopTARge23.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "QDALiSm2r5SpVY5Bm41qLzisj1puDHwQ";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";
            //127964 - Tallinna kood
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

               List<AccuLocationRootDto> accuResult = new JavaScriptSerializer()
                    .Deserialize<List<AccuLocationRootDto>>(json);

                dto.CityName = accuResult[0].LocalizedName;
                dto.CityCode = accuResult[0].Key;
            }

            string urlWeather = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.CityCode}?apikey={accuApiKey}&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlWeather);
                AccuWeatherRootDto.Root weatherRootDto = new JavaScriptSerializer()
                    .Deserialize<AccuWeatherRootDto.Root>(json);

                dto.EffectiveDate = weatherRootDto.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherRootDto.Headline.EffectiveEpochDate;
                dto.Severity = weatherRootDto.Headline.Severity;
                dto.Text = weatherRootDto.Headline.Text;
                dto.Category = weatherRootDto.Headline.Category;
                dto.EndDate = weatherRootDto.Headline.EndDate;
                dto.EndEpochDate = weatherRootDto.Headline.EndEpochDate;

                dto.MobileLink = weatherRootDto.Headline.MobileLink;
                dto.Link = weatherRootDto.Headline.Link;

                dto.DailyForecastsDate = weatherRootDto.DailyForecasts[0].Date;

            }

            return dto;
        }
    }
}
