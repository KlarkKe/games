using Scripts.ScriptableObjects;
using UnityEngine;

namespace Scripts.Health
{
    public class ModifyHPComponent : MonoBehaviour
    {
        public HealthEffect effect;

        public void ApplyHpModify(GameObject target)
        {
            if (target.CompareTag("Player"))
            {
                effect.ApplyEffect(target);
            }
            else if (target.CompareTag("enemy"))
            {
                effect.ApplyEffect(target);
            }
        }
    }
}