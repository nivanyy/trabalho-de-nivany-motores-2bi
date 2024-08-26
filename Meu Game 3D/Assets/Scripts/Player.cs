using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 1;
    private bool noChao;


    public Rigidbody rb;

    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (! noChao && collision.gameObject.tag == "Chão")
        {
            noChao = true;
        }
    }

void Update()
    {
        Debug.Log("update");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x, 0, y);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }




    if (transform.position.y <= -10)
        {
            //jogador caiu 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
}
}
