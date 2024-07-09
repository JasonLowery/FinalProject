using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton to this script
    public static GameManager Instance { get; private set;}
    public int score =0; //tracl points
    public TextMeshProUGUI scoreText; // holds score text
    public GameObject victoryText; // holds victory text
    public GameObject pickupParent; // hold  pickup parent
    public int TotalPickups = 0; //number of pickups
    private PlayerController player; 
    private void Awake()
    {
        if (Instance==null) 
        {
            Instance=this;
        }
        else
        {
            Debug.LogWarning("");
            Destroy(this.gameObject); 
        }
    }
    private void Start()
    {
        score= 0; //reset score
        UpdateScoreText();
        victoryText.SetActive(false); //disable score text
        TotalPickups= pickupParent.transform.childCount;
    }
    public void UpdateScore(int amount) //amount to increase by
    {
        //Increase score var by amount given
        if(score >= TotalPickups) WinGame(); //if no more pickups then
        score = score + amount;
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        scoreText.text= "score: " + score.ToString(); //ToString makes this into a string making the code work

    }
    public void WinGame()
    {
        victoryText.SetActive(true); //enable victory text
        EndGame();
    }
    public void EndGame()
    {
        Invoke("LoadCurrentLevel", 2f);
    }
    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void losegame()
    {
        {
            Invoke("LoadCurrentLevel", 2f);
        }
        void LoadCurrentLevel()
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene(). buildIndex));
        }
        
    }
}
