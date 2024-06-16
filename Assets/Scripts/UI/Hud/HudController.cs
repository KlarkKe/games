using Scripts.Health;
using Scripts.UI.Widgets;
using UnityEngine;

namespace Scripts.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ProgressBarWidget _healthBar;
        [SerializeField] private HealthComponent _playerHealthComponent;
        [SerializeField] private int _maxHealth;

        private void Start()
        {
            if (_playerHealthComponent != null)
            {
                _playerHealthComponent.AddOnChangeListener(OnHealthChanged);
                OnHealthChanged(_playerHealthComponent.Health);
            }
        }

        private void OnHealthChanged(int newValue)
        {
            var value = (float)newValue / _maxHealth;
            _healthBar.SetProgress(value);
        }

        private void OnDestroy()
        {
            if (_playerHealthComponent != null)
            {
                _playerHealthComponent.RemoveOnChangeListener(OnHealthChanged);
            }
        }
    }
}