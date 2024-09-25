using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Match3
{
    public class GameOver : MonoBehaviour
    {
        public GameObject screenParent;
        public GameObject scoreParent;
        public Text loseText;
        public Text scoreText;
        public Image[] stars;

        private void Start ()
        {
            screenParent.SetActive(false);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].enabled = false;
            }
        }

        public void ShowLose()
        {
            screenParent.SetActive(true);
            scoreParent.SetActive(false);

            Animator animator = GetComponent<Animator>();

            if (animator)
            {
                animator.Play("GameOverShow");
            }
        }

        public void ShowWin(int score, int starCount)
        {
            screenParent.SetActive(true);
            loseText.enabled = false;

            scoreText.text = score.ToString();
            scoreText.enabled = false;

            Animator animator = GetComponent<Animator>();

            if (animator)
            {
                animator.Play("GameOverShow");
            }

            StartCoroutine(ShowWinCoroutine(starCount));
        }

        private IEnumerator ShowWinCoroutine(int starCount)
        {
            yield return new WaitForSeconds(0.5f);

            if (starCount < stars.Length)
            {
                for (int i = 0; i <= starCount; i++)
                {
                    stars[i].enabled = true;

                    if (i > 0)
                    {
                        stars[i - 1].enabled = false;
                    }

                    yield return new WaitForSeconds(0.5f);
                }
            }

            scoreText.enabled = true;
            StartCoroutine(IncrementScore());
        }

        private IEnumerator IncrementScore()
        {
            int displayedScore = 0;
            int finalScore = int.Parse(scoreText.text);  // 현재 표시된 최종 점수 가져오기
            float duration = 1.5f;  // 점수 증가 시간 (1.5초)
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                displayedScore = Mathf.FloorToInt(Mathf.Lerp(0, finalScore, elapsed / duration));  // 점수 증가 계산
                scoreText.text = displayedScore.ToString();  // 스코어 텍스트 업데이트
                yield return null;  // 한 프레임 대기
            }

            // 최종 점수를 다시 정확하게 설정
            scoreText.text = finalScore.ToString();
        }

        public void OnReplayClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        public void OnDoneClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
        }

    }
}
