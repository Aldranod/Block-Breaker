using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration parameters

    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached references
    GameSession theGameSession;
    Ball theBall;

    // Use this for initialization
    void Start() {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();

    }

    // Update is called once per frame
    void Update() {
        // GetxPos - pozycja myszy na osi x podzielona przez szerokośc ekranu daje zakres 0 do 1, pomnozone przez szerokośc kamery (jednostki unit) 
        // lub jesli autoplay to zwraca pozycje ball na osi x
        // Vector2 to koordynaty obiektu (x,y), jest to tez typ zmiennej w Unity, słowo kluczowe new oznacza nową instancje zadeklarowanej zmiennej
        // transform.position - tak dostajemy sie do komponentu danego obiektu i updatujemy go w kazdej klatce animacji
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
