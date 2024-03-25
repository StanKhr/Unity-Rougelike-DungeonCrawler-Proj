namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackDestroyer : DamageFeedbackDisabler
    {
        #region Methods

        protected override void ApplyDeathEffect()
        {
            Destroy(Target);
        }

        #endregion
    }
}