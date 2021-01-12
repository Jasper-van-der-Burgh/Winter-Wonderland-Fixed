using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WinterWonderland {
    public static class SceneManagement {
        public static void Next() {
            Scene current = SceneManager.GetActiveScene();
            int next = ( current.buildIndex + 1 ) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene( next );
        }
    }
}