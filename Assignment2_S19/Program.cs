using System;
using System.Collections.Generic;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));
            
            // Team members - Neti, Janvi, Maria
        }
        /* This function will display the array */
        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
            }
        }

        /* This function will perform the given left rotation on the array */
        static int[] rotLeft(int[] a, int d)
        {
            // outer loop to shift the elements to left d times.
            for (int j = 0; j < d; j++)
            {
                // Take the first element and store it safely in a temporary variable.
                // It will be later assigned to the last element in the array
                int temp = a[0];
                int arrayLength = a.Length;
                // Inner loop to update the array by shifting all the elements to left by 1 bit
                for (int i = 1; i < arrayLength; i++)
                {
                    a[i - 1] = a[i];
                    // Assign the first element to the last element of the updated array
                    if (i == arrayLength - 1)
                    {
                        a[i] = temp;
                    }
                }

            }
            return a;
        }

        /* This function will find the maximum number of toys in a fixed budget */
        static int maximumToys(int[] prices, int k)
        {
            int[] sortedPrices = sortAscArray(prices);
            int itemCount = 0;
            int totalExpense = 0;
            for (int i = 0; i < sortedPrices.Length; i++)
            {
                totalExpense = totalExpense + sortedPrices[i];
                // If the total expense exceeds the budget, exit the loop
                if (totalExpense > k)
                {
                    break;
                }
                itemCount++;
            }
            return itemCount;
        }

        /* This function will sort the 1-D integer array in ascending order using selection sort algorithm */
        static int[] sortAscArray(int[] arr)
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {

                int min_idx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_idx])
                        min_idx = j;
                }
                // Swap the found minimum element with the first
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;

            }
            return arr;
        }



        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            return "";
        }

        /* This function will find the missing elements in the array */
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            // Sort both the arrays in ascending order
            int[] missingArray = sortAscArray(arr);
            int[] orignalArray = sortAscArray(brr);

            List<int> resultList = new List<int>();

            for (int i = 0; i < orignalArray.Length; i++)
            {
                int data = orignalArray[i];
                // If the element has already been indentifed as missing,
                // move on to the next element in the orignal array and continue with the next loop
                if (getFreqOfElement(resultList.ToArray(), data) > 0)
                {
                    continue;
                }
                // If the frequency of the element in orignalArray is not the same as in missing array, 
                // add it in the final resultList
                if (getFreqOfElement(orignalArray, data) != getFreqOfElement(missingArray, data))
                {
                    resultList.Add(data);
                }
            }
            return resultList.ToArray();
        }

        /* This function will get the frequency of an element in the array */
        static int getFreqOfElement(int[] arr, int num)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    count++;
                }
            }
            return count;
        }

        /* This function will round up the grades of the students if needed */
        static int[] gradingStudents(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                int grade = grades[i];
                // Case 1 ) If the difference between the grade and the next multiple of 5 is less than 3,
                // round grade up to the next multiple of 5.
                // Case 2 ) If the value of grade is less than 38,
                // no rounding occurs as the result will still be a failing grade.
                if ((getNextMultipleOfFive(grade) - grade) < 3 && grade >= 38)
                {
                    grades[i] = getNextMultipleOfFive(grade);
                }
            }
            return grades;
        }

        /* This function will get the next multiple of 5 for a number */
        static int getNextMultipleOfFive(int n)
        {
            int quotient = n / 10;
            int remainder = n % 10;

            if (remainder == 5)
            {
                // Number is already a multiple of 5
                return n;
            }
            else if (remainder > 5)
            {
                return (quotient * 10 + 10);
            }
            else
            {
                return (quotient * 10 + 5);
            }
        }

        /* This function will find the median of the array having odd number of elements */
        static int findMedian(int[] arr)
        {
            int[] sortedArray = sortAscArray(arr);
            int middleIndex = sortedArray.Length / 2;
            return arr[middleIndex];
        }


        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            return new int[] { };
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            return "";
        }
    }
}
