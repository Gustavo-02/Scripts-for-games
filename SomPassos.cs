using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPassos : MonoBehaviour {
    private float tempoUltimaJogada = -0.8f;
    private float tempoEspera = 0.8f;
    
    // Variáveis passos
    RaycastHit hit;
    public AudioClip normal, madeira, grama, agua;
    public AudioSource emissor;


    private void Update() 
    {
        ReproduzirSomPasso();

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            tempoEspera = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            tempoEspera = 0.8f;
        }
    }

    private void ReproduzirSomPasso() {
        if (Time.time - tempoUltimaJogada >= tempoEspera && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))) {
            if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
                switch (hit.collider.gameObject.tag) {
                    case "Madeira":
                        PlayFootStepSound(madeira);
                        break;
                    case "Grama":
                        PlayFootStepSound(grama);
                        break;
                    case "Agua":
                        PlayFootStepSound(agua);
                        break;
                    default:
                        PlayFootStepSound(normal);
                        break;
                }
            }
        }
    }

    private void PlayFootStepSound(AudioClip audio) {
        emissor.pitch = Random.Range(0.8f, 1f);
        emissor.PlayOneShot(audio);
        tempoUltimaJogada = Time.time;
    }
}
