using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDSA_2_CW
{
    public partial class RememberValueIndex : Form
    {
        int[] storedNumbers = new int[2] { -1, -1 };
        Random random = new Random();
        int randnum1, randnum2;
        string connectionString = "Data Source = Udana; Initial Catalog = PDSA; Integrated Security = True";

        public RememberValueIndex()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await RandomNumbers(randnum1, randnum2);
        }

        private async Task RandomNumbers(int num1, int num2)
        {
            int[] numbersArray = new int[5000];

            // Generate random numbers and sort them with sorting methods
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = random.Next(1, 1000001);
            }


            BubbleSort(numbersArray);
            InsertionSort(numbersArray);
            MergeSort(numbersArray);
            TimSort(numbersArray);
            RadixSort(numbersArray);
            ShellSort(numbersArray);
            QuickSort(numbersArray, 0, numbersArray.Length - 1);


            // Display the first 20 with 2sec delay
            for (int i = 0; i < 20; i++)
            {
                number.Text = string.Format("Index {0}: Value {1}", i, numbersArray[i]);
                await Task.Delay(2000); // Delay for 2 seconds
            }

            // Choose two random indexes from the first 20
            int index1 = random.Next(0, 19);
            int index2 = random.Next(0, 19);

            number.Text = string.Format("What is the Index of {0}, {1}", numbersArray[index1], numbersArray[index2]);

            // Store the index for button2 to check
            storedNumbers[0] = index1;
            storedNumbers[1] = index2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (storedNumbers[0] == -1 || storedNumbers[1] == -1)
            {
                number.Text = "Please generate random numbers first.";
                return;
            }

            int userInput1, userInput2;
            string playerName = textBox3.Text;
            // Get user inputs from TextBoxes
            if (int.TryParse(textBox1.Text, out userInput1) && int.TryParse(textBox2.Text, out userInput2))
            {
                // Check if user inputs match the stored indices
                if (userInput1 == storedNumbers[0] && userInput2 == storedNumbers[1])
                {
                    number.Text = "Congratulations! Your inputs match the random numbers.";

                    // Using sql connection to pass values to player -----------------------------------------------------------------------------------------
                    using (SqlConnection connection = new SqlConnection("Data Source=Udana;Initial Catalog=PDSA;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Connection = connection;
                                command.CommandText = "INSERT INTO player_details (player_name, value_one, value_two) VALUES (@PlayerName, @ValueOne, @ValueTwo)";
                                command.Parameters.AddWithValue("@PlayerName", playerName);
                                command.Parameters.AddWithValue("@ValueOne", userInput1);
                                command.Parameters.AddWithValue("@ValueTwo", userInput2);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            number.Text = "Error saving data to the database: " + ex.Message;
                        }
                    }
                }
                else
                {
                    number.Text = "Sorry, your inputs do not match the random numbers. Try again.";
                }
            }
            else
            {
                number.Text = "Please enter valid integer values in both TextBoxes.";
            }
        }

        // Bubble Sort ------------------------------------------------------------
        private void BubbleSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("BubbleSort", (float)elapsedTime.TotalMilliseconds);
        }

        //Insertion Sort ----------------------------------------------------------------
        private void InsertionSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("InsertionSort", (float)elapsedTime.TotalMilliseconds);
        }


        //Merge Sort -----------------------------------------------------------------
        private void MergeSort(int[] arr)
        {


            if (arr.Length <= 1)
                return;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];


            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }
            for (int i = mid; i < arr.Length; i++)
            {
                right[i - mid] = arr[i];
            }


            MergeSort(left);
            MergeSort(right);
            Merge(arr, left, right);


        }

        private void Merge(int[] arr, int[] left, int[] right)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("MergeSort", (float)elapsedTime.TotalMilliseconds);
        }


        // Tim sort ---------------------------------------------------------
        private void TimSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int minRun = 32;
            int n = array.Length;


            void InsertionSort(int[] arr, int start, int end)
            {
                for (int i = start + 1; i <= end; i++)
                {
                    int key = arr[i];
                    int j = i - 1;

                    while (j >= start && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }

                    arr[j + 1] = key;
                }
            }


            void Merge(int[] arr, int start, int mid, int end)
            {
                int len1 = mid - start + 1;
                int len2 = end - mid;

                int[] left = new int[len1];
                int[] right = new int[len2];

                Array.Copy(arr, start, left, 0, len1);
                Array.Copy(arr, mid + 1, right, 0, len2);

                int i = 0, j = 0, k = start;

                while (i < len1 && j < len2)
                {
                    if (left[i] <= right[j])
                    {
                        arr[k] = left[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = right[j];
                        j++;
                    }
                    k++;
                }

                while (i < len1)
                {
                    arr[k] = left[i];
                    i++;
                    k++;
                }

                while (j < len2)
                {
                    arr[k] = right[j];
                    j++;
                    k++;
                }
            }


            for (int i = 0; i < n; i += minRun)
            {
                InsertionSort(array, i, Math.Min(i + minRun - 1, n - 1));
            }

            for (int size = minRun; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);
                    Merge(array, left, mid, right);
                }
            }

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("TimSort", (float)elapsedTime.TotalMilliseconds);
        }


        // Radix Sort ------------------------------------------------------------------------
        private void RadixSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = arr.Length;
            int max = arr[0];

            // Find the maximum element in the array
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            // Do counting sort for each digit
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(arr, n, exp);
            }

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("RadixSort", (float)elapsedTime.TotalMilliseconds);
        }

        private void CountingSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10];

            // Count the occurrences of each digit
            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            // Update count[i] to contain the actual position of the digit in the output array
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array back to the original array
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }



        // Shell Sort ----------------------------------------------------------------------
        private void ShellSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;

                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }

                    arr[j] = temp;
                }

                gap /= 2;
            }

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("ShellSort", (float)elapsedTime.TotalMilliseconds);
        }



        // Quick sort ---------------------------------------------------------------------------
        private void QuickSort(int[] arr, int low, int high)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            InsertTimeTaken("QuickSort", (float)elapsedTime.TotalMilliseconds);
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();

            mm.Show();
            this.Hide();
        }


        // DB connection
        private void InsertTimeTaken(string sortMethod, double timeTaken)
        {

            string insertQuery = "INSERT INTO Time_Taken (Sort_Method, Time) VALUES (@SortMethod, @Time)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    try
                    {
                        connection.Open();

                        // Trim leading and trailing spaces
                        sortMethod = sortMethod.Trim();

                        command.Parameters.Add("@SortMethod", SqlDbType.NVarChar, 50).Value = sortMethod;
                        command.Parameters.Add("@Time", SqlDbType.Float).Value = timeTaken;

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting time taken: " + ex.Message);
                    }
                }
            }

        }


    }
}
