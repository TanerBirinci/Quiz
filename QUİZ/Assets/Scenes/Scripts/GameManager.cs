using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public QuizManager[] sorular;

    private static List<QuizManager> cevaplanmamisSorular;



    private QuizManager gecerliSoru;
    
    [SerializeField] private Text soruText;
    [SerializeField] private Text dogruCevapText, yanlisCevapText;
    [SerializeField] private GameObject dogruButon, yanlisButon;
    [SerializeField] private GameObject sonucPaneli;

    private int dogruAdet, yanlisAdet;
    private int toplamPuan;

    private SonucManager sonucManager;
    
    void Start()
    {
        if (cevaplanmamisSorular == null || cevaplanmamisSorular.Count==0)
        {
            cevaplanmamisSorular = sorular.ToList<QuizManager>();
        }

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;
        
        rastgeleSoruSec();
        


    }

     public void rastgeleSoruSec()
    {
        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(320f, .1f);
        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(-320f, .1f);
        int randomSoruIndex = Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];

        soruText.text = gecerliSoru.soru;
        if (gecerliSoru.dogrumu)
        {
            dogruCevapText.text = "DOĞRU CEVAPLADINIZ";
            yanlisCevapText.text = "YANLIŞ CEVAPLADINIZ";
        }
        else
        {
            yanlisCevapText.text = "DOĞRU CEVAPLADINIZ";
            dogruCevapText.text = "YANLIŞ CEVAPLADINIZ";
        }
        
    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru); 
        yield return new WaitForSeconds(1.3f);
        if (cevaplanmamisSorular.Count<=0) 
        {
            
            sonucPaneli.SetActive(true);
            sonucManager = FindObjectOfType<SonucManager>();
            sonucManager.SonuclariYazdir(dogruAdet,yanlisAdet,toplamPuan);

        }
        else
        {
            rastgeleSoruSec();
        }
    }


    public void dogruButonaBasildi()
    {
        if (gecerliSoru.dogrumu)
        {
            
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            
            yanlisAdet++;
        }

        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(1000f, 0.5f);

        StartCoroutine(SorularArasiBekleRoutine());
    }
    
    public void yanlisButonaBasildi()
    {
        if (!gecerliSoru.dogrumu)
        {
            
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }
        
        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(-1000f, 0.5f);

        StartCoroutine(SorularArasiBekleRoutine());
    }

    




}
