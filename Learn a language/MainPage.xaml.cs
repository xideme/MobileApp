using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Learn_a_language
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Sõna> WordList { get; set; } = new ObservableCollection<Sõna>();
        public Sõna NewWord { get; set; }
        public Command SaveWordCommand { get; }

        private string filePath;

        public MainPage()
        {
            InitializeComponent();

            NewWord = new Sõna { Kategooria = "õppimisel" };

            SaveWordCommand = new Command(SaveWord);

            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt");

            BindingContext = this;

            LoadWordsFromFileAsync();
        }

        private void SaveWord()
        {
            WordList.Add(new Sõna
            {
                Nimetus = NewWord.Nimetus,
                Tõlge = NewWord.Tõlge,
                Selgitus = NewWord.Selgitus,
                Kategooria = NewWord.Kategooria
            });

            NewWord.Nimetus = string.Empty;
            NewWord.Tõlge = string.Empty;
            NewWord.Selgitus = string.Empty;

            SaveWordsToFileAsync();
        }

        public async Task SaveWordsToFileAsync()
        {
            var lines = WordList.Select(w => $"{w.Nimetus}|{w.Tõlge}|{w.Selgitus}|{w.Kategooria}");
            await File.WriteAllLinesAsync(filePath, lines);
        }

        public async Task LoadWordsFromFileAsync()
        {
            if (File.Exists(filePath))
            {   

                Console.WriteLine($"Text file location: {filePath}");
                var lines = await File.ReadAllLinesAsync(filePath);
                WordList.Clear();
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        WordList.Add(new Sõna { Nimetus = parts[0], Tõlge = parts[1], Selgitus = parts[2], Kategooria = parts[3] });
                    }
                }
            }
        }



        // Back button functionality
        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (wordCarousel.Position > 0)
            {
                wordCarousel.Position -= 1;
            }
        }

        // Forward button functionality
        private void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (wordCarousel.Position < WordList.Count - 1)
            {
                wordCarousel.Position += 1;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadWordsFromFileAsync();
        }
    }
}

