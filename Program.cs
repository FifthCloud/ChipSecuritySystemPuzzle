
using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // [Blue, Yellow]
            // [Red, Green]
            // [Yellow, Red]
            // [Orange, Purple]
            // The List of chips that are in random order.
            List<Color[]> colors = new List<Color[]>();
            //colors.Add(new Color[] { Color.Blue, Color.Yellow });
            //colors.Add(new Color[] { Color.Red, Color.Green });
            //colors.Add(new Color[] { Color.Yellow, Color.Red });
            //colors.Add(new Color[] { Color.Orange, Color.Purple });

            // Now a harder scenario
            //colors.Add(new Color[] { Color.Blue, Color.Yellow });
            //colors.Add(new Color[] { Color.Blue, Color.Green });
            //colors.Add(new Color[] { Color.Blue, Color.Red });
            //colors.Add(new Color[] { Color.Red, Color.Purple });
            //colors.Add(new Color[] { Color.Yellow, Color.Purple });
            //colors.Add(new Color[] { Color.Purple, Color.Green });

            // Now an even harder scenario
            //colors.Add(new Color[] { Color.Blue, Color.Yellow });
            //colors.Add(new Color[] { Color.Blue, Color.Green });
            //colors.Add(new Color[] { Color.Blue, Color.Red });
            //colors.Add(new Color[] { Color.Red, Color.Orange });
            //colors.Add(new Color[] { Color.Orange, Color.Purple });
            //colors.Add(new Color[] { Color.Yellow, Color.Purple });
            //colors.Add(new Color[] { Color.Purple, Color.Green });

            // No security sequence scenario
            //colors.Add(new Color[] { Color.Blue, Color.Yellow });
            //colors.Add(new Color[] { Color.Blue, Color.Red });
            //colors.Add(new Color[] { Color.Red, Color.Orange });
            //colors.Add(new Color[] { Color.Orange, Color.Purple });
            //colors.Add(new Color[] { Color.Yellow, Color.Purple });

            FindTheSecuritySequence(Color.Blue, new List<Color[]>(), colors);
            OutputResults(longestPath);
        }

        private static List<Color[]> longestPath = new List<Color[]>();

        private static void FindTheSecuritySequence(Color endColor, List<Color[]> currentPath, List<Color[]> availableChips)
        {
            // Have we already found the longest path possible?
            if (endColor == Color.Green)
            {
                // If we found the path of a possible solution is this indeed the longest path?
                if (currentPath.Count > longestPath.Count)
                {
                    // Let's overwrite the current longest path with the new longest path.
                    longestPath = new List<Color[]>(currentPath);
                }
            }

            // We still need to keep searching for the longest path. Let's cycle through the remaining chips.
            for (int i = 0; i < availableChips.Count; i++)
            {
                // Let's look at the current available chips
                Color[] chip = availableChips[i];

                // Did we find the next chip in the path?
                if (chip[0] == endColor)
                {
                    // Awesome we found the next chip. Add this to the current path.
                    currentPath.Add(chip);

                    // Remove this chip from the available chips since we are now using it in the current path.
                    availableChips.RemoveAt(i);

                    // Let's keep looking through a recursive method by calling myself with the remaining chips.
                    FindTheSecuritySequence(chip[1], currentPath, availableChips);

                    // Hmmm... we didn't find the correct sequence. Let's put this back and keep going.
                    availableChips.Insert(i, chip);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        private static void OutputResults(List<Color[]> output)
        {
            if (output.Count > 0)
            {
                Console.WriteLine("The solution is:");
                foreach (Color[] chip in output)
                {
                    Console.WriteLine($"[{chip[0]}, {chip[1]}]");
                }
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
        }
    }
}
