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

        [SerializeField, Header("Item Added")] private LocalizedString _localizedStringItemAdded;
        [SerializeField] private AudioClip _notificationClip;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Inventory.OnItemAdded += ItemAddedCallback;
        }

        private void OnDestroy()
        {
            Inventory.OnItemAdded -= ItemAddedCallback;
        }

        #endregion

        #region Methods

        private void ItemAddedCallback(IItem context)
        {
            var variable = (StringVariable) _localizedStringItemAdded[VariableName];
            variable.Value = context.Name.GetLocalizedString();

            var storyEventData = new StoryEventData(_localizedStringItemAdded.GetLocalizedString(), _notificationClip);
            (this as IStoryEvent).TriggerEvent(storyEventData);
        }

        #endregion
    }
}