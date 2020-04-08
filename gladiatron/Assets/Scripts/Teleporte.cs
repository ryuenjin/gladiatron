using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Teleporte : MonoBehaviour
{

    public Transform[] destinos;
    public AudioClip audioTeleporte;
    [Space(10)]
    public bool destruirAoColidir = false;
    AudioSource emissorDeSom;
    bool rotinaIniciada = false;

    void Awake()
    {
        emissorDeSom = GetComponent<AudioSource>();
        emissorDeSom.playOnAwake = false;
        emissorDeSom.loop = false;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (destinos.Length > 0 && !rotinaIniciada)
        {
            int destino = Random.Range(0, destinos.Length);
            if (destinos[destino])
            {
                other.transform.position = destinos[destino].position;
                other.transform.rotation = destinos[destino].rotation;
                if (destruirAoColidir)
                {
                    StartCoroutine("EsperarParaDestruir");
                }
            }
            if (audioTeleporte)
            {
                emissorDeSom.clip = audioTeleporte;
                emissorDeSom.PlayOneShot(emissorDeSom.clip);
            }
        }
    }

    IEnumerator EsperarParaDestruir()
    {
        rotinaIniciada = true;
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = false;
        }
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}