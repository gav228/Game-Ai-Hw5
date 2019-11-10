﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************
 * IMPORTANT NOTES - PLEASE READ
 * 
 * This is where all the code needed for the Ghost AI goes. There should not
 * be any other place in the code that needs your attention.
 * 
 * There are several sets of variables set up below for you to use. Some of
 * those settings will do much to determine how the ghost behaves. You don't
 * have to use this if you have some other approach in mind. Other variables
 * are simply things you will find useful, and I am declaring them for you
 * so you don't have to.
 * 
 * If you need to add additional logic for a specific ghost, you can use the
 * variable ghostID, which is set to 1, 2, 3, or 4 depending on the ghost.
 * 
 * Similarly, set ghostID=ORIGINAL when the ghosts are doing the "original" 
 * PacMan ghost behavior, and to CUSTOM for the new behavior that you supply. 
 * Use ghostID and ghostMode in the Update() method to control all this.
 * 
 * You could if you wanted to, create four separate ghost AI modules, one per
 * ghost, instead. If so, call them something like BlinkyAI, PinkyAI, etc.,
 * and bind them to the correct ghost prefabs.
 * 
 * Finally there are a couple of utility routines at the end.
 * 
 * Please note that this implementation of PacMan is not entirely bug-free.
 * For example, player does not get a new screenful of dots once all the
 * current dots are consumed. There are also some issues with the sound 
 * effects. By all means, fix these bugs if you like.
 * 
 *****************************************************************************/

public class GhostAI : MonoBehaviour {

    const int BLINKY = 1;   // These are used to set ghostID, to facilitate testing.
    const int PINKY = 2;
    const int INKY = 3;
    const int CLYDE = 4;
    public int ghostID;     // This variable is set to the particular ghost in the prefabs,

    const int ORIGINAL = 1; // These are used to set ghostMode, needed for the assignment.
    const int CUSTOM = 2;
    public int ghostMode;   // ORIGINAL for "original" ghost AI; CUSTOM for your unique new AI

    Movement move;
    private Vector3 startPos;
    private bool[] dirs = new bool[4];
	private bool[] prevDirs = new bool[4];

	public float releaseTime = 0f;          // This could be a tunable number
	private float releaseTimeReset = 0f;
	public float waitTime = 0f;             // This could be a tunable number
    private const float ogWaitTime = .1f;
	public int range = 0;                   // This could be a tunable number

    public bool dead = false;               // state variables
	public bool fleeing = false;

	//Default: base value of likelihood of choice for each path
	public float Dflt = 1f;

	//Available: Zero or one based on whether a path is available
	int A = 0;

	//Value: negative 1 or 1 based on direction of pacman
	int V = 1;

	//Fleeing: negative if fleeing
	int F = 1;

	//Priority: calculated preference based on distance of target in one direction weighted by the distance in others (dist/total)
	float P = 0f;

    // Variables to hold distance calcs
	float distX = 0f;
	float distY = 0f;
	float total = 0f;

    // Percent chance of each coice. order is: up < right < 0 < down < left for random choice
    // These could be tunable numbers. You may or may not find this useful.
    public float[] directions = new float[4];
    
	//remember previous choice and make inverse illegal!
	private int[] prevChoices = new int[4]{1,1,1,1};

    // This will be PacMan when chasing, or Gate, when leaving the Pit
	public GameObject target;
	GameObject gate;
	GameObject pacMan;
    GameObject blinky;

	public bool chooseDirection = true;
	public int[] choices ;
	public float choice;
    private int recalculate;

	public enum State{
		waiting,
		entering,
		leaving,
		active,
		fleeing,
        scatter         // Optional - This is for more advanced ghost AI behavior
	}

	public State _state = State.waiting;

    // Use this for initialization
    private void Awake()
    {
        startPos = this.gameObject.transform.position;
    }

    void Start () {
		move = GetComponent<Movement> ();
		gate = GameObject.Find("Gate(Clone)");
		pacMan = GameObject.Find("PacMan(Clone)") ? GameObject.Find("PacMan(Clone)") : GameObject.Find("PacMan 1(Clone)");
        blinky = GameObject.Find("Blinky(Clone)");
		releaseTimeReset = releaseTime;
        recalculate = 0;
	}

	public void restart(){
		releaseTime = releaseTimeReset;
		transform.position = startPos;
		_state = State.waiting;
	}
	
    /// <summary>
    /// This is where most of the work will be done. A switch/case statement is probably 
    /// the first thing to test for. There can be additional tests for specific ghosts,
    /// controlled by the GhostID variable. But much of the variations in ghost behavior
    /// could be controlled by changing values of some of the above variables, like
    /// 
    /// </summary>
	void Update () {
		switch (_state) {
		case(State.waiting):

            // below is some sample code showing how you deal with animations, etc.
			move._dir = Movement.Direction.still;
			if (releaseTime <= 0f) {
				chooseDirection = true;
				gameObject.GetComponent<Animator>().SetBool("Dead", false);
				gameObject.GetComponent<Animator>().SetBool("Running", false);
				gameObject.GetComponent<Animator>().SetInteger ("Direction", 0);
				gameObject.GetComponent<Movement> ().MSpeed = 5f;

				_state = State.leaving;

                // etc.
			}
			gameObject.GetComponent<Animator>().SetBool("Dead", false);
			gameObject.GetComponent<Animator>().SetBool("Running", false);
			gameObject.GetComponent<Animator>().SetInteger ("Direction", 0);
			gameObject.GetComponent<Movement> ().MSpeed = 5f;
			releaseTime -= Time.deltaTime;
            // etc.
			break;


		case(State.leaving):
             transform.position = new Vector3(13.5f, -11f, 2f);
                _state = State.active;

                break;

		case(State.active):
                if (dead) {

                    // etc.
                    // most of your AI code will be placed here
                    _state = State.entering;
                }
                // Blinky Behavior (Chase the player)
                if (ghostID == 1)
                {
                    if (move._dir == Movement.Direction.still)
                    {
                        move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y);
                    }
                    else
                    {
                        if (move.graph.onNode(transform))
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y);
                            recalculate = 0;
                        }

                    }
                }

                // Pinky Behavior (Look in front of player)
                if(ghostID == 2)
                {
                    if (move._dir == Movement.Direction.still)
                    {
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.up)
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y + 4);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.left)
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x - 4, pacMan.transform.position.y);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.right)
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x + 4, pacMan.transform.position.y);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.down)
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y - 4);
                        }
                    }
                    else
                    {
                        if (move.graph.onNode(transform))
                        {
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.up)
                            {
                                move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y + 4);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.left)
                            {
                                move._dir = move.pathFind(transform, pacMan.transform.position.x - 4, pacMan.transform.position.y);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.right)
                            {
                                move._dir = move.pathFind(transform, pacMan.transform.position.x + 4, pacMan.transform.position.y);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.down)
                            {
                                move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y - 4);
                            }
                        }

                    }
                   
                }
                // Inky behavior (double vector between blinky and pacman)
                if (ghostID == 3)
                {
                    if (move._dir == Movement.Direction.still)
                    {
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.up)
                        {
                            move._dir = move.pathFind(transform, (pacMan.transform.position.x - blinky.transform.position.x) * 2, (pacMan.transform.position.y + 4 - blinky.transform.position.y) * 2);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.left)
                        {
                            move._dir = move.pathFind(transform, (pacMan.transform.position.x - 4 - blinky.transform.position.x) * 2, (pacMan.transform.position.y - blinky.transform.position.y) * 2);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.right)
                        {
                            move._dir = move.pathFind(transform, (pacMan.transform.position.x + 4 - blinky.transform.position.x) * 2, (pacMan.transform.position.y - blinky.transform.position.y) * 2);
                        }
                        if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.down)
                        {
                            move._dir = move.pathFind(transform, (pacMan.transform.position.x - blinky.transform.position.x) * 2, (pacMan.transform.position.y - 4 - blinky.transform.position.y) * 2);
                        }
                    }
                    else
                    {
                        if (move.graph.onNode(transform))
                        {
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.up)
                            {
                                move._dir = move.pathFind(transform, (pacMan.transform.position.x - blinky.transform.position.x) * 2, (pacMan.transform.position.y + 4 - blinky.transform.position.y) * 2);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.left)
                            {
                                move._dir = move.pathFind(transform, (pacMan.transform.position.x - 4 - blinky.transform.position.x) * 2, (pacMan.transform.position.y - blinky.transform.position.y) * 2);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.right)
                            {
                                move._dir = move.pathFind(transform, (pacMan.transform.position.x + 4 - blinky.transform.position.x) * 2, (pacMan.transform.position.y - blinky.transform.position.y) * 2);
                            }
                            if (pacMan.GetComponent<Movement>()._dir == Movement.Direction.down)
                            {
                                move._dir = move.pathFind(transform, (pacMan.transform.position.x - blinky.transform.position.x) * 2, (pacMan.transform.position.y - 4 - blinky.transform.position.y) * 2);
                            }
                        }
                    }
                }
                // Clide behavior (run at pacman, then run to the bottom of the screen)
                if (ghostID == 4)
                {
                    if (Vector3.Distance(transform.position, pacMan.transform.position)>8) {
                        if (move._dir == Movement.Direction.still)
                        {
                            move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y);
                        }
                        else
                        {
                            if (move.graph.onNode(transform))
                            {
                                move._dir = move.pathFind(transform, pacMan.transform.position.x, pacMan.transform.position.y);
                                recalculate = 0;
                            }

                        }
                    } else
                    {
                        if (move._dir == Movement.Direction.still)
                        {
                            move._dir = move.pathFind(transform, 1, -29);
                        }
                        else
                        {
                            if (move.graph.onNode(transform))
                            {
                                move._dir = move.pathFind(transform, 1, -29);
                                recalculate = 0;
                            }

                        }
                    }
                }


                    // etc.

                    break;

		case State.entering:

            // Leaving this code in here for you.
			move._dir = Movement.Direction.still;

			if (transform.position.x < 13.48f || transform.position.x > 13.52) {
				//print ("GOING LEFT OR RIGHT");
				transform.position = Vector3.Lerp (transform.position, new Vector3 (13.5f, transform.position.y, transform.position.z), 3f * Time.deltaTime);
			} else if (transform.position.y > -13.99f || transform.position.y < -14.01f) {
				gameObject.GetComponent<Animator>().SetInteger ("Direction", 2);
				transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, -14f, transform.position.z), 3f * Time.deltaTime);
			} else {
				fleeing = false;
				dead = false;
				gameObject.GetComponent<Animator>().SetBool("Running", true);
				_state = State.waiting;
			}

            break;
		}
	}

    // Utility routines

	Vector2 num2vec(int n){
        switch (n)
        {
            case 0:
                return new Vector2(0, 1);
            case 1:
    			return new Vector2(1, 0);
		    case 2:
			    return new Vector2(0, -1);
            case 3:
			    return new Vector2(-1, 0);
            default:    // should never happen
                return new Vector2(0, 0);
        }
	}

	bool compareDirections(bool[] n, bool[] p){
		for(int i = 0; i < n.Length; i++){
			if (n [i] != p [i]) {
				return false;
			}
		}
		return true;
	}
}
