namespace UGame.Activity.Tasks.API.Dtos.Responses;

public class TaskDetailDto
{
    public string DetailID { get; set; }
    public string UserID { get; set; }
    public string RewardID { get; set; }
    public int ItemID { get; set; }
    /// <summary>
    /// 是否是任务
    /// </summary>
    public bool IsTask { get; set; }
    /// <summary>
    /// 是否是常驻任务，完成不删除
    /// </summary>
    public bool IsResident { get; set; }
    /// <summary>
    /// 初始行为类型, 0-无动作，按钮不可用 1-跳转连接
    /// </summary>
    public int InitActionType { get; set; }
    public int RewardType { get; set; }
    public decimal RewardAmount { get; set; }
    public string Title { get; set; }
    public string Template { get; set; }
    public int Level { get; set; }
    public int CurrentValue { get; set; }
    public int ActionType { get; set; }
    public string ActionValue { get; set; }
    public int MaxValue { get; set; }
    public int Sequence { get; set; }
    public int Status { get; set; }
}
