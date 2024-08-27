﻿using WeatherService.Models.Enums;

namespace WeatherService.Interfaces
{
    public interface IWeatherBotFactory
    {
        IWeatherBot CreateBot(weatherbots BotType);

    }
}