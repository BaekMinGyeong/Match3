using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3
{
    public class StartGame : MonoBehaviour
    {
        // Start is called before the first frame update
       
        public void StartBtn()
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
