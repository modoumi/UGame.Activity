using SActivity.Common.Enums;
using SActivity.Common.Repositories.tinyfx;
using TinyFx.Data;

namespace SActivity.Common.Domain.Services;

public class ActivityOperatorService
{
    public async Task<L_activity_operatorEO> GetSingleActivityAsync(string operatorId, string currencyId, ActivityType activityType, TransactionManager tm = null)
    {
        return await new L_activity_operatorMO().GetSingleAsync("ActivityID = @ActivityID and OperatorID = @OperatorID and CurrencyID = @CurrencyID", (int)activityType, operatorId, currencyId);
    }
}
