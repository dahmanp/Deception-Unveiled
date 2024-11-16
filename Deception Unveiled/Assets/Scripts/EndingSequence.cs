using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingSequence : MonoBehaviour
{
    public GameObject questionScreen;
    public GameObject intro;
    public GameObject text;
    public GameObject finaleScreen;

    public bool correct = false;

    public TMP_Text paraText;

    public TMP_Text question;
    public TMP_Text r1;
    public TMP_Text r2;
    public TMP_Text r3;

    public int answer = 0;
    public int response = 0;
    public int currQuestion = 0;

    [Header("Sequence Text")]
    public string[] questions;
    public string[] answer1s;
    public string[] answer2s;
    public string[] answer3s;
    public string[] conclusions;
    public int[] correctAnswers;

    [Header("Item Text")]
    public string[] ITEM_questions;
    public string[] ITEM_answer1s;
    public string[] ITEM_answer2s;
    public string[] ITEM_answer3s;
    public string[] ITEM_conclusions;

    [Header("Interview Text")]
    public string[] INT_questions;
    public string[] INT_answer1s;
    public string[] INT_answer2s;
    public string[] INT_answer3s;
    public string[] INT_conclusions;

    [Header("Location Text")]
    public string[] LOC_questions;
    public string[] LOC_answer1s;
    public string[] LOC_answer2s;
    public string[] LOC_answer3s;
    public string[] LOC_conclusions;

    public string conclusionText;

    public void itemSelected()
    {
        questions = ITEM_questions;
        answer1s = ITEM_answer1s;
        answer2s = ITEM_answer2s;
        answer3s = ITEM_answer3s;
        conclusions = ITEM_conclusions;
        begin();
    }

    public void locSelected()
    {
        questions = LOC_questions;
        answer1s = LOC_answer1s;
        answer2s = LOC_answer2s;
        answer3s = LOC_answer3s;
        conclusions = LOC_conclusions;
        begin();
    }

    public void intSelected()
    {
        questions = INT_questions;
        answer1s = INT_answer1s;
        answer2s = INT_answer2s;
        answer3s = INT_answer3s;
        conclusions = INT_conclusions;
        begin();
    }

    public void answerSelected(int selectedAnswer)
    {
        response = selectedAnswer;
        check();
    }

    public void back()
    {
        if (response != answer)
        {
            questionScreen.SetActive(true);
            text.SetActive(false);
        }
        else if (currQuestion < 9)
        {
            currQuestion++;
            setQuestion(currQuestion);
            questionScreen.SetActive(true);
            text.SetActive(false);
        }
        else
        {
            finaleScreen.SetActive(true);
        }
    }

    public void check()
    {
        if (response == answer)
        {
            questionScreen.SetActive(false);
            text.SetActive(true);
            paraText.text = conclusionText;
        }
        else if (response != answer)
        {
            questionScreen.SetActive(false);
            text.SetActive(true);
            paraText.text = "Hmm... I'm not so sure that's correct. I need to think on this some more...";
        }
    }

    public void begin()
    {
        intro.SetActive(false);
        questionScreen.SetActive(true);
        setQuestion(0);
    }

    void setQuestion(int i)
    {
        question.text = questions[i];
        r1.text = answer1s[i];
        r2.text = answer2s[i];
        r3.text = answer3s[i];
        conclusionText = conclusions[i];
        answer = correctAnswers[i];
    }
}
