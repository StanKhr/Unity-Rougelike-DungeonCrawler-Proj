using Miscellaneous;
using Miscellaneous.EventWrapper.Main;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackDebug : DamageFeedback
    {
        #region Methods

        protected override void DamagedCallback(Events.FloatEvent context)
        {
            LogWriter.DevelopmentLog($"{name} was damaged for: {context.Float.ToString("F")}; remained health: {Health.CurrentValue.ToString("F")}/{Health.MaxValue.ToString("F")}");
        }

        #endregion
    }
}