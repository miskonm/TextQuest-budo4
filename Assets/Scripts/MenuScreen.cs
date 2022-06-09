using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : SingletonMonoBehaviour<MenuScreen>
{
    [SerializeField] private Button _playButton;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _loadSceneName;

    private List<Test> _spawnedBullets = new List<Test>();

    protected override void Awake()
    {
        base.Awake();

        _playButton.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        _sceneLoader.LoadScene(_loadSceneName);
        GameManager.Instance.Test();
        SceneLoader.Instance.LoadScene("");

        AudioSource audioSource = GameManager.Instance.gameObject.GetComponent<AudioSource>();
        AudioSource findObjectOfType = FindObjectOfType<AudioSource>();
    }

    public void Test()
    {
        GameObject bulletGO = null;
        Test test = bulletGO.GetComponent<Test>();
        test.TurnOffMono();
        SphereCollider sphereCollider = bulletGO.GetComponent<SphereCollider>();
        sphereCollider.radius = 10;
     
        _spawnedBullets.Add(test);
    }
}