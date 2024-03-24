using Miscellaneous;
using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Player.GameStories.StoryEvents
{
    public class StoryEpisodeInventoryUpdates : MonoBehaviour, IStoryEpisode
    {
        #region Constants

        private const string VariableName = "value";

        #endregion

        #region Editor Fields

        [SerializeField] private Inventory _inventory;

        [SerializeField] private LocalizedString _localizedStringItemAdded;
        [SerializeField] private LocalizedString _localizedStringItemDropped;
        [SerializeField] private LocalizedString _localizedStringItemUsed;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Inventory.OnItemAdded.AddListener(ItemAddedCallback);
            Inventory.OnItemDropped.AddListener(ItemDroppedCallback);
            Inventory.OnItemUsed.AddListener(ItemUsedCallback);
        }

        private void OnDestroy()
        {
            Inventory.OnItemAdded.RemoveListener(ItemAddedCallback);
            Inventory.OnItemDropped.RemoveListener(ItemDroppedCallback);
            Inventory.OnItemUsed.RemoveListener(ItemUsedCallback);
        }

        #endregion

        #region Methods

        private void ItemAddedCallback(EventContext.ItemEvent context)
        {
            CreateEpisode(context.Item, _localizedStringItemAdded);
        }

        private void ItemDroppedCallback(EventContext.ItemEvent context)
        {
            CreateEpisode(context.Item, _localizedStringItemDropped);
        }

        private void ItemUsedCallback(EventContext.ItemEvent context)
        {
            CreateEpisode(context.Item, _localizedStringItemUsed);
        }

        private void CreateEpisode(IItem item, LocalizedString localizedString)
        {
            var variable = (StringVariable) localizedString[VariableName];
            variable.Value = item.Name;

            var storyEpisodeData = new StoryEpisodeData(localizedString.GetLocalizedString());
            (this as IStoryEpisode).TriggerEvent(storyEpisodeData);
        }

        #endregion
    }
}