# Student Management System

A professional Windows Forms desktop application for managing student records built with C# and .NET Framework 4.7.2. This project demonstrates modern software development practices including CRUD operations, data validation, exception handling, and asynchronous programming.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![C#](https://img.shields.io/badge/C%23-7.3-green)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-orange)
![Build](https://img.shields.io/badge/build-passing-brightgreen)

## ? Features

### Core Functionality
- **CRUD Operations**: Complete Create, Read, Update, and Delete functionality for student records
- **Input Validation**: Comprehensive validation for all fields
  - ID must be positive and unique
  - Name cannot be empty
  - Marks must be between 0 and 100
- **Duplicate Prevention**: Prevents adding students with duplicate IDs
- **Smart Search**: Filter students by name with real-time results
- **Rich Statistics**: View count, average marks, highest and lowest scores
- **Data Persistence**: Reliable JSON file storage with error handling

### Technical Features
- **Modern Serialization**: Uses `DataContractJsonSerializer` for robust JSON handling
- **Async Operations**: Non-blocking data loading with async/await
- **Exception Handling**: Comprehensive error handling with user-friendly messages
- **Professional UI**: Modern color-coded interface with responsive design
- **Secure Storage**: Data stored in Windows AppData folder following best practices
- **Status Feedback**: Real-time status updates for all operations

## ?? Screenshots

*Add screenshots of your running application here*

## ?? Project Structure

```
WindowsFormsApp1VPL/
??? Program.cs              # Application entry point
??? MainForm.cs             # Main form logic and event handlers
??? MainForm.Designer.cs    # UI control definitions
??? MainForm.resx           # Form resources
??? Student.cs              # Student data model with validation
??? StudentRepository.cs    # JSON file operations with error handling
??? README.md               # Project documentation
??? REFACTORING_SUMMARY.md  # Detailed changes log
```

**Data Storage Location:**
```
%AppData%\StudentManagementSystem\students.json
```

## ??? Architecture & Classes

### Student Model
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Marks { get; set; }
    
    // Parameterized constructor
    public Student(int id, string name, double marks)
    
    // Validation with descriptive error messages
    public bool IsValid(out string errorMessage)
    
    // Override methods for proper object comparison
    public override bool Equals(object obj)
    public override int GetHashCode()
    public override string ToString()
}
```

**Features:**
- Auto-implemented properties
- Default and parameterized constructors
- Built-in validation logic
- Proper equality comparison based on ID

### StudentRepository (Data Access Layer)
```csharp
public static class StudentRepository
{
    // Load students from JSON file
    public static List<Student> Load()
    
    // Save students to JSON file
    public static void Save(List<Student> students)
    
    // Get data file path
    public static string GetDataFilePath()
}
```

**Features:**
- Uses `DataContractJsonSerializer` for modern JSON serialization
- Stores data in Windows AppData folder
- Comprehensive exception handling
- Automatic directory creation
- Null argument validation

### MainForm (Presentation Layer)

**Key Methods:**
- `button1_Click` - Add Student with validation
- `button2_Click` - Update Student with validation
- `button3_Click` - Delete Student with confirmation
- `button4_Click` - Search Students by name
- `button5_Click` - Display statistics
- `RefreshGrid()` - Update DataGridView display
- `SaveStudents()` - Centralized save with error handling

## ??? Technologies Used

| Technology | Purpose | Details |
|------------|---------|---------|
| C# 7.3 | Programming Language | Modern C# features |
| .NET Framework 4.7.2 | Runtime Framework | Stable, widely supported |
| Windows Forms | UI Framework | Rich desktop UI controls |
| DataContractJsonSerializer | JSON Serialization | Modern, maintained by Microsoft |
| LINQ | Data Querying | Efficient search and filtering |
| async/await | Asynchronous Programming | Non-blocking operations |
| System.IO | File Operations | Data persistence |

## ?? How to Run

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or higher
- Windows OS

### Steps
1. **Clone the repository:**
   ```bash
   git clone https://github.com/techieworld2/VPLStudentManagement.git
   cd VPLStudentManagement
   ```

2. **Open in Visual Studio:**
   - Double-click `WindowsFormsApp1VPL.sln`
   - Or open Visual Studio ? File ? Open ? Project/Solution

3. **Build the solution:**
   - Press `Ctrl + Shift + B`
   - Or Build ? Build Solution

4. **Run the application:**
   - Press `F5` (Debug mode)
   - Or `Ctrl + F5` (Release mode)

## ?? User Guide

### Adding a Student
1. Enter **Student ID** (must be unique, positive number)
2. Enter **Name** (cannot be empty)
3. Enter **Marks** (0-100)
4. Click **Add** button (Green)
5. ? Success message and updated count displayed

### Updating a Student
1. Enter the **existing Student ID**
2. Enter **new Name** and/or **new Marks**
3. Click **Update** button (Blue)
4. ? Student record updated

### Deleting a Student
1. **Select a row** in the grid
2. Click **Delete** button (Red)
3. **Confirm** deletion in dialog
4. ? Student removed from list

### Searching Students
1. Enter **name** (or partial name) in search box
2. Click **Search** button (Blue)
3. ?? Grid shows filtered results
4. Leave empty and search again to show all

### Viewing Statistics
1. Click **Count** button (Yellow)
2. ?? View:
   - Total student count
   - Average marks
   - Highest marks
   - Lowest marks

## ?? Validation Rules

| Field | Rules | Error Message |
|-------|-------|---------------|
| **ID** | Must be positive integer | "ID must be a positive number." |
| **ID** | Must be unique | "Student with ID {id} already exists." |
| **Name** | Cannot be empty/whitespace | "Name cannot be empty." |
| **Marks** | Must be 0-100 | "Marks must be between 0 and 100." |

## ?? UI Color Scheme

| Color | Action | Purpose |
|-------|--------|---------|
| ?? **Green** | Add | Success action |
| ?? **Blue** | Update/Search | Primary actions |
| ?? **Red** | Delete | Danger action |
| ?? **Yellow** | Count/Statistics | Information |
| ? **White** | Background | Clean interface |
| ? **Dark Gray** | Text | Readability |

## ? Requirements Covered

### Academic Requirements
- [x] **Data Management** - Full CRUD operations
- [x] **OOP Structure** - Classes, properties, constructors, encapsulation
- [x] **Validation** - Input validation with error messages
- [x] **Visual Programming** - Windows Forms with event handlers
- [x] **Data Storage** - JSON serialization and file I/O
- [x] **Search & Filter** - LINQ-based search functionality
- [x] **Statistics** - Count, average, min, max calculations
- [x] **Multithreading** - Async data loading
- [x] **Error Handling** - Try-catch blocks with specific exceptions
- [x] **Code Quality** - Clean code, documentation, best practices

### Professional Standards
- [x] Modern serialization (DataContractJsonSerializer)
- [x] Secure data storage (AppData folder)
- [x] Comprehensive exception handling
- [x] Input validation before processing
- [x] User-friendly error messages
- [x] Confirmation dialogs for destructive actions
- [x] Status feedback for operations
- [x] Duplicate prevention
- [x] Clean separation of concerns

## ?? Data Security & Storage

**Storage Location:**
```
C:\Users\{YourUsername}\AppData\Roaming\StudentManagementSystem\students.json
```

**Benefits:**
- ? Per-user data isolation
- ? No administrator permissions required
- ? Automatic backup by Windows
- ? Follows Windows application guidelines
- ? Data persists across application restarts

**File Format:** JSON (Human-readable, industry standard)

## ?? Testing Checklist

Before deployment, verify:
- [ ] Add student with valid data ?
- [ ] Add student with duplicate ID (should fail) ?
- [ ] Add student with invalid marks (should fail) ?
- [ ] Add student with empty name (should fail) ?
- [ ] Update existing student ?
- [ ] Update non-existent student (should fail) ?
- [ ] Delete student with confirmation ?
- [ ] Search by full name ?
- [ ] Search by partial name ?
- [ ] View statistics with data ?
- [ ] View statistics with empty list ?
- [ ] Application restart (data persists) ?
- [ ] Verify data file location ??

## ?? Error Handling

The application handles these scenarios gracefully:
- Invalid input format (non-numeric ID or marks)
- Duplicate student IDs
- Out-of-range marks
- Empty required fields
- File I/O errors (permissions, disk full)
- Corrupt JSON data
- Missing data directory
- No student selected for deletion

## ?? Educational Value

This project demonstrates:
1. **Software Design** - Clean architecture with separation of concerns
2. **OOP Principles** - Encapsulation, abstraction, proper class design
3. **Data Validation** - Input sanitization and business rule enforcement
4. **Exception Handling** - Graceful error recovery
5. **User Experience** - Intuitive UI with helpful feedback
6. **Best Practices** - Modern patterns and industry standards
7. **Documentation** - Comprehensive comments and README

## ?? Future Enhancements

Potential improvements:
- [ ] Export to Excel/CSV
- [ ] Import from file
- [ ] Student photo support
- [ ] Grade calculation with letter grades
- [ ] Sorting by multiple columns
- [ ] Advanced filtering options
- [ ] Print report functionality
- [ ] Database integration (SQL Server/SQLite)
- [ ] Multi-user support
- [ ] Backup/Restore functionality

## ?? License

This project is for educational purposes as part of the Visual Programming course.

## ????? Author
**aunraza19**  
GitHub: [@aunraza19](https://github.com/aunraza19)  

**Visual Programming Course Project**  
.NET Framework 4.7.2 | C# 7.3 | Windows Forms

---

## ?? Version History

**v2.0 (Current)** - Refactored Version
- ? Modern DataContractJsonSerializer
- ? Comprehensive validation
- ? Enhanced error handling
- ? AppData storage
- ? Rich statistics

**v1.0** - Initial Release
- Basic CRUD operations
- Simple file storage

---

**Build Status:** ? Passing  
**Code Quality:** ?????  
**Ready for Submission:** ? Yes

*For detailed refactoring changes, see [REFACTORING_SUMMARY.md](REFACTORING_SUMMARY.md)*
