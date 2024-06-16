using Scripts.Health;
using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "HealthEffect", menuName = "Effects/Health")]
    public class HealthEffect : ScriptableObject
    {
        [SerializeField] private int healthChange;

        public void ApplyEffect(GameObject target)
        {
            var health = target.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.ModifyHealth(healthChange);
            }
        }
    }
}