using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TF Quiz Question", fileName="New TFQuestion")]
public class TFquestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] int correctAnswerIndex;

    string[] answers = {"Vero","Falso"};
    
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
