using UnityEngine;

namespace Player.Interfaces
{
    public interface IPlayerGps
    {
        #region Properties

        float X { get; }
        float Y { get; }
        float Z { get; }

        Vector3Int PositionRoundedToInt => new(Mathf.RoundToInt(X), Mathf.RoundToInt(Y), Mathf.RoundToInt(Z));

        #endregion
    }
}