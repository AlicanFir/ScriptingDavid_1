using System;
using UnityEngine;

namespace _Scripts.TennisV3
{
    public class StartButton : MonoBehaviour
    {
        public void OnGameStart()
        {
            gameObject.SetActive(false);
        }

        private void OnGameStop()
        {
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            GameManagerAdvanced.Instance.OnGameStart += OnGameStart;
            GameManagerAdvanced.Instance.OnGameStop -= OnGameStop;
        }

        private void OnDisable()
        {
            GameManagerAdvanced.Instance.OnGameStart -= OnGameStart;
            GameManagerAdvanced.Instance.OnGameStop += OnGameStop;
        }
    }
}