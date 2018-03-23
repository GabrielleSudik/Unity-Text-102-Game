using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {bed_0, bed_1, bedroom_0, bedroom_1, 
		closet_0, 
		bathroom_0, bathroom_1, bathroom_2, 
		shave_woman, shave_man, makeup_woman, makeup_man,
		sh_makeup_woman, sh_makeup_man, natural,
		apartment_0, 
		car_0, 
		end_0, end_1, end_2};
	private States myState;
	private int minutesLeft = 120;
	private bool woman = true;

	//hmm... better to lay out states for woman and man,
	//or lay out states but have man/woman be if statements within each method?

	// Use this for initialization
	void Start () {

	text.text = "Today is your wedding day. Your alarm clock is blaring at you.";
	myState = States.bed_0;
			
	}
	
	// Update is called once per frame
	void Update ()
	{

		print (myState); //this is for console.

		if (minutesLeft <= 0) {
			end_0 ();
			//you need to change this. time running out
			//doesn't always happen in your bed.
			//make one for oversleeping, one (or more) for other misses...
		} else if (myState == States.bed_0) {
			bed_0 ();
		} else if (myState == States.end_0) {
			end_0 ();
		} else if (myState == States.bed_1) {
			bed_1 ();
		} else if (myState == States.bedroom_0) {
			bedroom_0 ();
		} else if (myState == States.closet_0) {
			closet_0 ();
		} else if (myState == States.bathroom_0) {
			bathroom_0 ();
		} else if (myState == States.bathroom_1) {
			bathroom_1 ();
		} else if (myState == States.bathroom_2) {
			bathroom_2 ();
		} else if (myState == States.shave_woman) {
			shave_woman ();
		} else if (myState == States.shave_man) {
			shave_man ();
		} else if (myState == States.makeup_woman) {
			makeup_woman ();
		} else if (myState == States.makeup_man) {
			makeup_man ();
		} else if (myState == States.sh_makeup_woman) {
			sh_makeup_woman ();
		} else if (myState == States.sh_makeup_man) {
			sh_makeup_man ();
		} else if (myState == States.natural) {
			natural ();
		} else if (myState == States.bedroom_1) {
			bedroom_1 ();
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
			myState = States.bedroom_0;
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
			myState = States.bedroom_0;
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

	void bedroom_0 ()  //get out of bed
	{
		text.text = "You get out bed, excited to start the day. " +
		"There's not much in your bedroom that you need right now. " +
		"From your bedroom, you can enter your closet, your bathroom, or " +
		"the rest of your apartment. " +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to enter the closet, B to enter the bathroom, or " +
		"A to enter the apartment.";

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.apartment_0;
			minutesLeft -= 1;
		}
	}

	//hmm, would better code put the substraction in the States if/else section?
	//you only have to write it once per state that way...

	void closet_0 ()  //go to closet for the first time
	{
		text.text = "You open your closet and admire your wedding clothes. " +
		"But you decide to clean yourself up before getting dressed. " +
		"So you close the closet, for now. " +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to open the closet, B to use the bathroom, or " +
		"A to enter the apartment.";

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.apartment_0;
			minutesLeft -= 1;
		}
	}

	void bathroom_0 ()  //go to bathroom for the first time. selects player's sex.
	{
		text.text = "You step into the bathroom. After getting 8 hours " +
		"of sleep, you really need to pee!\n\n" +
		"Press W to sit down, or M to remain standing.";

		if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.bathroom_1;
			minutesLeft -= 1;
			woman = true;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.bathroom_1;
			minutesLeft -= 1;
			woman = false;
		} 
	}

	//think about whether you want two separate tracks for woman/man
	//or just one track, with if statements where appropriate

	void bathroom_1()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press S to shower, or B to take a bubble bath";

		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.bathroom_2;
			minutesLeft -= 5;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom_2;
			minutesLeft -= 30;
		} 
	}

	void bathroom_2 ()
	{
		text.text = "You're all clean, but the bathing took " +
		"a bit of time. You have " + minutesLeft + " minutes left " +
		"before the ceremony. Still, you want to look your best.\n\n" +
		"Press S to shave, M to put on make-up, B to do both, " +
		"or N to remain natural.";

		if (Input.GetKeyDown (KeyCode.S)) {
			if (woman) {
				myState = States.shave_woman;
				minutesLeft -= 5;
			} else {
				myState = States.shave_man;
				minutesLeft -= 5;
			}
		} 

		else if (Input.GetKeyDown(KeyCode.M)) {
			if (woman) {
				myState = States.makeup_woman;
				minutesLeft -= 10;
			} else {
				myState = States.makeup_man;
				minutesLeft -= 3;
			}
		} 

		else if (Input.GetKeyDown(KeyCode.B)) {
			if (woman) {
				myState = States.sh_makeup_woman;
				minutesLeft -= 15;
			} else {
				myState = States.sh_makeup_man;
				minutesLeft -= 8;
			}
		} 

		else if (Input.GetKeyDown(KeyCode.N)) {
			myState = States.natural;
			minutesLeft -= 1;
		} 
	}

	void shave_woman ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}
	}

	void shave_man ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void makeup_woman ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void makeup_man ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void sh_makeup_woman ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void sh_makeup_man ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void natural ()
	{
		text.text = "*Tinkling sound*\n\n" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}
	}

	void bedroom_1 ()
	{
		text.text = "You return to your bedroom. You're all " +
		"done with your abulutions. You have" + minutesLeft + 
		" minutes left before the ceremony. " +
		"What will you do next?\n\n" +
		"Press C to enter your closet. Press A to enter the " +
		"rest of your apartment.";

		//if statements here....
	}
}
