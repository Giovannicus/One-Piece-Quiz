using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //mi serve per introdurre un nuovo tipo di variabile
using UnityEngine.SceneManagement;

public class QuizC : MonoBehaviour
{
    // Creo una variabile che mi serve per mantenere il contenuto utile
    [Header("Questions")]
    CquestionSO currentQuestion; //riferimento alla domanda
    [SerializeField] public List<CquestionSO> questionsC = new List<CquestionSO>();
    [SerializeField] public TextMeshProUGUI questionText; //riferimento al testo
    public int qcindex;

    [Header("Image")]
    [SerializeField] public GameObject Cimage;
    [SerializeField] public InputField Inputfield;

    [SerializeField] QuizCanvas quizCanvas;
    [SerializeField] GameManager0 GM;
    Graphic inputImage;
    private string input;

    void Update(){

        if(Input.GetKeyDown(KeyCode.Return)){
            EvaluateInput();
        }

    }
    
    void EvaluateInput(){

        bool thatsCorrect = false;
        foreach (string str in GM.currentQuestionC.GetCorrectAnswer()){
            thatsCorrect = thatsCorrect || (str == Inputfield.text.Trim());   
        }

        if (thatsCorrect){
            inputImage = Inputfield.GetComponent<Graphic>();
            inputImage.color = Color.green;
        } else {
            inputImage = Inputfield.GetComponent<Graphic>();
            inputImage.color = Color.red;
            Invoke("BackToNormal",4f);
        }

    }

    void BackToNormal(){

        inputImage.color = Color.white;

    }

    public void ReadStringInput(string s){

        input = s;

    }

}
