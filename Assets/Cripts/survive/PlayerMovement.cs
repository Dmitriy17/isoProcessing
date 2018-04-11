using UnityEngine;
//using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.
        public float rashRange = 4f;
        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
        /*
#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif
*/
        void Awake ()
        {
            /*
#if !MOBILE_INPUT
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask ("Floor");
#endif
*/
            // Set up references.
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody2D> ();
        }


        void FixedUpdate ()
        {
            // Store the input axes.
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");/*
            float attackH = Input.GetAxisRaw("HorizontalAttack");
            float attackV = Input.GetAxisRaw("VerticalAttack");
            bool isAttack = false;
            if (attackH == 1f || attackH == -1f || attackV == 1f || attackV == -1f)
            {
                isAttack = true;
            }*/
            bool rash = Input.GetKeyDown(KeyCode.Space);
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("bool", true);
            }*/
            // Move the player around the scene.
            if (!Kostul())
            {
                Move(h, v, rash);

                // Turn the player to face the mouse cursor.
                //Turning ();

                // Animate the player.
                Animating(/*attackH,attackV,*/h, v, rash/*,isAttack */);
            }

        }


        void Move ( float h, float v, bool rash)
        {
            if (rash)
            {
                // Set the movement vector based on the axis input.
                if (h == 0.0f && v == 0.0f)
                {
                    h = 1.0f;
                }
                    movement.Set(h*rashRange,v* rashRange, 0f);

                    // Normalise the movement vector and make it proportional to the speed per second.
                    movement = movement * 18 * Time.deltaTime;

                    // Move the player to it's current position plus the movement.
                    playerRigidbody.MovePosition(transform.position + movement );
            }
            else
            {
                // Set the movement vector based on the axis input.
                movement.Set(h, v, 0f);

                // Normalise the movement vector and make it proportional to the speed per second.
                movement = movement * speed * Time.deltaTime;

                // Move the player to it's current position plus the movement.
                playerRigidbody.MovePosition(transform.position + movement);
            }
        }

        /*
        void Turning ()
        {
#if !MOBILE_INPUT
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation (newRotatation);
            }
#else

            Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));

            if (turnDir != Vector3.zero)
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation(newRotatation);
            }
#endif
        }
        */

        void Animating (/*float attackH, float attackV,*/ float h, float v, bool rash /*, bool isAttack*/)
        {/*
            anim.SetBool("isAttack", isAttack);
            anim.SetFloat("HorizontalAttack", attackH);
            anim.SetFloat("VerticalAttack", attackV);
            */anim.SetBool("bool", rash);
            anim.SetFloat("Horizontal", h);
            anim.SetFloat("Vertical", v);
        }
       bool Kostul()
        {
            //Fetch the current Animation clip information for the base layer
            AnimatorClipInfo[] CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
            //Access the Animation clip name
            string ClipName = CurrentClipInfo[0].clip.name;
            return ClipName.ToLower().Contains("attack");
        }
    }
}