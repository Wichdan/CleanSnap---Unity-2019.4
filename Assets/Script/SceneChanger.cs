using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float _changeSceneDelay = 1f;
    [SerializeField] private int _targetSceneIndexDelay = 0;
    public static SceneChanger SharedInstance;

    private void Awake()
    {
        if (SharedInstance != null && SharedInstance != this) Destroy(this);
        else SharedInstance = this;
    }

    public void ChangeCurrentScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(_changeSceneDelay);
        ChangeCurrentScene(_targetSceneIndexDelay);
    }
}
