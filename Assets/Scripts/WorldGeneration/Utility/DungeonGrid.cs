using System.Collections.Generic;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Enums;

namespace WorldGeneration.Utility
{
    public class DungeonGrid
    {
        #region Constructors

        public DungeonGrid()
        {
            
        }

        #endregion

        #region Properties

        public Dictionary<Vector2Int, CellType> Cells { get; private set; } = new();

        #endregion

        #region Methods

        public CellType GetCellByAxis(Vector2Int position)
        {
            return Cells.GetValueOrDefault(position, CellType.Empty);
        }

        public void ClearCell(int x, int y)
        {
            SetCell(x, y, CellType.Empty);
        }
        
        public void ClearCell(Vector2Int position)
        {
            SetCell(position, CellType.Empty);
        }
        
        public void SetCell(int x, int y, CellType type)
        {
            SetCell(new Vector2Int(x, y), type);
        }
        
        public void SetCell(Vector2Int position, CellType type)
        {
            Cells[position] = type;
        }

        public void AddRoom(RoomData roomData)
        {
            var cornerX = GetRoomCornerAxis(roomData.SizeX);
            var cornerY = GetRoomCornerAxis(roomData.SizeY);
            
            for (int x = cornerX * -1; x <= cornerX; x++)
            {
                for (int y = cornerY * -1; y <= cornerY; y++)
                {
                    var cellPosition = new Vector2Int(x + roomData.GridCenterPosition.x,
                        y + roomData.GridCenterPosition.y);
                    
                    if (GetCellByAxis(cellPosition) == CellType.Floor)
                    {
                        continue;
                    }
                    
                    CellType usedType;
                    if (Mathf.Abs(x) == cornerX || Mathf.Abs(y) == cornerY)
                    {
                        usedType = CellType.Wall;
                    }
                    else
                    {
                        usedType = CellType.Floor;
                    }
                    
                    SetCell(cellPosition, usedType); 
                }
            }
        }

        private int GetRoomCornerAxis(int relatedSizeAxis)
        {
            return relatedSizeAxis % 2 == 0 ? relatedSizeAxis / 2 : (relatedSizeAxis + 1) / 2;
        }

        #endregion
    }
}