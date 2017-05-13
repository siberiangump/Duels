using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class ChangeText : MonoBehaviour
{
    public Text BlindText;
    private Color ColorStart; 
    private float _time=0f;
    public Animation TextAnimation;
    public float LerpSpeed = 0.2F;
    public UnityEvent OnDone;
 
    void Start()
    {
        ColorStart = BlindText.color;
        StartCount();
    }

    [ContextMenu("StartCount")]
    public void StartCount()
    {
        StartCoroutine(StartAnimationText());
    }

    IEnumerator StartAnimationText()
    {
        int i = 4;
        while (i > 0)
        {
            switch (i)
            {
                case 4:
                    {
                        BlindText.text = "3!";
                        break;
                    }
                case 3:
                    {
                        BlindText.text = "2!";
                        break;
                    }
                case 2:
                    {
                        BlindText.text = "1!";
                        break;
                    }
                case 1:
                    {
                        BlindText.text = "Start!";                        
                        break;
                    }
            }
            TextAnimation.Play();
            i--;
            yield return new WaitForSeconds(0.5f);
        }

        while (BlindText.color.a > 0)
        {
            _time += Time.deltaTime;
            BlindText.color = Color.Lerp(ColorStart, new Color(1, 1, 1, 0), _time*LerpSpeed);
            //yield return new WaitForSeconds(0.5f);
        }
       
        DoneCounting();
        yield return null;
    }

    public void DoneCounting()
    {
        StopCoroutine(StartAnimationText());
        OnDone.Invoke();
    }

    void Update()
    {
        //if (Timer > 0)
        //{
        //    Timer -= Time.deltaTime;
        //}
        ////if (Timer < 0)
        ////{
        ////    _time += Time.deltaTime;
        ////    BlindText.color = Color.Lerp(ColorStart, Color.clear, _time * LerpSpeed); // цвет начала, цвет конца, скорость изменения
        ////}

        //if (Timer > Changetext * 4)
        //{
        //    BlindText.text = "3!";
        //}
        //if (Timer > Changetext * 3)
        //{
        //    BlindText.text = "2!";
        //}
        //if (Timer > Changetext * 2)
        //{
        //    BlindText.text = "1!";
        //}
        //if (Timer > Changetext * 1)
        //{
        //    BlindText.text = "Start!";
        //}
        //if (Timer < 0)
        //{
        //    _time += Time.deltaTime;
        //    BlindText.color = Color.Lerp(ColorStart, Color.clear, _time * LerpSpeed); // цвет начала, цвет конца, скорость изменения
        //}
    }
}
