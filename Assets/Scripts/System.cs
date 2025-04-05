using UnityEngine;

namespace WarsOfShapes
{
    public class System : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit()
        {
            Destroy(this);
        }
    }
}
