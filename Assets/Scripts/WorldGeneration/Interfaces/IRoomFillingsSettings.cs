﻿using UnityEngine;
using WorldGeneration.Utility;

namespace WorldGeneration.Interfaces
{
    public interface IRoomFillingsSettings
    {
        #region Methods

        bool TryGetFilling(Vector2Int roomSize, out RoomFilling roomFilling);
        RoomFilling GetBossRoomFilling();

        #endregion
    }
}