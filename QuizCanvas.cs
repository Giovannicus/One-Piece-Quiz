using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizCanvas : MonoBehaviour
{
    [SerializeField] List<Sprite> backgroundsA = new List<Sprite>();
    [SerializeField] List<Sprite> backgroundsB = new List<Sprite>();
    [SerializeField] List<Sprite> backgroundsC = new List<Sprite>();

    [SerializeField] QuizA quizA;
    [SerializeField] QuizB quizB;
    [SerializeField] QuizC quizC;
    [SerializeField] GameManager0 GM;
    Sprite backgroundSprite;
    public int qindex;
    public AudioSource source;
    

    public void PlaySound(){

        source = GetComponent<AudioSource>();
        source.Play();

    }

    void SetBackground(int index){

        if(GM.icanvas == 0){
            backgroundSprite = backgroundsA[index];
        } else if(GM.icanvas == 1){
            backgroundSprite = backgroundsB[index];
        } else {
            backgroundSprite = backgroundsC[index];
        }
        Image img = GetComponent<Image>();
        img.sprite = backgroundSprite;

    }

    public void GetRandomBackground(){
        
        if(GM.icanvas == 0){
            int qindex = Random.Range(0, backgroundsA.Count);
            quizA.qaindex = qindex;
            SetBackground(qindex);
            if(backgroundsA.Contains(backgroundsA[qindex])){
                backgroundsA.Remove(backgroundsA[qindex]);
            }
        } else if(GM.icanvas == 1){
            int qindex = Random.Range(0, backgroundsB.Count);
            quizB.qbindex = qindex;
            SetBackground(qindex);
            if(backgroundsB.Contains(backgroundsB[qindex])){
                backgroundsB.Remove(backgroundsB[qindex]);
            }
        } else {
            int qindex = Random.Range(0, backgroundsC.Count);
            quizC.qcindex = qindex;
            SetBackground(qindex);
            if(backgroundsC.Contains(backgroundsC[qindex])){
                backgroundsC.Remove(backgroundsC[qindex]);
            }
        }
    }

}
