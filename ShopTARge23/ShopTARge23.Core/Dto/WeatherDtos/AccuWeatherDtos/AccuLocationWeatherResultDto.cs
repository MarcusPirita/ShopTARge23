
using Castle.Components.DictionaryAdapter;

namespace ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDtos
{
    public class AccuLocationWeatherResultDto
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int Rank { get; set; }


        public Int32 Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string AdministrativeArea { get; set; }
        public string TimeZone { get; set; }


    }
}
