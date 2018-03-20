using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {bed, bedroom, hall, bathroom, kitchen, car, end_0, end_1, end_2};
	private States myState;
	private int minutesLeft = 120;

	// Use this for initialization
	void Start () {

	text.text = "Today is your wedding day. Your alarm clock is blaring at you.";
	myState = States.bed;
			
	}
	
	// Update is called once per frame
	void Update () {

		if(myState == States.bed){
			bed();
		}

	}

	void bed ()
	{

		text.text = "You wake abruptly, your alarm clock blaring at you. " +
		"You quickly remember that today is your wedding day! " +
		"You set your alarm to ring two hours before the ceremony begins, " +
		"so you have " + minutesLeft + " until the ceremony. " +
		"What will you do now?\n\n" +
		"To get up right away, press W.\n" +
		"To snooze for 10 minutes, press the space bar.\n" +
		"To turn off your alarm completely and go back to sleep, press S.";

		if (Input.GetKeyDown (KeyCode.W)) {
			myState = States.bedroom;
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			myState = States.bed;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.end_0;
			minutesLeft -= 120;
		}
	}
}
