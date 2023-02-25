using UnityEngine;

namespace PixelSpark.MathTools
{
    public static class PSSPhysics
    {
        /// <summary>
        /// Returns a Vector2 representing the initial velocity of the rigidbody that it needs
        /// to have to hit the target while going through a parabola.
        /// The <paramref name="initialPosition"/> should be from where the
        /// rigidbody is launched and not the rigidbody's own position.
        /// </summary>
        /// <param name="initialPosition">Object's starting position.</param>
        /// <param name="finalPosition">Object's expected final position.</param>
        /// <param name="time">Elapsed time for the object to arrive at the expected position.</param>
        public static Vector2 GetParabolaInitialVelocity(Vector2 initialPosition, Vector2 finalPosition, float time)
        {
            var velocity = Velocity(initialPosition, finalPosition, time);
            velocity.y += 0.5f * PSSMath.Abs(Physics2D.gravity.y) * Mathf.Pow(time, 2f) / time;
            return velocity;
        }
        
        /// <summary>
        /// Returns a Vector3 representing the initial velocity of the rigidbody that it needs
        /// to have to hit the target while going through a parabola.
        /// The <paramref name="initialPosition"/> should be from where the
        /// rigidbody is launched and not the rigidbody's own position.
        /// </summary>
        /// <param name="initialPosition">Object's starting position.</param>
        /// <param name="finalPosition">Object's expected final position.</param>
        /// <param name="time">Elapsed time for the object to arrive at the expected position.</param>
        public static Vector3 GetParabolaInitialVelocity(Vector3 initialPosition, Vector3 finalPosition, float time)
        {
            var velocity = Velocity(initialPosition, finalPosition, time);
            velocity.y += 0.5f * PSSMath.Abs(Physics.gravity.y) * Mathf.Pow(time, 2f) / time;
            return velocity;
        }

        public static Vector2 Acceleration(Vector2 finalVelocity, Vector2 initialVelocity, float deltaTime)
        {
            if (deltaTime == 0f)
            {
                return Vector2.zero;
            }

            return (finalVelocity - initialVelocity) / deltaTime;
        }

        public static Vector2 Acceleration(Vector2 netForce, float mass)
        {
            if (netForce.Equals(Vector2.zero))
            {
                return Vector2.zero;
            }

            return netForce / mass;
        }

        public static Vector3 Acceleration(Vector3 netForce, float mass)
        {
            if (netForce.Equals(Vector3.zero))
            {
                return Vector3.zero;
            }

            return netForce / mass;
        }

        public static float Velocity(float startPosition, float endPosition, float deltaTime)
        {
            return (startPosition - endPosition) / deltaTime;
        }

        public static Vector2 Velocity(Vector2 startPosition, Vector2 endPosition, float deltaTime)
        {
            return (endPosition - startPosition) / deltaTime;
        }

        public static Vector2 Velocity(Vector3 startPosition, Vector3 endPosition, float deltaTime)
        {
            return (endPosition - startPosition) / deltaTime;
        }

        public static Vector2 Velocity(Vector2 acceleration)
        {
            return acceleration * Time.deltaTime;
        }

        public static Vector3 Velocity(Vector3 acceleration)
        {
            return acceleration * Time.deltaTime;
        }

        public static float Displacement(float initialPosition, float finalPosition)
        {
            return finalPosition - initialPosition;
        }

        public static Vector2 Displacement(Vector2 initialPosition, Vector2 finalPosition)
        {
            return finalPosition - initialPosition;
        }

        public static Vector3 Displacement(Vector3 initialPosition, Vector3 finalPosition)
        {
            return finalPosition - initialPosition;
        }

        public static Vector2 Displacement(Vector2 direction, float time)
        {
            return direction * time;
        }

        public static Vector3 Displacement(Vector3 direction, float time)
        {
            return direction * time;
        }

        /// <summary>
        /// Calculates the steepness of a slope given two points forming a line.
        /// </summary>
        public static float Slope(Vector2 p1, Vector2 p2)
        {
            return (p2.y - p1.y) / (p2.x - p1.x);
        }

        /// <summary>
        /// Calculates the steepness value of a slope perpendicular to the one provided.
        /// </summary>
        public static float PerpendicularSlope(float slope)
        {
            return -1f / slope;
        }

        // public static Vector2 FindPointPositionInParabola(float x, float width, )
        // {

        // }
    }
}
