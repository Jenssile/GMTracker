using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrandMasterTrackerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearSession();
            Eventloger("New Session started.");
            TotalSave totalSave = new TotalSave();
            Session session = new Session();
            var shardBox = new TextBox();
            var exoticBox = new TextBox();
            shardBox.Text = "0";
            exoticBox.Text = "0";
            StackPanel.Children.Add(shardBox);
            StackPanel.Children.Add(exoticBox);

            var submitButton = new Button();
            submitButton.Click += (s, e2) => {
                session.runs.Add(new Run(int.Parse(shardBox.Text), int.Parse(exoticBox.Text)));
                shardBox.Text = "0";
                exoticBox.Text = "0";
                Eventloger("Run Saved.");
            };
            submitButton.Content = "Submit Run";
            StackPanel.Children.Add(submitButton);
            var save = new Button();
            save.Click += (s2, e3) => {
                string currentDirr = Directory.GetCurrentDirectory();
                currentDirr += "/GMSession.json";
                string json = JsonConvert.SerializeObject(totalSave);
                if (File.Exists(currentDirr)) {
                    if (new FileInfo(currentDirr).Length != 0) {
                        File.AppendAllText(currentDirr, "," + json);
                        Eventloger("Session Appended to json.");
                        ClearSession();
                        Eventloger("Session Cleared.");
                    } else {
                        File.WriteAllText(currentDirr, json);
                        Eventloger("Session Saved to json.");
                        ClearSession();
                        Eventloger("Session Cleared.");
                    }
                } else {
                    File.WriteAllText(currentDirr, json);
                    Eventloger("Session Saved to json.");
                    ClearSession();
                    Eventloger("Session Cleared.");
                }
            };
            save.Content = "Save Session";
            savePanel.Children.Add(save);

            var totalButton = new Button();
            totalButton.Click += (s3, e4) => {
                int shardsSum = session.runs.Sum(item => item.shards);
                totalShards.Text = shardsSum.ToString();
                int exoticsSum = session.runs.Sum(item => item.exotics);
                totalExotics.Text = exoticsSum.ToString();
                int totalruns = session.runs.Count;
                totalRuns.Text = totalruns.ToString();
                double averageshards = shardsSum / totalruns;
                averageShards.Text = averageshards.ToString();
                double averageexotics = exoticsSum / totalruns;
                averageExotics.Text = averageexotics.ToString();
                totalSave.Save(shardsSum, exoticsSum, totalruns, averageshards, averageexotics);
            };
            totalButton.Content = "Sum";
            totalPanel.Children.Add(totalButton);
        }

        public void Eventloger(string messege)
        {
            var submitted = new TextBlock();
            submitted.Text = messege;
            submitted.Foreground = new SolidColorBrush(Colors.LightGreen);
            submitted.FontFamily = new FontFamily("Veranda");
            submitted.FontSize = 18;
            eventlog.Children.Add(submitted);
        }

        public void ClearSession() {
            StackPanel.Children.Clear();
            savePanel.Children.Clear();
            totalPanel.Children.Clear();
        }
    }
}
