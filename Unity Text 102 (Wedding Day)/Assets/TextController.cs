using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States //this is for each location and status
	{
		bed_0, bed_1, 
		bedroom_0, bedroom_1, 
		closet_0, closet_1, 
		bathroom_0, bathroom_1, bathroom_2, 
		shave_woman, shave_man, makeup_woman, makeup_man,
		sh_makeup_woman, sh_makeup_man, natural,
		gown, tux,
		apartment_0, apartment_1, apartment_2, 
		breakfast_0, exit_0, video_0, video_1, 
		car_0, bus_0, bus_1,
		decide_church, decide_airport, airport_end, 
		church_0, church_1, church_2, church_3,
		donut_0, donut_1, donut_2,
		order_0, order_1, 
		cute_man_0, cute_woman_0,
		end_0, end_1, end_2, end_3};

	private enum Locations //this is general location for running out of time endings
	{
		in_bed, in_apartment, out_apartment, on_date};

	private States myState;
	private Locations myLocation;
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

		//make sure the first if statements are about running out of time, and in the right place
		//also, can you add a way to check how much time is left whenever? or to exit whenever?
		//maybe make two methods, but the GetKeyDown goes in Update?

		if (minutesLeft <= 0 && (myLocation == Locations.in_bed)) {
			end_0 ();
		} else if (minutesLeft <= 0 && myLocation == Locations.in_apartment) {
			end_1 ();
		} else if (minutesLeft <= 0 && myLocation == Locations.out_apartment) {
			end_2 ();
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
		} else if (myState == States.apartment_2) {
			apartment_2 ();
		} else if (myState == States.breakfast_0) {
			breakfast_0 ();
		} else if (myState == States.exit_0) {
			exit_0 ();
		} else if (myState == States.video_0) {
			video_0 ();
		} else if (myState == States.video_1) {
			video_1 ();
		} else if (myState == States.end_1) {
			end_1 ();
		} else if (myState == States.car_0) {
			car_0 ();
		} else if (myState == States.bus_0) {
			bus_0 ();
		} else if (myState == States.end_2) {
			end_2 ();
		} else if (myState == States.bus_1) {
			bus_1 ();
		} else if (myState == States.church_0) {
			church_0 ();
		} else if (myState == States.church_1) {
			church_1 ();
		} else if (myState == States.donut_0) {
			donut_0 ();
		} else if (myState == States.donut_1) {
			donut_1 ();
		} else if (myState == States.donut_2) {
			donut_2 ();
		} else if (myState == States.decide_church) {
			decide_church ();
		} else if (myState == States.decide_airport) {
			decide_airport ();
		} else if (myState == States.order_0) {
			order_0 ();
		} else if (myState == States.order_1) {
			order_1 ();
		} else if (myState == States.cute_man_0) {
			cute_man_0 ();
		} else if (myState == States.cute_woman_0) {
			cute_woman_0 ();
		} else if (myState == States.airport_end) {
			airport_end ();
		} else if (myState == States.end_3) {
			end_3 ();
		} else if (myState == States.church_2) {
			church_2 ();
		} else if (myState == States.church_3) {
			church_3 ();
		}
	}


	//breakfast_0, exit_0, video_0,
	void bed_0 ()  //opening lines
	{
		myLocation = Locations.in_bed;

		text.text = "You wake abruptly, your alarm clock blaring at you. " +
		"You quickly remember that today is your wedding day! " +
		"You set your alarm to ring two hours before the ceremony begins, " +
		"so you have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press W to get out of bed.\n" +
		"Press the space bar to snooze for 10 minutes.\n" +
		"Press S to turn off your alarm completely and go back to sleep.";

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
		myLocation = Locations.in_bed;

		text.text = "Your alarm rings again." +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press W to get out of bed.\n" +
		"Press the space bar to snooze for another 10 minutes.\n" +
			"Press S to turn off your alarm completely and go back to sleep.";

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
			minutesLeft = 120;
			myState = States.bed_0;
		}

	}

	void bedroom_0 ()  //get out of bed
	{
		myLocation = Locations.in_apartment;

		text.text = "You get out bed, excited to start the day. " +
		"There's not much in your bedroom that you need right now. " +
		"From your bedroom, you can enter your closet, your bathroom, or " +
		"the rest of your apartment. " +
		"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to enter the closet.\nPress B to enter the bathroom.\n" +
		"Press A to enter the apartment.";

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
		myLocation = Locations.in_apartment;

		text.text = "You open your closet and admire your wedding clothes. " +
		"But you decide to clean yourself up before getting dressed. " +
		"So you close the closet, for now. " +
		//"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press B to use the bathroom.\n" +
		"Press A to enter the apartment.";

		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.bathroom_0;
			minutesLeft -= 1;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.apartment_0;
			minutesLeft -= 1;
		}
	}

	void bathroom_0 ()  //go to bathroom for the first time. selects player's sex.
	{
		myLocation = Locations.in_apartment;

		text.text = "You step into the bathroom. After getting 8 hours " +
		"of sleep, you really need to pee!\n\n" +
		"Press W to sit down.\nPress M to remain standing.";

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
		myLocation = Locations.in_apartment;

		text.text = "You open your bedroom door to step into your  " +
		"main living area. But since you're already near your bathroom " +
		"and wedding clothes, you decide to get ready for the day first, " +
		"and you remain in your bedroom." +
		//"You have " + minutesLeft + " minutes until the ceremony. " +
		"What will you do now?\n\n" +
		"Press C to open the closet.\nPress B to use the bathroom.";

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
		myLocation = Locations.in_apartment;

		text.text = "*Tinkling sound*\t" +
		"*Flushing toilet sound*\n\n" +
		"Ah, that's better! Time to wash up. Do you want to take " +
		"a quick shower or a long bubble bath?\n\n" +
		"Press S to shower.\nPress B to take a bubble bath";

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
		myLocation = Locations.in_apartment;

		text.text = "You're all clean, but the bathing took " +
		"a bit of time. You have " + minutesLeft + " minutes left " +
		"before the ceremony. Still, you want to look your best.\n\n" +
		"Press S to shave.\nPress M to put on make-up.\nPress B to do both.\n" +
		"Press N to remain natural.";

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
		myLocation = Locations.in_apartment;

		text.text = "You lather up all the areas you typially " +
		"shave and you get to work.\n\n" +
		"There now... All smooth and shiny!\n\n" +
		"You decide you're done gromming for today.\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}
	}

	void shave_man ()
	{
		myLocation = Locations.in_apartment;

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
		myLocation = Locations.in_apartment;

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
		myLocation = Locations.in_apartment;

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
		myLocation = Locations.in_apartment;

		text.text = "You spend a few minutes shaving all the usual " +
		"places until your skin is smooth and shiny. You spend a few more " +
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
		myLocation = Locations.in_apartment;

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
		myLocation = Locations.in_apartment;

		text.text = "You decide that the " +
		"whole-body natural look works best for you. In addition " +
		"to signalling your earth-loving nature, you save a lot of money in " +
		"cosmetics, not to mention grooming time.\n\n" +
		"Press B to return to your bedroom.";

		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.bedroom_1;
			minutesLeft -= 1;
		}
	}

	void bedroom_1 () //bedroom after done with bathroom
	{
		myLocation = Locations.in_apartment;

		text.text = "You return to your bedroom. You're all " +
		"done with your abulutions. You have " + minutesLeft + 
		" minutes left before the ceremony.\n\n " +
		"Press C to open your closet.\nPress A to move to the " +
		"main area of your apartment.";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_1;
			minutesLeft -= 10;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.apartment_1;
			minutesLeft -= 1;
		}
	}

	void closet_1 () //closet for both genders
	{
		myLocation = Locations.in_apartment;

		if (woman) {
			myState = States.gown;
			minutesLeft -= 10;
		} else {
			myState = States.tux;
			minutesLeft -= 10;
		} 
	}

	void gown() //closet for woman
	{
		myLocation = Locations.in_apartment;

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

	void tux ()  //closet for man
	{
		myLocation = Locations.in_apartment;

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

	void apartment_1 () //apartment when you are naked
	{
		myLocation = Locations.in_apartment;

		text.text = "You glance down, realize you're still naked, " +
		"and decide to dress before doing anything else.\n\n" +
		"Press C to look inside your closet.";

		if (Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_1;
			minutesLeft -= 1;
		}
	}

	//consider an option to let people leave the house naked...

	void apartment_2 () //apartment when dressed
	{
		myLocation = Locations.in_apartment;

		text.text = "You step into the main area of your apartment, a " +
		"combined living-dining-kitchen great room. " +
		"You'll be giving it up to move into your spouse's house " +
		"after the honeymoon. You worry you'll miss your solitude... " +
		"You have " + minutesLeft+ " minutes left before the ceremony.\n\n" +
		"Press K to make yourself a quick breakfast.\nPress V to relax with a " +
		"videogame.\nPress E to head out the door.";

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

	void breakfast_0() //breakfast in apartment (makes hunger = false)
	{
		myLocation = Locations.in_apartment;

		text.text = "You decide to put a little food in your belly before " +
		"leaving. You make a shot of espresso and heat up a Pop-Tart. " +
		"It's just enough food to give you energy but not slow you down. You " +
		"have " + minutesLeft + " minutes left until the ceremony.\n\n" +
		"Press V to relax with a " +
		"videogame.\nPress E to head out the door.";

		if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_0;
			minutesLeft -= 15;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void video_0() //play videogame first time
	{
		myLocation = Locations.in_apartment;

		text.text = "Knowing you might not get to enjoy your favorite hobby " +
		"for a few weeks, you load up a quick game of Civilization V. Next thing you " +
		"know, 15 minutes have passed! You have " + minutesLeft + " minutes " +
		"left until the ceremony.\n\n" +
		"Press E if you're done gaming and are ready to leave.\n" +
		"Press V if you want to play Just. One. More. Turn.";

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
		myLocation = Locations.in_apartment;

		text.text = "You tell yourself 'just one more turn'... " +
		"But as you know, one more turn takes 5 minutes. " +
		"You have " + minutesLeft + " minutes " +
		"left until the ceremony.\n\n" +
		"Press E if you're done gaming and are ready to leave.\n" +
		"Press V if you want to play Just. One. More. Turn. ... Again ... " +
		"Seriously. Only one more turn, you promise.";

		if (Input.GetKeyDown(KeyCode.V)){
			myState = States.video_1;
			minutesLeft -= 5;
		} else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.exit_0;
			minutesLeft -= 1;
		}
	}

	void exit_0()  //leaving the apartment (happens once)
	{
		myLocation = Locations.out_apartment;

		text.text = "You grab your already-packed honeymoon bag, step outside, " +
		"and lock your apartment door. You could drive your car to the church, or " +
		"catch the bus. The car is probably quicker, but the bus will be more " +
		"relaxing. You have " + minutesLeft + " minutes left until the ceremony.\n\n" +
		"Press C to drive your car.\nPress B to take the bus.";

		if (Input.GetKeyDown(KeyCode.C)){
			myState = States.car_0;
			minutesLeft -= 5;
		} else if (Input.GetKeyDown(KeyCode.B)){
			myState = States.bus_0;
			minutesLeft -= 15;
		}

		//don't forget time. I THINK IT IS HANDLED WITH THE LOCATIONS ENUM.
		//don't forget dealing with hunger.
	}


	void end_1() //missing the wedding by dawdling around the apartment

	{
		text.text = "You hear an unexpected banging at the door, followed by " +
		"loud and angry voices.\n\n" +
		"OH MY GOD IS THAT THE TIME!?!?!\n\n" +
		"You missed the ceremony because of all " +
		"your dawdling. You grab your honeymoon tickets, climb out a window, and run away.\n\n" +
		"Maybe you'll find true love next time.\nPress P to replay.";

		if (Input.GetKeyDown(KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void end_2() //missing the wedding by running out of time away from home
	{
		myLocation = Locations.out_apartment;

		text.text = "All of a sudden something is bothering you, like you " +
		"forgot something but can't remember what. Hmm... what " +
		"is it?\n\n" +
		"OH MY GOD IS THAT THE TIME!?!?!\n\n" +
		"You missed the ceremony because of all your dawdling, so you decide " +
		"to continue to the airport. Alone. And lonely. " +
		"Maybe you'll find true love next time.\n\nPress P to replay.";

		if (Input.GetKeyDown(KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void car_0 ()  //first time getting in car
	{
		myLocation = Locations.out_apartment;

		if (hungry) {
			text.text = "You get in the car, and pull out of the driveway. " +
			"The church is only a few minutes away. As soon as you turn the " +
			"first corner, though, your stomach growls with hunger. You have " +
			minutesLeft + " minutes left until the ceremony.\n\n" +
			"Press D to stop at a donut shop for breakfast.\nPress C to continue " +
			"to the church -- you're running late!";
		} else {
			text.text = "You get in the car, and pull out of the driveway. " +
			"The church is only a few minutes away, and you make it without " +
			"incident.\n\n" +
			"Press C to park your car and enter the church.";
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			minutesLeft -= 5;
			myState = States.church_0;

		} else if (Input.GetKeyDown(KeyCode.D)){
			minutesLeft -= 1;
			myState = States.donut_0;
		}
	}

	void bus_0 ()  //first time getting on bus
	{
		myLocation = Locations.out_apartment;

		if (woman) {
			text.text = "After a five minute wait, the bus arrives. " +
			"The bus driver looks you up and down. " + 
			"'Well, hellooooo, Miss Robinson! It's a fine day to run " +
			"away from a wedding,' he winks. You smile, then make your way to " +
			"the back seat.\n\n" +
			"As the bus rides through town, you think about what the driver said...\n\n" +
			"Press C to continue that thought...";
		}
		else {
			text.text = "After a five minute wait, the bus arrives. " +
			"The bus driver looks you up and down. " + 
			"'Well it looks like James Bond just got " +
			"on my bus, and is off to save the world and seduce the beautiful " + 
			"people,' he winks. You smile, then make your way to " +
			"the back seat.\n\n" +
			"As the bus rides through town, you think about what the driver said...\n\n" +
			"Press C to continue that thought...";

		}

		if (Input.GetKeyDown(KeyCode.C)) {
			minutesLeft -= 1;
			myState = States.bus_1; //goes to decision about staying on the bus
		}	
	}

	void bus_1 () //decision about staying on the bus
	{
		text.text = "On one hand, you love your intended and think sharing a life " +
		"with another person will be comfortable and comforting. On the other hand, " +
		"the mere reminder that there is a life of freedom out there " +
		"has got you riled up. You decide to:\n\n" +
		"Press C to continue to the church.\n" +
		"Press A to head directly to the airport.";

		if (Input.GetKeyDown(KeyCode.C)) {
			minutesLeft -= 10;
			myState = States.decide_church;

			//don't forget a hungry bit here if you head to the church
			//ignore it if you head to the airport
		}
		else if (Input.GetKeyDown(KeyCode.A)){
			myState = States.decide_airport;
		}
	}

	//woman! you've forgotten to add the minutes countdown

	void church_0 () //use for all debarkations from car or bus
	{
		text.text = "You exit the vehicle at the church. There are lots of cars " +
		"here but no one else. Looks like everyone else is inside. You straighten " +
		"your clothes one last time, then step inside the front door, ready " +
		"to say 'I do!'\n\n" +
		"Press C to continue.";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.church_1;
		}
	}

	void donut_0 ()  //arrive donut shop
	{
		myLocation = Locations.out_apartment;

		text.text = "You pull into the donut shop parking lot, park, " +
		"then enter the store. As you wait in the middle of three lines, you " +
		"notice a good-looking man to your right, and a good-looking woman " +
		"to your left. Both look you up and down, and smile. You have " +
		minutesLeft + " minutes left until the ceremony.\n\n" +
		"Press M to focus on the shop menu.\nPress R to smile back at the man.\n" +
		"Press L to smile back at the woman.";

		if (Input.GetKeyDown (KeyCode.M)) {
			minutesLeft -= 3;
			myState = States.order_0;

		} else if (Input.GetKeyDown(KeyCode.R)){
			minutesLeft -= 3;
			myState = States.cute_man_0;
		} else if (Input.GetKeyDown(KeyCode.L)){
			minutesLeft -= 3;
			myState = States.cute_woman_0;
		}
	}

	void church_1 () //enter the church
	{
		if (hungry == true) //if hungry, you faint
		{
			text.text = "You climb the stairs and your stomach growls. " +
			"LOUDLY. D'oh! You forgot to eat. Well, too late now! You " +
			"step into the church. As you lay eyes on all the guests, your " +
			"head starts to spin. Your stomach rumbles again. The room goes " +
			"dark...\n\n" +
			"Press C to continue.";

			if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.church_2;
			}

		} else //if not hungry, proceed to ceremony.
		{
			text.text = "You climb the stairs, pass through the vestibule, " +
			"and step into the church. A sea of faces turns towards you, but " +
			"you have eyes only for your intended. As music plays, you walk down " +
			"the aisle. You clasp your intended's hand, smile, and turn towards " +
			"the officiant, ready to say 'I do!'\n\n" +
			"Press C to continue";

			if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.end_3;
			}

		}

	}

	void church_2 () //you fainted in church
	{
		text.text = "You open your eyes, flat on your back. " +
		"You find your intended staring " +
		"you in the face. Beyond that are several relatives, looking " +
		"concerned. Beyond that are several naked churubs, gazing down from " +
		"the ceiling.\n" +
		"How embarrassing... you fainted from hunger at your own wedding!\n\n" + 
		"Press P to pick up your dignity and get on with it already.";

		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.church_3;
		}
	}

	void church_3() //ceremony after you fainted
	{
		text.text = "You get up, brush yourself off, and clasp your intended's " +
			"hand. You receive a few pats on the back, then everyone else " +
			"returns to their seats. As music plays, you walk down " +
			"the aisle, hand in hand with your intended. You approach " +
			"the officiant, ready to say 'I do!'\n\n" +
			"Press C to continue";

			if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.end_3;
			}
	}



	void end_3 () //you get married!

	{
		text.text = "Congratulations! You are married.\n\n" + 
		"Press P to play again.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}



	void decide_church () //on the bus if you decide to get married
	{
		myLocation = Locations.out_apartment;

		text.text = "You briefly daydream about the bus driver's " + 
		"comments, knowing that a life of singlehood and adventure " +
		"could be fulfilling. But you know marrying your true love will " +
		"be even more so, so you sit up and watch for the church, getting " +
		"off at the proper stop.\n\n" +
		"Press C to continue to the church.";

		if (Input.GetKeyDown (KeyCode.C)) {
			minutesLeft -= 5;
			myState = States.church_0;
		}
	}

	void decide_airport () //on the bus if you decide not to get married
	{
		text.text = "From your seat you yell, 'Hey driver, does this bus " +
		"go to the airport?'\n\n" +
		"'Sure does,' he yells back, with a grin.\n\n" +
		"You settle back into your seat, watching the church go past...\n\n" +
		"Press C to continue...";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.airport_end;
		}
	}

	void airport_end () //ending if you were on the bus and decided not to marry
	{
		text.text = "You continue to watch the town on your " +
		"way to the airport, minus the person you had planned to marry. " +
		"You're not positive you're doing the right thing, but you do " +
		"know that freedom from commitment can bring contentment, so you " +
		"decide to worry about the future when you reach your next destination... " +
		"wherever that may be.\n\n" +
		"Press P to play again.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void order_0 () //in line at the donut shop
	//maybe revise to cover all three option in line at the shop (if you don't say yes to a date)
	{
		myLocation = Locations.out_apartment;

		text.text = "You notice some fellow customers checking out " +
		"your wedding clothes. You don't have time to chit-chat, though. " +
		"You've got donuts to eat and a church to get to!\n\n" +
		"Press D to order a couple donuts.";

		if (Input.GetKeyDown (KeyCode.D)) {
			minutesLeft -= 1;
			myState = States.order_1;
		}
	}

	void order_1 () //donut shop if you ignore other customers
	{
		myLocation = Locations.out_apartment;

		text.text = "You order two of your favorite donuts and an espresso. " +
		"It's enough to satisfy your hunger and give you energy without " +
		"slowing you down. You head back to your car.\n\n" +
		"Press C to continue to the church.";

		//update:
		if (Input.GetKeyDown (KeyCode.C)) {
			minutesLeft -= 5;
			hungry = false;
			myState = States.church_0;
		}
	}

	void cute_man_0() //donut shop if you chat with the man
	{
		myLocation = Locations.out_apartment; //maybe make man or woman Plan B, 
		//instaed of "go to airpot"? YES. if you say yes.

		text.text = "You turn to get a good look at the man. He's not " +
		"just good-looking, he's gorgeous. You return his smile, and his gets " +
		"bigger. 'I can see you're on your way someplace special,' he says, " +
		"'but care to join me for a donut?'\n\n" +
		"Press Y to say yes.\nPress N to politely turn him down.";

		if (Input.GetKeyDown (KeyCode.Y)) {
			minutesLeft -= 3;
			myState = States.donut_1;
		}
		else if (Input.GetKeyDown (KeyCode.N)) {
			minutesLeft -= 3;
			myState = States.donut_2;
		}
	}

	void cute_woman_0 () //donut shop if you chat with the woman
	{
		myLocation = Locations.out_apartment; //maybe make man or woman Plan B, 
		//instaed of "go to airpot"? YES if you say yes

		text.text = "You turn to smile back at the woman and notice " +
		"she is quite pretty. 'Don't you look nice,' she says. 'Any chance " +
		"you'd like to join me for a donut before you head off?'\n\n" +
		"Press Y to say yes.\nPress N to politely turn her down.";

		if (Input.GetKeyDown (KeyCode.Y)) {
			minutesLeft -= 3;
			myState = States.donut_1;
		}
		else if (Input.GetKeyDown (KeyCode.N)) {
			minutesLeft -= 3;
			myState = States.donut_2;
		}
	}

	void donut_1 () //if you accept the date (yes)
	{
		text.text = "Greatly flattered, you accept the offer. You both " +
		"order some donuts and espresso, then sit at a quiet table. " +
		"For the next 20 minutes, you completely forget what you're " +
		"supposed to be doing today, you're so taken with the company.\n\n" +
		"Press C to keep chatting.";

		//update:
		if (Input.GetKeyDown (KeyCode.P)) { //go to either run out of time on_date
				//or if you don't run out of time, decision to stay or go to church.
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void donut_2 () //if you decline the date (no)
	{
		text.text = "enter text here about being flattered but declining the offer.";

		//update:
		if (Input.GetKeyDown (KeyCode.P)) { 
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}
}
