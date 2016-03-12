using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour
{
    AudioClip[] meows;
    AudioClip[] hisses;
    AudioClip[] purrs;
    AudioSource audio;
    public static GameController instance;
    public int points;
    public Text scoreText;
    public Text messageText;
    void Awake()
    {
        if (instance != null) { Destroy(this); }
        else { instance = this; }
    }
    void Start()
    {
        points = 0;
        audio = GetComponent<AudioSource>();
        meows = Resources.LoadAll<AudioClip>("Audio/Meow");
        hisses = Resources.LoadAll<AudioClip>("Audio/Hiss");
        purrs = Resources.LoadAll<AudioClip>("Audio/Purr");
        UpdateUI();
    }

    void Update()
    {
        if (points < 0)
        {
            SceneManager.LoadScene("Game"); 
        }
    }

    public void AddPoints(PointType type)
    {
        switch (type)
        {
            case PointType.Purrfect:
                points += 50;
                break;
            case PointType.Awesome:
                points += 25;
                break;
            case PointType.Good:
                points += 15;
                break;
            case PointType.Meh:
                points += 1;
                break;
            case PointType.Failcat:
                points -= 25;
                break;
            default:
                break;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score " + points;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        StartCoroutine(FadeMessage());
    }
    public void PlayRandomSound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Meow:
                audio.PlayOneShot(meows[Random.Range(0, meows.Length)], 1f);
                break;
            case SoundType.Hiss:
                audio.PlayOneShot(hisses[Random.Range(0, hisses.Length)], 1f);
                break;
            case SoundType.Purr:
                audio.PlayOneShot(purrs[Random.Range(0, purrs.Length)], 1f);
                break;
            default:
                Debug.Log("Unknown SoundType");
                break;
        }
    }

    IEnumerator FadeMessage()
    {
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        messageText.gameObject.SetActive(false);
    }
    
}
