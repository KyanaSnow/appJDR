using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    [SerializeField] private bool FadeOutScreen;
    [SerializeField] private bool LoadInActivate;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private bool loadDebug;

    void Update()
    {
        if (Input.GetButtonDown("Debug"))
            Application.LoadLevel(SceneToLoad);
    }

    void Start()
    {
        if (LoadInActivate)
        {
            Application.LoadLevel(SceneToLoad);
        }
    }

    public void loadScene(string scene)
    {
        Application.LoadLevel(scene);
    }
}
