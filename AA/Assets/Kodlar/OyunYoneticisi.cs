using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;





    void Start() {

        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if (kacTaneKucukCemberOlsun<2) {

            bir.text = kacTaneKucukCemberOlsun + "";

        }

        else if (kacTaneKucukCemberOlsun<3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1)+ "";
        }
        else {
    

            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text =(kacTaneKucukCemberOlsun - 1)+ "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";

        }
    }

    public void KucukCemberlerdeTextGosterme()
    {
        kacTaneKucukCemberOlsun--;

        if (kacTaneKucukCemberOlsun < 2)
        {

            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";

        }

        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";

        }
        else
        {


            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";

        }
        if (kacTaneKucukCemberOlsun==0)
        {
            StartCoroutine(yeniLevel());


        }
    }

    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }



    public void OyunBitti() {

        StartCoroutine(CagrılanMetot());

    }

    IEnumerator CagrılanMetot() {

        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;

        yield return new WaitForSeconds(1); 
        SceneManager.LoadScene("AnaMenu");

    }

}
