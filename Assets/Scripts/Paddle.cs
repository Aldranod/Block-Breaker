using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration parameters

    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // mousePosInUnits - pozycja myszy na osi x podzielona przez szerokośc ekranu daje zakres 0 do 1, pomnozone przez szerokośc kamery (jednostki unit)
        // Vector2 to koordynaty obiektu (x,y), jest to tez typ zmiennej w Unity, słowo kluczowe new oznacza nową instancje zadeklarowanej zmiennej
        // transform.position - tak dostajemy sie do komponentu danego obiektu i updatujemy go w kazdej klatce animacji
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
