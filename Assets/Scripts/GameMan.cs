using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public TMPro.TextMeshProUGUI question;
    Game game = new Game();

    public Button answerText1;
    public Button answerText2;
    public Button answerText3;
    public Button answerText4;


    int correctIndex;


    int score = 0;
    public TMPro.TextMeshProUGUI scoreText;

    public GameObject glitch;

    void Start()
    {
        scoreText.text = score.ToString();
        question.text = game.MakeEquation();
        GenerateAnswers();
        glitch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 31)
        {
            glitch.SetActive(true);
            Invoke("NextScene", 2f);

        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(3);
    }

    public bool CheckAnswer(int ChoosenIndex)
    {
        if (ChoosenIndex == correctIndex)
        {
            Debug.Log("Correct");
            score++;
            scoreText.text = score.ToString();
            
            return true;
        }
        else
        {
            Debug.Log("Wrong");
            return false;
        }
    }

    public void NextQuestion()
    {
        answerText1.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        answerText2.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        answerText3.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        answerText4.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

        answerText1.interactable = true;
        answerText2.interactable = true;
        answerText3.interactable = true;
        answerText4.interactable = true;

        question.text = game.MakeEquation();
        GenerateAnswers();
    }

    public void GenerateAnswers()
    {
        
            List<int> answers = new List<int>();

            // Add the correct answer
            answers.Add(31);

            // Generate three random incorrect answers
            while (answers.Count < 4)
            {
                int randomAnswer = Random.Range(1, 51); // Adjust range as needed
                if (randomAnswer != 31 && !answers.Contains(randomAnswer))
                {
                    answers.Add(randomAnswer);
                }
            }

            // Shuffle the list to randomize the position of the correct answer
            for (int i = 0; i < answers.Count; i++)
            {
                int temp = answers[i];
                int randomIndex = Random.Range(i, answers.Count);
                answers[i] = answers[randomIndex];
                answers[randomIndex] = temp;
            }

        // Assuming you have TextMeshProUGUI elements for answer options
        // Example: answerText1, answerText2, answerText3, answerText4
        // Assign the answers to these elements
        answerText1.GetComponentInChildren<TextMeshProUGUI>().text = answers[0].ToString();
        answerText2.GetComponentInChildren<TextMeshProUGUI>().text = answers[1].ToString();
        answerText3.GetComponentInChildren<TextMeshProUGUI>().text = answers[2].ToString();
        answerText4.GetComponentInChildren<TextMeshProUGUI>().text = answers[3].ToString();

        

        correctIndex = answers.IndexOf(31);


    }

    public void Chose1()
    {
        

        if (CheckAnswer(0))
        {
            answerText1.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            answerText1.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }

        //make other buttons unclickable
        answerText1.interactable = false;
        answerText2.interactable = false;
        answerText3.interactable = false;
        answerText4.interactable = false;

        // next question after 1 second
        Invoke("NextQuestion", 2f);
        
    }
    public void Chose2()
    {
          if (CheckAnswer(1))
        {
            answerText2.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            answerText2.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }

        answerText1.interactable = false;
        answerText2.interactable = false;
        answerText3.interactable = false;
        answerText4.interactable = false;

        // next question after 1 second
        Invoke("NextQuestion", 2f);

    }

    public void Chose3()
    {
          if (CheckAnswer(2))
        {
            answerText3.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            answerText3.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }

        answerText1.interactable = false;
        answerText2.interactable = false;
        answerText3.interactable = false;
        answerText4.interactable = false;

        // next question after 1 second
        Invoke("NextQuestion", 2f);

    }

    public void Chose4()
    {
          if (CheckAnswer(3))
        {
            answerText4.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            answerText4.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }

        answerText2.interactable = false;
        answerText3.interactable = false;
        answerText4.interactable = false;
        answerText1.interactable = false;

        // next question after 1 second
        Invoke("NextQuestion", 2f);

    }


}
