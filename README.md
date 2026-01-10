# Student Management System

A Windows Forms desktop application for managing student records built with C# and .NET Framework 4.7.2.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![C#](https://img.shields.io/badge/C%23-7.3-green)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-orange)

##  Features

- **CRUD Operations**: Add, Update, Delete, and View student records
- **Search**: Filter students by name
- **Summary**: Count total number of students
- **Data Persistence**: JSON file storage
- **Modern UI**: Color-coded buttons and styled DataGridView
- **Multithreading**: Async data loading with status indicator
- **Error Handling**: User-friendly error messages



##  Project Structure

```
WindowsFormsApp1VPL/
??? Program.cs              # Application entry point
??? MainForm.cs             # Main form logic and event handlers
??? MainForm.Designer.cs    # UI control definitions
??? Student.cs              # Student data model class
??? StudentRepository.cs    # JSON file read/write operations
??? students.json           # Data storage (created at runtime)
```

##  Classes

### Student
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Marks { get; set; }
}
```

### StudentRepository
- `Load()` - Reads student data from JSON file
- `Save()` - Writes student data to JSON file

##  Technologies Used

| Technology | Purpose |
|------------|---------|
| C# 7.3 | Programming Language |
| .NET Framework 4.7.2 | Runtime Framework |
| Windows Forms | UI Framework |
| JSON | Data Storage Format |
| LINQ | Search/Filter Operations |
| Task.Run() | Multithreading |

##  How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR_USERNAME/WindowsFormsApp1VPL.git
   ```

2. Open `WindowsFormsApp1VPL.sln` in Visual Studio 2019 or later

3. Build the solution (Ctrl + Shift + B)

4. Run the application (F5)

##  Usage

| Action | How To |
|--------|--------|
| **Add Student** | Enter ID, Name, Marks ? Click "Add" (Green) |
| **Update Student** | Enter ID with new Name/Marks ? Click "Update" (Blue) |
| **Delete Student** | Select row in grid ? Click "Delete" (Red) |
| **Search** | Enter name in search box ? Click "Search" |
| **Count** | Click "Count" (Yellow) to see total students |

##  UI Color Scheme

- ?? **Green** - Add (Success action)
- ?? **Blue** - Update/Search (Primary action)
- ?? **Red** - Delete (Danger action)
- ?? **Yellow** - Count (Info action)

##  Requirements Covered

- [x] Data Management (CRUD)
- [x] OOP Structure (Classes, Properties, Constructors, Encapsulation)
- [x] Visual Programming & Events
- [x] Data Storage (JSON)
- [x] Search & Summary Features
- [x] Multithreading (Background loading)
- [x] Error Handling (Try/Catch)

##  License

This project is for educational purposes.

##  Author

*Muhammad Anas Muqeem*

---
*Visual Programming Course Project*
