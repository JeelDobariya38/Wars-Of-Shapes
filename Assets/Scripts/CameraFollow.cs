using UnityEngine;

namespace WarsOfShapes
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
        [SerializeField] private float smoothSpeed = 0.125f;

        private void Start()
        {   
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
