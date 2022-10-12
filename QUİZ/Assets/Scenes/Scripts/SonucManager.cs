using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField] private Text dogruSayısıText, yanlisSayisiText, toplamPuanText;
    [SerializeField] private GameObject yildiz1, yildiz2, yildiz3;

    private GameManager gameManager;


    public void SonuclariYazdir(int dogruAdet,int yanlisAdet,int puan)
    {
        dogruSayısıText.text = dogruAdet.ToString();
        yanlisSayisiText.text = yanlisAdet.ToString();
        toplamPuanText.text = puan.ToString();
        
        yildiz1.SetActive(false);
        yildiz2.SetActive(false);
        yildiz3.SetActive(false);

        if (dogruAdet==1)
        {
            yildiz1.SetActive(true);
        }else if (dogruAdet==2)
        {
            yildiz1.SetActive(true);
            yildiz2.SetActive(true);
        }
        else
        {
            yildiz1.SetActive(true);
            yildiz2.SetActive(true);
            yildiz3.SetActive(true);
        }
        
        
        
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene("QuizGame");
    }

}
