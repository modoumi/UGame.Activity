using UGame.Activity.Redpack.Models.Enums;

namespace UGame.Activity.Redpack.Models.Dtos;

public class TaskRecordDto
{
    /// <summary>
    /// 任务分类
    /// </summary>
    public TaskCategoryEnums TaskCategory { get; set; }

    /// <summary>
    /// 进度奖金
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Bonus奖金
    /// </summary>
    public decimal Bonus { get; set; }

    /// <summary>
    /// 操作时间
    /// </summary>
    public DateTime RecDate { get; set; }

    /// <summary>
    /// 被分享用户编码
    /// </summary>
    public string PUserId { get; set; }

    /// <summary>
    /// 被分享用户手机
    /// </summary>
    public string PMobile { get; set; }

    /// <summary>
    /// 被分享用户名称
    /// </summary>
    public string PUserName { get; set; }

    /// <summary>
    /// 被分享用户昵称
    /// </summary>
    public string PNickName { get; set; }
}
