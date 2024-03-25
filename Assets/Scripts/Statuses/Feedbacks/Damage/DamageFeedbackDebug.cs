using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.Utility;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackDebug : DamageFeedback
    {
        #region Methods

        protected override void DamagedCallback(EventContext.FloatEvent context)
        {
            LogWriter.DevelopmentLog($"{name} was damaged for: {context.Float.ToString("F")}; remained health: {Health.CurrentValue.ToString("F")}/{Health.MaxValue.ToString("F")}");
        }

        #endregion
    }
}