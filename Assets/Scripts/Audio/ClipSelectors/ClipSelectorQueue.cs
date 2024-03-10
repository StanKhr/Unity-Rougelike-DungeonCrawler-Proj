using System.Collections.Generic;
using Miscellaneous;
using UnityEngine;

namespace Audio.ClipSelectors
{
    [CreateAssetMenu (menuName = "RPG / Clip Selectors / Queue", fileName = "ClipSelector_Queue_NEW")]
    public class ClipSelectorQueue : ClipSelector
    {
        #region Editor Fields

        [SerializeField] private bool _randomOrder;
        [SerializeField] private AudioClip[] _clips;

        #endregion

        #region Fields

        private Queue<AudioClip> _queue;
        private static readonly List<AudioClip> TempList = new();

        #endregion

        #region Methods
        
        public override AudioClip SelectNext()
        {
            if (_queue == null)
            {
                _queue = new Queue<AudioClip>(_clips.Length);
                if (_randomOrder)
                {
                    TempList.Clear();
                    TempList.AddRange(_clips);

                    for (int i = TempList.Count - 1; i >= 0; i--)
                    {
                        var clipIndex = Randomizer.RangeInt(0, TempList.Count);
                        var addClip = TempList[clipIndex];
                        TempList.RemoveAt(clipIndex);
                    
                        _queue.Enqueue(addClip);
                    }
                }
                else
                {
                    for (int i = 0; i < _clips.Length; i++)
                    {
                        _queue.Enqueue(_clips[i]);
                    }
                }
            }

            if (_queue.Count <= 0)
            {
                return null;
            }

            var clip = _queue.Dequeue();
            _queue.Enqueue(clip);
            return clip;
        }
        
        #endregion
    }
}