using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagment : MonoBehaviour {

    public event Action OnAxisPressed;
    public event Action OnJumpKeyPressed;
    public event Action OnSlideKeyPressed;
    public event Action NoAxisPressed;
    public event Action OnFireKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnJumpKeyPressed();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            OnSlideKeyPressed();

        if (Input.GetKey(KeyCode.B))
            OnFireKeyPressed();
        //if (Input.GetKey(KeyCode.Escape))
        //    SceneManager.LoadScene(4);
    }

    private void FixedUpdate() {
        if ( Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 )
            OnAxisPressed();
        else {
            NoAxisPressed();
            }
        }
    }





