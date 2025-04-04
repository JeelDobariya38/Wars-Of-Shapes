using UnityEngine;
using TMPro;

namespace WarsOfShapes
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private float _score = 0f;
        private bool _isCounting = false;

        private void Update()
        {
            if (_isCounting)
            {
                _score += Time.deltaTime;
                GameMenuManager.Instance.UpdateScoreText(Mathf.FloorToInt(_score));
            }
        }

        public void StartScoring()
        {
            _isCounting = true;
        }

        public void StopScoring()
        {
            _isCounting = false;
        }

        public void ResetScore()
        {
            _score = 0f;
            GameMenuManager.Instance.UpdateScoreText(Mathf.FloorToInt(_score));
        }

        public int GetScore()
        {
            return Mathf.FloorToInt(_score);
        }
    }
}
