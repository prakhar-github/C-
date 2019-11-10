using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Search;
using Newtonsoft.Json;
using Syn.WordNet;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string IndexFolderPath, DatafileName;
        LuceneSearchEngine LuceneSearch;
        

        public Form1()
        {
            InitializeComponent();
            LuceneSearch = new LuceneSearchEngine(); 
        }

        private void DataFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog DataFileDialog = new OpenFileDialog();

            if (DataFileDialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                DatafileName = DataFileDialog.FileName;
                DataFileTextBox.Text = DatafileName;
                
            }
        }

        private void IndexFolderSelectButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog IndexFolderBrowserDialog = new FolderBrowserDialog();
            if (IndexFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IndexFolderPath = IndexFolderBrowserDialog.SelectedPath;
                IndexFolderTextBox.Text = IndexFolderPath;
            }
        }

        private void DisplaySearch(TopDocs resultDoc)
        {
            List<String[]> results = LuceneSearch.DisplayResults(resultDoc);

            if (results != null && results.Count > 0)
            {
                foreach (String[] result in results)
                {
                    resultsTable.Rows.Add(result[0], result[4], result[3], result[2]);
                }
            }
            else
            {
                MessageBox.Show("No result found", "Sorry!!");
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            searchQuery();
        }

        private void QueryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchQuery();
            }
        }

        private void LoadIndexButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(IndexFolderPath))
            {
                LuceneSearch.LoadIndex(IndexFolderPath);
            }
            else
            {
                MessageBox.Show("Please select a directory containing an index to load.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resultsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (resultsTable.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
                if (resultsTable.CurrentCell != null && resultsTable.CurrentCell.Value != null)
                {
                    MessageBox.Show(resultsTable.CurrentCell.Value.ToString(), "Rank "+(e.RowIndex+1));
                }                   
            }
            else if (resultsTable.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
            {
                if (resultsTable.CurrentCell != null && resultsTable.CurrentCell.Value != null)
                {
                    MessageBox.Show(resultsTable.CurrentCell.Value.ToString(), "Rank " + (e.RowIndex+1));
                }
            }

        }

        private void CreateIndexButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DatafileName) && !string.IsNullOrEmpty(IndexFolderPath))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                LuceneSearch.CreateIndex(IndexFolderPath);
                using (StreamReader r = new StreamReader(DatafileName))
                {
                    string json = r.ReadToEnd();
                    List<Rootobject> items = JsonConvert.DeserializeObject<List<Rootobject>>(json);

                    //for testing successful loading of Json file
                    /*for (int i = 0; i < 10; i++)
                    {
                        foreach (Passage passage in items[i].passages)
                        {
                            resultsListBox.Items.Add(passage.passage_text);
                        }
                        LuceneSearch.IndexRootobject(items[i]);
                    }*/
                    foreach (Rootobject item in items)
                    {
                        LuceneSearch.IndexRootobject(item);
                    }
                    LuceneSearch.CleanUpIndexer();
                    stopwatch.Stop();
                    TimeSpan elapsed = stopwatch.Elapsed;
                    string elapsedTime = elapsed.ToString(@"hh\:mm\:ss\.fff");
                    IndexingCompleteLabel.Text = "Indexing complete; time elapsed: " + elapsedTime;


                }
            }
            else if (string.IsNullOrEmpty(DatafileName) && !string.IsNullOrEmpty(IndexFolderPath))
            {
                MessageBox.Show("Please select the JSON file to index data from.");
            }
            else if (!string.IsNullOrEmpty(DatafileName) && string.IsNullOrEmpty(IndexFolderPath))
            {
                MessageBox.Show("Please select the folder to save the index into.");
            }
            else
            {
                MessageBox.Show("Please select the JSON data file to index, and the folder to save the index into.");
            }
            
        }

        private void queryTextBox_Clicked(object sender, MouseEventArgs e)
        {
            MessageBox.Show(queryTextBox.Text);
        }

        private void multiTermCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (multiTermCheckBox.Checked == true)
            {
                queryExpansionCheckBox.Enabled = false;
            }
            else
            {
                queryExpansionCheckBox.Enabled = true;
            }
            
        }

        private void queryExpansionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (queryExpansionCheckBox.Checked == true)
            {
                multiTermCheckBox.Enabled = false;
            }
            else
            {
                multiTermCheckBox.Enabled = true;
            }
        }

        //This method will initite the search process.
        private void searchQuery()
        {
            if (!LuceneSearch.isIndexAvailale())
            {
                MessageBox.Show("Please create/load an index first", "Index Error");
                return;
            }

            if (String.IsNullOrEmpty(QueryBox.Text))
            {
                MessageBox.Show("Please enter a query to search.", "Retry");
                return;
            }

            resultsTable.Rows.Clear();
            resultsTable.Refresh();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (queryExpansionCheckBox.Checked == false && multiTermCheckBox.Checked == false)
            {
                //Lucene search without query expansion
                LuceneSearch.CreateSearcher();
                LuceneSearch.CreateParser(LuceneSearch.FIELDS_FN[2]);
                Query parsedQuery = LuceneSearch.ParseQuery(QueryBox.Text);
                queryTextBox.Text = parsedQuery.ToString();
                TopDocs resultDocs = LuceneSearch.SearchText(parsedQuery);
                DisplaySearch(resultDocs);
            }
            else if (queryExpansionCheckBox.Checked == true)
            {
                //Lucene search with query expansion
                var directory = Directory.GetCurrentDirectory() + "/wordnet";
                var wordNet = new WordNetEngine();
                
                wordNet.AddDataSource(new StreamReader(Path.Combine(directory, "data.adj")), PartOfSpeech.Adjective);
                wordNet.AddDataSource(new StreamReader(Path.Combine(directory, "data.adv")), PartOfSpeech.Adverb);
                wordNet.AddDataSource(new StreamReader(Path.Combine(directory, "data.noun")), PartOfSpeech.Noun);
                wordNet.AddDataSource(new StreamReader(Path.Combine(directory, "data.verb")), PartOfSpeech.Verb);

                wordNet.AddIndexSource(new StreamReader(Path.Combine(directory, "index.adj")), PartOfSpeech.Adjective);
                wordNet.AddIndexSource(new StreamReader(Path.Combine(directory, "index.adv")), PartOfSpeech.Adverb);
                wordNet.AddIndexSource(new StreamReader(Path.Combine(directory, "index.noun")), PartOfSpeech.Noun);
                wordNet.AddIndexSource(new StreamReader(Path.Combine(directory, "index.verb")), PartOfSpeech.Verb);

                wordNet.Load();

                string baseQuery = QueryBox.Text.ToLower();
                List<string> tokenizedBaseQuery = LuceneSearch.TokenizeString(baseQuery);
                string synonyms = "";
                string finalQuery = "";

                foreach (string token in tokenizedBaseQuery)
                {
                    finalQuery += token + "^5 ";
                    List<SynSet> synSetList = wordNet.GetSynSets(token);
                    if (synSetList.Count != 0)
                    {
                        foreach (SynSet synSet in synSetList)
                        {
                            foreach (string word in synSet.Words)
                            {
                                if (!word.Equals(token))
                                {
                                    synonyms += word + " ";
                                }
                            }
                        }
                    }
                }
                finalQuery += synonyms;
                LuceneSearch.CreateSearcher();
                LuceneSearch.CreateParser(LuceneSearch.FIELDS_FN[2]);
                Query parsedQuery = LuceneSearch.ParseQuery(finalQuery);
                queryTextBox.Text = parsedQuery.ToString();
                TopDocs resultDocs = LuceneSearch.SearchText(parsedQuery);
                DisplaySearch(resultDocs);
            }
            else if (multiTermCheckBox.Checked == true)
            {
                LuceneSearch.CreateSearcher();
                LuceneSearch.CreateParser(LuceneSearch.FIELDS_FN[2]);
                Query parsedQuery = LuceneSearch.ParseQuery("\"" + QueryBox.Text + "\"");
                queryTextBox.Text = parsedQuery.ToString();
                TopDocs resultDocs = LuceneSearch.SearchText(parsedQuery);
                DisplaySearch(resultDocs);
            }

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = elapsed.ToString(@"hh\:mm\:ss\.fff");
            SearchTimeLabel.Text = "Search time elapsed: " + elapsedTime;
        }
    }
}