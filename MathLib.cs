namespace YoukaiFox.Math 
{
    public class MathLib
    {
        /**
        return num > 0 if angle between vectors is greater than 90 degrees
        return num < 0 if angle between vectors is lesser than 90 degrees
        return 0 if angle between vectors is equal to 90 degrees
        */
        public static float Dot(Vector3 v1, Vector3 v2) //ok
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /**
        returns the length of the vector
        */
        public static float Magnitude(Vector3 v) 
        {
            return Mathf.Sqrt(Square(v.x) + Square(v.y) + Square(v.z));
        }

        /**
        returns the distance between the two vectors
        */
        public static float Distance(Vector3 currentPos, Vector3 destinationPos) //ok
        {
            return Mathf.Sqrt(Square(destinationPos.x - currentPos.x) + 
                Square(destinationPos.y - currentPos.y) + Square(destinationPos.z - currentPos.z));
        }

        /**
        returns the direction from currentPos to focusPos
        */
        public static Vector3 Direction(Vector3 currentPos, Vector3 focusPos) {
            return new Vector3(focusPos.x - currentPos.x, focusPos.y - currentPos.y, focusPos.z - currentPos.z);
        }

        /**
        returns the vector normal, which is the same vector with magnitude 1
        */
        public static Vector2 Normal(Vector2 v)
        {
            return new Vector2(v.x / (v).magnitude, v.y / (v).magnitude);
        }

        /**
        Returns the angle between two vectors in radians
        */
        public static float Angle(Vector2 v1, Vector2 v2)
        {
            // return Mathf.Acos(Dot(v1.normalized, v2.normalized) / (v1).magnitude * (v2).magnitude);
            return Mathf.Acos(Dot(v1, v2) / (Distance(Vector2.zero, v1) * Distance(Vector2.zero, v2)));
        }

        /**
        returns n squared
        */
        public static float Square(float n) 
        {
            return n * n;
        }

        /**
        returns something less than zero if the rotation needs to be clockwise
        and returns greater than zero if counter-clockwise
        */
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }

        /**
        make the object with the currentPos face the focusPos using Atan2
        */
        public static Quaternion LookAt2D(Vector3 currentPos, Vector3 focusPos) { 
            Vector2 dirNormalized = Normal(Direction(currentPos, focusPos));
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dirNormalized.y, dirNormalized.x) * Mathf.Rad2Deg);
            return rotation;
        }

        /**
        make the object with the currentPos face the focusPos (dont use on update)
        */
        public static Vector3 LookAt2D(Vector3 facingDirection, Vector3 currentPos, Vector3 focusPos)
        {
            Vector3 direction = Direction(currentPos, focusPos);
            float angle = Angle(facingDirection, direction);
            bool clockwise = Cross(currentPos, direction).z < 0 ? true : false;
            return Rotate(facingDirection, angle, clockwise);
        }

        /**
        Rotates the object on itself. Store this in object's transform.up
        */
        public static Vector2 Rotate(Vector3 facingDirection, float angle, bool rotateClockwise)
        {
            // angle *= 180 / 2;
            if (rotateClockwise)
                angle = 2 * Mathf.PI - angle;

            return new Vector2(facingDirection.x * Mathf.Cos(angle) - facingDirection.y * Mathf.Sin(angle),
                                facingDirection.x * Mathf.Sin(angle) + facingDirection.y * Mathf.Cos(angle));
        }

        /**
        "Moves" the object to a destiny.!-- Please store the return in the localPosition atribute
        */
        public static Vector2 Translate(Vector3 currentPos, Vector3 destinationPos) 
        {
            return currentPos + destinationPos * Time.deltaTime;
        }

        /**
        "Moves" the object while pixel perfect. Please store the return in the localPosition atribute
        */
        // public static Vector2 TranslatePixelArt(Vector3 currentPos, Vector3 destinationPos, float pixelInUnits) 
        // {
        //     return Vector3.Lerp(currentPos, Translate(currentPos, destinationPos * pixelInUnits), Time.deltaTime * Random.Range(300f, 500f));
        //     // return Translate(currentPos, destinationPos * pixelInUnits);
        // }

        /**
        returns a number which must then be multiplied with a angle in radians
        what will result in a number representing the same angle in degrees
        */
        public static float RadiansToDegrees() 
        {
            return 180 / Mathf.PI;
        }

        /**
        Round the unit measured in unit values to the nearest value that can
        perfect pixel
        */
        // public static float RoundUnitToPixel(float unityUnits, float pixelPerUnit) 
        // {//please set the V-Sync to Every V Blank
        //     float valueInPixels = unityUnits * pixelPerUnit;
        //     valueInPixels = Mathf.Round(valueInPixels);
        //     float roundedUnityUnits = valueInPixels * (1 / pixelPerUnit);
        //     return roundedUnityUnits;
        // }
        
        /**
        Round vector axes to the nearest value that can be perfect pixel
        */
        // public static Vector2 RoundVectorToPixel(Vector2 vector, float pixelPerUnit) 
        // {//please set the V-Sync to Every V Blank
        //     return new Vector2(RoundUnitToPixel(vector.x, pixelPerUnit), RoundUnitToPixel(vector.y, pixelPerUnit));
        // }

        // public static float GetPixelPerfectCameraSize()
        // {

        // }

        /**
        Move Towards horizontally
        **/
        public static Vector2 MoveTowardsHorizontally(Vector2 start, Vector2 end, float maxDistanceDelta)
        {
            Vector2 a = start - end;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) {return end;}
            return new Vector2(start.x + a.x, start.y) / magnitude * maxDistanceDelta;
        }
        public static Vector2 GetDownRightVector2() {return new Vector2(1, -1);}
        public static Vector2 GetUpLeftVector2() {return new Vector2(-1, 1);}
        /**
        
        **/
        public static float GetVelocity(float initialPos, float finalPos, float deltaTime) 
        {
            return (finalPos - initialPos) / deltaTime;
        }
        public static Vector2 GetVelocity(Vector2 initialPos, Vector2 finalPos, float deltaTime)
        {
            return (finalPos - initialPos) / deltaTime;
        }
        public static float Abs(float n) 
        {
            if (n >= 0) return n;
            return -n;
        }
        public static float Abs(int n) 
        {
            if (n >= 0) return n;
            return -n;
        }
        /// <summary>
        /// Returns a Vector2 representing the initial velocity of the rigidbody so it hits the target
        /// while going through a parabola. The <paramref name="initialPos"/> should be from where the
        /// rigidbody is launched and not the rigidbody's own position.
        /// </summary>
        /// <param name="initialPos"></param>
        /// <param name="finalPos"></param>
        /// <param name="time"></param>
        public static Vector2 GetParabolaInitialVelocity(Vector2 initialPos, Vector2 finalPos, float time)
        {
            Vector2 velocity = GetVelocity(initialPos, finalPos, time);
            velocity.y += 0.5f * Abs(Physics2D.gravity.y) * MathLib.Square(time) / time;
            return velocity;
        }
        public static bool HeadsOrTails() {return Random.Range(0, 2) > 0;}
    }
}