using Microsoft.Extensions.Configuration;
using Xxyy.Common;

namespace UGame.Activity.TreasureBox.Extensions;

/// <summary>
/// Options
/// </summary>
public class OptionsSection : AppSectionBase
{
    #region 环境变量可配置

    private const string ENV_MarqueeLangKey = "ENV_MarqueeLangKey";

    private const string ENV_MyGameRandomAppNumber = "ENV_MyGameRandomAppNumber";

    private const string ENV_ImageBaseUrl = "ENV_ImageBaseUrl";

    /// <summary>
    /// 优先级：环境变量ENV_MarqueeLangKey > 配置文件
    /// </summary>
    public string MarqueeLangKey { get; set; }

    /// <summary>
    /// 优先级：环境变量ENV_MyGameRandomAppNumber > 配置文件
    /// </summary>
    public string MyGameRandomAppNumber { get; set; }

    /// <summary>
    /// 优先级：环境变量ENV_ImageBaseUrl > 配置文件
    /// </summary>
    public string ImageBaseUrl { get; set; }

    public string MessageImgUrl { get; set; }

    #endregion

    public override void Bind(IConfiguration configuration)
    {
        base.Bind(configuration);

        // MarqueeLangKey
        var marqueeLangKey = Environment.GetEnvironmentVariable(ENV_MarqueeLangKey);
        if (!string.IsNullOrEmpty(marqueeLangKey))
            MarqueeLangKey = marqueeLangKey;

        // MyGameRandomAppNumber
        var myGameRandomAppNumber = Environment.GetEnvironmentVariable(ENV_MyGameRandomAppNumber);
        if (!string.IsNullOrEmpty(myGameRandomAppNumber))
            MyGameRandomAppNumber = myGameRandomAppNumber;

        // ImageBaseUrl
        var imageBaseUrl = Environment.GetEnvironmentVariable(ENV_ImageBaseUrl);
        if (!string.IsNullOrEmpty(imageBaseUrl))
            ImageBaseUrl = imageBaseUrl;
    }
}
