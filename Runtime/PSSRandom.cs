using UnityEngine;

namespace PixelRouge.MathTools
{
    public static class PSSRandom
    {
        /// <summary>
        /// Simulate a heads or tails toss.
        /// </summary>
        /// <returns>True if the result was "heads".</returns>
        public static bool HeadsOrTails()
        {
            return Random.Range(0, 2) > 0; 
        }

        /// <summary>
        /// Simulate a dice roll with the given number of sides. The minimum value is 1.
        /// </summary>
        /// <returns></returns>
        /// 
        public static int RollDice(int sides = 6)
        { 
            return Random.Range(1, sides + 1);
        }

        /// <summary>
        /// Returns a random Vector2 with a length of 1.
        /// </summary>
        /// <returns></returns>
        public static Vector2 RandomVector2()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        /// <summary>
        /// Returns a random Vector2 with a length of 1.
        /// </summary>
        /// <returns></returns>
        public static Vector2 RandomNormalizedVector2()
        {
            return RandomNormalizedVector2().normalized;
        }

        /// <summary>
        /// Returns a random Vector2 with a length of 1.
        /// </summary>
        /// <returns></returns>
        public static Vector3 RandomVector3()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        /// <summary>
        /// Returns a random Vector2 with a length of 1.
        /// </summary>
        /// <returns></returns>
        public static Vector2 RandomNormalizedVector3()
        {
            return RandomVector3().normalized;
        }
    }
}
