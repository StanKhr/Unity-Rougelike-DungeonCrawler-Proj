using Player.Inventories.Items;

namespace Player.Inventories
{
    public class ItemDatabase : ScriptableDatabase<Item>
    {
        #region Fields

        private static ItemDatabase _instance;

        #endregion
        
        #region Properties

        public static ItemDatabase Instance => _instance ??= new ItemDatabase();

        #endregion
        
        #region Methods

        protected override string GetGuid(Item scriptableObject)
        {
            if (!scriptableObject)
            {
                return string.Empty;
            }
            
            return scriptableObject.Guid;
        }

        #endregion
    }
}