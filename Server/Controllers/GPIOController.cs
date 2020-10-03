using BlazorGPIO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Iot.Device.CpuTemperature;

namespace BlazorGPIO.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GPIOController : ControllerBase
    {

        private readonly ILogger<GPIOController> logger;

        public GPIOController(ILogger<GPIOController> logger)
        {
            this.logger = logger;
        }



        [HttpGet]
        public Double Get()
        {
            CpuTemperature cpuTemperature = new CpuTemperature();
            double temperature = -1;
            if (cpuTemperature.IsAvailable)
            {
                temperature = cpuTemperature.Temperature.Celsius;
                if (!double.IsNaN(temperature))
                {
                    System.Diagnostics.Debug.WriteLine($"CPU Temperature: {temperature} C");
                }
            }
            return temperature;
        }

        [HttpGet("{state}")]
        public string Get(bool state)
        {
            string result =  Shared.RaspberryPiDriverGPIOTester.InputPullResistorsWork(state);
            return result;
        }
    }
}
