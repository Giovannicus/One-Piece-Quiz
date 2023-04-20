using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //mi serve per introdurre un nuovo tipo di variabile
using UnityEngine.SceneManagement;

public class QuizA : MonoBehaviour
{
    // Creo una variabile che mi serve per mantenere il contenuto utile
    [Header("Questions")]
    QuestionSO currentQuestion; //riferimento alla domanda
    [SerializeField] public List<QuestionSO> questionsA = new List<QuestionSO>();
    [SerializeField] public TextMeshProUGUI questionText; //riferimento al testo
    public int qaindex;
    
    [Header("Answers")]
    [SerializeField] public GameObject[] answerButtons; //riferimento al testo

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite; //dato che abbiamo necessita di modificarle,
    
    [SerializeField] QuizCanvas quizCanvas;

    void Start()
    {
        gameObject.transform.Find("Easter egg").gameObject.SetActive(false);
    }

    public void EasterEgg(){
        gameObject.transform.Find("Easter egg").gameObject.SetActive(true);
        Invoke("NullFunc",4f);
    }

    void NullFunc(){
        gameObject.transform.Find("Easter egg").gameObject.SetActive(false);
    }
}
