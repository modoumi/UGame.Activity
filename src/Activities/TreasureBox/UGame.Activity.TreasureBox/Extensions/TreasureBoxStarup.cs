using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using TinyFx.AspNet;

namespace UGame.Activity.TreasureBox.Extensions;

/// <summary>
/// 应用程序加载
/// </summary>
public class TreasureBoxStarup : ITinyFxHostingStartup
{
    /// <summary>
    /// Configuration
    /// </summary>
    /// <param name="webApplication"></param> 
    public void Configure(WebApplication webApplication)
    {

    }

    /// <summary>
    /// Servers
    /// </summary>
    /// <param name="webApplicationBuilder"></param> 
    public void ConfigureServices(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Host.UseXxyyCommonServer<OptionsSection>();
    }
}
