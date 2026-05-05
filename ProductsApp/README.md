# Aplicație Gestiune Produse - C# Windows Forms

Această aplicație implementează operațiile CRUD (Create, Read, Update, Delete) pentru gestionarea produselor, cu stocarea datelor într-o bază de date SQL Server.

## Structura Proiectului

```
ProductsApp/
├── ProductsApp.csproj    # Fișierul de proiect .NET
├── Program.cs            # Punctul de intrare al aplicației
├── MainForm.cs           # Formularul principal cu interfața grafică
├── Product.cs            # Modelul de date pentru produs
└── DatabaseHelper.cs     # Clasa pentru accesul la baza de date
```

## Cerințe

- .NET 6.0 sau versiune mai recentă
- SQL Server (Express, Developer sau orice altă ediție)
- Windows (pentru interfața Windows Forms)

## Configurare

### 1. Configurați șirul de conexiune

Deschideți fișierul `Program.cs` și modificați șirul de conexiune în funcție de configurația dumneavoastră:

```csharp
// Pentru autentificare Windows:
string connectionString = "Server=localhost;Database=ProductsDB;Integrated Security=true;TrustServerCertificate=true;";

// Pentru autentificare SQL Server:
string connectionString = "Server=localhost;Database=ProductsDB;User Id=your_username;Password=your_password;TrustServerCertificate=true;";
```

### 2. Construirea aplicației

```bash
cd ProductsApp
dotnet restore
dotnet build
```

### 3. Rularea aplicației

```bash
dotnet run
```

## Funcționalități

Aplicația oferă următoarele funcționalități:

1. **Afișare produse**: Toate produsele sunt afișate într-un tabel (DataGridView)
2. **Adăugare produs**: Introduceți numele, prețul și cantitatea, apoi apăsați "Adaugă"
3. **Editare produs**: Selectați un produs din tabel, modificați câmpurile și apăsați "Editează"
4. **Ștergere produs**: Selectați un produs din tabel și apăsați "Șterge"
5. **Reîmprospătare**: Actualizați lista de produse apăsând "Reîmprospătează"

## Baza de Date

Aplicația creează automat tabela `Products` dacă nu există, cu următoarea structură:

```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL
)
```

## Note Importante

- Asigurați-vă că SQL Server este instalat și rulează înainte de a porni aplicația
- Dacă utilizați o instanță numită de SQL Server, actualizați șirul de conexiune (de exemplu: `Server=localhost\\SQLEXPRESS`)
- Aplicația folosește `TrustServerCertificate=true` pentru dezvoltare locală. În producție, configurați certificatele corespunzător.
