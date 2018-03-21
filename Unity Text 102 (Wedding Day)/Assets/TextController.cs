using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {bed_0, bed_1, bedroom, closet, bathroom, apartment, 
		car, end_0, end_1, end_2};
	private States myState;
	private int minutesLeft = 120;

	// Use this for initialization
	void Start () {

	text.text = "Today is your wedding day. Your alarm clock is blaring at you.";
	myState = States.bed_0;
			
	}
	
	// Update is called once per frame
	void Update () {

		print(myState); //this is for console.

		if (minutesLeft <= 0) {
			end_0();
		} else if 
			(myState == States.bed_0){
			bed_0();
		} else if 
			(myState == States.end_0){
			end_0();
		} else if 
			(myState == States.bed_1){
			bed_1();
		} else if 
			(myState == States.bedroom){
			bedroom();
		}

	}

	void bed_0 ()  //opening lines
	{

		text.text = "You wake abruptly, your alarm clock blaring at you. " +
		"You quickly remember that today is your wedding day! " +
		"You set your alarm to ring two hours before the ceremony begins, " +
		"so you have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"To get out of bed, press W.\n" +
		"To snooze for 10 minutes, press the space bar.\n" +
		"To turn off your alarm completely and go back to sleep, press S.";

		if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.bedroom;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.bed_1;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.end_0;
			minutesLeft -= 120;
		}
	}

	void bed_1 ()  //if snooze
	{

		text.text = "Your alarm rings again." +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"To get out of bed, press W.\n" +
		"To snooze for another 10 minutes, press the space bar.\n" +
		"To turn off your alarm completely and go back to sleep, press S.";

		if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.bedroom;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.bed_1;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.end_0;
			minutesLeft -= 120;
		}
	}

	void end_0 ()  //if you oversleep
	{
		text.text = "You drift back to sleep.\n\n" +
			"After what feels like only a minute, you are awakened by " +
			"a cacophony! Your phone is ringing, your cell is buzzing, " +
			"fists pound on your door, and your computer lets you know " +
			"You Have Mail." +
			"You slept through your wedding! Your intended has called it " +
			"off, and has sent relatives after you. You grab the " +
			"honeymoon tickets and flee. Better luck next time!\n\n" +
			"Press P to try again.";

		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.bed_0;
			minutesLeft = 120;
		}

	}

	void bedroom ()  //get out of bed
	{
		text.text = "You get out bed, excited to start the day. " +
		"There's nothing in your bedroom that you need right now. " +
		"From your bedroom, you can enter your closet, your bathroom, or " +
		"the rest of your apartment. " +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to enter the closet, B to enter the bathroom, or " +
		"A to enter the apartment.";

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.apartment;
			minutesLeft -= 1;
		}
	}

	//hmm, would better code put the substraction in the States if/else section?
	//you only have to write it once per state that way...

}
