using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {bed_0, bed_1, bedroom_0, bedroom_1, 
		closet_0, closet_1, 
		bathroom_0, bathroom_1, bathroom_2, 
		shave_woman, shave_man, makeup_woman, makeup_man,
		sh_makeup_woman, sh_makeup_man, natural,
		gown, tux,
		apartment_0, apartment_1, apartment_2, 
		breakfast_0, exit_0, video_0, video_1, 
		car_0, 
		end_0, end_1, end_2};
	private States myState;
	private int minutesLeft = 120;
	private bool woman = true;
	private bool hungry = true;

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
		} else if (myState == States.closet_1) {
			closet_1 ();
		} else if (myState == States.apartment_1) {
			apartment_1 ();
		} else if (myState == States.gown) {
			gown ();
		} else if (myState == States.tux) {
			tux ();
		}  else if (myState == States.apartment_2) {
			apartment_2 ();
		}  else if (myState == States.breakfast_0) {
			breakfast_0 ();
		}  else if (myState == States.exit_0) {
			exit_0 ();
		}  else if (myState == States.video_0) {
			video_0 ();
		} else if (myState == States.video_1) {
			video_1 ();
		}
	}


	//breakfast_0, exit_0, video_0,
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
		//"You have " + minutesLeft + " minutes until the ceremony. " +
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

	void apartment_0 ()
	{
		text.text = "You open your bedroom door to step into your  " +
		"main living area. But since you're already near your bathroom " +
		"and wedding clothes, you decide to get ready for the day first, " +
		"and you remain in your bedroom." +
		//"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to open the closet, or B to use the bathroom.";

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom_0;
			minutesLeft -= 1;
		} 
	}

	//think about whether you want two separate tracks for woman/man
	//or just one track, with if statements where appropriate

	void bathroom_1()
	{
		text.text = "*Tinkling sound*\t" +
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
				minutesLeft -= 8;
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
				minutesLeft -= 11;
			}
		} 

		else if (Input.GetKeyDown(KeyCode.N)) {
			myState = States.natural;
			minutesLeft -= 1;
		} 
	}

	void shave_woman ()
	{
		text.text = "You lather up all the areas you typially " +
		"shave and you get to work.\n\n" +
		"There now... All smooth and shiny!\n\n" +
		"You decide you're done gromming for today." +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}
	}

	void shave_man ()
	{
		text.text = "You use your electric razor for some " +
		"touch-ups here and there, and lather up your face " +
		"for a very close shave. You take your time, as you " +
		"don't want to walk down the aisle with toilet paper on " +
		"your face. The effort pays off, and you look very clean-cut.\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void makeup_woman ()
	{
		text.text = "You start with foundation, then some concealer. " +
		"You add some blush, some eyeshadow, and slightly darken your " +
		"brows with a pencil. You finish off with some mascara and lipstick " +
		"then give your hair a quick style. You look beautiful!\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void makeup_man ()
	{
		text.text = "Yeah, you're a dude, but you know that " +
		"a bit of color makes you look even hotter than usual. " +
		"So you dab on tiny bits of concealer to even out your skin " +
		"tone, then finish up with some guyliner. Rawr!\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void sh_makeup_woman ()
	{
		text.text = "You spend a few minutes shaving all the usual " +
		"places until your skin is smooth and shiney. You spend a few more " +
		"minutes applying makeup and styling your hair. The effort " +
		"pays off -- you are clean-cut and beautiful!\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void sh_makeup_man ()
	{
		text.text = "The metrosexual look works well on you, so " +
		"you first use your electric razor to clean up around the edges. " +
		"You then carefully use a blade to keep the stubble from showing. " +
		"Finally, you dab on just a bit of concealer and a trace of " +
		"guyliner. Queer Eye would approve!\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}

	}

	void natural ()
	{
		text.text = "You decide -- quite correctly -- that the " +
		"whole-body natural look works best for you. In addition " +
		"to signalling your earth-loving nature, you save a lot of money in " +
		"cosmetics, not to mention grooming time.\n\n" +
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
		"Press C to open your closet. Press A to enter the " +
		"rest of your apartment.";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_1;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.apartment_1;
			minutesLeft -= 1;
		}
	}

	void closet_1 ()
	{
		if (woman) {
			myState = States.gown;
			minutesLeft -= 10;
		} else {
			myState = States.tux;
			minutesLeft -= 10;
		} 
	}

	void gown(){
		text.text= "You open your closet door and admire a beautiful " +
		"white gown, along with shoes, gloves, a veil and matching beaded " +
		"purse. You dress as quickly as possible, but there are a lot of " +
		"buttons, so it takes a few minutes. Finally, you are dressed!\n\n" +
		"Press A to move to the main living area of your apartment.";	

		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.apartment_2;
			minutesLeft -= 10;
		}		
	}

	void tux ()
	{
		text.text = "You open your closet door and remove a stylish tux, " +
		"along with all of its accessories. You spend several minutes " +
		"getting dressed and finish your ensemble with a jaunty pocket " +
		"handkerchief, in your wedding's theme color (which is 'white').\n\n" +
		"Press A to move to the main living area of your apartment.";	

		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.apartment_2;
			minutesLeft -= 10;
		}
	}

	void apartment_1 ()
	{
		text.text = "You glance down, realize you're still naked, " +
		"and decide to dress before doing anything else.\n\n" +
		"Press C to look inside your closet instead.";

		if (Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_1;
			minutesLeft -= 1;
		}
	}

	//consider an option to let people leave the house naked...

	void apartment_2 ()
	{
		text.text = "You step into the main area of your apartment, a " +
		"combined living-dining-kitchen great room. While it IS a great " +
		"room, you'll be giving it up to move into your spouse's house " +
		"after the honeymoon. You worry you'll miss your solitude...\n\n" +
		"You have " + minutesLeft+ " minutes left before the ceremony.\n\n" +
		"To make yourself a quick breakfast, press K. To relax with some " +
		"videogame time, press V. To head out the door, press E.";

		if (Input.GetKeyDown(KeyCode.K)){
			myState = States.breakfast_0;
			hungry = false;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_0;
			minutesLeft -= 15;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void breakfast_0()
	{
		text.text = "You decide to put a little food in your belly before " +
		"leaving. You make a shot of espresso and heat up a Pop-Tart. " +
		"It's just enough food to give you energy but not slow you down.\n\n" +
		"To relax with some " +
		"videogame time, press V. To head out the door, press E.";

		if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_0;
			minutesLeft -= 15;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void video_0()
	{
		text.text = "Knowing you might not get to enjoy your favorite hobby " +
		"for a few weeks, you load up a quick game of Civilization V. Next thing you " +
		"know, 15 minutes have passed! You have " + minutesLeft + " minutes " +
		"left until the ceremony.\n\n" +
		"If you've had your gaming fix, press E to head out the door. " +
		"If you want to play just one more turn, press V.";

		if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_1;
			minutesLeft -= 5;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void video_1() //just 5 more minutes lol
	{
		text.text = "You tell yourself 'just one more turn'... " +
		"But as you know, one more turn takes 5 minutes. " +
		"You have " + minutesLeft + " minutes " +
		"left until the ceremony.\n\n" +
		"If you've had your gaming fix, press E to head out the door. " +
		"If you want to play just one more turn -- seriously, only one " +
		"more turn, you promise -- press V.";

		if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_1;
			minutesLeft -= 5;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void exit_0()
	{
		text.text = "You grab your already-packed honeymoon bag, step outside, " +
		"and lock your apartment door. You could drive your car to the church, or " +
		"catch the bus. The car is probably quicker, but the bus will be more " +
		"relaxing. You have " + minutesLeft + " minutes left until the ceremony.\n\n" +
		"Press C to drive your car, or press B to ride the bus.";

		//need if statements
		//don't forget time
		//don't forget dealing with hunger.
	}
}
