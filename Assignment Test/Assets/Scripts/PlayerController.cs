using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fL;
    public GameObject rL;
    public GameObject fR;
    public GameObject rR;

    public Canvas endScreen;

    AudioSource sound;
    float minPitch = 0.7f;
    float maxPitch = 1.3f;

    public float maxFSpeed = 250;
    public float maxRSpeed = 50;

    private float speed = 0.0f;

    private KeyCode forward;
    private KeyCode back;
    private KeyCode left;
    private KeyCode right;
    private KeyCode recover;

    // Start is called before the first frame update
    void Start()
    {
        //Detects if you are Player 1 or 2 and changes key bindings
        if (tag == "Player1") {
            forward = KeyCode.W;
            back = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
            recover = KeyCode.R;
        } else if (tag == "Player2") {
            forward = KeyCode.I;
            back = KeyCode.K;
            left = KeyCode.J;
            right = KeyCode.L;
            recover = KeyCode.P;
        }

        //Gets the component for the audio
        sound = GetComponent<AudioSource>();
        sound.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the end screen is active, if not it lets you play
        if (endScreen.enabled == true) {
            EndGame();
        } else {
            if (transform.position.y < 0.3 && transform.position.y > -0.3) {
                Accelerate();
                Turn();
            }
            RotateWheels();
            Steer();
            Recover();
        }
    }

    // Accelerates, decelerates, and reverses the car
    void Accelerate() {
        //Always moving forward based on speed
        transform.Translate(Vector3.forward * Time.deltaTime * (speed / 5));

        //Increases speed if pressing W or I, slowly reduces speed if not
        if (Input.GetKey(forward)) {
            if (speed < maxFSpeed) {
                speed++;
                if (sound.pitch < maxPitch) { //Also modulates the sound of the engines
                    sound.pitch += 0.006f;
                } else {
                    sound.pitch = maxPitch;
                }
            } else {
                speed = maxFSpeed;
                sound.pitch = maxPitch;
            }
        } else {
            if (speed > 0) {
                speed -= 0.5f;
                if (sound.pitch > minPitch) {
                    sound.pitch -= 0.0033f;
                } else {
                    sound.pitch = minPitch;
                }
            }
        }

        //If pressing S or K, it will reduce speed and eventually go in reverse
        if (Input.GetKey(back)) {
            if (speed > -maxRSpeed) {
                speed--;
            } else {
                speed = -maxRSpeed;
            }
        } else {
            if (speed < 0) {
                speed += 0.5f;
            }
        }
    }

    // Turn the car. Can't turn when stopped
    // Chenges rate of turning based on speed: higher speed = slower turn
    void Turn() {
        if (Input.GetKey(right)) {
            if (speed != 0 && speed <= maxFSpeed / 2)
                transform.Rotate(new Vector3(0, 1f, 0), Space.Self);
            else if (speed > maxFSpeed / 2)
                transform.Rotate(new Vector3(0, 0.75f, 0), Space.Self);
        } else if (Input.GetKey(left)) {
            if (speed != 0 && speed <= maxFSpeed / 2)
                transform.Rotate(new Vector3(0, -1f, 0), Space.Self);
            else if (speed > maxFSpeed / 2)
                transform.Rotate(new Vector3(0, -0.75f, 0), Space.Self);
        }
    }

    // Rotates the wheels of the car based on the speed
    void RotateWheels() {
        fL.transform.Rotate(new Vector3((speed / 12), 0, 0));
        rL.transform.Rotate(new Vector3((speed / 12), 0, 0));
        fR.transform.Rotate(new Vector3((speed / 12), 0, 0));
        rR.transform.Rotate(new Vector3((speed / 12), 0, 0));
    }

    // Simple enough, just rotates the wheels when turning
    void Steer() {
        if (Input.GetKey(right)) {
            fL.transform.localEulerAngles = new Vector3(0, 30f, 0);
            fR.transform.localEulerAngles = new Vector3(0, 30f, 0);
        } else if (Input.GetKey(left)) {
            fL.transform.localEulerAngles = new Vector3(0, -30f, 0);
            fR.transform.localEulerAngles = new Vector3(0, -30f, 0);
        } else {
            fL.transform.localEulerAngles = new Vector3(0, 0, 0);
            fR.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    //Will respawn the car at the start of the lap if you get stuck
    void Recover() {
        if (Input.GetKey(recover)) {
            transform.position = new Vector3(0, 0.25f, 60);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            speed = 0;
        }
    }

    //Puts game into "slowmo" when the game is ended
    void EndGame() {
        transform.Translate(Vector3.forward * Time.deltaTime * (speed / 15));
        if (speed > 0) {
            speed -= 0.5f;
        }
    }
}