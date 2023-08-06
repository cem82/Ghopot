using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Orders : MonoBehaviour
{
    [SerializeField] Potion pot;
    public GameObject potion;
    public int spice;
    public int net;
    float time = 20;
    [SerializeField] int numOrder;
    [SerializeField] Text tex;
    public GameObject gameOver;
    public int score;
    bool GamesOver;
    public TimeBar timebar;
    public SpriteRenderer srBlue;
    public Sprite rightBlue;
    public Sprite notRightBlue;

    public SpriteRenderer srRed;
    public Sprite rightRed;
    public Sprite notRightRed;

    [Header("Images")]
    [SerializeField] Image[] SpiceOrders;
    [SerializeField] Image[] NetOrders;

        [Header("Sprites")]

    [SerializeField] Sprite fullSpice;
    [SerializeField] Sprite emptySpice;


    [SerializeField] Sprite fullNet;
    [SerializeField] Sprite emptyNet;



    public void Restart()
    {
        SceneManager.LoadScene(1);
        gameOver.SetActive(false);
        GamesOver = false;
        potion.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        spice = Random.Range(1, 6);
        net = Random.Range(1, 6);
         timebar.SetTime(time);
    }

    // Update is called once per frame
    void Update()
    {
        tex.text = score.ToString();
        if(time > 0)
        {
         time -= 1 * Time.deltaTime;
        timebar.SetTime(time);

        }

        if(time <= 0)
        {
            gameOver.SetActive(true);
            potion.SetActive(false);
            GamesOver = true;
        }


        if(spice > numOrder)
        {
            spice = numOrder;
        }

        for(int i = 0; i < SpiceOrders.Length; i++)
        {
            if(i < spice)
            {
                SpiceOrders[i].sprite = fullSpice;
            } else 
            {
                SpiceOrders[i].sprite = emptySpice;
            }
            if(i < numOrder)
            {
                SpiceOrders[i].enabled = true;
            } else 
            {
                SpiceOrders[i].enabled = false;
            }
        }

        if(net > numOrder)
        {
            net = numOrder;
        }

        for(int i = 0; i < NetOrders.Length; i++)
        {
            if(i < net)
            {
                NetOrders[i].sprite = fullNet;
            } else 
            {
                NetOrders[i].sprite = emptyNet;
            }
            if(i < numOrder)
            {
                NetOrders[i].enabled = true;
            } else 
            {
                NetOrders[i].enabled = false;
            }
        }
    }

    public void Next()
    {
        if(!GamesOver)
        {
            StartCoroutine(NextOrder());
            SfxManager.SFXInstance.Audio.PlayOneShot(SfxManager.SFXInstance.click);
            if((net == pot.net || spice == pot.spice) && !GamesOver)
            {
            score++;
            }
            if(net == pot.net)
            {
                srBlue.sprite = rightBlue;
            } else 
            {
                srBlue.sprite = notRightBlue;
            }

                if(spice == pot.spice)
            {
                srRed.sprite = rightRed;
            } else 
            {
                srRed.sprite = notRightRed;
            }
        }

    }

    IEnumerator NextOrder()
    {

        yield return new WaitForSeconds(0.1f);
        spice = Random.Range(1, 6);
        net = Random.Range(1, 6);
        pot.spice = 0;
        pot.net = 0;
    }
}
