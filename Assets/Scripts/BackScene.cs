using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3
{
    public class BackScene : MonoBehaviour
    {
        public void StartBtn()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
