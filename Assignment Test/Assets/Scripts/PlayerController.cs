using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fL;
    public GameObject rL;
    public GameObject fR;
    public GameObject rR;

    AudioSource sound;
    float minPitch = 0.7f;
    float maxPitch = 1.3f;

    public float maxFSpeed = 300;
    public float maxRSpeed = 50;

    private float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.3 && transform.position.y > -0.1) {
            Accelerate();
            Turn();
        }
        RotateWheels();
        Steer();
        Recover();
    }

    // Accelerates, decelerates, and reverses the car
    void Accelerate() {
        transform.Translate(Vector3.forward * Time.deltaTime * (speed / 5));

        if (Input.GetKey(KeyCode.W)) {
            if (speed < maxFSpeed) {
                speed++;
                //if (sound.pitch < maxPitch) {
                //    sound.pitch += 0.006f;
                //} else {
                //    sound.pitch = maxPitch;
                //}
            } else {
                speed = maxFSpeed;
                //sound.pitch = maxPitch;
            }
        } else {
            if (speed > 0) {
                speed -= 0.5f;
                //if (sound.pitch > minPitch) {
                //    sound.pitch -= 0.0033f;
                //} else {
                //    sound.pitch = minPitch;
                //}
            }
        }

        if (Input.GetKey(KeyCode.S)) {
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
    void Turn() {
        if (Input.GetKey(KeyCode.D)) {
            if (speed != 0 && speed <= maxFSpeed / 2)
                transform.Rotate(new Vector3(0, 1f, 0), Space.Self);
            else if (speed > maxFSpeed / 2)
                transform.Rotate(new Vector3(0, 0.75f, 0), Space.Self);
        } else if (Input.GetKey(KeyCode.A)) {
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

    void Steer() {
        if (Input.GetKey(KeyCode.D)) {
            fL.transform.localEulerAngles = new Vector3(0, 30f, 0);
            fR.transform.localEulerAngles = new Vector3(0, 30f, 0);
        } else if (Input.GetKey(KeyCode.A)) {
            fL.transform.localEulerAngles = new Vector3(0, -30f, 0);
            fR.transform.localEulerAngles = new Vector3(0, -30f, 0);
        } else {
            fL.transform.localEulerAngles = new Vector3(0, 0, 0);
            fR.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    void Recover() {
        if (Input.GetKey(KeyCode.R)) {
            transform.position = new Vector3(0, 1.25f, 40);
            speed = 0;
        }
    }
}