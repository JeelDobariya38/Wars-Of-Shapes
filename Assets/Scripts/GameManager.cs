using UnityEngine;

namespace WarsOfShapes
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            if (Application.isEditor) {
                Application.targetFrameRate = 30;
            }
        }
    }
}
