using UnityEngine;

namespace Scripts.Obstacles
{
    public class RotateObjectComponent : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;

        void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
