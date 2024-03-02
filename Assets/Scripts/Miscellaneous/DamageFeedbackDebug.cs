namespace Miscellaneous
{
    public class DamageFeedbackDebug : DamageFeedback
    {
        #region Methods

        protected override void DamagedCallback(float context)
        {
            LogWriter.DevelopmentLog($"{name} was damaged for: {context.ToString("F")}; remained health: {Health.CurrentValue.ToString("F")}/{Health.MaxValue.ToString("F")}");
        }

        #endregion
    }
}