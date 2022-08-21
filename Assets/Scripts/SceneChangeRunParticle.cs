using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeRunParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    public string sceneName;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayParticles()
    {
        ps.Stop();
        ps.Play();
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
