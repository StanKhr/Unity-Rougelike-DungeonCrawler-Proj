using WorldGeneration.Data;

namespace WorldGeneration.Interfaces
{
    public interface ILevelLayoutSettings
    {
        #region Methods
        
        int GetExpectedRoomsAmount();
        int GetCorridorSteps();
        RoomData GetStartRoom();
        RoomData GetRandomRoom();        
        RoomData GetBossRoom();

        #endregion
    }
}