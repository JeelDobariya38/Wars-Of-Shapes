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
                UpdateScoreText();
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
            UpdateScoreText();
        }

        public int GetScore()
        {
            return Mathf.FloorToInt(_score);
        }

        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(_score).ToString();
        }
    }
}
