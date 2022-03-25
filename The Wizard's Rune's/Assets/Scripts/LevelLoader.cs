using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    [SerializeField] float TransitionTime = 2f;
    [SerializeField] GameObject transitionImg;    
    [SerializeField]  AudioMixer audioMixer;
    public void PlayScene()
    {
        transitionImg.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transitionAnim.SetTrigger("TransitionTrigger");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }
}
