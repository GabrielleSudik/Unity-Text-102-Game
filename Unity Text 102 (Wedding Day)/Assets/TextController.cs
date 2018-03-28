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
		decide_church, decide_airport,
		church_0, church_1, donut_0, donut_1,
		end_0, end_1, end_2};

	private enum Locations //this is general location for running out of time endings
	{
		in_bed, in_apartment, out_apartment};

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
		} else if (myState == States.decide_church) {
			decide_church ();
		} else if (myState == States.decide_airport) {
			decide_airport ();
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
		"Press S to shave.\nPress M to put on make-up.\bPress B to do both.\n" +
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

	void bedroom_1 ()
	{
		myLocation = Locations.in_apartment;

		text.text = "You return to your bedroom. You're all " +
		"done with your abulutions. You have" + minutesLeft + 
		" minutes left before the ceremony. " +
		"What will you do next?\n\n" +
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

	void closet_1 ()
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

	void gown()
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

	void tux ()
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

	void apartment_1 ()
	{
		myLocation = Locations.in_apartment;

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
		myLocation = Locations.in_apartment;

		text.text = "You step into the main area of your apartment, a " +
		"combined living-dining-kitchen great room. While it IS a great " +
		"room, you'll be giving it up to move into your spouse's house " +
		"after the honeymoon. You worry you'll miss your solitude...\n\n" +
		"You have " + minutesLeft+ " minutes left before the ceremony.\n\n" +
		"Press K to make yourself a quick breakfast.\nPress V to relax with some " +
		"videogame time.\nPress E to head out the door.";

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
		myLocation = Locations.in_apartment;

		text.text = "You decide to put a little food in your belly before " +
		"leaving. You make a shot of espresso and heat up a Pop-Tart. " +
		"It's just enough food to give you energy but not slow you down.\n\n" +
		"Press V to relax with some " +
		"videogame time.\nPress E to head out the door.";

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

		//need if statements
		//don't forget time. I THINK IT IS HANDLED WITH THE LOCATIONS ENUM.
		//don't forget dealing with hunger.
	}


	void end_1() //shoot. need to make this work between rising from bed and leaving apartment
		//maybe need to make another enum list of general locations (home, transport, coffee shop, whatever)
		//to implement the correct ending
	{
		text.text = "You hear an unexpected banging at the door, followed by " +
		"loud and angry voices.\n\n" +
		"OH MY GOD IS THAT THE TIME!?!?!.\n\n" +
		"You missed the ceremony because of all " +
		"your dawdling. You grab your honeymoon tickets, climb out a window, and run away.\n\n" +
		"Maybe you'll find true love next time.\nPress P to replay.";

		if (Input.GetKeyDown(KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void end_2() //shoot. need to make this work between rising from bed and leaving apartment
		//maybe need to make another enum list of general locations (home, transport, coffee shop, whatever)
		//to implement the correct ending. I THINK YOU GOT IT WITH THE LOCATIONS ENUM.
	{
		text.text = "You need some text for time running out away from home.\n\n" +
		"Maybe you'll find true love next time.\nPress P to replay.";

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
			"first corner, though, your stomach growls with hunger. You realize " +
			"you forgot to eat.\n\n" +
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
			text.text = "After a five minute wait, the bus arrives. As you " +
			"swipe your pass, the bus driver looks you up and down.\n\n" + 
			"'Well, hellooooo, Miss Robinson! It's a fine day to run " +
			"away from a wedding,' he winks. You smile, then make your way to " +
			"the back seat.\n\n" +
			"As the bus rides through town, you think about what the driver said...\n\n" +
			"Press C to continue that thought...";
		}
		else {
			text.text = "After a five minute wait, the bus arrives. As you " +
			"swipe your pass, the bus driver looks you up and down.\n\n" + 
			"'Well don't you look fine! I kinda wonder if James Bond just got " +
			"on my bus, and is off to save the world and seduce the beautiful " + 
			"people,' he winks. You smile, then make your way to " +
			"the back seat.\n\n" +
			"As the bus rides through town, you think about what the driver said...\n\n" +
			"Press C to continue that thought...";

		}

		if (Input.GetKeyDown(KeyCode.C)) {
			minutesLeft -= 1;
			myState = States.bus_1; //goes to decision to stay on the bus
		}	
	}

	void bus_1 () //decision to stay on the bus
	{
		text.text = "On one hand, you love your intended and think sharing a life " +
		"with another person will be comfortable and comforting. On the other hand, " +
		"the mere reminder that there is a life without the trappings " +
		"of marriage has got you riled up. You decide to:\n\n" +
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

	void church_0 ()
	{
		text.text = "You're in church.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void donut_0 ()
	{
		text.text = "You're at the donut shop.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void church_1()
	{
		text.text = "differnt church text here.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void donut_1 ()
	{
		text.text = "other donut text here.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void decide_church ()
	{
		text.text = "You decide to continue on to church text here.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

	void decide_airport ()
	{
		text.text = "You make a break for the airport text here lol.";

		if (Input.GetKeyDown (KeyCode.P)) {
			minutesLeft = 120;
			myState = States.bed_0;
		}
	}

}
