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
//using static PDSA_2_Course_Work.PredictValueIndex;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PDSA_2_CW
{
    public partial class PredictValueIndex : Form
    {
        Random random = new Random();
        int[] randomArray;
        BinarySearchTree bst;
        private string connectionString;

        public object Interaction { get; private set; }

        //connectionString = "Data Source=KAVINDU;Initial Catalog=PredictTheValue;Integrated Security=True;Encrypt=True;";

        public PredictValueIndex()
        {
            InitializeComponent();
            bst = new BinarySearchTree();
        }
        //private bool TestConnection()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            con.Open();
        //            return true;
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        return false;
        //    }
        //}
        TimeSpan BinarySearchTime, jumpSearchTime, exponentialSearchTime;
        private void btn_start_Click(object sender, EventArgs e)
        {
            randomArray = GenerateRandomArray(5000);
            Array.Sort(randomArray);

            foreach (int num in randomArray)
            {
                bst.Insert(num);
            }

            //if (!TestConnection())
            //{
            //    MessageBox.Show("Failed to establish database connection. Please check your connection string.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            int targetValue = random.Next(1, 1000001);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int BinarySearchIndex = bst.Search(targetValue);
            stopwatch.Stop();
             BinarySearchTime = stopwatch.Elapsed;
            stopwatch.Reset();

            stopwatch.Start();
            int jumpSearchIndex = JumpSearch(randomArray, targetValue);
            stopwatch.Stop();
             jumpSearchTime = stopwatch.Elapsed;
            stopwatch.Reset();

            stopwatch.Start();
            int exponentialSearchIndex = ExponentialSearch(randomArray, targetValue);
            stopwatch.Stop();
             exponentialSearchTime = stopwatch.Elapsed;
            stopwatch.Reset();

            txt_number.Text = targetValue.ToString();

            int predictedIndex = random.Next(0, randomArray.Length);

            List<int> choices = new List<int>();
            choices.Add(predictedIndex); 
            while (choices.Count < 4)
            {
                int choice = random.Next(0, randomArray.Length);
                if (!choices.Contains(choice))
                    choices.Add(choice); 
            }
            choices.Sort();

            txt_index1.Text = choices[0].ToString();
            txt_index2.Text = choices[1].ToString();
            txt_index3.Text = choices[2].ToString();
            txt_index4.Text = choices[3].ToString();

            txt_index1.Tag = predictedIndex;
            txt_index2.Tag = predictedIndex;
            txt_index3.Tag = predictedIndex;
            txt_index4.Tag = predictedIndex;

            //txt_index.Text = $"Binary Search Index: {BinarySearchIndex}{Environment.NewLine}" +
            //                 $"Jump Search Index:{jumpSearchIndex}{Environment.NewLine}" +
            //                 $"Exponentail Search Index: {exponentialSearchIndex}{Environment.NewLine}";

            txt_time.Text = $"{BinarySearchTime.TotalMilliseconds} ms";

            txt_jumpTime.Text = $"{jumpSearchTime.TotalMilliseconds} ms";

            txt_expoTine.Text = $"{exponentialSearchTime.TotalMilliseconds} ms";

        }

        private int[] GenerateRandomArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(1, 1000001);
            }
            return array;
        }

        public class BinarySearchTree
        {
            private Node root;
            public BinarySearchTree()
            {
                root = null;
            }

            public void Insert(int key)
            {
                root = InsertRec(root, key);
            }

            private Node InsertRec(Node root, int key)
            {
                if (root == null)
                {
                    root = new Node(key);
                    return root;
                }

                if (key < root.data)
                {
                    root.left = InsertRec(root.left, key);
                }
                else if (key > root.data)
                {
                    root.right = InsertRec(root.right, key);
                }

                return root;
            }

            public int Search(int key)
            {
                return SearchRec(root, key);
            }

            private int SearchRec(Node root, int key)
            {
                if (root == null)
                {
                    return -1;
                }

                if (root.data == key)
                {
                    return root.data;
                }

                if (key < root.data)
                {
                    return SearchRec(root.left, key);
                }
                else
                {
                    return SearchRec(root.right, key);
                }
            }
            private class Node
            {
                public int data;
                public Node left, right;

                public Node(int item)
                {
                    data = item;
                    left = right = null;
                }
            }
        }
        private int JumpSearch(int[] array, int target)
        {
            int n = array.Length;
            int step = (int)Math.Floor(Math.Sqrt(n));

            int prev = 0;
            while (array[Math.Min(step, n) - 1] < target)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (array[prev] < target)
            {
                prev++;
                if (prev == Math.Min(step, n))
                    return -1;
            }

            if (array[prev] == target)
                return prev;

            return -1;
        }
        private int ExponentialSearch(int[] array, int target)
        {
            int n = array.Length;
            if (array[0] == target)
                return 0;
            int i = 1;
            while (i < n && array[i] <= target)
                i *= 2;
            return BinarySearch(array, target, i / 2, Math.Min(i, n - 1));
        }
        private int BinarySearch(int[] array, int target, int low, int high)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (array[mid] == target)
                    return mid;
                else if (array[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
        private void btn_CheckValue_Click(object sender, EventArgs e)
        {
            int predictedIndex = (int)groupBox1.Controls.OfType<TextBox>().FirstOrDefault(txt => txt.Name.StartsWith("txt_index") && txt.Tag != null && txt.Tag.ToString() == txt.Text)?.Tag;

            int userPrediction;
            if (!int.TryParse(txt_userPrediction.Text, out userPrediction))
            {
                MessageBox.Show("Please enter a valid number for prediction.", "Null Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userPrediction == predictedIndex)
            {
                if (string.IsNullOrWhiteSpace(txt_name.Text))
                {
                    MessageBox.Show("Please enter your name.", "Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string userName = txt_name.Text;
                //RecordPredictionResult(userName, Convert.ToDouble(txt_time.Text.Split(':')[1].TrimEnd(" ms".ToCharArray())),
                //                                 Convert.ToDouble(txt_jumpTime.Text.Split(':')[1].TrimEnd(" ms".ToCharArray())),
                //                                 Convert.ToDouble(txt_expoTine.Text.Split(':')[1].TrimEnd(" ms".ToCharArray())));

                RecordPredictionResult(userName, BinarySearchTime, jumpSearchTime, exponentialSearchTime);

                MessageBox.Show("Congratulations! Your prediction is correct.", "Prediction Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show($"Sorry, your prediction is incorrect. Try again", "Prediction Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_number.Clear();
            txt_index1.Clear();
            txt_index2.Clear();
            txt_index3.Clear();
            txt_index4.Clear();
            txt_userPrediction.Clear();
            txt_name.Clear();
            txt_time.Clear();
            txt_jumpTime.Clear();
            txt_expoTine.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();

            mm.Show();
            this.Hide();
        }

        private void RecordPredictionResult(string userName, TimeSpan BinarySearchTime, TimeSpan jumpSearchTime, TimeSpan exponentialSearchTime)
        {
            string query = "INSERT INTO Results (UserName, BinarySearchTime, JumpSearchTime, ExponentialSearchTime) " +
               "VALUES (@UserName, @BinarySearchTime, @JumpSearchTime, @ExponentialSearchTime)";

            connectionString = "Data Source=KAVINDU;Initial Catalog=PredictTheValue;Integrated Security=True;Encrypt=False";
            using (SqlCommand command = new SqlCommand(query, new SqlConnection(connectionString)))
            {
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@BinarySearchTime", BinarySearchTime.TotalMilliseconds);
                command.Parameters.AddWithValue("@JumpSearchTime", jumpSearchTime.TotalMilliseconds);
                command.Parameters.AddWithValue("@ExponentialSearchTime", exponentialSearchTime.TotalMilliseconds);

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting prediction result into database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void txt_userPrediction_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    //public class ConnectionClass
    //{
    //    private string connectionString;

    //    public ConnectionClass(string connectionString)
    //    {
    //        this.connectionString = connectionString;
    //    }

    //    public bool TestConnection()
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(connectionString))
    //            {
    //                con.Open();
    //                return true;
    //            }
    //        }
    //        catch (SqlException)
    //        {
    //            return false;
    //        }
    //    }
    //}
