using UnityEngine.Events;
using UnityEngine;

namespace Scripts.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent<int> _onChange;

        public void ModifyHealth(int amount)
        {
            if (_health <= 0) return;

            if (amount < 0)
            {
                _health += amount;
                _onDamage?.Invoke();

                if (_health <= 0)
                {
                    _onDie?.Invoke();
                }
            }
            else if (amount > 0 && Health < 10) // 10 = maxHealth
            {
                _health += amount;
            }

            _onChange?.Invoke(_health);
        }

        public int Health => _health;

#if UNITY_EDITOR
        [ContextMenu("Update Health")]
        private void UpdateHealth()
        {
            _onChange?.Invoke(_health);
        }
#endif
        public void SetHealth(int health)
        {
            _health = health;
            _onChange?.Invoke(_health);
        }

        public void AddOnChangeListener(UnityAction<int> listener)
        {
            _onChange.AddListener(listener);
        }

        public void RemoveOnChangeListener(UnityAction<int> listener)
        {
            _onChange.RemoveListener(listener);
        }
    }
}