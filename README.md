# BlazGPIO
Test [dotnet/iot](https://github.com/dotnet/iot) functionality in a Blazor App.

**Blazor WebAssembly app**  
Demonstrates that a Blazor WASM Client can't call hardware directly.  
Can call it via the service though.  
Focus is upon GPIO functionality and Bindings Devices functionality.

## Pages

- All calls fail gracefully if hardware not available.
- Get CPU Core Temperature
  - Gets the CPU Core temperature of a RPi when running Debian/Linux
  - Nb: Does not work with Windows 10 IoT-Core
  - Uses the **CpuTemperature** Device form **IoT.Devices.Bindings**
  - Call to Device is from .ASP.NET Core _(.Net Core functionality)_
- Get Set GPIO Pins
  - Sets or clears a RPi pin
  - Does/should work with Windows 10 IoT-Core as well
  - Uses **System.Device.GPIO** directly
  - System.Device.GPIO is a .NET Standard library
  - Call is from the Shared Library _(Which is also .NET Standard)_
  - Nb: Call can only be via service. Call direct from WASM Client always fails.
