﻿using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.AccuWeathers;

namespace ShopTARge23.Controllers
{
    public class AccuWeathersController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public AccuWeathersController
            (
            IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("City", "AccuWeathers", new {city = model.CityName});
            }

            return View(model);
        }

        [HttpGet]

        public IActionResult City(string city)
        {
            AccuLocationWeatherResultDto dto = new();
            dto.CityName = city;

            _weatherForecastServices.AccuWeatherResult(dto);

            return View();
        }
    }
}