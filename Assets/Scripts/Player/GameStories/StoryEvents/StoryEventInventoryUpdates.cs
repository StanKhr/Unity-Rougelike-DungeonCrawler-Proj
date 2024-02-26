using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Player.GameStories.StoryEvents
{
    public class StoryEventInventoryUpdates : MonoBehaviour, IStoryEvent
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
            Inventory.OnItemAdded += ItemAddedCallback;
            Inventory.OnItemDropped += ItemDroppedCallback;
            Inventory.OnItemUsed += ItemUsedCallback;
        }

        private void OnDestroy()
        {
            Inventory.OnItemAdded -= ItemAddedCallback;
            Inventory.OnItemDropped -= ItemDroppedCallback;
            Inventory.OnItemUsed -= ItemUsedCallback;
        }

        #endregion

        #region Methods

        private void ItemAddedCallback(IItem context)
        {
            CreateEvent(context, _localizedStringItemAdded);
        }

        private void ItemDroppedCallback(IItem context)
        {
            CreateEvent(context, _localizedStringItemDropped);
        }

        private void ItemUsedCallback(IItem context)
        {
            CreateEvent(context, _localizedStringItemUsed);
        }

        private void CreateEvent(IItem item, LocalizedString localizedString)
        {
            var variable = (StringVariable) localizedString[VariableName];
            variable.Value = item.Name;

            var storyEventData = new StoryEventData(localizedString.GetLocalizedString());
            CallEvent(storyEventData);
        }

        private void CallEvent(StoryEventData storyEventData)
        {
            (this as IStoryEvent).TriggerEvent(storyEventData);
        }

        #endregion
    }
}