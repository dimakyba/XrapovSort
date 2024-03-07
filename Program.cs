using System;



namespace XrapovSort
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] massiv = new int[] { 5, 6, 2, 5, 7, 1, -5, 2, 4, 9 };
      PrintMassiv(massiv);

      XrapovSort(ref massiv);
      PrintMassiv(massiv);
    }

    static void XrapovSort(ref int[] massiv)
    {
      int[] poison = GetPoison(massiv);
      int[] poisonedmassiv = FoodPoisoning(massiv, poison);
      massiv = FilterMassiv(poisonedmassiv, poison);
      Massiv.Sort(massiv);
    }
    static int[] GetPoison(int[] massiv)
    {
      int min = GetMin(massiv);
      int max = GetMax(massiv);

      int[] shit = new int[massiv.Length];

      Random rnd = new Random();
      int counter = 0;

      while (counter < massiv.Length)
      {
        int rndTemp = rnd.Next(min, max + 1);

        if (!massiv.Contains(rndTemp))
        {
          shit[counter] = rndTemp;
          counter++;
        }

      }

      return shit;
    }



    static int[] FoodPoisoning(int[] massiv, int[] shit)
    {
      Random rnd = new Random();

      int prob = 0;
      int cleanCounter = 0;
      int poisonCounter = 0;

      int[] poisonedmassiv = new int[massiv.Length * 2];
      for (int i = 0; i < poisonedmassiv.Length; i++)
      {
        prob = rnd.Next(0, 101);
        if (prob > 50)
        {

          poisonedmassiv[i] = massiv[cleanCounter];
          cleanCounter++;
          if (cleanCounter == 9)
          {
            cleanCounter = 0;
          }
        }
        else
        {

          poisonedmassiv[i] = shit[poisonCounter];
          poisonCounter++;

        }
        if (poisonCounter == 9)
        {
          poisonCounter = 0;
        }
      }
      // counter++;

      return poisonedmassiv;
    }


    static int[] FilterMassiv(int[] poisonedmassiv, int[] poison)
    {
      int[] filterredmassiv = new int[poisonedmassiv.Length / 2];
      int counter = 0;
      for (int i = 0; i < poisonedmassiv.Length; i++)
      {
        if (!poison.Contains(poisonedmassiv[i]))
        {
          filterredmassiv[counter] = poisonedmassiv[i];
          counter++;
        }
      }
      return filterredmassiv;
    }



    static void PrintMassiv(int[] massiv)
    {
      foreach (int el in massiv)
      {
        Console.Write($"{el} ");
      }
      Console.WriteLine();
    }


    static int GetMin(int[] massiv)
    {
      int min = int.MaxValue;
      foreach (int el in massiv)
      {
        if (el < min)
        {
          min = el;
        }
      }

      return min;
    }

    static int GetMax(int[] massiv)
    {
      int max = int.MinValue;
      foreach (int el in massiv)
      {
        if (el > max)
        {
          max = el;
        }
      }

      return max;
    }
  }


  public static class Massiv
  {
    public static void Sort(int[] massiv)
    {
      Array.Sort(massiv);
    }
  }

}
