using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenericParsing;
using System.IO;

namespace ProfanityCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheckFile_Click(object sender, EventArgs e)
        {
            if (ofdCheckFile.ShowDialog() == DialogResult.OK)
            {
                tbCheckFile.Text = ofdCheckFile.FileName;
            }
        }

        private void btnProfanityList_Click(object sender, EventArgs e)
        {
            if (ofdProfanityList.ShowDialog() == DialogResult.OK)
            {
                tbProfanityList.Text = ofdProfanityList.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Text = "Running...";
            btnRun.Enabled = false;
            RunProfanityCheckOnBGThread();
        }

        private void RunProfanityCheckOnBGThread()
        {
            BackgroundWorker worker = new BackgroundWorker();

            // Tell the worker to report progress.
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += ProfanityCheckProgressChanged;
            worker.DoWork += ProfanityCheck;
            worker.RunWorkerCompleted += ProfanityCheckCompleted;
            worker.RunWorkerAsync();
        }

        void ProfanityCheckProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbMyProgressBar.Value = e.ProgressPercentage;
            lblProgress.Text = "Progress: " + e.ProgressPercentage + "%";
        }

        private void ProfanityCheck(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; //bad practice, but don't care :)

            BackgroundWorker worker = sender as BackgroundWorker;

            //Set up the profanity checker
            GenericParserAdapter profanityFileParser = new GenericParserAdapter();
            profanityFileParser.SetDataSource(tbProfanityList.Text);
            profanityFileParser.FirstRowHasHeader = true;
            profanityFileParser.ColumnDelimiter = ',';
            System.Data.DataTable profanityFileTable = profanityFileParser.GetDataTable();
            List<string> profanityList = new List<string>();

            foreach(DataRow currentRow in profanityFileTable.Rows)
            {
                profanityList.Add((string)currentRow[0]);
            }

            Censor myProfanityCensor = new Censor(profanityList);



            //Set up the file to be checked for profanity
            GenericParserAdapter checkFileParser = new GenericParserAdapter();
            checkFileParser.SetDataSource(tbCheckFile.Text);
            checkFileParser.FirstRowHasHeader = true;
            checkFileParser.ColumnDelimiter = ',';
            System.Data.DataTable checkFileTable = checkFileParser.GetDataTable();

            
            //Set up various ouput files
            FileStream nonProfaneStream = File.Create(tbCheckFile.Text + ".clean.csv");
            FileStream profaneStream = File.Create(tbCheckFile.Text + ".dirty.csv");

            
            //Run the profanity check, outputting data as we go
            int totalSteps = checkFileTable.Rows.Count;
            int iterations = 0;
            foreach (DataRow currentRow in checkFileTable.Rows)
            {
                iterations += 1;
                bool taintedRow = false;
                String profanity = "";
                String profanityContext = "";

                //Check for profanity
                foreach (String currItem in currentRow.ItemArray)
                {
                    //if profane, break the loop and proceed to file output
                    if (myProfanityCensor.ContainsProfanity(currItem,ref profanity))
                    {
                        taintedRow = true;
                        profanityContext = currItem;
                        break;
                    }
                }

                //Output to appropriate file;
                if (taintedRow)
                {
                    AddText(profaneStream, profanity + ",");
                    AddText(profaneStream, profanityContext + ",");

                    for (int i = 0; i < currentRow.ItemArray.Length - 1; i++)
                    {
                        AddText(profaneStream, EncapsulateSpeech(currentRow.ItemArray[i].ToString()) + ",");
                    }
                    if (currentRow.ItemArray.Length >= 1) AddText(profaneStream, EncapsulateSpeech( currentRow.ItemArray[currentRow.ItemArray.Length-1].ToString()) + Environment.NewLine);
                }
                else
                {
                    for (int i = 0; i < currentRow.ItemArray.Length - 1; i++)
                    {
                        AddText(nonProfaneStream, EncapsulateSpeech(currentRow.ItemArray[i].ToString()) + ",");
                    }
                    if (currentRow.ItemArray.Length >= 1) AddText(nonProfaneStream, EncapsulateSpeech(currentRow.ItemArray[currentRow.ItemArray.Length - 1].ToString()) + Environment.NewLine);
                }

                //Report progress to UI
                worker.ReportProgress((int)(((double)iterations / (double)totalSteps) * 100));
            }


            //Tidy up
            profaneStream.Close();
            nonProfaneStream.Close();

        }

        void ProfanityCheckCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRun.Enabled = true;
            btnRun.Text = "Complete";
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private string EncapsulateSpeech(string theString)
        {
            return "\"" + theString + "\"";
        }
    }
}
