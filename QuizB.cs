using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //mi serve per introdurre un nuovo tipo di variabile
using UnityEngine.SceneManagement;

public class QuizB : MonoBehaviour
{
    // Creo una variabile che mi serve per mantenere il contenuto utile
    [Header("Questions")]
    TFquestionSO currentQuestion; //riferimento alla domanda
    [SerializeField] public List<TFquestionSO> questionsB = new List<TFquestionSO>();
    [SerializeField] public TextMeshProUGUI questionText; //riferimento al testo
    public int qbindex;
    
    [Header("Answers")]
    [SerializeField] public GameObject[] answerButtons; //riferimento al testo

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite; //dato che abbiamo necessita di modificarle,
    
    [SerializeField] QuizCanvas quizCanvas;

   
}
