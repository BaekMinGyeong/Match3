using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    public class QuitBtn : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
        }
    }
}
