# Aplicație Gestiune Produse - .NET Framework 4.7.2

Această aplicație Windows Forms implementează operațiile CRUD (Create, Read, Update, Delete) pentru gestionarea produselor, cu datele stocate într-o bază de date SQL Server.

## Cerințe de sistem

- **Windows** (aplicația este Windows Forms)
- **.NET Framework 4.7.2** sau o versiune mai recentă
- **SQL Server** (Express, Developer sau orice altă ediție)
- **Visual Studio 2017+** (recomandat pentru compilare și debug)

## Configurare

### 1. Instalare .NET Framework 4.7.2

Descărcați și instalați .NET Framework 4.7.2 de la:
https://dotnet.microsoft.com/download/dotnet-framework/net472

### 2. Configurare SQL Server

1. Asigurați-vă că SQL Server este instalat și rulează
2. Actualizați șirul de conexiune în fișierul `Program.cs`:

```csharp
string connectionString = "Server=localhost;Database=ProductsDB;Integrated Security=true;";
```

Pentru autentificare cu username și parolă:
```csharp
string connectionString = "Server=localhost;Database=ProductsDB;User Id=your_username;Password=your_password;";
```

### 3. Deschidere în Visual Studio

1. Deschideți Visual Studio
2. Selectați **File > Open > Project/Solution**
3. Navigați la `ProductsApp.csproj` și deschideți-l
4. Compilați proiectul (**Build > Build Solution** sau Ctrl+Shift+B)
5. Rulați aplicația (**Debug > Start Debugging** sau F5)

## Alternativ: Compile din linia de comandă

Dacă aveți MSBuild instalat (vine cu Visual Studio):

```cmd
msbuild ProductsApp.csproj /p:Configuration=Release
```

Aplicația compilată va fi în `bin\Release\ProductsApp.exe`

## Funcționalități

- **Afișare produse**: Toate produsele sunt afișate într-un DataGridView
- **Adăugare produs**: Introduceți numele, prețul și cantitatea, apoi apăsați "Adaugă"
- **Editare produs**: Selectați un produs din tabel, modificați câmpurile și apăsați "Editează"
- **Ștergere produs**: Selectați un produs și apăsați "Șterge" (cu confirmare)
- **Reîmprospătare**: Butonul "Reîmprospătează" reîncarcă lista de produse

## Structura bazei de date

Tabela `Products` este creată automat la prima rulare cu următoarea structură:

```sql
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL
)
```

## Depanare

### Eroare de conectare la baza de date

1. Verificați dacă SQL Server rulează
2. Confirmați că șirul de conexiune este corect
3. Asigurați-vă că aveți permisiuni pentru a crea/accesa baza de date

### Eroare de compilare

1. Verificați dacă .NET Framework 4.7.2 este instalat
2. Deschideți Visual Studio ca Administrator
3. Rebuild la soluție (**Build > Rebuild Solution**)

## Note

- Aplicația folosește `System.Data.SqlClient` inclus în .NET Framework 4.7.2
- Interfața este complet construită din cod (nu necesită fișiere .designer complexe)
- Validările de input previn introducerea de date incorecte
