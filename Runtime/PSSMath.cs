using UnityEngine;

namespace PixelRouge.MathTools
{
    public static class PSSMath
    {
        /// <summary>
        /// Converts an angle value in radians to its correspondent value in degrees.
        /// </summary>
        public static float RadiansToDegrees(float angleRadians)
        {
            return angleRadians * 57.29577951f;
        }
        
        /// <summary>
        /// Converts an angle value in degrees to its correspondent value in radians.
        /// </summary>
        public static float DegreesToRadians(float angleDegrees)
        {
            return angleDegrees * 0.017453293f;
        }

        /// <summary>
        /// Return the absolute value of n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float Abs(float n)
        {
            return n >= 0f ? n : -n;
        }

        /// <summary>
        /// Return the absolute value of n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Abs(int n)
        {
            return n >= 0 ? n : -n;
        }

        /// <summary>
        /// Returns the distance between the two vectors.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public static float Distance(Vector2 currentPosition, Vector2 targetPosition)
        {
            var deltaPosition = targetPosition - currentPosition;
            return Mathf.Sqrt(Mathf.Pow(deltaPosition.x, 2f) + Mathf.Pow(deltaPosition.y, 2f));
        }

        /// <summary>
        /// Returns the distance between the two vectors.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public static float Distance(Vector3 currentPosition, Vector3 targetPosition)
        {
            var deltaPosition = targetPosition - currentPosition;
            return Mathf.Sqrt(Mathf.Pow(deltaPosition.x, 2f) + Mathf.Pow(deltaPosition.y, 2f) + Mathf.Pow(deltaPosition.z, 2f));
        }

        /// <summary>
        /// Returns the direction from currentPosition to targetPosition.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public static Vector2 Direction(Vector2 currentPosition, Vector2 targetPosition)
        {
            return targetPosition - currentPosition;
        }

        /// <summary>
        /// Returns the direction from currentPosition to targetPosition.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public static Vector3 Direction(Vector3 currentPosition, Vector3 targetPosition)
        {
            return targetPosition - currentPosition;
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Magnitude(Vector3 v)
        {
            return Mathf.Sqrt(Mathf.Pow(v.x, 2f) + Mathf.Pow(v.y, 2f) + Mathf.Pow(v.z, 2f));
        }

        /// <summary>
        /// Returns the vector normalized, which is the same vector with magnitude 1.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 Normalize(Vector2 v)
        {
            return new Vector2(v.x / (v).magnitude, v.y / (v).magnitude);
        }

        /// <summary>
        /// Returns the vector normalized, which is the same vector with magnitude 1.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Normalize(Vector3 v)
        {
            return new Vector3(v.x / (v).magnitude, v.y / (v).magnitude, v.z / (v).magnitude);
        }

        /// <summary>
        /// Returns the angle between two vectors in radians.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Angle in radians.</returns>
        public static float Angle(Vector2 v1, Vector2 v2)
        {
            return Mathf.Acos(Dot(v1, v2) / (Distance(Vector2.zero, v1) * Distance(Vector2.zero, v2)));
        }

        /// <summary>
        /// Returns the angle between two vectors in radians.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Angle in radians.</returns>
        public static float Angle(Vector3 v1, Vector3 v2)
        {
            return Mathf.Acos(Dot(v1, v2) / (v1.magnitude * v2.magnitude));
        }

        /// <summary>
        /// Returns the angle between two vectors in radians.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float AngleFromDotProduct(Vector2 v1, Vector2 v2, float dotProduct)
        {
            return 1f / Mathf.Cos(dotProduct / v1.magnitude * v2.magnitude);
        }
        
        /// <summary>
        /// Return num > 0 if angle between vectors is greater than 90 degrees, 
        /// return num < 0 if angle between vectors is lesser than 90 degrees
        /// return 0 if angle between vectors is equal to 90 degrees.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
        
        /// <summary>
        /// Return num > 0 if angle between vectors is greater than 90 degrees, 
        /// return num < 0 if angle between vectors is lesser than 90 degrees
        /// return 0 if angle between vectors is equal to 90 degrees.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// Returns something less than zero if the rotation needs to be clockwise and returns 
        /// greater than zero if counter-clockwise
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }

        /// <summary>
        /// Make the object with the currentPos face the focusPos using Atan2.
        /// </summary>
        /// <param name="currentPos"></param>
        /// <param name="focusPos"></param>
        /// <returns></returns>
        public static Quaternion LookAt2D(Vector3 currentPos, Vector3 focusPos)
        {
            Vector2 dirNormalized = Normalize(Direction(currentPos, focusPos));
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dirNormalized.y, dirNormalized.x) * Mathf.Rad2Deg);
            return rotation;
        }

        /// <summary>
        /// Make the object with the currentPos face the focusPos (dont use on update).
        /// </summary>
        /// <param name="facingDirection"></param>
        /// <param name="currentPos"></param>
        /// <param name="focusPos"></param>
        /// <returns></returns>
        public static Vector3 LookAt2D(Vector3 facingDirection, Vector3 currentPos, Vector3 focusPos)
        {
            Vector3 direction = Direction(currentPos, focusPos);
            float angle = Angle(facingDirection, direction);
            bool clockwise = Cross(currentPos, direction).z < 0;
            return Rotate(facingDirection, angle, clockwise);
        }

        /// <summary>
        /// Rotates the object on itself. Assign the return value to this in object's transform.up.
        /// </summary>
        /// <param name="facingDirection"></param>
        /// <param name="angle"></param>
        /// <param name="rotateClockwise"></param>
        /// <returns></returns>
        public static Vector2 Rotate(Vector3 facingDirection, float angle, bool rotateClockwise)
        {
            if (rotateClockwise)
            {
                angle = 2 * Mathf.PI - angle;
            }

            var x = facingDirection.x * Mathf.Cos(angle) - facingDirection.y * Mathf.Sin(angle);
            var y = facingDirection.x * Mathf.Sin(angle) + facingDirection.y * Mathf.Cos(angle);
            return new Vector2(x, y);
        }

        /// <summary>
        /// "Moves" the object to a destination point.!-- Assign the return value to the localPosition atribute.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="destinationPosition"></param>
        /// <returns></returns>
        public static Vector2 Translate(Vector3 currentPosition, Vector3 destinationPosition)
        {
            return currentPosition + destinationPosition * Time.deltaTime;
        }

        /// <summary>
        /// Move towards horizontally.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static Vector2 MoveTowardsHorizontally(Vector2 start, Vector2 end, float maxDistanceDelta)
        {
            Vector2 a = start - end;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) { return end; }
            return new Vector2(start.x + a.x, start.y) / magnitude * maxDistanceDelta;
        }

        public static Vector2 ClampVector2(Vector2 value, float maxLength)
        {
            var magnitude = value.magnitude;

            if (magnitude <= maxLength)
            {
                return value;
            }

            return value.normalized * maxLength;
        }

        /// <summary>
        /// Translates a world position <paramref name="worldPosition"/> to relative position in relation
        /// to a point <paramref name="relativePoint"/>;
        /// </summary>
        /// <param name="worldPosition">Position to be translated.</param>
        /// <param name="relativePoint">Point which will be the origin relative to point in <paramref name="worldPosition"/></param>
        /// <returns></returns>
        public static Vector3 WorldToLocalPosition(Vector3 worldPosition, Vector3 relativePoint)
        {
            return worldPosition - relativePoint;
        }

        /// <summary>
        /// Round the <paramref name="value"/> to a number divisible by 0.5.
        /// </summary>
        public static float RoundToHalf(float value)
        {
            return (float)System.Math.Round(value * 2f, System.MidpointRounding.AwayFromZero) * 0.5f;
        }

        /// <summary>
        /// Returns the point positioned exactly at the middle of the distance between the two points provided.
        /// </summary>
        public static Vector2 Midpoint(Vector2 p1, Vector2 p2)
        {
            var x = p1.x + p2.x;
            var y = p1.y + p2.y;
            return new Vector2(x * 0.5f, y * 0.5f);
        }

        /// <summary>
        /// Returns the point positioned exactly at the middle of the distance between the two points provided.
        /// </summary>
        public static Vector3 Midpoint(Vector3 p1, Vector3 p2)
        {
            var x = p1.x + p2.x;
            var y = p1.y + p2.y;
            var z = p1.z + p2.z;
            return new Vector3(x * 0.5f, y * 0.5f, z * 0.5f);
        }

        // TODO: add precalculated sin, cos and tg
    }
}