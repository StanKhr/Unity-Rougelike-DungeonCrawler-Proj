using Miscellaneous;
using Player.Inventories;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace Player.GameStories.StoryEvents
{
    public class StoryEpisodeInventory : StoryEpisode
    {
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
            CreateGenericEpisode(context.Item.Name, _localizedStringItemAdded);
        }

        private void ItemDroppedCallback(EventContext.ItemEvent context)
        {
            CreateGenericEpisode(context.Item.Name, _localizedStringItemDropped);
        }

        private void ItemUsedCallback(EventContext.ItemEvent context)
        {
            CreateGenericEpisode(context.Item.Name, _localizedStringItemUsed);
        }

        #endregion
    }
}