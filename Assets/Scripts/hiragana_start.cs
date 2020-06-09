using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hiragana_start : MonoBehaviour
{
    [SerializeField]
    private Text _CountText;

    [SerializeField]
    private GameObject _button;

    [SerializeField]
    private Text _Textone;

    [SerializeField]
    private Text _Texttwo;

    [SerializeField]
    private Text _Textthree;

    [SerializeField]
    private Text _Textfour;

    [SerializeField]
    private Text _Textfive;

    [SerializeField]
    private Text _Textsix;

    [SerializeField]
    private Text _Textseven;

    [SerializeField]
    private Text _Texteight;

    [SerializeField]
    private Text _Textnine;

    [SerializeField]
    private Text _Title;

    [SerializeField]
    private Text _Timer;

    [SerializeField]
    private Text _Gameover;

    [SerializeField]
    private Text _Titleback;


    public string[] textMessage;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    AudioSource audioSource;

    public AudioSource BGM_title;
    public AudioSource BGM_main;

    private int rowlength;
    private int rowlength_counter = 0;
    private string[,] words = new string[9, 30];
    private int[] wordscount = new int[9];
    private int wordslength;
    private string[] wordsR = new string[9];
    private int wordsR_counter;
    private int wordsR_rand;
    private bool buttoncheck = false;
    private int stagecheck = 2;
    private bool stagestart = false;
    private float theta = 0;
    private int[] wordsP = new int[9];
    private int wordsP_counter = 0;
    private int words_click_counter = 0;
    private float countTime;
    private float limitTime = 15;
    private float posrand;



    // Start is called before the first frame update
    void Start()
    {
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("hiragana_resource", typeof(TextAsset)) as TextAsset;
        string TextLines = textasset.text;
        textMessage = TextLines.Split('\n');
        rowlength = textMessage.Length;
        while (rowlength_counter < rowlength)
        {
            textMessage[rowlength_counter] = textMessage[rowlength_counter].Trim();
            wordslength = textMessage[rowlength_counter].Length;
            words[wordslength - 1, wordscount[wordslength - 1]] = textMessage[rowlength_counter];
            wordscount[wordslength - 1] = wordscount[wordslength - 1] + 1;
            rowlength_counter = rowlength_counter + 1;
        }


        _CountText.text = "";
        _Textone.text = "";
        _Texttwo.text = "";
        _Textthree.text = "";
        _Textfour.text = "";
        _Textfive.text = "";
        _Textsix.text = "";
        _Textseven.text = "";
        _Texteight.text = "";
        _Textnine.text = "";
        _Timer.text = "";
        _Gameover.text = "";
        _Titleback.text = "";

        while (wordsP_counter < 9)
        {
            wordsP[wordsP_counter] = -1;
            wordsP_counter = wordsP_counter + 1;
        }

        audioSource = GetComponent<AudioSource>();

        Transform Transformfourstartout = _Textfour.transform;
        Vector2 posfourstartout = Transformfourstartout.localPosition;
        posfourstartout.x = 1000;
        posfourstartout.y = 1000;
        Transformfourstartout.localPosition = posfourstartout;

        Transform Transformfivestartout = _Textfive.transform;
        Vector2 posfivestartout = Transformfivestartout.localPosition;
        posfivestartout.x = 1000;
        posfivestartout.y = 1000;
        Transformfivestartout.localPosition = posfivestartout;

        Transform Transformsixstartout = _Textsix.transform;
        Vector2 possixstartout = Transformsixstartout.localPosition;
        possixstartout.x = 1000;
        possixstartout.y = 1000;
        Transformsixstartout.localPosition = possixstartout;

        Transform Transformsevenstartout = _Textseven.transform;
        Vector2 possevenstartout = Transformsevenstartout.localPosition;
        possevenstartout.x = 1000;
        possevenstartout.y = 1000;
        Transformsevenstartout.localPosition = possevenstartout;

        Transform Transformeightstartout = _Texteight.transform;
        Vector2 poseightstartout = Transformeightstartout.localPosition;
        poseightstartout.x = 1000;
        poseightstartout.y = 1000;
        Transformeightstartout.localPosition = poseightstartout;

        Transform Transformninestartout = _Textnine.transform;
        Vector2 posninestartout = Transformninestartout.localPosition;
        posninestartout.x = 1000;
        posninestartout.y = 1000;
        Transformninestartout.localPosition = posninestartout;

        Transform Transformgameoverstartout = _Gameover.transform;
        Vector2 posgameoverstartout = Transformgameoverstartout.localPosition;
        posgameoverstartout.x = 1000;
        posgameoverstartout.y = 1000;
        Transformgameoverstartout.localPosition = posgameoverstartout;

        Transform Transformtitlebackstartout = _Titleback.transform;
        Vector2 postitlebackstartout = Transformtitlebackstartout.localPosition;
        postitlebackstartout.x = 1000;
        postitlebackstartout.y = 1000;
        Transformtitlebackstartout.localPosition = postitlebackstartout;

        countTime = limitTime;
    }

    public void OnClick()
    {
        Debug.Log("押された!");
        BGM_title.Stop();

        wordsR_counter = 0;
        while (wordsR_counter < 9)
        {
            wordsR_rand = Random.Range(0, wordscount[wordsR_counter]);
            wordsR[wordsR_counter] = words[wordsR_counter, wordsR_rand];
            wordsR_counter = wordsR_counter + 1;
        }

        Transform Transformbutton = _button.transform;
        Vector2 posbutton = Transformbutton.position;
        posbutton.x += 1000f;
        posbutton.y += 1000f;
        Transformbutton.position = posbutton;
        _Title.text = "";

        Transform Transformtitleclickout = _Title.transform;
        Vector2 postitleclickout = Transformtitleclickout.localPosition;
        postitleclickout.x = 1000;
        postitleclickout.y = 1000;
        Transformtitleclickout.localPosition = postitleclickout;

        audioSource.PlayOneShot(sound3);
        StartCoroutine(CountdownCoroutine());
        Invoke("buttoncheckchange", 4.01f);
    }

    IEnumerator CountdownCoroutine()
    {
        Transform Transformcountstartcome = _CountText.transform;
        Vector2 poscountstartcome = Transformcountstartcome.localPosition;
        poscountstartcome.x = 30;
        poscountstartcome.y = 0;
        Transformcountstartcome.localPosition = poscountstartcome;

        _CountText.gameObject.SetActive(true);

        _CountText.text = "3";
        yield return new WaitForSeconds(1.0f);

        _CountText.text = "2";
        yield return new WaitForSeconds(1.0f);

        _CountText.text = "1";
        yield return new WaitForSeconds(1.0f);

        _CountText.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _CountText.text = "";

        Transform Transformcountstartout = _CountText.transform;
        Vector2 poscountstartout = Transformcountstartout.localPosition;
        poscountstartout.x = 1000;
        poscountstartout.y = 1000;
        Transformcountstartout.localPosition = poscountstartout;
    }

    void buttoncheckchange()
    {
        buttoncheck = true;
        BGM_main.Play();
    }

    void stagechange()
    {
        audioSource.PlayOneShot(sound4);
    }


    // Update is called once per frame
    void Update()
    {
        if (buttoncheck == true)
        {
            if (stagecheck == 2)
            {
                if (stagestart == false)
                {
                    wordsP[0] = 0;
                    wordsP[1] = 2;
                    wordsP[2] = 1;
                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    Transform Transformonestarttwo = _Textone.transform;
                    Vector2 posonestarttwo = Transformonestarttwo.localPosition;
                    posonestarttwo.x = 0;
                    posonestarttwo.y = -80;
                    Transformonestarttwo.localPosition = posonestarttwo;
                    Transform Transformtwostarttwo = _Texttwo.transform;
                    Vector2 postwostarttwo = Transformtwostarttwo.localPosition;
                    postwostarttwo.x = 91;
                    postwostarttwo.y = 78;
                    Transformtwostarttwo.localPosition = postwostarttwo;
                    Transform Transformthreestarttwo = _Textthree.transform;
                    Vector2 posthreestarttwo = Transformthreestarttwo.localPosition;
                    posthreestarttwo.x = -91;
                    posthreestarttwo.y = 78;
                    Transformthreestarttwo.localPosition = posthreestarttwo;
                    stagestart = true;
                }
                
                if (words_click_counter < 1) {
                    Transform Transformonetwo = _Textone.transform;
                    Vector2 posonetwo = Transformonetwo.localPosition;
                    posonetwo.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posonetwo.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformonetwo.localPosition = posonetwo;
                }

                if (words_click_counter < 3)
                {
                        Transform Transformtwotwo = _Texttwo.transform;
                        Vector2 postwotwo = Transformtwotwo.localPosition;
                        postwotwo.x += 105f * Mathf.Cos(theta + 2.094395f) * 0.01f;
                        postwotwo.y += 105f * Mathf.Sin(theta + 2.094395f) * 0.01f;
                        Transformtwotwo.localPosition = postwotwo;
                }

                if (words_click_counter < 2) {
                        Transform Transformthreetwo = _Textthree.transform;
                        Vector2 posthreetwo = Transformthreetwo.localPosition;
                        posthreetwo.x += 105f * Mathf.Cos(theta + 4.18879f) * 0.01f;
                        posthreetwo.y += 105f * Mathf.Sin(theta + 4.18879f) * 0.01f;
                        Transformthreetwo.localPosition = posthreetwo; 
                }

                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }


                if (Textone.textone_click == true)
                {
                    Transform Transformonetwoclick = _Textone.transform;
                    Vector2 posonetwoclick = Transformonetwoclick.localPosition;
                    posonetwoclick.x = -100;
                    posonetwoclick.y = -150;
                    Transformonetwoclick.localPosition = posonetwoclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > 1)
                    {
                        Transform Transformtwotwoclick = _Texttwo.transform;
                        Vector2 postwotwoclick = Transformtwotwoclick.localPosition;
                        postwotwoclick.x = 100;
                        postwotwoclick.y = -150;
                        Transformtwotwoclick.localPosition = postwotwoclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    } else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > 0)
                    {
                        Transform Transformthreetwoclick = _Textthree.transform;
                        Vector2 posthreetwoclick = Transformthreetwoclick.localPosition;
                        posthreetwoclick.x = 0;
                        posthreetwoclick.y = -150;
                        Transformthreetwoclick.localPosition = posthreetwoclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    } else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 2)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();

                }
            }

            if (stagecheck == 3)
            {
                if (stagestart == false)
                {
                    wordsP[0] = 0;
                    wordsP[1] = 3;
                    wordsP[2] = 1;
                    wordsP[3] = 2;
                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    Transform Transformonestartthree = _Textone.transform;
                    Vector2 posonestartthree = Transformonestartthree.localPosition;
                    posonestartthree.x = 0;
                    posonestartthree.y = -80;
                    Transformonestartthree.localPosition = posonestartthree;
                    Transform Transformtwostartthree = _Texttwo.transform;
                    Vector2 postwostartthree = Transformtwostartthree.localPosition;
                    postwostartthree.x = 105;
                    postwostartthree.y = 25;
                    Transformtwostartthree.localPosition = postwostartthree;
                    Transform Transformthreestartthree = _Textthree.transform;
                    Vector2 posthreestartthree = Transformthreestartthree.localPosition;
                    posthreestartthree.x = 0;
                    posthreestartthree.y = 130;
                    Transformthreestartthree.localPosition = posthreestartthree;
                    Transform Transformfourstartthree = _Textfour.transform;
                    Vector2 posfourstartthree = Transformfourstartthree.localPosition;
                    posfourstartthree.x = -105;
                    posfourstartthree.y = 25;
                    Transformfourstartthree.localPosition = posfourstartthree;
                    stagestart = true;
                }

                if (words_click_counter < 1)
                {
                    Transform Transformonethree = _Textone.transform;
                    Vector2 posonethree = Transformonethree.localPosition;
                    posonethree.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posonethree.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformonethree.localPosition = posonethree;
                }

                if (words_click_counter < 4)
                {
                    Transform Transformtwothree = _Texttwo.transform;
                    Vector2 postwothree = Transformtwothree.localPosition;
                    postwothree.x += 105f * Mathf.Cos(theta + 1.570796f) * 0.01f;
                    postwothree.y += 105f * Mathf.Sin(theta + 1.570796f) * 0.01f;
                    Transformtwothree.localPosition = postwothree;
                }

                if (words_click_counter < 2)
                {
                    Transform Transformthreethree = _Textthree.transform;
                    Vector2 posthreethree = Transformthreethree.localPosition;
                    posthreethree.x += 105f * Mathf.Cos(theta + 3.141593f) * 0.01f;
                    posthreethree.y += 105f * Mathf.Sin(theta + 3.141593f) * 0.01f;
                    Transformthreethree.localPosition = posthreethree;
                }

                if (words_click_counter < 3)
                {
                    Transform Transformfourthree = _Textfour.transform;
                    Vector2 posfourthree = Transformfourthree.localPosition;
                    posfourthree.x += 105f * Mathf.Cos(theta + 4.712389f) * 0.01f;
                    posfourthree.y += 105f * Mathf.Sin(theta + 4.712389f) * 0.01f;
                    Transformfourthree.localPosition = posfourthree;
                }

                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }


                if (Textone.textone_click == true)
                {
                    Transform Transformonethreeclick = _Textone.transform;
                    Vector2 posonethreeclick = Transformonethreeclick.localPosition;
                    posonethreeclick.x = -100;
                    posonethreeclick.y = -150;
                    Transformonethreeclick.localPosition = posonethreeclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > 2)
                    {
                        Transform Transformtwothreeclick = _Texttwo.transform;
                        Vector2 postwothreeclick = Transformtwothreeclick.localPosition;
                        postwothreeclick.x = 140;
                        postwothreeclick.y = -150;
                        Transformtwothreeclick.localPosition = postwothreeclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > 0)
                    {
                        Transform Transformthreethreeclick = _Textthree.transform;
                        Vector2 posthreethreeclick = Transformthreethreeclick.localPosition;
                        posthreethreeclick.x = -20;
                        posthreethreeclick.y = -150;
                        Transformthreethreeclick.localPosition = posthreethreeclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                if (Textfour.textfour_click == true)
                {
                    if (words_click_counter > 1)
                    {
                        Transform Transformfourthreeclick = _Textfour.transform;
                        Vector2 posfourthreeclick = Transformfourthreeclick.localPosition;
                        posfourthreeclick.x = 60;
                        posfourthreeclick.y = -150;
                        Transformfourthreeclick.localPosition = posfourthreeclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfour.textfour_click = false;
                }

                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 3)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }

            if (stagecheck == 4)
            {
                if (stagestart == false)
                {
                    posrand = Random.Range(0, 2);
                    if (posrand == 0)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 3;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 2;
                    } else
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 2;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 3;
                    }
                    
                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    _Textfive.text = wordsR[stagecheck].Substring(wordsP[4], 1);
                    Transform Transformonestartfour = _Textone.transform;
                    Vector2 posonestartfour = Transformonestartfour.localPosition;
                    posonestartfour.x = 0;
                    posonestartfour.y = -80;
                    Transformonestartfour.localPosition = posonestartfour;
                    Transform Transformtwostartfour = _Texttwo.transform;
                    Vector2 postwostartfour = Transformtwostartfour.localPosition;
                    postwostartfour.x = 100;
                    postwostartfour.y = -7;
                    Transformtwostartfour.localPosition = postwostartfour;
                    Transform Transformthreestartfour = _Textthree.transform;
                    Vector2 posthreestartfour = Transformthreestartfour.localPosition;
                    posthreestartfour.x = 62;
                    posthreestartfour.y = 110;
                    Transformthreestartfour.localPosition = posthreestartfour;
                    Transform Transformfourstartfour = _Textfour.transform;
                    Vector2 posfourstartfour = Transformfourstartfour.localPosition;
                    posfourstartfour.x = -62;
                    posfourstartfour.y = 110;
                    Transformfourstartfour.localPosition = posfourstartfour;
                    Transform Transformfivestartfour = _Textfive.transform;
                    Vector2 posfivestartfour = Transformfivestartfour.localPosition;
                    posfivestartfour.x = -100;
                    posfivestartfour.y = -7;
                    Transformfivestartfour.localPosition = posfivestartfour;
                    stagestart = true;
                }


                    if (words_click_counter < (wordsP[0] + 1))
                    {
                        Transform Transformonefour = _Textone.transform;
                        Vector2 posonefour = Transformonefour.localPosition;
                        posonefour.x += 105f * Mathf.Cos(theta) * 0.01f;
                        posonefour.y += 105f * Mathf.Sin(theta) * 0.01f;
                        Transformonefour.localPosition = posonefour;
                    }

                    if (words_click_counter < (wordsP[1] + 1))
                    {
                        Transform Transformtwofour = _Texttwo.transform;
                        Vector2 postwofour = Transformtwofour.localPosition;
                        postwofour.x += 105f * Mathf.Cos(theta + 1.256637f) * 0.01f;
                        postwofour.y += 105f * Mathf.Sin(theta + 1.256637f) * 0.01f;
                        Transformtwofour.localPosition = postwofour;
                    }

                    if (words_click_counter < (wordsP[2] + 1))
                    {
                        Transform Transformthreefour = _Textthree.transform;
                        Vector2 posthreefour = Transformthreefour.localPosition;
                        posthreefour.x += 105f * Mathf.Cos(theta + 2.513274f) * 0.01f;
                        posthreefour.y += 105f * Mathf.Sin(theta + 2.513274f) * 0.01f;
                        Transformthreefour.localPosition = posthreefour;
                    }

                    if (words_click_counter < (wordsP[3] + 1))
                    {
                        Transform Transformfourfour = _Textfour.transform;
                        Vector2 posfourfour = Transformfourfour.localPosition;
                        posfourfour.x += 105f * Mathf.Cos(theta + 3.769911f) * 0.01f;
                        posfourfour.y += 105f * Mathf.Sin(theta + 3.769911f) * 0.01f;
                        Transformfourfour.localPosition = posfourfour;
                    }

                    if (words_click_counter < (wordsP[4] + 1))
                    {
                        Transform Transformfivefour = _Textfive.transform;
                        Vector2 posfivefour = Transformfivefour.localPosition;
                        posfivefour.x += 105f * Mathf.Cos(theta + 5.026548f) * 0.01f;
                        posfivefour.y += 105f * Mathf.Sin(theta + 5.026548f) * 0.01f;
                        Transformfivefour.localPosition = posfivefour;
                    }


                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }


                
                    if (Textone.textone_click == true)
                    {
                        Transform Transformonefourclick = _Textone.transform;
                        Vector2 posonefourclick = Transformonefourclick.localPosition;
                        posonefourclick.x = -100;
                        posonefourclick.y = -150;
                        Transformonefourclick.localPosition = posonefourclick;
                        words_click_counter = words_click_counter + 1;
                        Textone.textone_click = false;
                        audioSource.PlayOneShot(sound1);
                    }

                    if (Texttwo.texttwo_click == true)
                    {
                        if (words_click_counter > (wordsP[1] - 1))
                        {
                            Transform Transformtwofourclick = _Texttwo.transform;
                            Vector2 postwofourclick = Transformtwofourclick.localPosition;
                            postwofourclick.x = -100 + wordsP[1] * 70;
                            postwofourclick.y = -150;
                            Transformtwofourclick.localPosition = postwofourclick;
                            words_click_counter = words_click_counter + 1;
                            audioSource.PlayOneShot(sound1);
                        }
                        else
                        {
                            audioSource.PlayOneShot(sound2);
                        }
                        Texttwo.texttwo_click = false;
                    }

                    if (Textthree.textthree_click == true)
                    {
                        if (words_click_counter > (wordsP[2] - 1))
                        {
                            Transform Transformthreefourclick = _Textthree.transform;
                            Vector2 posthreefourclick = Transformthreefourclick.localPosition;
                            posthreefourclick.x = -100 + wordsP[2] * 70;
                            posthreefourclick.y = -150;
                            Transformthreefourclick.localPosition = posthreefourclick;
                            words_click_counter = words_click_counter + 1;
                            audioSource.PlayOneShot(sound1);
                        }
                        else
                        {
                            audioSource.PlayOneShot(sound2);
                        }
                        Textthree.textthree_click = false;
                    }

                    if (Textfour.textfour_click == true)
                    {
                        if (words_click_counter > (wordsP[3] - 1))
                        {
                            Transform Transformfourfourclick = _Textfour.transform;
                            Vector2 posfourfourclick = Transformfourfourclick.localPosition;
                            posfourfourclick.x = -100 + wordsP[3] * 70;
                            posfourfourclick.y = -150;
                            Transformfourfourclick.localPosition = posfourfourclick;
                            words_click_counter = words_click_counter + 1;
                            audioSource.PlayOneShot(sound1);
                        }
                        else
                        {
                            audioSource.PlayOneShot(sound2);
                        }
                        Textfour.textfour_click = false;
                    }

                    if (Textfive.textfive_click == true)
                    {
                        if (words_click_counter > (wordsP[4] - 1))
                        {
                            Transform Transformfivefourclick = _Textfive.transform;
                            Vector2 posfivefourclick = Transformfivefourclick.localPosition;
                            posfivefourclick.x = -100 + wordsP[4] * 70;
                            posfivefourclick.y = -150;
                            Transformfivefourclick.localPosition = posfivefourclick;
                            words_click_counter = words_click_counter + 1;
                            audioSource.PlayOneShot(sound1);
                        }
                        else
                        {
                            audioSource.PlayOneShot(sound2);
                        }
                        Textfive.textfive_click = false;
                    }
               

                

                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 4)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";
                    _Textfive.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformfivefinishout = _Textfive.transform;
                    Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                    posfivefinishout.x = 1000;
                    posfivefinishout.y = 1000;
                    Transformfivefinishout.localPosition = posfivefinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }

            if (stagecheck == 5)
            {
                if (stagestart == false)
                {
                    posrand = Random.Range(0, 3);
                    if (posrand == 0)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 3;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 2;
                        wordsP[5] = 5;
                    }
                    else if (posrand == 1)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 2;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 3;
                        wordsP[5] = 5;
                    }
                    else
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 4;
                        wordsP[2] = 2;
                        wordsP[3] = 1;
                        wordsP[4] = 5;
                        wordsP[5] = 3;
                    }

                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    _Textfive.text = wordsR[stagecheck].Substring(wordsP[4], 1);
                    _Textsix.text = wordsR[stagecheck].Substring(wordsP[5], 1);
                    Transform Transformonestartfive = _Textone.transform;
                    Vector2 posonestartfive = Transformonestartfive.localPosition;
                    posonestartfive.x = 0;
                    posonestartfive.y = -80;
                    Transformonestartfive.localPosition = posonestartfive;
                    Transform Transformtwostartfive = _Texttwo.transform;
                    Vector2 postwostartfive = Transformtwostartfive.localPosition;
                    postwostartfive.x = 91;
                    postwostartfive.y = -27;
                    Transformtwostartfive.localPosition = postwostartfive;
                    Transform Transformthreestartfive = _Textthree.transform;
                    Vector2 posthreestartfive = Transformthreestartfive.localPosition;
                    posthreestartfive.x = 91;
                    posthreestartfive.y = 77;
                    Transformthreestartfive.localPosition = posthreestartfive;
                    Transform Transformfourstartfive = _Textfour.transform;
                    Vector2 posfourstartfive = Transformfourstartfive.localPosition;
                    posfourstartfive.x = 0;
                    posfourstartfive.y = 130;
                    Transformfourstartfive.localPosition = posfourstartfive;
                    Transform Transformfivestartfive = _Textfive.transform;
                    Vector2 posfivestartfive = Transformfivestartfive.localPosition;
                    posfivestartfive.x = -91;
                    posfivestartfive.y = 77;
                    Transformfivestartfive.localPosition = posfivestartfive;
                    Transform Transformsixstartfive = _Textsix.transform;
                    Vector2 possixstartfive = Transformsixstartfive.localPosition;
                    possixstartfive.x = -91;
                    possixstartfive.y = -27;
                    Transformsixstartfive.localPosition = possixstartfive;
                    stagestart = true;
                }


                if (words_click_counter < (wordsP[0] + 1))
                {
                    Transform Transformonefive = _Textone.transform;
                    Vector2 posonefive = Transformonefive.localPosition;
                    posonefive.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posonefive.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformonefive.localPosition = posonefive;
                }

                if (words_click_counter < (wordsP[1] + 1))
                {
                    Transform Transformtwofive = _Texttwo.transform;
                    Vector2 postwofive = Transformtwofive.localPosition;
                    postwofive.x += 105f * Mathf.Cos(theta + 1.047198f) * 0.01f;
                    postwofive.y += 105f * Mathf.Sin(theta + 1.047198f) * 0.01f;
                    Transformtwofive.localPosition = postwofive;
                }

                if (words_click_counter < (wordsP[2] + 1))
                {
                    Transform Transformthreefive = _Textthree.transform;
                    Vector2 posthreefive = Transformthreefive.localPosition;
                    posthreefive.x += 105f * Mathf.Cos(theta + 2.094395f) * 0.01f;
                    posthreefive.y += 105f * Mathf.Sin(theta + 2.094395f) * 0.01f;
                    Transformthreefive.localPosition = posthreefive;
                }

                if (words_click_counter < (wordsP[3] + 1))
                {
                    Transform Transformfourfive = _Textfour.transform;
                    Vector2 posfourfive = Transformfourfive.localPosition;
                    posfourfive.x += 105f * Mathf.Cos(theta + 3.141593f) * 0.01f;
                    posfourfive.y += 105f * Mathf.Sin(theta + 3.141593f) * 0.01f;
                    Transformfourfive.localPosition = posfourfive;
                }

                if (words_click_counter < (wordsP[4] + 1))
                {
                    Transform Transformfivefive = _Textfive.transform;
                    Vector2 posfivefive = Transformfivefive.localPosition;
                    posfivefive.x += 105f * Mathf.Cos(theta + 4.18879f) * 0.01f;
                    posfivefive.y += 105f * Mathf.Sin(theta + 4.18879f) * 0.01f;
                    Transformfivefive.localPosition = posfivefive;
                }

                if (words_click_counter < (wordsP[5] + 1))
                {
                    Transform Transformsixfive = _Textsix.transform;
                    Vector2 possixfive = Transformsixfive.localPosition;
                    possixfive.x += 105f * Mathf.Cos(theta + 5.235988f) * 0.01f;
                    possixfive.y += 105f * Mathf.Sin(theta + 5.235988f) * 0.01f;
                    Transformsixfive.localPosition = possixfive;
                }


                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }



                if (Textone.textone_click == true)
                {
                    Transform Transformonefiveclick = _Textone.transform;
                    Vector2 posonefiveclick = Transformonefiveclick.localPosition;
                    posonefiveclick.x = -100;
                    posonefiveclick.y = -150;
                    Transformonefiveclick.localPosition = posonefiveclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > (wordsP[1] - 1))
                    {
                        Transform Transformtwofiveclick = _Texttwo.transform;
                        Vector2 postwofiveclick = Transformtwofiveclick.localPosition;
                        postwofiveclick.x = -100 + wordsP[1] * 60;
                        postwofiveclick.y = -150;
                        Transformtwofiveclick.localPosition = postwofiveclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > (wordsP[2] - 1))
                    {
                        Transform Transformthreefiveclick = _Textthree.transform;
                        Vector2 posthreefiveclick = Transformthreefiveclick.localPosition;
                        posthreefiveclick.x = -100 + wordsP[2] * 60;
                        posthreefiveclick.y = -150;
                        Transformthreefiveclick.localPosition = posthreefiveclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                if (Textfour.textfour_click == true)
                {
                    if (words_click_counter > (wordsP[3] - 1))
                    {
                        Transform Transformfourfiveclick = _Textfour.transform;
                        Vector2 posfourfiveclick = Transformfourfiveclick.localPosition;
                        posfourfiveclick.x = -100 + wordsP[3] * 60;
                        posfourfiveclick.y = -150;
                        Transformfourfiveclick.localPosition = posfourfiveclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfour.textfour_click = false;
                }

                if (Textfive.textfive_click == true)
                {
                    if (words_click_counter > (wordsP[4] - 1))
                    {
                        Transform Transformfivefiveclick = _Textfive.transform;
                        Vector2 posfivefiveclick = Transformfivefiveclick.localPosition;
                        posfivefiveclick.x = -100 + wordsP[4] * 60;
                        posfivefiveclick.y = -150;
                        Transformfivefiveclick.localPosition = posfivefiveclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfive.textfive_click = false;
                }

                if (Textsix.textsix_click == true)
                {
                    if (words_click_counter > (wordsP[5] - 1))
                    {
                        Transform Transformsixfiveclick = _Textsix.transform;
                        Vector2 possixfiveclick = Transformsixfiveclick.localPosition;
                        possixfiveclick.x = -100 + wordsP[5] * 60;
                        possixfiveclick.y = -150;
                        Transformsixfiveclick.localPosition = possixfiveclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textsix.textsix_click = false;
                }




                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 5)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";
                    _Textfive.text = "";
                    _Textsix.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformfivefinishout = _Textfive.transform;
                    Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                    posfivefinishout.x = 1000;
                    posfivefinishout.y = 1000;
                    Transformfivefinishout.localPosition = posfivefinishout;

                    Transform Transformsixfinishout = _Textsix.transform;
                    Vector2 possixfinishout = Transformsixfinishout.localPosition;
                    possixfinishout.x = 1000;
                    possixfinishout.y = 1000;
                    Transformsixfinishout.localPosition = possixfinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }

            if (stagecheck == 6)
            {
                if (stagestart == false)
                {
                    posrand = Random.Range(0, 3);
                    if (posrand == 0)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 4;
                        wordsP[2] = 3;
                        wordsP[3] = 1;
                        wordsP[4] = 5;
                        wordsP[5] = 2;
                        wordsP[6] = 6;
                    }
                    else if (posrand == 1)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 2;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 3;
                        wordsP[5] = 6;
                        wordsP[6] = 5;
                    }
                    else
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 6;
                        wordsP[2] = 2;
                        wordsP[3] = 1;
                        wordsP[4] = 3;
                        wordsP[5] = 5;
                        wordsP[6] = 4;
                    }

                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    _Textfive.text = wordsR[stagecheck].Substring(wordsP[4], 1);
                    _Textsix.text = wordsR[stagecheck].Substring(wordsP[5], 1);
                    _Textseven.text = wordsR[stagecheck].Substring(wordsP[6], 1);
                    Transform Transformonestartsix = _Textone.transform;
                    Vector2 posonestartsix = Transformonestartsix.localPosition;
                    posonestartsix.x = 0;
                    posonestartsix.y = -80;
                    Transformonestartsix.localPosition = posonestartsix;
                    Transform Transformtwostartsix = _Texttwo.transform;
                    Vector2 postwostartsix = Transformtwostartsix.localPosition;
                    postwostartsix.x = 82;
                    postwostartsix.y = -40;
                    Transformtwostartsix.localPosition = postwostartsix;
                    Transform Transformthreestartsix = _Textthree.transform;
                    Vector2 posthreestartsix = Transformthreestartsix.localPosition;
                    posthreestartsix.x = 102;
                    posthreestartsix.y = 48;
                    Transformthreestartsix.localPosition = posthreestartsix;
                    Transform Transformfourstartsix = _Textfour.transform;
                    Vector2 posfourstartsix = Transformfourstartsix.localPosition;
                    posfourstartsix.x = 46;
                    posfourstartsix.y = 120;
                    Transformfourstartsix.localPosition = posfourstartsix;
                    Transform Transformfivestartsix = _Textfive.transform;
                    Vector2 posfivestartsix = Transformfivestartsix.localPosition;
                    posfivestartsix.x = -46;
                    posfivestartsix.y = 120;
                    Transformfivestartsix.localPosition = posfivestartsix;
                    Transform Transformsixstartsix = _Textsix.transform;
                    Vector2 possixstartsix = Transformsixstartsix.localPosition;
                    possixstartsix.x = -102;
                    possixstartsix.y = 48;
                    Transformsixstartsix.localPosition = possixstartsix;
                    Transform Transformsevenstartsix = _Textseven.transform;
                    Vector2 possevenstartsix = Transformsevenstartsix.localPosition;
                    possevenstartsix.x = -82;
                    possevenstartsix.y = -40;
                    Transformsevenstartsix.localPosition = possevenstartsix;
                    stagestart = true;
                }


                if (words_click_counter < (wordsP[0] + 1))
                {
                    Transform Transformonesix = _Textone.transform;
                    Vector2 posonesix = Transformonesix.localPosition;
                    posonesix.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posonesix.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformonesix.localPosition = posonesix;
                }

                if (words_click_counter < (wordsP[1] + 1))
                {
                    Transform Transformtwosix = _Texttwo.transform;
                    Vector2 postwosix = Transformtwosix.localPosition;
                    postwosix.x += 105f * Mathf.Cos(theta + 0.897598f) * 0.01f;
                    postwosix.y += 105f * Mathf.Sin(theta + 0.897598f) * 0.01f;
                    Transformtwosix.localPosition = postwosix;
                }

                if (words_click_counter < (wordsP[2] + 1))
                {
                    Transform Transformthreesix = _Textthree.transform;
                    Vector2 posthreesix = Transformthreesix.localPosition;
                    posthreesix.x += 105f * Mathf.Cos(theta + 1.795196f) * 0.01f;
                    posthreesix.y += 105f * Mathf.Sin(theta + 1.795196f) * 0.01f;
                    Transformthreesix.localPosition = posthreesix;
                }

                if (words_click_counter < (wordsP[3] + 1))
                {
                    Transform Transformfoursix = _Textfour.transform;
                    Vector2 posfoursix = Transformfoursix.localPosition;
                    posfoursix.x += 105f * Mathf.Cos(theta + 2.692794f) * 0.01f;
                    posfoursix.y += 105f * Mathf.Sin(theta + 2.692794f) * 0.01f;
                    Transformfoursix.localPosition = posfoursix;
                }

                if (words_click_counter < (wordsP[4] + 1))
                {
                    Transform Transformfivesix = _Textfive.transform;
                    Vector2 posfivesix = Transformfivesix.localPosition;
                    posfivesix.x += 105f * Mathf.Cos(theta + 3.590392f) * 0.01f;
                    posfivesix.y += 105f * Mathf.Sin(theta + 3.590392f) * 0.01f;
                    Transformfivesix.localPosition = posfivesix;
                }

                if (words_click_counter < (wordsP[5] + 1))
                {
                    Transform Transformsixsix = _Textsix.transform;
                    Vector2 possixsix = Transformsixsix.localPosition;
                    possixsix.x += 105f * Mathf.Cos(theta + 4.48799f) * 0.01f;
                    possixsix.y += 105f * Mathf.Sin(theta + 4.48799f) * 0.01f;
                    Transformsixsix.localPosition = possixsix;
                }

                if (words_click_counter < (wordsP[6] + 1))
                {
                    Transform Transformsevensix = _Textseven.transform;
                    Vector2 possevensix = Transformsevensix.localPosition;
                    possevensix.x += 105f * Mathf.Cos(theta + 5.385587f) * 0.01f;
                    possevensix.y += 105f * Mathf.Sin(theta + 5.385587f) * 0.01f;
                    Transformsevensix.localPosition = possevensix;
                }

                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }



                if (Textone.textone_click == true)
                {
                    Transform Transformonesixclick = _Textone.transform;
                    Vector2 posonesixclick = Transformonesixclick.localPosition;
                    posonesixclick.x = -100;
                    posonesixclick.y = -150;
                    Transformonesixclick.localPosition = posonesixclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > (wordsP[1] - 1))
                    {
                        Transform Transformtwosixclick = _Texttwo.transform;
                        Vector2 postwosixclick = Transformtwosixclick.localPosition;
                        postwosixclick.x = -100 + wordsP[1] * 50;
                        postwosixclick.y = -150;
                        Transformtwosixclick.localPosition = postwosixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > (wordsP[2] - 1))
                    {
                        Transform Transformthreesixclick = _Textthree.transform;
                        Vector2 posthreesixclick = Transformthreesixclick.localPosition;
                        posthreesixclick.x = -100 + wordsP[2] * 50;
                        posthreesixclick.y = -150;
                        Transformthreesixclick.localPosition = posthreesixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                if (Textfour.textfour_click == true)
                {
                    if (words_click_counter > (wordsP[3] - 1))
                    {
                        Transform Transformfoursixclick = _Textfour.transform;
                        Vector2 posfoursixclick = Transformfoursixclick.localPosition;
                        posfoursixclick.x = -100 + wordsP[3] * 50;
                        posfoursixclick.y = -150;
                        Transformfoursixclick.localPosition = posfoursixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfour.textfour_click = false;
                }

                if (Textfive.textfive_click == true)
                {
                    if (words_click_counter > (wordsP[4] - 1))
                    {
                        Transform Transformfivesixclick = _Textfive.transform;
                        Vector2 posfivesixclick = Transformfivesixclick.localPosition;
                        posfivesixclick.x = -100 + wordsP[4] * 50;
                        posfivesixclick.y = -150;
                        Transformfivesixclick.localPosition = posfivesixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfive.textfive_click = false;
                }

                if (Textsix.textsix_click == true)
                {
                    if (words_click_counter > (wordsP[5] - 1))
                    {
                        Transform Transformsixsixclick = _Textsix.transform;
                        Vector2 possixsixclick = Transformsixsixclick.localPosition;
                        possixsixclick.x = -100 + wordsP[5] * 50;
                        possixsixclick.y = -150;
                        Transformsixsixclick.localPosition = possixsixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textsix.textsix_click = false;
                }

                if (Textseven.textseven_click == true)
                {
                    if (words_click_counter > (wordsP[6] - 1))
                    {
                        Transform Transformsevensixclick = _Textseven.transform;
                        Vector2 possevensixclick = Transformsevensixclick.localPosition;
                        possevensixclick.x = -100 + wordsP[6] * 50;
                        possevensixclick.y = -150;
                        Transformsevensixclick.localPosition = possevensixclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textseven.textseven_click = false;
                }


                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 6)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";
                    _Textfive.text = "";
                    _Textsix.text = "";
                    _Textseven.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformfivefinishout = _Textfive.transform;
                    Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                    posfivefinishout.x = 1000;
                    posfivefinishout.y = 1000;
                    Transformfivefinishout.localPosition = posfivefinishout;

                    Transform Transformsixfinishout = _Textsix.transform;
                    Vector2 possixfinishout = Transformsixfinishout.localPosition;
                    possixfinishout.x = 1000;
                    possixfinishout.y = 1000;
                    Transformsixfinishout.localPosition = possixfinishout;

                    Transform Transformsevenfinishout = _Textsix.transform;
                    Vector2 possevenfinishout = Transformsevenfinishout.localPosition;
                    possevenfinishout.x = 1000;
                    possevenfinishout.y = 1000;
                    Transformsevenfinishout.localPosition = possevenfinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }


            if (stagecheck == 7)
            {
                if (stagestart == false)
                {
                    posrand = Random.Range(0, 3);
                    if (posrand == 0)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 4;
                        wordsP[2] = 3;
                        wordsP[3] = 1;
                        wordsP[4] = 5;
                        wordsP[5] = 2;
                        wordsP[6] = 7;
                        wordsP[7] = 6;
                    }
                    else if (posrand == 1)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 7;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 3;
                        wordsP[5] = 6;
                        wordsP[6] = 5;
                        wordsP[7] = 2;
                    }
                    else
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 6;
                        wordsP[2] = 2;
                        wordsP[3] = 1;
                        wordsP[4] = 3;
                        wordsP[5] = 5;
                        wordsP[6] = 4;
                        wordsP[7] = 7;
                    }

                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    _Textfive.text = wordsR[stagecheck].Substring(wordsP[4], 1);
                    _Textsix.text = wordsR[stagecheck].Substring(wordsP[5], 1);
                    _Textseven.text = wordsR[stagecheck].Substring(wordsP[6], 1);
                    _Texteight.text = wordsR[stagecheck].Substring(wordsP[7], 1);
                    Transform Transformonestartseven = _Textone.transform;
                    Vector2 posonestartseven = Transformonestartseven.localPosition;
                    posonestartseven.x = 0;
                    posonestartseven.y = -80;
                    Transformonestartseven.localPosition = posonestartseven;
                    Transform Transformtwostartseven = _Texttwo.transform;
                    Vector2 postwostartseven = Transformtwostartseven.localPosition;
                    postwostartseven.x = 74;
                    postwostartseven.y = -49;
                    Transformtwostartseven.localPosition = postwostartseven;
                    Transform Transformthreestartseven = _Textthree.transform;
                    Vector2 posthreestartseven = Transformthreestartseven.localPosition;
                    posthreestartseven.x = 105;
                    posthreestartseven.y = 25;
                    Transformthreestartseven.localPosition = posthreestartseven;
                    Transform Transformfourstartseven = _Textfour.transform;
                    Vector2 posfourstartseven = Transformfourstartseven.localPosition;
                    posfourstartseven.x = 74;
                    posfourstartseven.y = 99;
                    Transformfourstartseven.localPosition = posfourstartseven;
                    Transform Transformfivestartseven = _Textfive.transform;
                    Vector2 posfivestartseven = Transformfivestartseven.localPosition;
                    posfivestartseven.x = 0;
                    posfivestartseven.y = 130;
                    Transformfivestartseven.localPosition = posfivestartseven;
                    Transform Transformsixstartseven = _Textsix.transform;
                    Vector2 possixstartseven = Transformsixstartseven.localPosition;
                    possixstartseven.x = -74;
                    possixstartseven.y = 99;
                    Transformsixstartseven.localPosition = possixstartseven;
                    Transform Transformsevenstartseven = _Textseven.transform;
                    Vector2 possevenstartseven = Transformsevenstartseven.localPosition;
                    possevenstartseven.x = -105;
                    possevenstartseven.y = 25;
                    Transformsevenstartseven.localPosition = possevenstartseven;
                    Transform Transformeightstartseven = _Texteight.transform;
                    Vector2 poseightstartseven = Transformeightstartseven.localPosition;
                    poseightstartseven.x = -74;
                    poseightstartseven.y = -49;
                    Transformeightstartseven.localPosition = poseightstartseven;
                    stagestart = true;
                }


                if (words_click_counter < (wordsP[0] + 1))
                {
                    Transform Transformoneseven = _Textone.transform;
                    Vector2 posoneseven = Transformoneseven.localPosition;
                    posoneseven.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posoneseven.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformoneseven.localPosition = posoneseven;
                }

                if (words_click_counter < (wordsP[1] + 1))
                {
                    Transform Transformtwoseven = _Texttwo.transform;
                    Vector2 postwoseven = Transformtwoseven.localPosition;
                    postwoseven.x += 105f * Mathf.Cos(theta + 0.785398f) * 0.01f;
                    postwoseven.y += 105f * Mathf.Sin(theta + 0.785398f) * 0.01f;
                    Transformtwoseven.localPosition = postwoseven;
                }

                if (words_click_counter < (wordsP[2] + 1))
                {
                    Transform Transformthreeseven = _Textthree.transform;
                    Vector2 posthreeseven = Transformthreeseven.localPosition;
                    posthreeseven.x += 105f * Mathf.Cos(theta + 1.570796f) * 0.01f;
                    posthreeseven.y += 105f * Mathf.Sin(theta + 1.570796f) * 0.01f;
                    Transformthreeseven.localPosition = posthreeseven;
                }

                if (words_click_counter < (wordsP[3] + 1))
                {
                    Transform Transformfourseven = _Textfour.transform;
                    Vector2 posfourseven = Transformfourseven.localPosition;
                    posfourseven.x += 105f * Mathf.Cos(theta + 2.356194f) * 0.01f;
                    posfourseven.y += 105f * Mathf.Sin(theta + 2.356194f) * 0.01f;
                    Transformfourseven.localPosition = posfourseven;
                }

                if (words_click_counter < (wordsP[4] + 1))
                {
                    Transform Transformfiveseven = _Textfive.transform;
                    Vector2 posfiveseven = Transformfiveseven.localPosition;
                    posfiveseven.x += 105f * Mathf.Cos(theta + 3.141593f) * 0.01f;
                    posfiveseven.y += 105f * Mathf.Sin(theta + 3.141593f) * 0.01f;
                    Transformfiveseven.localPosition = posfiveseven;
                }

                if (words_click_counter < (wordsP[5] + 1))
                {
                    Transform Transformsixseven = _Textsix.transform;
                    Vector2 possixseven = Transformsixseven.localPosition;
                    possixseven.x += 105f * Mathf.Cos(theta + 3.926991f) * 0.01f;
                    possixseven.y += 105f * Mathf.Sin(theta + 3.926991f) * 0.01f;
                    Transformsixseven.localPosition = possixseven;
                }

                if (words_click_counter < (wordsP[6] + 1))
                {
                    Transform Transformsevenseven = _Textseven.transform;
                    Vector2 possevenseven = Transformsevenseven.localPosition;
                    possevenseven.x += 105f * Mathf.Cos(theta + 4.712389f) * 0.01f;
                    possevenseven.y += 105f * Mathf.Sin(theta + 4.712389f) * 0.01f;
                    Transformsevenseven.localPosition = possevenseven;
                }

                if (words_click_counter < (wordsP[7] + 1))
                {
                    Transform Transformeightseven = _Texteight.transform;
                    Vector2 poseightseven = Transformeightseven.localPosition;
                    poseightseven.x += 105f * Mathf.Cos(theta + 5.497787f) * 0.01f;
                    poseightseven.y += 105f * Mathf.Sin(theta + 5.497787f) * 0.01f;
                    Transformeightseven.localPosition = poseightseven;
                }


                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }



                if (Textone.textone_click == true)
                {
                    Transform Transformonesevenclick = _Textone.transform;
                    Vector2 posonesevenclick = Transformonesevenclick.localPosition;
                    posonesevenclick.x = -100;
                    posonesevenclick.y = -150;
                    Transformonesevenclick.localPosition = posonesevenclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > (wordsP[1] - 1))
                    {
                        Transform Transformtwosevenclick = _Texttwo.transform;
                        Vector2 postwosevenclick = Transformtwosevenclick.localPosition;
                        postwosevenclick.x = -100 + wordsP[1] * 40;
                        postwosevenclick.y = -150;
                        Transformtwosevenclick.localPosition = postwosevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > (wordsP[2] - 1))
                    {
                        Transform Transformthreesevenclick = _Textthree.transform;
                        Vector2 posthreesevenclick = Transformthreesevenclick.localPosition;
                        posthreesevenclick.x = -100 + wordsP[2] * 40;
                        posthreesevenclick.y = -150;
                        Transformthreesevenclick.localPosition = posthreesevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                if (Textfour.textfour_click == true)
                {
                    if (words_click_counter > (wordsP[3] - 1))
                    {
                        Transform Transformfoursevenclick = _Textfour.transform;
                        Vector2 posfoursevenclick = Transformfoursevenclick.localPosition;
                        posfoursevenclick.x = -100 + wordsP[3] * 40;
                        posfoursevenclick.y = -150;
                        Transformfoursevenclick.localPosition = posfoursevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfour.textfour_click = false;
                }

                if (Textfive.textfive_click == true)
                {
                    if (words_click_counter > (wordsP[4] - 1))
                    {
                        Transform Transformfivesevenclick = _Textfive.transform;
                        Vector2 posfivesevenclick = Transformfivesevenclick.localPosition;
                        posfivesevenclick.x = -100 + wordsP[4] * 40;
                        posfivesevenclick.y = -150;
                        Transformfivesevenclick.localPosition = posfivesevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfive.textfive_click = false;
                }

                if (Textsix.textsix_click == true)
                {
                    if (words_click_counter > (wordsP[5] - 1))
                    {
                        Transform Transformsixsevenclick = _Textsix.transform;
                        Vector2 possixsevenclick = Transformsixsevenclick.localPosition;
                        possixsevenclick.x = -100 + wordsP[5] * 40;
                        possixsevenclick.y = -150;
                        Transformsixsevenclick.localPosition = possixsevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textsix.textsix_click = false;
                }

                if (Textseven.textseven_click == true)
                {
                    if (words_click_counter > (wordsP[6] - 1))
                    {
                        Transform Transformsevensevenclick = _Textseven.transform;
                        Vector2 possevensevenclick = Transformsevensevenclick.localPosition;
                        possevensevenclick.x = -100 + wordsP[6] * 40;
                        possevensevenclick.y = -150;
                        Transformsevensevenclick.localPosition = possevensevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textseven.textseven_click = false;
                }

                if (Texteight.texteight_click == true)
                {
                    if (words_click_counter > (wordsP[7] - 1))
                    {
                        Transform Transformeightsevenclick = _Texteight.transform;
                        Vector2 poseightsevenclick = Transformeightsevenclick.localPosition;
                        poseightsevenclick.x = -100 + wordsP[7] * 40;
                        poseightsevenclick.y = -150;
                        Transformeightsevenclick.localPosition = poseightsevenclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texteight.texteight_click = false;
                }


                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 7)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";
                    _Textfive.text = "";
                    _Textsix.text = "";
                    _Textseven.text = "";
                    _Texteight.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformfivefinishout = _Textfive.transform;
                    Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                    posfivefinishout.x = 1000;
                    posfivefinishout.y = 1000;
                    Transformfivefinishout.localPosition = posfivefinishout;

                    Transform Transformsixfinishout = _Textsix.transform;
                    Vector2 possixfinishout = Transformsixfinishout.localPosition;
                    possixfinishout.x = 1000;
                    possixfinishout.y = 1000;
                    Transformsixfinishout.localPosition = possixfinishout;

                    Transform Transformsevenfinishout = _Textsix.transform;
                    Vector2 possevenfinishout = Transformsevenfinishout.localPosition;
                    possevenfinishout.x = 1000;
                    possevenfinishout.y = 1000;
                    Transformsevenfinishout.localPosition = possevenfinishout;

                    Transform Transformeightfinishout = _Textsix.transform;
                    Vector2 poseightfinishout = Transformeightfinishout.localPosition;
                    poseightfinishout.x = 1000;
                    poseightfinishout.y = 1000;
                    Transformeightfinishout.localPosition = poseightfinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }


            if (stagecheck == 8)
            {
                if (stagestart == false)
                {
                    posrand = Random.Range(0, 3);
                    if (posrand == 0)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 4;
                        wordsP[2] = 3;
                        wordsP[3] = 1;
                        wordsP[4] = 5;
                        wordsP[5] = 2;
                        wordsP[6] = 7;
                        wordsP[7] = 6;
                        wordsP[8] = 8;
                    }
                    else if (posrand == 1)
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 7;
                        wordsP[2] = 1;
                        wordsP[3] = 4;
                        wordsP[4] = 3;
                        wordsP[5] = 6;
                        wordsP[6] = 8;
                        wordsP[7] = 2;
                        wordsP[8] = 5;
                    }
                    else
                    {
                        wordsP[0] = 0;
                        wordsP[1] = 6;
                        wordsP[2] = 2;
                        wordsP[3] = 1;
                        wordsP[4] = 3;
                        wordsP[5] = 5;
                        wordsP[6] = 8;
                        wordsP[7] = 7;
                        wordsP[8] = 4;
                    }

                    _Textone.text = wordsR[stagecheck].Substring(wordsP[0], 1);
                    _Texttwo.text = wordsR[stagecheck].Substring(wordsP[1], 1);
                    _Textthree.text = wordsR[stagecheck].Substring(wordsP[2], 1);
                    _Textfour.text = wordsR[stagecheck].Substring(wordsP[3], 1);
                    _Textfive.text = wordsR[stagecheck].Substring(wordsP[4], 1);
                    _Textsix.text = wordsR[stagecheck].Substring(wordsP[5], 1);
                    _Textseven.text = wordsR[stagecheck].Substring(wordsP[6], 1);
                    _Texteight.text = wordsR[stagecheck].Substring(wordsP[7], 1);
                    _Textnine.text = wordsR[stagecheck].Substring(wordsP[8], 1);
                    Transform Transformonestarteight = _Textone.transform;
                    Vector2 posonestarteight = Transformonestarteight.localPosition;
                    posonestarteight.x = 0;
                    posonestarteight.y = -80;
                    Transformonestarteight.localPosition = posonestarteight;
                    Transform Transformtwostarteight = _Texttwo.transform;
                    Vector2 postwostarteight = Transformtwostarteight.localPosition;
                    postwostarteight.x = 67;
                    postwostarteight.y = -55;
                    Transformtwostarteight.localPosition = postwostarteight;
                    Transform Transformthreestarteight = _Textthree.transform;
                    Vector2 posthreestarteight = Transformthreestarteight.localPosition;
                    posthreestarteight.x = 103;
                    posthreestarteight.y = 7;
                    Transformthreestarteight.localPosition = posthreestarteight;
                    Transform Transformfourstarteight = _Textfour.transform;
                    Vector2 posfourstarteight = Transformfourstarteight.localPosition;
                    posfourstarteight.x = 91;
                    posfourstarteight.y = 77;
                    Transformfourstarteight.localPosition = posfourstarteight;
                    Transform Transformfivestarteight = _Textfive.transform;
                    Vector2 posfivestarteight = Transformfivestarteight.localPosition;
                    posfivestarteight.x = 36;
                    posfivestarteight.y = 124;
                    Transformfivestarteight.localPosition = posfivestarteight;
                    Transform Transformsixstarteight = _Textsix.transform;
                    Vector2 possixstarteight = Transformsixstarteight.localPosition;
                    possixstarteight.x = -36;
                    possixstarteight.y = 124;
                    Transformsixstarteight.localPosition = possixstarteight;
                    Transform Transformsevenstarteight = _Textseven.transform;
                    Vector2 possevenstarteight = Transformsevenstarteight.localPosition;
                    possevenstarteight.x = -91;
                    possevenstarteight.y = 77;
                    Transformsevenstarteight.localPosition = possevenstarteight;
                    Transform Transformeightstarteight = _Texteight.transform;
                    Vector2 poseightstarteight = Transformeightstarteight.localPosition;
                    poseightstarteight.x = -103;
                    poseightstarteight.y = 7;
                    Transformeightstarteight.localPosition = poseightstarteight;
                    Transform Transformninestarteight = _Textnine.transform;
                    Vector2 posninestarteight = Transformninestarteight.localPosition;
                    posninestarteight.x = -67;
                    posninestarteight.y = -55;
                    Transformninestarteight.localPosition = posninestarteight;
                    stagestart = true;
                }


                if (words_click_counter < (wordsP[0] + 1))
                {
                    Transform Transformoneeight = _Textone.transform;
                    Vector2 posoneeight = Transformoneeight.localPosition;
                    posoneeight.x += 105f * Mathf.Cos(theta) * 0.01f;
                    posoneeight.y += 105f * Mathf.Sin(theta) * 0.01f;
                    Transformoneeight.localPosition = posoneeight;
                }

                if (words_click_counter < (wordsP[1] + 1))
                {
                    Transform Transformtwoeight = _Texttwo.transform;
                    Vector2 postwoeight = Transformtwoeight.localPosition;
                    postwoeight.x += 105f * Mathf.Cos(theta + 0.698132f) * 0.01f;
                    postwoeight.y += 105f * Mathf.Sin(theta + 0.698132f) * 0.01f;
                    Transformtwoeight.localPosition = postwoeight;
                }

                if (words_click_counter < (wordsP[2] + 1))
                {
                    Transform Transformthreeeight = _Textthree.transform;
                    Vector2 posthreeeight = Transformthreeeight.localPosition;
                    posthreeeight.x += 105f * Mathf.Cos(theta + 1.396263f) * 0.01f;
                    posthreeeight.y += 105f * Mathf.Sin(theta + 1.396263f) * 0.01f;
                    Transformthreeeight.localPosition = posthreeeight;
                }

                if (words_click_counter < (wordsP[3] + 1))
                {
                    Transform Transformfoureight = _Textfour.transform;
                    Vector2 posfoureight = Transformfoureight.localPosition;
                    posfoureight.x += 105f * Mathf.Cos(theta + 2.094395f) * 0.01f;
                    posfoureight.y += 105f * Mathf.Sin(theta + 2.094395f) * 0.01f;
                    Transformfoureight.localPosition = posfoureight;
                }

                if (words_click_counter < (wordsP[4] + 1))
                {
                    Transform Transformfiveeight = _Textfive.transform;
                    Vector2 posfiveeight = Transformfiveeight.localPosition;
                    posfiveeight.x += 105f * Mathf.Cos(theta + 2.792527f) * 0.01f;
                    posfiveeight.y += 105f * Mathf.Sin(theta + 2.792527f) * 0.01f;
                    Transformfiveeight.localPosition = posfiveeight;
                }

                if (words_click_counter < (wordsP[5] + 1))
                {
                    Transform Transformsixeight = _Textsix.transform;
                    Vector2 possixeight = Transformsixeight.localPosition;
                    possixeight.x += 105f * Mathf.Cos(theta + 3.490659f) * 0.01f;
                    possixeight.y += 105f * Mathf.Sin(theta + 3.490659f) * 0.01f;
                    Transformsixeight.localPosition = possixeight;
                }

                if (words_click_counter < (wordsP[6] + 1))
                {
                    Transform Transformseveneight = _Textseven.transform;
                    Vector2 posseveneight = Transformseveneight.localPosition;
                    posseveneight.x += 105f * Mathf.Cos(theta + 4.18879f) * 0.01f;
                    posseveneight.y += 105f * Mathf.Sin(theta + 4.18879f) * 0.01f;
                    Transformseveneight.localPosition = posseveneight;
                }

                if (words_click_counter < (wordsP[7] + 1))
                {
                    Transform Transformeighteight = _Texteight.transform;
                    Vector2 poseighteight = Transformeighteight.localPosition;
                    poseighteight.x += 105f * Mathf.Cos(theta + 4.886922f) * 0.01f;
                    poseighteight.y += 105f * Mathf.Sin(theta + 4.886922f) * 0.01f;
                    Transformeighteight.localPosition = poseighteight;
                }

                if (words_click_counter < (wordsP[8] + 1))
                {
                    Transform Transformnineeight = _Textnine.transform;
                    Vector2 posnineeight = Transformnineeight.localPosition;
                    posnineeight.x += 105f * Mathf.Cos(theta + 5.585054f) * 0.01f;
                    posnineeight.y += 105f * Mathf.Sin(theta + 5.585054f) * 0.01f;
                    Transformnineeight.localPosition = posnineeight;
                }


                theta = theta + 0.01f;
                if (theta > 6.283185f)
                {
                    theta = theta - 6.283185f;
                }



                if (Textone.textone_click == true)
                {
                    Transform Transformoneeightclick = _Textone.transform;
                    Vector2 posoneeightclick = Transformoneeightclick.localPosition;
                    posoneeightclick.x = -100;
                    posoneeightclick.y = -150;
                    Transformoneeightclick.localPosition = posoneeightclick;
                    words_click_counter = words_click_counter + 1;
                    Textone.textone_click = false;
                    audioSource.PlayOneShot(sound1);
                }

                if (Texttwo.texttwo_click == true)
                {
                    if (words_click_counter > (wordsP[1] - 1))
                    {
                        Transform Transformtwoeightclick = _Texttwo.transform;
                        Vector2 postwoeightclick = Transformtwoeightclick.localPosition;
                        postwoeightclick.x = -100 + wordsP[1] * 30;
                        postwoeightclick.y = -150;
                        Transformtwoeightclick.localPosition = postwoeightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texttwo.texttwo_click = false;
                }

                if (Textthree.textthree_click == true)
                {
                    if (words_click_counter > (wordsP[2] - 1))
                    {
                        Transform Transformthreeeightclick = _Textthree.transform;
                        Vector2 posthreeeightclick = Transformthreeeightclick.localPosition;
                        posthreeeightclick.x = -100 + wordsP[2] * 30;
                        posthreeeightclick.y = -150;
                        Transformthreeeightclick.localPosition = posthreeeightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textthree.textthree_click = false;
                }

                if (Textfour.textfour_click == true)
                {
                    if (words_click_counter > (wordsP[3] - 1))
                    {
                        Transform Transformfoureightclick = _Textfour.transform;
                        Vector2 posfoureightclick = Transformfoureightclick.localPosition;
                        posfoureightclick.x = -100 + wordsP[3] * 30;
                        posfoureightclick.y = -150;
                        Transformfoureightclick.localPosition = posfoureightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfour.textfour_click = false;
                }

                if (Textfive.textfive_click == true)
                {
                    if (words_click_counter > (wordsP[4] - 1))
                    {
                        Transform Transformfiveeightclick = _Textfive.transform;
                        Vector2 posfiveeightclick = Transformfiveeightclick.localPosition;
                        posfiveeightclick.x = -100 + wordsP[4] * 30;
                        posfiveeightclick.y = -150;
                        Transformfiveeightclick.localPosition = posfiveeightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textfive.textfive_click = false;
                }

                if (Textsix.textsix_click == true)
                {
                    if (words_click_counter > (wordsP[5] - 1))
                    {
                        Transform Transformsixeightclick = _Textsix.transform;
                        Vector2 possixeightclick = Transformsixeightclick.localPosition;
                        possixeightclick.x = -100 + wordsP[5] * 30;
                        possixeightclick.y = -150;
                        Transformsixeightclick.localPosition = possixeightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textsix.textsix_click = false;
                }

                if (Textseven.textseven_click == true)
                {
                    if (words_click_counter > (wordsP[6] - 1))
                    {
                        Transform Transformseveneightclick = _Textseven.transform;
                        Vector2 posseveneightclick = Transformseveneightclick.localPosition;
                        posseveneightclick.x = -100 + wordsP[6] * 30;
                        posseveneightclick.y = -150;
                        Transformseveneightclick.localPosition = posseveneightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textseven.textseven_click = false;
                }

                if (Texteight.texteight_click == true)
                {
                    if (words_click_counter > (wordsP[7] - 1))
                    {
                        Transform Transformeighteightclick = _Texteight.transform;
                        Vector2 poseighteightclick = Transformeighteightclick.localPosition;
                        poseighteightclick.x = -100 + wordsP[7] * 30;
                        poseighteightclick.y = -150;
                        Transformeighteightclick.localPosition = poseighteightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Texteight.texteight_click = false;
                }

                if (Textnine.textnine_click == true)
                {
                    if (words_click_counter > (wordsP[8] - 1))
                    {
                        Transform Transformnineeightclick = _Textnine.transform;
                        Vector2 posnineeightclick = Transformnineeightclick.localPosition;
                        posnineeightclick.x = -100 + wordsP[8] * 30;
                        posnineeightclick.y = -150;
                        Transformnineeightclick.localPosition = posnineeightclick;
                        words_click_counter = words_click_counter + 1;
                        audioSource.PlayOneShot(sound1);
                    }
                    else
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    Textnine.textnine_click = false;
                }


                countTime = countTime - Time.deltaTime;
                _Timer.text = countTime.ToString("F0");

                if (words_click_counter > 8)
                {
                    Invoke("stagechange", 1.0f);
                    stagecheck = stagecheck + 1;
                    words_click_counter = 0;
                    theta = 0;
                    countTime = limitTime;
                    stagestart = false;
                }

                if (countTime < 0)
                {
                    stagecheck = 10;
                    _Textone.text = "";
                    _Texttwo.text = "";
                    _Textthree.text = "";
                    _Textfour.text = "";
                    _Textfive.text = "";
                    _Textsix.text = "";
                    _Textseven.text = "";
                    _Texteight.text = "";
                    _Textnine.text = "";

                    Transform Transformonefinishout = _Textone.transform;
                    Vector2 posonefinishout = Transformonefinishout.localPosition;
                    posonefinishout.x = 1000;
                    posonefinishout.y = 1000;
                    Transformonefinishout.localPosition = posonefinishout;

                    Transform Transformtwofinishout = _Texttwo.transform;
                    Vector2 postwofinishout = Transformtwofinishout.localPosition;
                    postwofinishout.x = 1000;
                    postwofinishout.y = 1000;
                    Transformtwofinishout.localPosition = postwofinishout;

                    Transform Transformthreefinishout = _Textthree.transform;
                    Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                    posthreefinishout.x = 1000;
                    posthreefinishout.y = 1000;
                    Transformthreefinishout.localPosition = posthreefinishout;

                    Transform Transformfourfinishout = _Textfour.transform;
                    Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                    posfourfinishout.x = 1000;
                    posfourfinishout.y = 1000;
                    Transformfourfinishout.localPosition = posfourfinishout;

                    Transform Transformfivefinishout = _Textfive.transform;
                    Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                    posfivefinishout.x = 1000;
                    posfivefinishout.y = 1000;
                    Transformfivefinishout.localPosition = posfivefinishout;

                    Transform Transformsixfinishout = _Textsix.transform;
                    Vector2 possixfinishout = Transformsixfinishout.localPosition;
                    possixfinishout.x = 1000;
                    possixfinishout.y = 1000;
                    Transformsixfinishout.localPosition = possixfinishout;

                    Transform Transformsevenfinishout = _Textseven.transform;
                    Vector2 possevenfinishout = Transformsevenfinishout.localPosition;
                    possevenfinishout.x = 1000;
                    possevenfinishout.y = 1000;
                    Transformsevenfinishout.localPosition = possevenfinishout;

                    Transform Transformeightfinishout = _Texteight.transform;
                    Vector2 poseightfinishout = Transformeightfinishout.localPosition;
                    poseightfinishout.x = 1000;
                    poseightfinishout.y = 1000;
                    Transformeightfinishout.localPosition = poseightfinishout;

                    Transform Transformninefinishout = _Textnine.transform;
                    Vector2 posninefinishout = Transformninefinishout.localPosition;
                    posninefinishout.x = 1000;
                    posninefinishout.y = 1000;
                    Transformninefinishout.localPosition = posninefinishout;

                    Transform Transformgameoverfinishcome = _Gameover.transform;
                    Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                    posgameoverfinishcome.x = 0;
                    posgameoverfinishcome.y = 60;
                    Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                    Transform Transformtitlebackfinishcome = _Titleback.transform;
                    Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                    postitlebackfinishcome.x = 20;
                    postitlebackfinishcome.y = -30;
                    Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                    _Gameover.text = "GameOver";
                    _Titleback.text = "タイトルへもどる";
                    BGM_main.Stop();
                }

            }


            if (stagecheck == 9)
            {
                stagecheck = 10;
                _Textone.text = "";
                _Texttwo.text = "";
                _Textthree.text = "";
                _Textfour.text = "";
                _Textfive.text = "";
                _Textsix.text = "";
                _Textseven.text = "";
                _Texteight.text = "";
                _Textnine.text = "";

                Transform Transformonefinishout = _Textone.transform;
                Vector2 posonefinishout = Transformonefinishout.localPosition;
                posonefinishout.x = 1000;
                posonefinishout.y = 1000;
                Transformonefinishout.localPosition = posonefinishout;

                Transform Transformtwofinishout = _Texttwo.transform;
                Vector2 postwofinishout = Transformtwofinishout.localPosition;
                postwofinishout.x = 1000;
                postwofinishout.y = 1000;
                Transformtwofinishout.localPosition = postwofinishout;

                Transform Transformthreefinishout = _Textthree.transform;
                Vector2 posthreefinishout = Transformthreefinishout.localPosition;
                posthreefinishout.x = 1000;
                posthreefinishout.y = 1000;
                Transformthreefinishout.localPosition = posthreefinishout;

                Transform Transformfourfinishout = _Textfour.transform;
                Vector2 posfourfinishout = Transformfourfinishout.localPosition;
                posfourfinishout.x = 1000;
                posfourfinishout.y = 1000;
                Transformfourfinishout.localPosition = posfourfinishout;

                Transform Transformfivefinishout = _Textfive.transform;
                Vector2 posfivefinishout = Transformfivefinishout.localPosition;
                posfivefinishout.x = 1000;
                posfivefinishout.y = 1000;
                Transformfivefinishout.localPosition = posfivefinishout;

                Transform Transformsixfinishout = _Textsix.transform;
                Vector2 possixfinishout = Transformsixfinishout.localPosition;
                possixfinishout.x = 1000;
                possixfinishout.y = 1000;
                Transformsixfinishout.localPosition = possixfinishout;

                Transform Transformsevenfinishout = _Textseven.transform;
                Vector2 possevenfinishout = Transformsevenfinishout.localPosition;
                possevenfinishout.x = 1000;
                possevenfinishout.y = 1000;
                Transformsevenfinishout.localPosition = possevenfinishout;

                Transform Transformeightfinishout = _Texteight.transform;
                Vector2 poseightfinishout = Transformeightfinishout.localPosition;
                poseightfinishout.x = 1000;
                poseightfinishout.y = 1000;
                Transformeightfinishout.localPosition = poseightfinishout;

                Transform Transformninefinishout = _Textnine.transform;
                Vector2 posninefinishout = Transformninefinishout.localPosition;
                posninefinishout.x = 1000;
                posninefinishout.y = 1000;
                Transformninefinishout.localPosition = posninefinishout;

                Transform Transformgameoverfinishcome = _Gameover.transform;
                Vector2 posgameoverfinishcome = Transformgameoverfinishcome.localPosition;
                posgameoverfinishcome.x = 0;
                posgameoverfinishcome.y = 60;
                Transformgameoverfinishcome.localPosition = posgameoverfinishcome;

                Transform Transformtitlebackfinishcome = _Titleback.transform;
                Vector2 postitlebackfinishcome = Transformtitlebackfinishcome.localPosition;
                postitlebackfinishcome.x = 20;
                postitlebackfinishcome.y = -30;
                Transformtitlebackfinishcome.localPosition = postitlebackfinishcome;

                _Gameover.text = "GameClear!";
                _Titleback.text = "タイトルへもどる";
                BGM_main.Stop();
            }

            if (Titleback.Titleback_click == true)
            {

                stagecheck = 2;
                words_click_counter = 0;
                theta = 0;
                countTime = limitTime;
                stagestart = false;
                buttoncheck = false;

                Transform Transformgameoverreloadout = _Gameover.transform;
                Vector2 posgameoverreloadout = Transformgameoverreloadout.localPosition;
                posgameoverreloadout.x = 1000;
                posgameoverreloadout.y = 1000;
                Transformgameoverreloadout.localPosition = posgameoverreloadout;

                Transform Transformtitlebackreloadout = _Titleback.transform;
                Vector2 postitlebackreloadout = Transformtitlebackreloadout.localPosition;
                postitlebackreloadout.x = 1000;
                postitlebackreloadout.y = 1000;
                Transformtitlebackreloadout.localPosition = postitlebackreloadout;

                Transform Transformbuttonreloadfail = _button.transform;
                Vector2 posbuttonreloadfail = Transformbuttonreloadfail.localPosition;
                posbuttonreloadfail.x = 0;
                posbuttonreloadfail.y = -100;
                Transformbuttonreloadfail.localPosition = posbuttonreloadfail;

                Transform Transformtitlereloadfail = _Title.transform;
                Vector2 postitlereloadfail = Transformtitlereloadfail.localPosition;
                postitlereloadfail.x = 0;
                postitlereloadfail.y = 0;
                Transformtitlereloadfail.localPosition = postitlereloadfail;

                _Title.text = "ぐるぐる単語";
                _Timer.text = "";
                BGM_title.Play();

                Titleback.Titleback_click = false;
            }
        }
    }
}
