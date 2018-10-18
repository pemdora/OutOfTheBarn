using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateTextLetterByLetter : MonoBehaviour
{
    public Text text;
    private string str;

    public string textToDisplay;
    public float speed;

    // Use this for initialization
    void Start()
    {
        Invoke("DisplayText",3f);
        // "Things are not quite so simple always as black and white." - Doris Lessing 
        // "There's so much grey to every story - nothing is so black and white." - Lisa Ling
        // "In the begining, it was all black and white" - Maureen O'Hara
    }

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            text.text = str;
            yield return new WaitForSeconds(0.12F);
        }
    }
    public void DisplayText()
    {
        StartCoroutine(AnimateText(textToDisplay));
    }
}
