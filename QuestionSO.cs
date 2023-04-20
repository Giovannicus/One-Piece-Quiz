using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName="New Question")] //serve per far comparire QuestionSO nel menu di creazione
//che me lo dara come Quiz Questione e creerà gli oggetti come New Question
public class QuestionSO : ScriptableObject //credo che non essendo un behaviour,
{//non viene assegnato ad un oggetto, ma definisce un tipo di oggetto che posso richiamare
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion() {
        return question;
    }
    
    public int GetCorrectAnswerIndex(){
        return correctAnswerIndex;
    }
    
    public string GetAnswer(int index){
        return answers[index];
    }
}