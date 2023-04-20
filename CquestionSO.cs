using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New CQuestion", menuName = "C Quiz Question" )]
public class CquestionSO : ScriptableObject
{
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] Sprite referenceImage;
    [SerializeField] string[] correctAnswers = new string[1];
    
    public string GetQuestion(){
        return question;
    }
    
    public Sprite GetQuestionImage() {
        return referenceImage;
    }
    
    public string[] GetCorrectAnswer(){
        return correctAnswers;
    }

}
