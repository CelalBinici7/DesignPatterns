using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObserverDesignPattern : MonoBehaviour
{
  
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.Instance.AddScore(10);
        }
    }
}

public interface IObserver
{
    void OnNotify();
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.OnNotify();
        }
    }
}


public class ScoreDisplay : MonoBehaviour, IObserver
{
    public Text scoreText;

    public void OnNotify()
    {
        
        scoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
    }
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int score = 0;
    private Subject subject = new Subject();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
      
        ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
        subject.AddObserver(scoreDisplay);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score updated. Current score: " + score);

      
        subject.NotifyObservers();
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void AddObserver(IObserver observer)
    {
        subject.AddObserver(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        subject.RemoveObserver(observer);
    }
}
