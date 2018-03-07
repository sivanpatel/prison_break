using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {
	public Text text;
	private enum States {cell, sheets_0, sheets_1, lock_0, lock_1, mirror, cell_mirror, corridor_0,
						 stairs_0, stairs_1, stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3,
						 closet_door, in_closet, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}

	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell)		 {cell();}
		else if (myState == States.sheets_0)	 {sheets_0();}
		else if (myState == States.sheets_1) 	 {sheets_1();}
		else if (myState == States.lock_0) 		 {lock_0();}
		else if (myState == States.lock_1) 		 {lock_1();}
		else if (myState == States.mirror) 		 {mirror();}
		else if (myState == States.cell_mirror)  {cell_mirror();}
		else if (myState == States.corridor_0) 	 {corridor_0();}
		else if (myState == States.stairs_0) 	 {stairs_0();}
		else if (myState == States.stairs_1) 	 {stairs_1();}
		else if (myState == States.stairs_2) 	 {stairs_2();}
		else if (myState == States.courtyard) 	 {courtyard();}
		else if (myState == States.floor) 		 {floor();}
		else if (myState == States.corridor_1) 	 {corridor_1();}
		else if (myState == States.corridor_2) 	 {corridor_2();}
		else if (myState == States.corridor_3) 	 {corridor_3();}
		else if (myState == States.closet_door)  {closet_door();}
		else if (myState == States.in_closet) 	 {in_closet();}
	}

	#region state handler methods
	void cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) {myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;}
	}

	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if (Input.GetKeyDown(KeyCode.T)) {myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}

	void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if (Input.GetKeyDown(KeyCode.O)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}

	void cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_1;}
	}

	void corridor_0() {
		text.text = "You are in long corridor. There is a locked closet and some stairs.\n\n" +
					"Press C to view closet. Press S to go up the stairs. Press F to look at the floor";
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.closet_door;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) {myState = States.floor;}
	}

	void stairs_0() {
		text.text = "You think about going up the stairs, but you won't get far dressed in prisoner clothes.\n\n" +
					"Press R to return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void stairs_1() {
		text.text = "You think about going up the stairs, but you won't get far dressed in prisoner clothes.\n\n" +
					"Press R to return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
	}

	void stairs_2() {
		text.text = "You think about going up the stairs, but you won't get far dressed in prisoner clothes. Maybe if you get changed you would have a chance\n\n" +
					"Press R to return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
	}

	void courtyard() {
		text.text = "You are free!!!\n\nPress P to play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}

	void floor() {
		text.text = "You look at the floor, you see a hairpin.\n\n" +
					"Press T to take the hairpin. Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.T)) {myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;} 
	}

	void corridor_1() {
		text.text = "You are in long corridor. There is a locked closet and some stairs.\n\n" +
					"Press C to break into the closet. Press S to go up the stairs.";
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;}
	}

	void corridor_2() {
		text.text = "You are in long corridor. There is a locked closet and some stairs.\n\n" +
					"Press C to break into the closet. Press S to go up the stairs.";
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;}
	}

	void corridor_3() {
		text.text = "Do you want to make a break for freedom, or undress?\n\n" +
					"Press F to break for freedom. Press U to undress";
		if (Input.GetKeyDown(KeyCode.F)) {myState = States.courtyard;}
		else if (Input.GetKeyDown(KeyCode.U)) {myState = States.in_closet;}
	}

	void closet_door() {
		text.text = "You are looking at the closet door, but you cannot open it.\n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void in_closet() {
		text.text = "There are some clothes here, do you want to change into them?\n\n" +
					"Press C to change clothes. Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.corridor_3;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
	}
	#endregion
}