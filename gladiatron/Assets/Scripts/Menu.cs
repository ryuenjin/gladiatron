using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void CarregarFase1()
    {
        SceneManager.LoadScene("FASE1");
    }
    public void CarregarFase2()
    {
        SceneManager.LoadScene("FASE2");
    }
    public void VoltaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SairAPK()
    {
        Application.Quit();
    }
}
