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
    public void CarregarOPCOES()
    {
        SceneManager.LoadScene("OPCOES");
    }
    public void CarregarFase1()
    {
        SceneManager.LoadScene("FASE1");
    }
    public void CarregarPLAYGROUND1()
    {
        SceneManager.LoadScene("PLAYGROUND1");
    }
    public void CarregarPLAYGROUND2()
    {
        SceneManager.LoadScene("PLAYGROUND2");
    }
    public void CarregarPLAYGROUND3()
    {
        SceneManager.LoadScene("PLAYGROUND3");
    }
    public void CarregarPLAYGROUND4()
    {
        SceneManager.LoadScene("PLAYGROUND4");
    }
    public void CarregarTESTE()
    {
        SceneManager.LoadScene("TESTE");
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
