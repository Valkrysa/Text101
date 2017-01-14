using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	enum States {cell, sketchpad, bed, pills, doortry, doorslip, doorsmash, hallway, fightbear, sketchbear, hum, finaldoor, fightend, bearend, pillsend};
	private States myState;
	
	private bool inventory_pills;
	private bool inventory_sleep;
	private bool inventory_sketch_pad;
	private bool inventory_bear;

	// Use this for initialization
	void Start () {
		inventory_pills = false;
		inventory_sleep = false;
		inventory_sketch_pad = false;
		inventory_bear = false;
	
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if(myState == States.cell){
			state_cell();
		} else if(myState == States.sketchpad){
			state_sketchpad();
		} else if(myState == States.bed){
			state_bed();
		} else if(myState == States.pills){
			state_pills();
		} else if(myState == States.doorslip){
			state_doorslip();
		} else if(myState == States.doorsmash){
			state_doorsmash();
		} else if(myState == States.doortry){
			state_doortry();
		} else if(myState == States.hallway){
			state_hallway();
		} else if(myState == States.fightbear){
			state_fightbear();
		} else if(myState == States.sketchbear){
			state_sketchbear();
		} else if(myState == States.hum){
			state_hum();
		} else if(myState == States.finaldoor){
			state_finaldoor();
		} else if(myState == States.fightend){
			state_fightend();
		} else if(myState == States.bearend){
			state_bearend();
		} else if(myState == States.pillsend){
			state_pillsend();
		}
	}
	
	void state_cell(){
		text.text =		"You wake up in a stark and neglected prison cell. You don't know how you got here.\n" +
							"In the room are a bottle of pills,";
		if(!inventory_sketch_pad){
			text.text +=	" a sketch pad,";
		}
		text.text +=	" a bed,";
		text.text +=	" and of course the cell door.\n\n";
		text.text +=	"Press B to go back to (B)ed,";
		if(!inventory_sketch_pad){
			text.text +=	" S to examine the (S)ketch Pad,";
		}
		if(!inventory_pills){
			text.text +=	" P to eat the (P)ills,";
		}
		if(!inventory_sleep && !inventory_pills){
			text.text +=	" or D to try to open the (D)oor.";
		} else if(inventory_pills){
			text.text +=	" or D to use your steroid strength to smash the (D)oor.";
		} else {
			text.text +=	" or D to use your recently emaciated form to slip between the bars in the (D)oor.";
		}
		
		if(!inventory_sketch_pad && Input.GetKeyDown(KeyCode.S)){
			myState = States.sketchpad;
		} else if(Input.GetKeyDown(KeyCode.B)){
			myState = States.bed;
		} else if(!inventory_pills && Input.GetKeyDown(KeyCode.P)){
			myState = States.pills;
		} else if(inventory_pills && Input.GetKeyDown(KeyCode.D)){
			myState = States.doorsmash;
		} else if(inventory_sleep && Input.GetKeyDown(KeyCode.D)){
			myState = States.doorslip;
		} else if(Input.GetKeyDown(KeyCode.D)){
			myState = States.doorslip;
		}
	}
	
	void state_sketchpad(){
		text.text = "This is the most rad sketchpad you've ever seen, it has doodles of dinosaurs in the margins. You take it with you.\n\n" +
				"Press SPACE to look around again.";
				
		inventory_sketch_pad = true;
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.cell;
		}
	}
	
	void state_bed(){
		if(inventory_sleep){
			text.text = "If one night of sleeping didn't solve the issue then surely a second night will do the trick!\n" +
							"Unfortunately after a second night of starvation you lack the strength to get up, dying in the most comfortable bed ever.\n\n" +
							"Press SPACE to restart.";
			
			if(Input.GetKeyDown(KeyCode.Space)){
				Start();
			}
		} else {
			text.text = "You decide to sleep and forget about this whole mess. Unfortunately in the morning you wake up in the same situation as yesterday, only hungrier and thinner.\n\n" +
							"Press SPACE to look around again. ";
			
			if(Input.GetKeyDown(KeyCode.Space)){
				inventory_sleep = true;
				
				myState = States.cell;
			}
		}
	}
	
	void state_pills(){
		text.text = "The label on the side of the pill bottle reads 'EXPERIMENTAL STEROIDS'. You down only half the bottle just to be safe.\n\n" +
			"Press SPACE to look around again.";
		
		inventory_pills = true;
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.cell;
		}
	}
	
	void state_doortry(){
		text.text = "The door was built by someone who clearly cares about what they do. Despite your loose sense of morality you fail to come up with a way to remove it.\n\n" +
			"Press SPACE to look around again.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.cell;
		}
	}
	
	void state_doorslip(){
		text.text = "The door was built by someone who clearly cares about what they do but they didn't count on you being so clever as to use sleeping as a weapon. You slip through with little effort.\n\n" +
			"Press SPACE to look around the hallway.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.hallway;
		}
	}
	
	void state_doorsmash(){
		text.text = "The door was built by someone who clearly cares about what they do but you have a loose sense of morality and so have no problem smashing it to pieces. \n\n" +
			"Press SPACE to look around the hallway.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.hallway;
		}
	}
	
	void state_hallway(){
		text.text = "You find yourself in a long hallway. At the other end a bear sits. Watching you. You get the menacing feeling that it will not be letting you leave. \n\n" +
			"Press F to (F)ight the bear";
		if(inventory_sketch_pad){
			text.text += ", S to offer the (S)ketchpad to the bear";
		}
		text.text += ", or H to appeal to nationalism by (H)umming the National anthem of Russia.";
		
		if(inventory_sketch_pad && Input.GetKeyDown(KeyCode.S)){
			myState = States.sketchbear;
		} else if(Input.GetKeyDown(KeyCode.F)){
			myState = States.fightbear;
		} else if(Input.GetKeyDown(KeyCode.H)){
			myState = States.hum;
		}
	}
	
	void state_fightbear(){
		text.text = "You size the bear up, preparing to teach it a thing or two, but you respect animals too much to try to take it on. Either that or you chickened out. Who knows? \n\n" +
			"Press SPACE to look around the hallway.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.hallway;
		}
	}
	
	void state_sketchbear(){
		text.text = "As you hand the sketchpad to the bear you see that it is on the verge of tears. This bear will be your friend for life. Go now and face your final challenge. Let your legend come to life! \n\n" +
			"Press SPACE to approach the final door.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			inventory_bear = true;
			myState = States.finaldoor;
		}
	}
	
	void state_hum(){
		text.text = "The bear's eyes glaze over as if lost in distant memory. It wanders away, it won't be bothering you again for awhile. \n\n" +
			"Press SPACE to approach the final door.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.finaldoor;
		}
	}
	
	void state_finaldoor(){
		text.text = "Finally, you arrive at the final door. Freedom awaits beyond. The biggest baddest guard ever is determined to stop you. How will you meet destiny? \n\n" +
			"Press F to (F)ight to the death";
		if(inventory_bear){
			text.text += ", or B to summon your (B)ear ally";
		}
		if(inventory_pills){
			text.text += ", or P to down the rest of the (P)ills.";
		}
		
		if(inventory_bear && Input.GetKeyDown(KeyCode.B)){
			myState = States.bearend;
		} else if(inventory_pills && Input.GetKeyDown(KeyCode.P)){
			myState = States.pillsend;
		} else if(Input.GetKeyDown(KeyCode.F)){
			myState = States.fightend;
		}
	}
	
	void state_fightend(){
		text.text = "You give it your all but your all just isn't enough.\n" +
			"If only you had more strength, or friends, or both.\n\n" +
			"Press SPACE to restart.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			Start();
		}
	}
	
	void state_bearend(){
		text.text = "Your ally comes to your aid and it fill you with confidence.\n" +
			"You are victorious because you believe in your own justice.\n" +
			"As you exit the prison you know that many more wonderous adventures await you. \n\n" +
			"Press SPACE to restart.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			Start();
		}
	}
	
	void state_pillsend(){
		text.text = "You eat all of the pills and are filled with an immense strength. You have become truly huge .\n" +
			"The puny guard is crushed with ease and so you consume his body for protein in order to maintain your girth.\n" +
				"As you exit the prison you know that the quest for huge has just begun.\n" +
				"You will need to acquire more pills and more protein to realize your destiny. \n\n" +
				"Press SPACE to restart.";
		
		if(Input.GetKeyDown(KeyCode.Space)){
			Start();
		}
	}
}
