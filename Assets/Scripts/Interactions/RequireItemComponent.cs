using Scripts.Collectables;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Interactions
{
    public class RequireItemComponent : MonoBehaviour
    {
        [SerializeField] private bool _removeAfterUse;
        [SerializeField] private UnityEvent _onSuccess;
        [SerializeField] private UnityEvent _onFail;
        [SerializeField] private KeyCollector _keyCollector;

        public void Check()
        {
            if (_keyCollector == null)
            {
                Debug.LogWarning("KeyCollector is not assigned.");
                _onFail?.Invoke();
                return;
            }

            var areAllKeysCollected = _keyCollector.AreAllKeysCollected();

            if (areAllKeysCollected)
            {
                if (_removeAfterUse)
                {
                    _keyCollector.ResetKeys();
                }

                _onSuccess?.Invoke();
            }
            else
            {
                _onFail?.Invoke();
            }
        }
    }
}
