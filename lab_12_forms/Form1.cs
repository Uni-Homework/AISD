using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab_12_forms
{
    public partial class Form1 : Form
    {
        private List<string> dictionary = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadDictionary_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dictionary = File.ReadAllLines(ofd.FileName).ToList();
                MessageBox.Show("Словарь загружен! Кол-во слов: " + dictionary.Count);
            }
        }

        private void btnFindClosest_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(input) || dictionary.Count == 0)
            {
                MessageBox.Show("Введите слово и загрузите словарь!");
                return;
            }

            int minDistance = int.MaxValue;
            List<string> closestWords = new List<string>();

            foreach (var word in dictionary)
            {
                int dist = Levenshtein(input, word.ToLower());
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestWords.Clear();
                    closestWords.Add(word);
                }
                else if (dist == minDistance)
                {
                    closestWords.Add(word);
                }
            }

            listBoxResults.Items.Clear();
            foreach (var word in closestWords)
            {
                listBoxResults.Items.Add($"{word} (дистанция: {minDistance})");
            }
        }

        private int Levenshtein(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++) dp[i, 0] = i;
            for (int j = 0; j <= b.Length; j++) dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = (a[i - 1] == b[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(
                        dp[i - 1, j] + 1,
                        dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }
            }

            return dp[a.Length, b.Length];
        }
    }
}
