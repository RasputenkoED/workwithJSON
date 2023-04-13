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
using System.Text.Json;
using System.Text.Encodings.Web;

namespace jsonPerson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnSer_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                Name = "Вася",
                Surname = "Пупкин",
                Age = 38,
                Birthday = new DateTime(1983, 01, 16)
            };
            string personJson = JsonSerializer.Serialize(person);
            StreamWriter file = File.CreateText("person.json");
            file.WriteLine(personJson);
            file.Close();
        }

        private void BtnDser_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("person.json"))
            {
                string data = File.ReadAllText("person.json");
                Person person = JsonSerializer.Deserialize<Person>(data);
                txtName.Text = person.Name;
                txtSur.Text = person.Surname;
                txtAge.Text = person.Age.ToString();
                txtDB.Text = person.Birthday.ToString();
            }

        }

        private void BtnPr_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                Name = "Вася",
                Surname = "Пупкин",
                Age = 38,
                Birthday = new DateTime(1983, 01, 16)
            };
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string personJson = JsonSerializer.Serialize(person, options);
        }

        private void BtCl_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true, //добавляем пробелы для красоты
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping //не экранируем символы в строках
            };
        }
    }
}
