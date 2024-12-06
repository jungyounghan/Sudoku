using System;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[9, 9];
            MakeNumbers(array);
            Print(array);
        }

        static void MakeNumbers(int[,] array)
        {
            Random random = new Random();
            int width = array.GetLength(1);
            int height = array.GetLength(0);
            //열을 순회한다.
            for (int y = 0; y < height; y++)
            {
                int[] numbers = new int[width];
                //숫자 1,2,3,4,5,6,7,8,9를 섞어준다.
                for(int i = 0; i < width; i++)
                {
                    numbers[i] = i + 1;
                }
                for (int i = 0; i < width; i++)
                {
                    int index = random.Next(0, width);
                    int temp = numbers[i];
                    numbers[i] = numbers[index];
                    numbers[index] = temp;
                }
                //행을 순회한다.
                for (int x = 0; x < width; x++)
                {
                    int length = numbers.Length;        //난수의 숫자들을 대입해주는 배열 공간의 크기
                    int[] temps = new int[length - 1];  //numbers 배열에서 난수 하나를 선택하고 남은 숫자들을 담을 배열 공간
                    for (int i = 0; i < length; i++)
                    {
                        //사용 가능한할 값이라면
                        if (CanApplyNumber(array, x, y, numbers[i]))
                        {
                            //temp의 남은 배열 공간에 남은 numbers 내용을 대입한다. 
                            for(int j = i + 1; j < length; j++)
                            {
                                temps[j - 1] = numbers[j];
                            }
                            array[y, x] = numbers[i];
                            break;
                        }
                        //그렇지 않다면 보류하고 임시로 저장해둔다.
                        else
                        {
                            temps[i] = numbers[i];
                        }
                    }
                    numbers = temps;
                }
            }
        }

        static bool CanApplyNumber(int[,] array, int x, int y, int value)
        {
            int width = array.GetLength(1);
            int height = array.GetLength(0);
            //세로줄에 같은 숫자가 있는가?
            //규격 안에 같은 숫자가 있는가?

            return true;
        }

        static void Print(int[,] array)
        {
            int width = array.GetLength(1);
            int height = array.GetLength(0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(array[y, x]);
                    if (x % 3 == 2)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                if (y % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
