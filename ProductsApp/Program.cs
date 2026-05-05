using System;
using System.Windows.Forms;

namespace ProductsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configurați șirul de conexiune către baza de date SQL Server
            // Modificați această valoare în funcție de configurația dumneavoastră
            string connectionString = "Server=localhost;Database=ProductsDB;Integrated Security=true;";

            // Pentru autentificare cu username și parolă, folosiți:
            // string connectionString = "Server=localhost;Database=ProductsDB;User Id=your_username;Password=your_password;";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var dbHelper = new DatabaseHelper(connectionString);
                var mainForm = new MainForm(dbHelper);
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Eroare la conectarea la baza de date:\n\n{ex.Message}\n\n" +
                    $"Asigurați-vă că:\n" +
                    $"1. SQL Server este instalat și rulează\n" +
                    $"2. Șirul de conexiune este corect configurat în Program.cs\n" +
                    $"3. Aveți permisiuni pentru a accesa baza de date",
                    "Eroare Conectare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
