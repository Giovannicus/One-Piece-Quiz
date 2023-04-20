using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager0 : MonoBehaviour
{
    [SerializeField] PreCanvas preCanvas;
    [SerializeField] StartCanvas startCanvas;
    [SerializeField] QuizCanvas quizCanvas;
    [SerializeField] EndCanvas endCanvas;
    QuestionSO currentQuestionA;
    TFquestionSO currentQuestionB;
    public CquestionSO currentQuestionC;
    QuizA quizA;
    QuizB quizB;
    QuizC quizC;
    [SerializeField] public int icanvas;
    [SerializeField] int qMax = 3;
    [SerializeField] int givenAnswers;
    [SerializeField] bool loadNextQuestion = true;
    [SerializeField] bool isAnsweringQuestion = false;
    public bool gameStarted;

    private void Awake() {
        
        endCanvas.source.mute = true;
        
    }

    IEnumerator PreCanvasCoroutine(){
        
        yield return new WaitForSeconds(3f);

    }

    void GoStartCanvas(){

        preCanvas.gameObject.SetActive(false);
        startCanvas.gameObject.SetActive(true);
        startCanvas.PlaySound();

    }

    private void Start() {
        
        preCanvas.gameObject.SetActive(true);
        startCanvas.gameObject.SetActive(false);
        StartCoroutine(PreCanvasCoroutine());
        Invoke("GoStartCanvas",15f);
        
    }
    
    public void startGame() {
        
        quizA = FindObjectOfType<QuizA>();
        quizB = FindObjectOfType<QuizB>();
        quizC = FindObjectOfType<QuizC>();
        
        startCanvas.gameObject.SetActive(true);
        quizCanvas.gameObject.SetActive(false);
        quizA.gameObject.SetActive(false);
        quizB.gameObject.SetActive(false);
        quizC.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(false);

        Invoke("NewGame",4f);
    }

    void StartRandomCanvas(){

        if((quizA.questionsA.Count != 0) && (quizB.questionsB.Count != 0) && (quizC.questionsC.Count != 0)){
            icanvas = Random.Range(0, 3);
            if (icanvas == 0){
                quizA.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            } else if (icanvas == 1) {
                quizB.gameObject.SetActive(true);
                quizA.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            } else {
                quizC.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizA.gameObject.SetActive(false);
            }
        } else if (quizA.questionsA.Count == 0) {
            if(quizB.questionsB.Count == 0){
                icanvas = 2;
                quizC.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizA.gameObject.SetActive(false);
            }
            if(quizC.questionsC.Count == 0){
                icanvas = 1;
                quizB.gameObject.SetActive(true);
                quizA.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            } else {
                icanvas = Random.Range(1, 3);
                if (icanvas == 1) {
                    quizB.gameObject.SetActive(true);
                    quizA.gameObject.SetActive(false);
                    quizC.gameObject.SetActive(false);
                } else {
                    quizC.gameObject.SetActive(true);
                    quizB.gameObject.SetActive(false);
                    quizA.gameObject.SetActive(false);
                }
            }
        } else if (quizB.questionsB.Count == 0) {
            if(quizA.questionsA.Count == 0){
                icanvas = 2;
                quizC.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizA.gameObject.SetActive(false);
            }
            if(quizC.questionsC.Count == 0){
                icanvas = 0;
                quizA.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            } else {
                icanvas = 2*Random.Range(0, 2);
                if (icanvas == 0) {
                    quizA.gameObject.SetActive(true);
                    quizB.gameObject.SetActive(false);
                    quizC.gameObject.SetActive(false);
                } else {
                    quizC.gameObject.SetActive(true);
                    quizB.gameObject.SetActive(false);
                    quizA.gameObject.SetActive(false);
                }
            }
        } else if (quizC.questionsC.Count == 0) {
            if(quizB.questionsB.Count == 0){
                icanvas = 0;
                quizA.gameObject.SetActive(true);
                quizB.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            }
            if(quizA.questionsA.Count == 0){
                icanvas = 1;
                quizB.gameObject.SetActive(true);
                quizA.gameObject.SetActive(false);
                quizC.gameObject.SetActive(false);
            } else {
                icanvas = Random.Range(0, 2);
                if (icanvas == 0) {
                    quizA.gameObject.SetActive(true);
                    quizB.gameObject.SetActive(false);
                    quizC.gameObject.SetActive(false);
                } else {
                    quizB.gameObject.SetActive(true);
                    quizC.gameObject.SetActive(false);
                    quizA.gameObject.SetActive(false);
                }
            }
        } 

    }

    public void SetButtonState(bool doit){
        
        if (icanvas == 0) {
            for( int ct = 0; ct<quizA.answerButtons.Length; ct++) {
            Button button = quizA.answerButtons[ct].GetComponent<Button>();
            button.interactable = doit;
            }
        } else if (icanvas == 1) {
            for( int ct = 0; ct<quizB.answerButtons.Length; ct++) {
            Button button = quizB.answerButtons[ct].GetComponent<Button>();
            button.interactable = doit;
            }
        } else if (icanvas == 2) {
            
        }

    }

    void SetDefaultButtonSprite(){
        
        if (icanvas == 0) {
            for( int ct = 0; ct<quizA.answerButtons.Length; ct++) {
            Graphic buttonImage = quizA.answerButtons[ct].GetComponent<Graphic>();
            buttonImage.color = Color.white;
            }
        } else if (icanvas == 1) {
            for( int ct = 0; ct<quizB.answerButtons.Length; ct++) {
            Graphic buttonImage = quizB.answerButtons[ct].GetComponent<Graphic>();
            buttonImage.color = Color.white;
            }
        } else if (icanvas == 2) {
            Graphic buttonImage = quizC.Inputfield.GetComponent<Graphic>();
            buttonImage.color = Color.white;
            quizC.Inputfield.text = "";
        }

    }

    void GetRandomQuestion(){
    
        if(icanvas == 0){
            currentQuestionA = quizA.questionsA[quizA.qaindex];
            if(quizA.questionsA.Contains(currentQuestionA)){
                quizA.questionsA.Remove(currentQuestionA);
            }
        } else if(icanvas == 1){
            currentQuestionB = quizB.questionsB[quizB.qbindex];
            if(quizB.questionsB.Contains(currentQuestionB)){
                quizB.questionsB.Remove(currentQuestionB);
            }
        } else {
            currentQuestionC = quizC.questionsC[quizC.qcindex];
            if(quizC.questionsC.Contains(currentQuestionC)){
                quizC.questionsC.Remove(currentQuestionC);
            }
        }

    }

    void DisplayQuestion(){
        
        if(icanvas == 0){
            quizA.questionText.text = currentQuestionA.GetQuestion();
            for( int ct = 0; ct<quizA.answerButtons.Length; ct++) {
                TextMeshProUGUI buttonText = quizA.answerButtons[ct].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = currentQuestionA.GetAnswer(ct);
            }
        } else if(icanvas == 1){
            quizB.questionText.text = currentQuestionB.GetQuestion();
            for( int ct = 0; ct<quizB.answerButtons.Length; ct++) {
                TextMeshProUGUI buttonText = quizB.answerButtons[ct].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = currentQuestionB.GetAnswer(ct);
            }
        } else {
            quizC.questionText.text = currentQuestionC.GetQuestion();
            quizC.Cimage.GetComponent<Image>().sprite = currentQuestionC.GetQuestionImage();
        }
    }

    void GetNextQuestion(){

        if(icanvas == 0){
            if(quizA.questionsA.Count > 0){
                quizCanvas.GetRandomBackground();
                SetButtonState(true);
                SetDefaultButtonSprite();
                GetRandomQuestion();
                DisplayQuestion();
            }
        } else if (icanvas == 1) {
            if(quizB.questionsB.Count > 0){
                quizCanvas.GetRandomBackground();
                SetButtonState(true);
                SetDefaultButtonSprite();
                GetRandomQuestion();
                DisplayQuestion();
            }
        } else {
            if(quizC.questionsC.Count > 0){
                quizCanvas.GetRandomBackground();
                SetButtonState(true);
                SetDefaultButtonSprite();
                GetRandomQuestion();
                DisplayQuestion();
            }
        }
        
    }

    private void NewGame(){

        preCanvas.gameObject.SetActive(false);
        startCanvas.gameObject.SetActive(false);
        quizCanvas.gameObject.SetActive(true);
        StartRandomCanvas();
        quizCanvas.PlaySound();
        gameStarted = true;
        givenAnswers = 0;
        GetNextQuestion();
        loadNextQuestion = false;
        isAnsweringQuestion = true;

    }

    private void Update() {

        if(loadNextQuestion){

            StartRandomCanvas();
            GetNextQuestion();
            loadNextQuestion = false;
            isAnsweringQuestion = true;

        }
        
        if(givenAnswers == qMax){
            endCanvas.source.mute = false;
            startCanvas.gameObject.SetActive(false);
            quizCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(true);
        }

    }

    public void OnReplayLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void OnSunPressed(){

        givenAnswers++;
        loadNextQuestion = true;
        isAnsweringQuestion = false;

    }

    void DisplayAnswer(int index){
        
        if(icanvas == 0){
            if(index == currentQuestionA.GetCorrectAnswerIndex()){
                Graphic buttonImage = quizA.answerButtons[index].GetComponent<Graphic>();
                buttonImage.color = Color.green;
            } else {
                Graphic buttonImage = quizA.answerButtons[index].GetComponent<Graphic>();
                buttonImage.color = Color.red;
            }
        } else {
            if(index == currentQuestionB.GetCorrectAnswerIndex()){
                Graphic buttonImage = quizB.answerButtons[index].GetComponent<Graphic>();
                buttonImage.color = Color.green;
            } else {
                Graphic buttonImage = quizB.answerButtons[index].GetComponent<Graphic>();
                buttonImage.color = Color.red;
            }
        }
    }

    public void OnAnswerSelected(int index){

        if(icanvas == 0){
            if(currentQuestionA.GetAnswer(index)=="Pandaman"){
                quizA.EasterEgg();
            }
            isAnsweringQuestion = false;
            DisplayAnswer(index);
            if(index == currentQuestionA.GetCorrectAnswerIndex()){
                SetButtonState(false);
            }
        } else {
            isAnsweringQuestion = false;
            DisplayAnswer(index);
            if(index == currentQuestionB.GetCorrectAnswerIndex()){
                SetButtonState(false);
            }
        }

    }

}
