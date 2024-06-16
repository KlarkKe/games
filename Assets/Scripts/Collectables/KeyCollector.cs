using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Collectables
{
    public class KeyCollector : MonoBehaviour
    {
        [SerializeField] private TMP_Text keyProgressText;
        [SerializeField] private int totalKeys = 5;
        [SerializeField] private int collectedKeys = 0;
        [SerializeField] private UnityEvent onAllKeysCollected;

        void Start()
        {
            UpdateKeyProgress();
        }

        public void CollectKey()
        {
            collectedKeys++;
            UpdateKeyProgress();

            if (collectedKeys >= totalKeys)
            {
                onAllKeysCollected?.Invoke();
            }
        }

        void UpdateKeyProgress()
        {
            keyProgressText.text = $"Собрано {collectedKeys}/{totalKeys} ключей";
        }

        public bool AreAllKeysCollected()
        {
            return collectedKeys >= totalKeys;
        }

        public void ResetKeys()
        {
            collectedKeys = 0;
            UpdateKeyProgress();
        }
    }
}