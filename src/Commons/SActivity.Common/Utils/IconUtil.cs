using SActivity.Common.Options;
using TinyFx.Configuration;

namespace SActivity.Common.Utils;

/// <summary>
/// 
/// </summary>
public class IconUtil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="icon"></param>
    /// <returns></returns>
    public static string GetIcon(string icon)
    {
        var _options = ConfigUtil.GetSection<OptionsSection>();

        if (icon.StartsWith("http")) return icon;

        return _options.ImageBaseUrl + icon;
    }
}
