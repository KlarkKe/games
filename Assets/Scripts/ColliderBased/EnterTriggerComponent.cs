using UnityEngine.Events;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.ColliderBased
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private UnityEvent<GameObject> _action;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.IsInLayer(_layer)) return;

            if (!string.IsNullOrEmpty(_tag) && !collision.gameObject.CompareTag(_tag)) return;

            _action?.Invoke(collision.gameObject);
        }
    }
}