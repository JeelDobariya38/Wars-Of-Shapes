using UnityEngine;
using TMPro;

namespace WarsOfShapes
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private float _startTime;
        private float _updateInterval = 0.1f;
        private float _nextUpdateTime;

        private void Start()
        {
            _startTime = Time.time;
            _nextUpdateTime = Time.time;
        }

        private void Update()
        {
            if (Time.time >= _nextUpdateTime)
            {
                _nextUpdateTime = Time.time + _updateInterval;
                UpdateScoreText();
            }
        }

        public void ResetTimer()
        {
            _startTime = Time.time;
        }

        private void UpdateScoreText()
        {
            _scoreText.text = $"Survival Time: {Time.time - _startTime:F1} sec";
        }
    }
}
